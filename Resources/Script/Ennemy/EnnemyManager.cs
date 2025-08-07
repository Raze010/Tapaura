using NUnit.Framework;
using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;

public class EnnemyManager : MonoBehaviour
{
    private static readonly Lazy<EnnemyManager> lazy = new Lazy<EnnemyManager>(() => new EnnemyManager());
    public static EnnemyManager Instance { get { return lazy.Value; } }

    public List<Ennemy> listEnnemy = new List<Ennemy>();
    public int indexEnnemy;

    public EnnemyManager()
    {
        listEnnemy = new List<Ennemy>(Resources.LoadAll<Ennemy>("Prefab/SimpleEnnemy"));

        AddNewEnnemy();
    }

    public void Update()
    {
    }

    public Ennemy Ennemy;

    public float MeterCount = 10;

    public int KillCount = 0, MaxKillCount = 10;

    public void KilledEnnemy ()
    {
        Destroy(Ennemy.gameObject);

        Chasseur.Instance.AjouterOr(5 + (MeterCount - 10) / 10 * 3);

        KillCount++;
        if(KillCount > MaxKillCount)
        {
            KillCount = 0;
            MeterCount += 10;
        }

        AddNewEnnemy();
    }

    public void AddNewEnnemy ()
    {
        float PvEnnemy = 10 + (MeterCount - 10) / 10 * 7;

        int randomIndex = -1;

        do {
            randomIndex = UnityEngine.Random.Range(0, listEnnemy.Count);
        } while (randomIndex == indexEnnemy);

        indexEnnemy = randomIndex;

        Ennemy = Instantiate(listEnnemy[indexEnnemy].gameObject).GetComponent<Ennemy>();

        Ennemy.PV = PvEnnemy;
        Ennemy.PVMax = PvEnnemy;
    }
}
