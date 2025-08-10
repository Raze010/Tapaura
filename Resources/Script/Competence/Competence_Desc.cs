using UnityEngine;

public partial class Competence
{
    public string CalcTitre()
    {
        return Info.Titre + " niv. " + NiveauDebloquer;
    }

    public string CalcSousTitre()
    {
        return Info.SousTitre;
    }

    public string CalcDesc()
    {
        return Info.Description.Replace("*pwr*", "" + Power);
    }

    public string CalcSousDesc()
    {
        return Info.SousDescription + " coûte " + CoutOr.ValeurAffichage() + " Or";
    }
}
