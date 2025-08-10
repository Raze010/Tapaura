using System.Buffers.Text;
using System;
using UnityEngine;

public class FormuleManager : MonoBehaviour
{
    private static FormuleManager _instance;
    public static FormuleManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = GameObject.Find("FormuleManager").GetComponent<FormuleManager>();
            return _instance;
        }
    }

    public GN CalcEnnemie_PV(float MeterCount, bool Boss)
    {
        var croissance = 1.15f;

        var pwr = Math.Pow(croissance, (MeterCount / 10) - 1);

        var pv = 10 * pwr * pwr;

        if (Boss) pv *= 10;

        return new GN(pv);
    }

    public GN CalcEnnemie_DropOr(float MeterCount, bool Boss)
    {
        var croissance = 1.12f;

        var pwr = Math.Pow(croissance, (MeterCount / 10) - 1);

        var or = 2 * pwr * pwr;

        if (Boss) or *= 15;

        return new GN(or);
    }

    public GN CalcLeveler_Cost(float MeterCount, int Level)
    {
        var croissance = 1.2f;

        var pwr = Math.Pow(croissance, (MeterCount / 10) - 1);

        var or = (10 + 5 * Level) * pwr * pwr;

        return new GN(or);
    }

    public GN CalcCompetence_Cost(float MeterCount, int Level)
    {
        return CalcLeveler_Cost(MeterCount, Level + 5);
    }
}
