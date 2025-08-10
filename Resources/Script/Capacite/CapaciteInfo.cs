using UnityEngine;

public class CapaciteInfo : MonoBehaviour
{
    public string Titre { get; set; }
    public string SousTitre { get; set; }
    public string Description { get; set; }
    public string SousDescription { get; set; }

    public Capacite capacite;

    public CapaciteInfo(string titre, string description, string sousTitre, string sousDescription)
    {
        Titre = titre;
        Description = description;
        SousTitre = sousTitre;
        SousDescription = sousDescription;
    }
}
