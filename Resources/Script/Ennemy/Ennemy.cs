using UnityEngine;

public class Ennemy : MonoBehaviour
{
    [HideInInspector]
    public GN PV, PVMax;

    [HideInInspector]
    public bool dead = false;

    public void Damage(GN amount)
    {
        if (dead)
            return;

        PV.Retirer(amount);
        if (PV.Nombre <= 0)
        {
            dead = true;
            EnnemyManager.Instance.TuerEnnemie(true, false);
        }
    }
}
