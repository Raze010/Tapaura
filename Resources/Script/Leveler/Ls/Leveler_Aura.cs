using UnityEngine;

public class Leveler_Aura : Leveler
{
    public override string Suffixe()
    {
        return Aura() + " " + LevelerInfo.dps;
    }

    public float Aura()
    {
        return Niveau;
    }
}
