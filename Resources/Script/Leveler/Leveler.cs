
public class Leveler {

    public float CoutOr;
    /// <summary>
    /// Le cout en or totale dépensé pour les gains de niveau / l'achat de compétence
    /// </summary>
    public float CoutOrTotale;

    public int Niveau = 0, NiveauMax = 200;

    public delegate void EventNiveauDelegate(int OrDepense);

    public EventNiveauDelegate EventGainNiveau;

    public bool Ameliorable() {
        return CoutOr <= Chasseur.Instance.Or;
    }

    public void Ameliorer () {
        if (!Ameliorable()) 
            return;

        Niveau++;

        Chasseur.Instance.RetirerOr(CoutOr);

        EventGainNiveau(CoutOr);

        CoutOrTotale += CoutOr;
        CoutOr += 5;

        Chasseur.Instance.CalcCarac();
    }

    public List<Competence> ListeCompetence = new List<Competence>();

    public void NouvelleCompetenceAcheter (Competence competence) {
        CoutOrTotale += competence.CoutOr;

        Chasseur.Instance.CalcCarac();
    }
}