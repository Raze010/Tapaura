using UnityEngine;

public class Ennemy : MonoBehaviour
{
    [HideInInspector]
    public float PV = 10, PVMax = 10;

    [HideInInspector]
    public bool dead = false;

    public void Damage (float amount)
    {
        if (dead)
            return;

        PV -= amount;
        if (PV <= 0) {
            PV = 0;
            dead = true;
            EnnemyManager.Instance.KilledEnnemy();
        }
    }
}
