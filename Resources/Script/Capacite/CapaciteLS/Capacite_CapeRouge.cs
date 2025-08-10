using System.Collections;
using UnityEngine;

public class Capacite_CapeRouge : Capacite
{
    [HideInInspector]
    public float ActiveTime;

    public float ActiveTimeMax;

    public override void DoEffect()
    {
        StopAllCoroutines();
        StartCoroutine(Effect());
    }

    public IEnumerator Effect()
    {
        ActiveTime = ActiveTimeMax;

        var nbSeconde = 30;

        while (nbSeconde > 0)
        {
            nbSeconde--;

            yield return new WaitForSeconds(1);

            ActiveTime -= 1;
        }

        FinishEffect();
    }

    public override bool Visible()
    {
        return LevelerInfoManager.Instance.ObtenirLeveler(LevelerInfoManager.ID.Chasseur_Aura).ObtenirCompetenceActif(CompetenceInfoManager.ID.Aura_CapeRouge);
    }
}
