using UnityEngine;

public class Leveler_Frappe : Leveler
{
    public override string Suffixe()
    {
        return Frappe().ValeurAffichage() + " " + LevelerInfo.dpt;
    }

    public GN Frappe ()
    {
        return new GN(Niveau * ObtenirCompetencePuissance(CompetenceInfoManager.ID.FrappeSup));
    }
}
