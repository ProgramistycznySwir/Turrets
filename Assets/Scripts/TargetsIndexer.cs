using UnityEngine;

public class TargetsIndexer : MonoBehaviour {

    public static GameObject[] enemies;
    public static string enemyTag;
    public float indexDelays = 0.5f;

    private void Start()
    {
        InvokeRepeating("IndexTargets", 0f, indexDelays);
    }

    static void IndexTargets()
    {
        enemies = GameObject.FindGameObjectsWithTag(enemyTag);
    }
}
