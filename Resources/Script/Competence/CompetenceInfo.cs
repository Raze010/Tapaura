using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class CompetenceInfo {
    public string Titre { get; set; }
    public string SousTitre { get; set; }
    public string Description { get; set; }
    public string SousDescription { get; set; }

    public CompetenceInfo(string titre,string description,string sousTitre,string sousDescription) {
        Titre = titre;
        Description = description;
        SousTitre = sousTitre;
        SousDescription = sousDescription;
    }
}