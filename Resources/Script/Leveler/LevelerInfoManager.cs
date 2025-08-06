public class LevelerInfoManager {

    private static readonly Lazy<LevelerInfoManager> lazy = new Lazy<LevelerInfoManager>(() => new LevelerInfoManager());
    public static LevelerInfoManager Instance { get { return lazy.Value; } }

    public enum ID {
        Chasseur_Expertise,
        Chasseur_Frappe,
        Chasseur_Aura,
        Perso_Ruel
    }

    private Dictionary<ID, LevelerInfo> DicoLevelerInfo = new Dictionary<ID, LevelerInfo>();

    public string ObtenirTitre(ID id) {
        return DicoLevelerInfo[id].Titre;
    }

    public string ObtenirSousTitre(ID id) {
        return DicoLevelerInfo[id].SousTitre;
    }

    public string ObtenirDescription(ID id) {
        return DicoLevelerInfo[id].Description;
    }

    public string ObtenirSousDescription(ID id) {
        return DicoLevelerInfo[id].SousDescription;
    }

    public CompetenceInfo() {
        InitInfo();
    }

    public void InitInfo() {
        DicoLevelerInfo.Clear();

        AjouterInfo(ID.Chasseur_Expertise, "Expertise", "Obtenez de précieux outils");
        AjouterInfo(ID.Chasseur_Frappe, "Frappe", "Augmentez les dégâts de vos frappes", "", "La frappe est les dégâts infligés lorsque vous tapotez votre ecran")
        AjouterInfo(ID.Chasseur_Aura, "AURA", "Augmentez les dégâts de votre AURA", "", "L'aura inflige des dégâts chaque seconde passivement");

        AjouterInfo(ID.Perso_Ruel, "Muel", "Bien que vous gagnez de l'argent grace à lui vous ressentez tout de même que vous devriez en gagnant un montant nettement plus grand...", "", "c'est bizarre...");
    }

    public void AjouterInfo(ID id, string titre, string description, string sousTitre, string sousDescription) {
        DicoLevelerInfo.Add(id, new LevelerInfo(titre, description, sousTitre, sousDescription));
    }
}
