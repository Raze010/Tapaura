using System.Collections.Generic;
using System;
using UnityEngine;

public class CapaciteInfoManager : MonoBehaviour
{
    private static readonly Lazy<CapaciteInfoManager> lazy = new Lazy<CapaciteInfoManager>(() => new CapaciteInfoManager());
    public static CapaciteInfoManager Instance { get { return lazy.Value; } }

    public enum ID
    {
        Rage, Cape_Rouge
    }

    private Dictionary<ID, CapaciteInfo> DicoCapaciteInfo = new Dictionary<ID, CapaciteInfo>();

    public Capacite ObtenirCapacite(ID id)
    {
        return DicoCapaciteInfo[id].capacite;
    }

    public CapaciteInfo ObtenirInfo(ID id)
    {
        return DicoCapaciteInfo[id];
    }

    public string ObtenirTitre(ID id)
    {
        return DicoCapaciteInfo[id].Titre;
    }

    public string ObtenirSousTitre(ID id)
    {
        return DicoCapaciteInfo[id].SousTitre;
    }

    public string ObtenirDescription(ID id)
    {
        return DicoCapaciteInfo[id].Description;
    }

    public string ObtenirSousDescription(ID id)
    {
        return DicoCapaciteInfo[id].SousDescription;
    }

    public CapaciteInfoManager()
    {
        InitInfo();
    }

    public void InitInfo()
    {
        DicoCapaciteInfo.Clear();

        //Frappe et aura
        AjouterInfo(ID.Rage, "Rage", "Frappez 10 fois par seconde pendant 30 seconde", "", "Temps de recharge : 180s");
        AjouterInfo(ID.Cape_Rouge, "Cape rouge", "+200% d'aura pendant 30 seconde", "", "Temps de recharge : 180s");
    }

    public void AjouterInfo(ID id, string titre = "", string description = "", string sousTitre = "", string sousDescription = "")
    {
        DicoCapaciteInfo.Add(id, new CapaciteInfo(titre, description, sousTitre, sousDescription));
    }
}
