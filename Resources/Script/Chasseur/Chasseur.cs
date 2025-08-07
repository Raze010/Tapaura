using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public partial class Chasseur : MonoBehaviour
{
    private static Chasseur _instance;
    public static Chasseur Instance
    {
        get
        {
            if (_instance == null)
                _instance = GameObject.Find("Chasseur").GetComponent<Chasseur>();
            return _instance;
        }
    }

    public void Start()
    {
        CalcCarac();
    }

    [HideInInspector]
    public float PV = 30, PVMax = 30;

    [HideInInspector]
    public float DgtFrappe = 1, DgtAura = 0;

    public void CalcCarac()
    {
        PVMax = 30;

        Leveler_Frappe frappeLeveler = LevelerInfoManager.Instance.ObtenirLeveler(LevelerInfoManager.ID.Chasseur_Frappe) as Leveler_Frappe;
        Leveler_Aura auraLeveler = LevelerInfoManager.Instance.ObtenirLeveler(LevelerInfoManager.ID.Chasseur_Aura) as Leveler_Aura;

        DgtFrappe = frappeLeveler.Frappe() +10;
        DgtAura = auraLeveler.Aura();
    }

    public void Update()
    {
        if (TouchHelper.TapDetecter(out var pos) && pos.y >= 0.3f)
        {
            EnnemyManager.Instance.Ennemy.Damage(DgtFrappe);
        }

        if(DgtAura > 0)
        {
            EnnemyManager.Instance.Ennemy.Damage(DgtAura * Time.deltaTime);
        }
    }
}