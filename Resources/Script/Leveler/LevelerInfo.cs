using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class LevelerInfo
{
    public const string dpt = "dpt", dps = "dps";

    public string Titre { get; set; }
    public string SousTitre { get; set; }
    public string Description { get; set; }
    public string SousDescription { get; set; }

    public int NiveauStarter = 1;
    public int MeterStarter = 0;

    public Leveler Leveler;

    public LevelerInfo(string titre, string description, string sousDescription, string sousTitre)
    {
        Titre = titre;
        Description = description;
        SousDescription = sousDescription;
        SousTitre = sousTitre;
    }

    public LevelerInfo SetStarter(int niveauStarter, int MeterStarter)
    {
        this.MeterStarter = MeterStarter;
        NiveauStarter = niveauStarter;
        return this;
    }
}