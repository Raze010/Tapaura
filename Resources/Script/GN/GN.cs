using UnityEngine;
using System;

/// <summary>
/// Grand nombre
/// </summary>
public class GN
{
    //On ne veut garder que les n premier chiffre significatif
    public double Nombre { get; private set; }

    //L'exposant du nombre, si gn = 10 exposant = 0
    //Pour gn = 1 000 exposant = 0
    //Pour gn = 10 000 exposant = 0
    //Pour gn = 100 000 exposant = 1 soit Nombre = 100 000 et exposant = 1 mais ToString = 10 000e1
    public int Exposant { get; private set; }

    public bool FORCEEXPOSANT;

    public GN(double Nombre = 0, int Exposant = 0, bool FORCEEXPOSANT = false)
    {
        this.Nombre = Nombre;
        this.Exposant = Exposant;
        this.FORCEEXPOSANT = FORCEEXPOSANT;
        Ergonomiser();
    }

    public GN Clone()
    {
        return new GN(Nombre, Exposant, FORCEEXPOSANT);
    }

    #region Ajout/Soustraction

    public void Ajouter(GN gn)
    {
        Ajouter(gn.Nombre, gn.Exposant);
    }

    public void Ajouter(double nombreModifier, int ExposantModifier)
    {
        if (Exposant == ExposantModifier)
        {
            Nombre += nombreModifier;
        }
        else
        {
            Nombre += ModifierAExposant(nombreModifier, ExposantModifier, Exposant);
        }

        Ergonomiser();
    }

    public void Retirer(GN gn)
    {
        Supprimer(gn.Nombre, gn.Exposant);
    }

    public void Supprimer(double nombreModifier, int ExposantModifier)
    {
        if (Exposant == ExposantModifier)
        {
            Nombre -= nombreModifier;
        }
        else
        {
            Nombre -= ModifierAExposant(nombreModifier, ExposantModifier, Exposant);
        }

        Ergonomiser();
    }

    #endregion

    #region Comparaison 

    public bool EstEgaleA(GN cible)
    {
        var nbCible = ModifierAExposant(cible.Nombre, cible.Exposant, Exposant);

        return double.Equals(nbCible, Nombre);
    }

    public bool EstSuperieurA(GN cible)
    {
        var nbCible = ModifierAExposant(cible.Nombre, cible.Exposant, Exposant);

        return Nombre > nbCible;
    }

    public bool EstInferieurA(GN cible)
    {
        var nbCible = ModifierAExposant(cible.Nombre, cible.Exposant, Exposant);

        return Nombre < nbCible;
    }

    #endregion

    private double ModifierAExposant(double nombreAModifier, int ancienExposant, int nouveauExposant)
    {
        int diff = nouveauExposant - ancienExposant;

        return nombreAModifier / Math.Pow(10, diff);
    }

    private const float NombreSignificatif = 100000;

    private void Ergonomiser()
    {
        if (FORCEEXPOSANT) return;

        while (Nombre >= NombreSignificatif)
        {
            Nombre /= 10;
            Exposant++;
        }
        while (Nombre < NombreSignificatif / 10 && Exposant != 0)
        {
            Nombre *= 10;
            Exposant--;
        }
    }

    public string ValeurAffichage()
    {
        var strNombre = Mathf.Ceil((float)Nombre).ToString();

        if (Exposant == 0) return strNombre;
        else return strNombre + " e" + Exposant;
    }

}
