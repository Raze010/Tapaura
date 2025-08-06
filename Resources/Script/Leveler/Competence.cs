
public class Competence {
    public Leveler Leveler;

    public void DefinirLeveler(Leveler leveler) {
        Leveler = leveler;

        Leveler.EventGainNiveau += EventLevelerMonterNiveau;
    }

    public void EventLevelerMonterNiveau (int OrDepense) {

    }

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
}