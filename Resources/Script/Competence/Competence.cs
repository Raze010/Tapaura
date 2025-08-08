using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public partial class Competence {
    public Leveler Leveler;
    public CompetenceInfo Info;

    public CompetenceInfoManager.ID ID;

    public void Start () {
        info = CompetenceInfoManager.Instance.ObtenirInfo(ID);
    }

    public void DefinirLeveler(Leveler leveler) {
        Leveler = leveler;

        Leveler.EventGainNiveau += EventLevelerMonterNiveau;
    }

    public void EventLevelerMonterNiveau (float OrDepense) {  }

    public bool EstVisible = false;

    public int NiveauDebloquer = 10;

    public bool EstDebloquer () {
        return Leveler.Niveau >= NiveauDebloquer;   
    }

    public float CoutOr;
    private bool EstAcheter = false, Actif = false;

    public bool EstActif() {
        return EstDebloquer() && EstAcheter && Actif;
    }

    public void Acheter() {
        if (CoutOr > Chasseur.Instance.Or)
            return;

        EstAcheter = true;
        Actif = true;

        Chasseur.Instance.RetirerOr(CoutOr);

        Leveler.NouvelleCompetenceAcheter(this);
    }

    public virtual void StartFunc() { }

    public void Update () {

    }
}