using UnityEngine;

public class Leveler_Frappe : Leveler
{
    public override string Suffixe()
    {
        return Frappe() + " " + LevelerInfo.dpt;
    }

    public float Frappe ()
    {
        return Niveau;
    }
}
