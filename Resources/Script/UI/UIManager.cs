using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text txt_meter, txt_life, txt_killCount, txt_or;
    public Image lifeSlice;

    public void Update()
    {
        var ennemyManager = EnnemyManager.Instance;
        var ennemy = ennemyManager.Ennemy;

        txt_meter.text = "" + ennemyManager.MeterCount + " m";
        txt_life.text = "" + Mathf.CeilToInt(ennemy.PV);
        lifeSlice.fillAmount = ennemy.PV / ennemy.PVMax;
        txt_killCount.text = "" +ennemyManager.KillCount + " / " +ennemyManager.MaxKillCount;
        txt_or.text = "" + Chasseur.Instance.Or + " or";
    }
}
