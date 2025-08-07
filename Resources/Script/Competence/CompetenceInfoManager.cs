using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CompetenceInfoManager {
    private static readonly Lazy<CompetenceInfoManager> lazy = new Lazy<CompetenceInfoManager>(() => new CompetenceInfoManager());
    public static CompetenceInfoManager Instance { get { return lazy.Value; } }

    public enum ID {

        //Expertise
        Expertise_Or,
        Expertise_Anomalie,
        Expertise_Equipement,
        Expertise_Compagnon,
        Expertise_Capacite,
        
        //Muel
        Muel_10aura,
        Muel_FrappeOr,
        Muel_30aura,
        Muel_RamasseurPiece,
        Muel_Expert,
        Muel_Effort
    }

    private Dictionary<ID, CompetenceInfo> DicoCompetenceInfo = new Dictionary<ID, CompetenceInfo>();

    public string ObtenirTitre(ID id) {
        return DicoCompetenceInfo[id].Titre;
    }

    public string ObtenirSousTitre(ID id) {
        return DicoCompetenceInfo[id].SousTitre;
    }

    public string ObtenirDescription(ID id) {
        return DicoCompetenceInfo[id].Description;
    }

    public string ObtenirSousDescription(ID id) {
        return DicoCompetenceInfo[id].SousDescription;
    }

    public CompetenceInfoManager() {
        InitInfo();
    }

    public void InitInfo() {
        DicoCompetenceInfo.Clear();

        //Expertise
        AjouterInfo(ID.Expertise_Or, "", "Gagnez 100 or et 10 lorsque vous parcourez 1 metre");
        AjouterInfo(ID.Expertise_Anomalie, "", "Gagnez 10 pierre d'anomalie et 1 lorsque vous parcourez 100 metre");
        AjouterInfo(ID.Expertise_Equipement, "", "Obtenez un équipement au hasard");
        AjouterInfo(ID.Expertise_Compagnon, "", "Obtenez un compagnon au hasard");
        AjouterInfo(ID.Expertise_Capacite, "", "Obtenez une capacité au hasard");

        //Muel
        AjouterInfo(ID.Muel_10aura, "", "+10 aura","","Sa simple présence inquiète les banquiers aux alentours");
        AjouterInfo(ID.Muel_FrappeOr, "Frappe en or", "Vos frappes vous font gagner 1% de l’or de l’ennemie");
    }

    public void AjouterInfo(ID id, string titre = "", string description = "", string sousTitre = "", string sousDescription = "") {
        DicoCompetenceInfo.Add(id, new CompetenceInfo(titre, description, sousTitre, sousDescription));
    }
}