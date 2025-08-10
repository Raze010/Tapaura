using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class Capacite : MonoBehaviour
{
    [HideInInspector]
    public CapaciteInfo Info;
    public CapaciteInfoManager.ID ID;

    public void Start()
    {
        Info = CapaciteInfoManager.Instance.ObtenirInfo(ID);
        Info.capacite = this;
    }

    [HideInInspector]
    public float Cooldown;

    public float CooldownMax;

    public Text CooldownTxt;

    public GameObject Groupe;

    public void Update()
    {
        Cooldown -= Time.deltaTime;
        if (IsActive)
        {
            CooldownTxt.text = "active";
        }
        else
        {
            CooldownTxt.text = Cooldown > 0 ? Mathf.CeilToInt(Cooldown).ToString() : "";
        }

        Groupe.gameObject.SetActive(Visible());
    }

    public bool OnCooldown()
    {
        return Cooldown > 0;
    }

    public void Use()
    {
        if (OnCooldown() || OnUse() || !Visible()) return;

        IsActive = true;

        DoEffect();
    }

    [HideInInspector]
    public bool IsActive = false;

    public abstract void DoEffect();

    public virtual bool OnUse()
    {
        return false;
    }

    public void FinishEffect()
    {
        Cooldown = CooldownMax;
        IsActive = false;
    }

    public virtual bool Visible ()
    {
        return true;
    }
}
