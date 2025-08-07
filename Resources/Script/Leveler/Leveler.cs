using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public partial class Leveler : MonoBehaviour{

    public LevelerInfoManager.ID ID;

    [HideInInspector]
    public LevelerInfo info;

    public void Start()
    {
        info = LevelerInfoManager.Instance.ObtenirInfo(ID);

        info.Leveler = this;

        Niveau = info.NiveauStarter;
        CoutOr = info.CoutOrStarter;
    }

    [HideInInspector]
    public float CoutOr;

    [HideInInspector]
    /// <summary>
    /// Le cout en or totale dépensé pour les gains de niveau / l'achat de compétence
    /// </summary>
    public float CoutOrTotale;

    [HideInInspector]
    public int Niveau = 0, NiveauMax = 200;

    public delegate void EventNiveauDelegate(float OrDepense);

    public EventNiveauDelegate EventGainNiveau;

    public bool Ameliorable() {
        return CoutOr <= Chasseur.Instance.Or;
    }

    public void Ameliorer () {
        if (!Ameliorable()) 
            return;

        Niveau++;

        Chasseur.Instance.RetirerOr(CoutOr);

        EventGainNiveau?.Invoke(CoutOr);

        CoutOrTotale += CoutOr;
        CoutOr += 5;

        Chasseur.Instance.CalcCarac();
    }

    public List<Competence> ListeCompetence = new List<Competence>();

    public void NouvelleCompetenceAcheter (Competence competence) {
        CoutOrTotale += competence.CoutOr;

        Chasseur.Instance.CalcCarac();
    }

    public virtual string Suffixe ()
    {
        return "";
    }
}