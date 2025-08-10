using UnityEngine;

public class Leveler_Aura : Leveler
{
    public override string Suffixe()
    {
        return Aura().ValeurAffichage() + " " + LevelerInfo.dps;
    }

    public GN Aura()
    {
        float aura = Niveau;

        aura *= ObtenirCompetencePuissance(CompetenceInfoManager.ID.AuraSup);

        var capacite = CapaciteInfoManager.Instance.ObtenirCapacite(CapaciteInfoManager.ID.Cape_Rouge);

        if (capacite.IsActive)
            aura *= 3;

        return new GN(aura); 
    }
}
