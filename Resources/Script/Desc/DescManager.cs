using UnityEngine;
using UnityEngine.UI;

public class DescManager : MonoBehaviour
{
    private static DescManager _instance;
    public static DescManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = GameObject.Find("DescManager").GetComponent<DescManager>();
            return _instance;
        }
    }

    public GameObject Desc;

    [HideInInspector]
    public bool DescActif;

    public void Update()
    {
        Desc.gameObject.SetActive(DescActif);
    }

    public Text Desc_titre, Desc_SousTitre, Desc_Desc, Desc_SousDesc;

    public void Afficher(string titre, string sousTitre, string desc, string sousDesc)
    {
        DescActif = true;

        Desc_titre.text = titre;
        Desc_SousTitre.text = sousTitre;

        Desc_Desc.text = desc;
        Desc_SousDesc.text = sousDesc;
    }

    public void Desafficher()
    {
        DescActif = false;
    }
}

