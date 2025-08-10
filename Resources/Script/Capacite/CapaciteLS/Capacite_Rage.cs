using System.Collections;
using UnityEngine;

public class Capacite_Rage : Capacite
{
    [HideInInspector]
    public float ActiveTime;

    public float ActiveTimeMax;

    public override void DoEffect()
    {
        StopAllCoroutines();
        StartCoroutine(Effect());
    }

    public IEnumerator Effect ()
    {
        ActiveTime = ActiveTimeMax;

        float nbFrappe = 10;

        var nbSeconde = 30;

        while(nbSeconde > 0)
        {
            nbSeconde--;
        
            for(int i = 0; i < nbFrappe; i++)
            {
                Chasseur.Instance.Frappe();
                yield return new WaitForSeconds(1 / nbFrappe);
            }

            ActiveTime -= 1;
        }

        FinishEffect();
    }

    public override bool Visible()
    {
        return LevelerInfoManager.Instance.ObtenirLeveler(LevelerInfoManager.ID.Chasseur_Frappe).ObtenirCompetenceActif(CompetenceInfoManager.ID.Frappe_Rage);
    }
}
