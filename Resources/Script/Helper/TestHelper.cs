using UnityEngine;

public class TestHelper : MonoBehaviour
{
    private static TestHelper _instance;
    public static TestHelper Instance
    {
        get
        {
            if (_instance == null)
                _instance = GameObject.Find("TestHelper").GetComponent<TestHelper>();
            return _instance;
        }
    }

    public bool Active;

    public bool InfiniteGold;

    public bool FrappeInstaKill, AuraInstaKill;

    public int LevelStarter = -1;

    public int WantedMeter = -1;

    public void Update()
    {
        if (!Active) return;

        if (InfiniteGold) Chasseur.Instance.Or = new GN( float.MaxValue);
    }
}
