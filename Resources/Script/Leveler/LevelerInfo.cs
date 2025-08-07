using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class LevelerInfo {
    public const string dpt = "dpt", dps = "dps";

    public string Titre, Description, SousDescription, SousTitre;

    public int NiveauStarter = 1;
    public int CoutOrStarter = 5;

    public Leveler Leveler;

    public LevelerInfo(string titre,string description,string sousDescription,string sousTitre) {
        Titre = titre;
        Description = description;
        SousDescription = sousDescription;
        SousTitre = sousTitre;
    }

    public LevelerInfo SetStarter (int niveauStarter,int coutOrStarter)
    {
        NiveauStarter = niveauStarter;
        CoutOrStarter = coutOrStarter;
        return this;
    }
}