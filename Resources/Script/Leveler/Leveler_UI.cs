using UnityEngine;
using UnityEngine.UI;

public partial class Leveler : MonoBehaviour
{
    public Text Txt_Titre, Txt_Cost, Txt_suffixe;

    public void Update()
    {
        Txt_Titre.text = info.Titre + " Nv." + Niveau;
        Txt_Cost.text = "Améliorer\n" + CoutOr + " Or";
        Txt_suffixe.text = Suffixe();
    }
}
