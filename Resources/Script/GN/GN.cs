using UnityEngine;
using System;

/// <summary>
/// Grand nombre
/// </summary>
public class GN {
    //On ne veut garder que les n premier chiffre significatif
    public double Nombre { get; private set; }

    //L'exposant du nombre, si gn = 10 exposant = 0
    //Pour gn = 1 000 exposant = 0
    //Pour gn = 10 000 exposant = 0
    //Pour gn = 100 000 exposant = 1 soit Nombre = 100 000 et exposant = 1 mais ToString = 10 000e1
    public int Exposant { get; private set; }

    public bool FORCEEXPOSANT;

    public GN(double Nombre = 0, int Exposant = 0, bool FORCEEXPOSANT = false) {
        this.Nombre = Nombre;
        this.Exposant = Exposant;
        this.FORCEEXPOSANT = FORCEEXPOSANT;
        Ergonomiser();
    }

    public GN Clone() {
        return new GN(Nombre, Exposant, FORCEEXPOSANT);
    }

    #region Ajout/Soustraction

    public void Ajouter(GN gn) {
        Ajouter(gn.Nombre, gn.Exposant);
    }

    public void Ajouter(double nombreModifier, int ExposantModifier) {
        if (Exposant == ExposantModifier) {
            Nombre += nombreModifier;
        } else {
            Nombre += ModifierAExposant(nombreModifier, ExposantModifier, Exposant);
        }

        Ergonomiser();
    }

    public void Retirer(GN gn) {
        Supprimer(gn.Nombre, gn.Exposant);
    }

    public void Supprimer(double nombreModifier, int ExposantModifier) {
        if (Exposant == ExposantModifier) {
            Nombre -= nombreModifier;
        } else {
            Nombre -= ModifierAExposant(nombreModifier, ExposantModifier, Exposant);
        }

        Ergonomiser();
    }

    #endregion

    #region Comparaison 

    public bool EstEgaleA(GN cible) {
        var nbCible = ModifierAExposant(cible.Nombre, cible.Exposant, Exposant);

        return double.Equals(nbCible, Nombre);
    }

    public bool EstSuperieurA(GN cible) {
        var nbCible = ModifierAExposant(cible.Nombre, cible.Exposant, Exposant);

        return Nombre > nbCible;
    }

    public bool EstInferieurA(GN cible) {
        var nbCible = ModifierAExposant(cible.Nombre, cible.Exposant, Exposant);

        return Nombre < nbCible;
    }

    #endregion

    private double ModifierAExposant(double nombreAModifier, int ancienExposant, int nouveauExposant) {
        int diff = nouveauExposant - ancienExposant;

        return nombreAModifier / Math.Pow(10, diff);
    }

    private const float NombreSignificatif = 100000;

    private void Ergonomiser() {
        if (FORCEEXPOSANT) return;

        while (Nombre >= NombreSignificatif) {
            Nombre /= 10;
            Exposant++;
        }
        while (Nombre < NombreSignificatif / 10 && Exposant != 0) {
            Nombre *= 10;
            Exposant--;
        }
    }

    public List<GNSuffixe> ListeGNSuffixe = new List<GNSuffixe>();
    public int exposantMax;

    public void InitListeGNSuffixe() {
        ListeGNSuffixe.Clear();
        ListeGNSuffixe.Add(new GNSuffixe("Mille", "K", 3, 6));
        ListeGNSuffixe.Add(new GNSuffixe("Million", "M", 6, 9));
        ListeGNSuffixe.Add(new GNSuffixe("Milliard", "B", 9, 12));
        ListeGNSuffixe.Add(new GNSuffixe("Billion", "T", 12, 15));
        ListeGNSuffixe.Add(new GNSuffixe("Billiard", "Qa", 15, 18));
        ListeGNSuffixe.Add(new GNSuffixe("Trillion", "Qi", 18, 21));
        ListeGNSuffixe.Add(new GNSuffixe("Trilliard", "Sx", 21, 24));
        ListeGNSuffixe.Add(new GNSuffixe("Quadrillion", "Sp", 24, 27));
        ListeGNSuffixe.Add(new GNSuffixe("Quintrillion", "Oc", 27, 30));
        ListeGNSuffixe.Add(new GNSuffixe("Sextillion", "No", 30, 33));
        ListeGNSuffixe.Add(new GNSuffixe("Septillion", "Dc", 33, 36));
        ListeGNSuffixe.Add(new GNSuffixe("Octillion", "Ud", 36, 39));
        ListeGNSuffixe.Add(new GNSuffixe("Nonillion", "Dd", 39, 42));
        ListeGNSuffixe.Add(new GNSuffixe("Décillion", "Td", 42, 45));
        ListeGNSuffixe.Add(new GNSuffixe("Undécillion", "Qad", 45, 48));
        ListeGNSuffixe.Add(new GNSuffixe("Duodécillion", "Qid", 48, 51));
        ListeGNSuffixe.Add(new GNSuffixe("Trédécillion", "Sxd", 51, 54));
        ListeGNSuffixe.Add(new GNSuffixe("Quattuordécillion", "Spd", 54, 57));
        ListeGNSuffixe.Add(new GNSuffixe("Quindécillion", "Ocd", 57, 60));
        ListeGNSuffixe.Add(new GNSuffixe("Sezdécillion", "Nod", 60, 63));
        ListeGNSuffixe.Add(new GNSuffixe("Septendécillion", "Vg", 63, 66));
        ListeGNSuffixe.Add(new GNSuffixe("Octodécillion", "Uv", 66, 69));
        ListeGNSuffixe.Add(new GNSuffixe("Novemdécillion", "Dv", 69, 72));

        exposantMax = 75;
    }

    public List<char> ListeAlphabet = new List<char>() {
    'a','b','c','d','e','f','g','h','i','j','k','l','m',
    'n','o','p','q','r','s','t','u','v','w','x','y','z'
};

    public string ValeurAffichage() {
        var strNombre = Mathf.Ceil((float)Nombre).ToString();

        if (Exposant == 0) return strNombre;

        if (Exposant > exposantMax) {
            int nombreExposantApresMax = Exposant - exposantMax;

            int premier = nombreExposantApresMax / 26;
            int second = nombreExposantApresMax % 26;

            return strNombre + " " +premier + second;
        }

        foreach (var suffixe in ListeGNSuffixe) {
            if (suffixe.exposantCible != Exposant)
                break;

            return ModifierAExposant(nombreAModifier, Exposant, suffixe.Exposant) + " " + suffixe.Abreviation;
        }
    }
}

public class GNSuffixe {
    public string NomComplet, Abreviation;
    public int Exposant, ExposantCible;

    public GNSuffixe(string nomCompet, string abreviation, int exposant, int exposantCible) {
        this.NomComplet = nomCompet;
        this.Abreviation = abreviation;
        this.Exposant = exposant;
        this.ExposantCible = exposantCible;
    }
}