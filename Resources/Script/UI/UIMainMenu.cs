using UnityEngine;

public class UIMainMenu : MonoBehaviour
{
    public float posYShowed, posYHidden;

    [HideInInspector]
    public bool Expanded = false;

    public void Update()
    {
        if (Expanded)
        {
            transform.position = new Vector3(0, posYShowed);
        }
        else
        {
            transform.position = new Vector3(0, posYHidden);
        }
    }

    public void ExpandButton ()
    {
        Expanded = !Expanded;
    }
}
