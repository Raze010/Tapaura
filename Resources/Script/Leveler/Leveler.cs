using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
public partial class Leveler : MonoBehaviour
{

    public LevelerInfoManager.ID ID;

    [HideInInspector]
    public LevelerInfo info;

    public void Start()
    {
        info = LevelerInfoManager.Instance.ObtenirInfo(ID);

        info.Leveler = this;

        Niveau = info.NiveauStarter;
        if (TestHelper.Instance.Active && TestHelper.Instance.LevelStarter != -1)
            Niveau = TestHelper.Instance.LevelStarter;

        CoutOr = FormuleManager.Instance.CalcLeveler_Cost(info.MeterStarter, Niveau);

        foreach (var competence in ListeCompetence)
        {
            competence.SetLeveler(this);
        }
    }

    [HideInInspector]
    public GN CoutOr;

    [HideInInspector]
    /// <summary>
    /// Le cout en or totale dépensé pour les gains de niveau / l'achat de compétence
    /// </summary>
    public GN CoutOrTotale = new GN();

    [HideInInspector]
    public int Niveau = 0, NiveauMax = 200;

    public delegate void EventNiveauDelegate(GN OrDepense);

    public EventNiveauDelegate EventGainNiveau;

    public bool Ameliorable()
    {
        return Chasseur.Instance.Or.EstSuperieurA(CoutOr) || Chasseur.Instance.Or.EstEgaleA(CoutOr);
    }

    public void Ameliorer()
    {
        if (!Ameliorable())
            return;

        Niveau++;

        Chasseur.Instance.Or.Retirer(CoutOr);

        EventGainNiveau?.Invoke(CoutOr);

        CoutOrTotale.Ajouter(CoutOr);
        CoutOr = FormuleManager.Instance.CalcLeveler_Cost(info.MeterStarter, Niveau);

        Chasseur.Instance.CalcCarac();
    }

    public List<Competence> ListeCompetence = new List<Competence>();

    public void NouvelleCompetenceAcheter(Competence competence)
    {
        CoutOrTotale.Ajouter(competence.CoutOr);

        Chasseur.Instance.CalcCarac();
    }

    public virtual string Suffixe()
    {
        return "";
    }

    public bool ObtenirCompetenceActif(CompetenceInfoManager.ID id)
    {
        var competence = ListeCompetence.FirstOrDefault(a => a.ID == id);

        if (competence == null) return false;

        return competence.EstActif();
    }

    public float ObtenirCompetencePuissance(CompetenceInfoManager.ID id)
    {
        float power = 1;

        foreach (var competence in ListeCompetence)
        {
            if (competence.ID != id || !competence.EstActif())
                continue;

            power *= 1 + competence.Power / 100;
        }

        return power;
    }
}
