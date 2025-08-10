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
    public GN DgtFrappe, DgtAura;

    public void CalcCarac()
    {
        PVMax = 30;

        DgtFrappe = CalcFrappe();
        DgtAura = CalcAura();
    }

    public GN CalcFrappe()
    {
        GN frappe = new GN();

        Leveler_Frappe frappeLeveler = LevelerInfoManager.Instance.ObtenirLeveler(LevelerInfoManager.ID.Chasseur_Frappe) as Leveler_Frappe;

        frappe.Ajouter(frappeLeveler.Frappe());

        if (TestHelper.Instance.Active && TestHelper.Instance.FrappeInstaKill) frappe = new GN(float.MaxValue);

        return frappe;
    }

    public GN CalcAura()
    {
        GN aura = new GN();

        Leveler_Aura auraLeveler = LevelerInfoManager.Instance.ObtenirLeveler(LevelerInfoManager.ID.Chasseur_Aura) as Leveler_Aura;

        aura = auraLeveler.Aura();

        if (TestHelper.Instance.Active && TestHelper.Instance.AuraInstaKill) aura = new GN(float.MaxValue);

        return aura;
    }

    public void Update()
    {
        CalcCarac();

        if (TouchHelper.TapDetecter(out var pos) && pos.y >= 0.3f)
        {
            Frappe();
        }

        if (DgtAura.Nombre > 0)
        {
            EnnemyManager.Instance.Ennemy.Damage(new GN(DgtAura.Nombre * Time.deltaTime,DgtAura.Exposant));
        }
    }

    public void Frappe()
    {
        EnnemyManager.Instance.Ennemy.Damage(DgtFrappe);
    }
}