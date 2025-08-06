
public partial class Chasseur {

    public float Or { get; private set; }

    public void AjouterOr(float montant) {
        Or += montant;
    }

    public void RetirerOr(float montant) {
        Or -= montant;
    }
}