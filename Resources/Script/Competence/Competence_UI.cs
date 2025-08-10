using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public partial class Competence : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject groupe, voile;

    public void UI()
    {
        groupe.SetActive(EstVisible);
        voile.SetActive(!Actif);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        DescManager.Instance.Afficher(CalcTitre(), CalcSousTitre(), CalcDesc(), CalcSousDesc());
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        DescManager.Instance.Desafficher();
    }
}
