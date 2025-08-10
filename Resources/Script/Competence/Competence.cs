using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public partial class Competence {

    [HideInInspector]
    public Leveler Leveler;

    [HideInInspector]
    public CompetenceInfo Info;

    public CompetenceInfoManager.ID ID;

    public float Power;

    public void SetLeveler (Leveler leveler) {
        Info = CompetenceInfoManager.Instance.ObtenirInfo(ID);
        Leveler.EventGainNiveau += EventLevelerMonterNiveau;
        CoutOr = FormuleManager.Instance.CalcCompetence_Cost(Leveler.info.MeterStarter,NiveauDebloquer);
    }

    public void EventLevelerMonterNiveau (GN OrDepense) {  }

    [HideInInspector]
    public bool EstVisible = false;

    public int NiveauDebloquer = 10;

    [HideInInspector]
    public GN CoutOr;
    [HideInInspector]
    private bool EstAcheter = false, Actif = false;

    public bool EstActif() {
        return EstAcheter && Actif;
    }

    public void Acheter() {
        if (Chasseur.Instance.Or.EstInferieurA(CoutOr) || NiveauDebloquer > Leveler.Niveau)
            return;

        EstAcheter = true;
        Actif = true;

        Chasseur.Instance.Or.Retirer(CoutOr);

        Leveler.NouvelleCompetenceAcheter(this);
    }

    public void Update () {
        EstVisible = false;

        if (Leveler.Niveau >= NiveauDebloquer) {
            EstVisible = true;
        } else {
            var listeComptence = Leveler.ListeCompetence.OrderBy(a => a.NiveauDebloquer).ToList();
        
            for(int i = 0; i < listeComptence.Count; i++) {
                var competence = listeComptence[i];

                if (competence == this)
                    EstVisible = true;

                if (competence.NiveauDebloquer > Leveler.Niveau)
                    break;
            }
        }

        UI();
    }
}
