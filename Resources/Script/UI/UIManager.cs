using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text txt_meter, txt_life, txt_killCount, txt_or;
    public Image lifeSlice;
    public GameObject bouton_AffronterBoss, Bouton_AbandonnerBoss;

    public void Update()
    {
        var ennemyManager = EnnemyManager.Instance;
        var ennemy = ennemyManager.Ennemy;

        txt_meter.text = "" + ennemyManager.MeterCount + " m";
        txt_life.text = "" + ennemy.PV.ValeurAffichage();

        var pv = new GN(ennemy.PV.Nombre, ennemy.PVMax.Exposant, true);

        lifeSlice.fillAmount = (float)(pv.Nombre / ennemy.PVMax.Nombre);
        txt_or.text = "" + Chasseur.Instance.Or.ValeurAffichage() + " or";

        txt_killCount.text = "";
        Bouton_AbandonnerBoss.gameObject.SetActive(false);
        bouton_AffronterBoss.gameObject.SetActive(false);

        switch (ennemyManager.modeCombat)
        {
            case EnnemyManager.ModeCombat.Killing:
                txt_killCount.text = "" + ennemyManager.KillCount + " / " + ennemyManager.MaxKillCount;
                break;
            case EnnemyManager.ModeCombat.Endless:
                bouton_AffronterBoss.gameObject.SetActive(true);
                break;
            case EnnemyManager.ModeCombat.Boss:
                txt_killCount.text = "" + Mathf.CeilToInt(ennemyManager.ActiveTimeBossRemaining) + " s";
                Bouton_AbandonnerBoss.gameObject.SetActive(true);
                break;
        }

    }
}
