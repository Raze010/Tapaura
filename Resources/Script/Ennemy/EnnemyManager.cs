using NUnit.Framework;
using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;

public class EnnemyManager : MonoBehaviour
{
    private static EnnemyManager _instance;
    public static EnnemyManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = GameObject.Find("EnnemyManager").GetComponent<EnnemyManager>();
            return _instance;
        }
    }

    [HideInInspector]
    public List<Ennemy> listBoss = new List<Ennemy>();

    [HideInInspector]
    public List<Ennemy> listEnnemy = new List<Ennemy>();

    [HideInInspector]
    public int indexEnnemy;

    public void Awake()
    {
        if (TestHelper.Instance.Active && TestHelper.Instance.WantedMeter != -1)
            MeterCount = TestHelper.Instance.WantedMeter;

        listBoss = new List<Ennemy>(Resources.LoadAll<Ennemy>("Prefab/SimpleBoss"));
        listEnnemy = new List<Ennemy>(Resources.LoadAll<Ennemy>("Prefab/SimpleEnnemy"));

        AddNewEnnemy(true);
    }

    public void Update()
    {
        ActiveTimeBossRemaining -= Time.deltaTime;

        if (modeCombat == ModeCombat.Boss && ActiveTimeBossRemaining < 0)
        {
            TuerEnnemie(false, false);
            modeCombat = ModeCombat.Endless;
        }
    }

    [HideInInspector]
    public Ennemy Ennemy;

    [HideInInspector]
    public float MeterCount = 10;

    [HideInInspector]
    public int KillCount = 0, MaxKillCount = 10;

    public enum ModeCombat { Killing, Endless, Boss };

    [HideInInspector]
    public ModeCombat modeCombat = ModeCombat.Killing;

    [HideInInspector]
    public float ActiveTimeBossRemaining;

    public void TuerEnnemie(bool withReward, bool ForceBoss)
    {
        Destroy(Ennemy.gameObject);

        bool normalEnnemy = true;

        if (withReward)
        {
            if (modeCombat == ModeCombat.Boss)
            {
                KillCount = 0;
                MeterCount += 10;

                modeCombat = ModeCombat.Killing;

                if (withReward)
                    Chasseur.Instance.Or.Ajouter(FormuleManager.Instance.CalcEnnemie_DropOr(MeterCount - 10, true));
            }
            else
            {
                if (withReward)
                    Chasseur.Instance.Or.Ajouter(FormuleManager.Instance.CalcEnnemie_DropOr(MeterCount, false));

                if (modeCombat == ModeCombat.Killing)
                {
                    KillCount++;
                    if (KillCount > MaxKillCount)
                    {
                        normalEnnemy = false;
                        modeCombat = ModeCombat.Boss;
                        ActiveTimeBossRemaining = 30;
                    }
                }
            }
        }
        else
        {
            modeCombat = ModeCombat.Endless;
        }

        if (ForceBoss)
        {
            normalEnnemy = false;
            modeCombat = ModeCombat.Boss;
            ActiveTimeBossRemaining = 30;
        }

        AddNewEnnemy(normalEnnemy);
    }

    public void AddNewEnnemy(bool normal)
    {
        if (normal)
        {
            int randomIndex = -1;

            do
            {
                randomIndex = UnityEngine.Random.Range(0, listEnnemy.Count);
            } while (randomIndex == indexEnnemy);

            indexEnnemy = randomIndex;

            Ennemy = Instantiate(listEnnemy[indexEnnemy].gameObject).GetComponent<Ennemy>();
        }
        else
        {
            indexEnnemy = -1;

            int index = UnityEngine.Random.Range(0, listBoss.Count);

            Ennemy = Instantiate(listBoss[index].gameObject).GetComponent<Ennemy>();
        }

        GN PvEnnemy = FormuleManager.Instance.CalcEnnemie_PV(MeterCount, !normal);

        Ennemy.PV = PvEnnemy.Clone();
        Ennemy.PVMax = PvEnnemy.Clone();
    }

    public void AbandonnerBoss()
    {
        TuerEnnemie(false, false);
    }

    public void AffronterBoss()
    {
        TuerEnnemie(false, true);
    }
}
