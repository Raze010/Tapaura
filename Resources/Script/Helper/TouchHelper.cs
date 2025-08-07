using UnityEngine;

public class TouchHelper : MonoBehaviour
{
    public static bool TapDetecter(out Vector3 positionInWorld)
    {
        positionInWorld = Vector3.zero;

#if UNITY_EDITOR
        // Utilise la souris pour simuler un touch
        if (Input.GetMouseButtonDown(0))
        {
            positionInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            return true;
        }
        return false;
#else
    // Sur mobile, on utilise les touches
    if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
    {
        Vector2 pos = Input.GetTouch(0).position;
        Debug.Log("Touch détecté à : " + pos);
    }
#endif
    }
}
