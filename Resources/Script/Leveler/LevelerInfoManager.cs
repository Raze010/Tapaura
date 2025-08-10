using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelerInfoManager
{

    private static readonly Lazy<LevelerInfoManager> lazy = new Lazy<LevelerInfoManager>(() => new LevelerInfoManager());
    public static LevelerInfoManager Instance { get { return lazy.Value; } }

    public enum ID
    {
        Chasseur_Expertise,
        Chasseur_Frappe,
        Chasseur_Aura,
        Perso_Ruel
    }

    private Dictionary<ID, LevelerInfo> DicoLevelerInfo = new Dictionary<ID, LevelerInfo>();

    public LevelerInfo ObtenirInfo(ID id)
    {
        return DicoLevelerInfo[id];
    }

    public Leveler ObtenirLeveler (ID id)
    {
        return DicoLevelerInfo[id].Leveler;
    }

    public string ObtenirTitre(ID id)
    {
        return DicoLevelerInfo[id].Titre;
    }

    public string ObtenirSousTitre(ID id)
    {
        return DicoLevelerInfo[id].SousTitre;
    }

    public string ObtenirDescription(ID id)
    {
        return DicoLevelerInfo[id].Description;
    }

    public string ObtenirSousDescription(ID id)
    {
        return DicoLevelerInfo[id].SousDescription;
    }

    public LevelerInfoManager()
    {
        InitInfo();
    }

    public void InitInfo()
    {
        DicoLevelerInfo.Clear();

        AjouterInfo(ID.Chasseur_Expertise, "Expertise", "Obtenez de précieux outils").SetStarter(0,100);
        AjouterInfo(ID.Chasseur_Frappe, "Frappe", "Augmentez les dégâts de vos frappes", "", "La frappe est les dégâts infligés lorsque vous tapotez votre ecran");
        AjouterInfo(ID.Chasseur_Aura, "Aura", "Augmentez les dégâts de votre AURA", "", "L'aura inflige des dégâts chaque seconde passivement").SetStarter(0, 50);

        AjouterInfo(ID.Perso_Ruel, "Muel", "Bien que vous gagnez de l'argent grace à lui vous ressentez que vous devriez en gagnant un montant nettement plus grand...", "", "c'est bizarre...").SetStarter(1, 50);
    }

    public LevelerInfo AjouterInfo(ID id, string titre = "", string description = "", string sousTitre = "", string sousDescription = "")
    {
        var leveler = new LevelerInfo(titre, description, sousTitre, sousDescription);

        DicoLevelerInfo.Add(id, leveler);

        return leveler;
    }
}
