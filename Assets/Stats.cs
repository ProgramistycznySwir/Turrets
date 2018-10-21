using UnityEngine;

public class Stats : MonoBehaviour {

    public float maxHitPoints = 100f;
    private float hitPoints;

    private void Start()
    {
        hitPoints = maxHitPoints;
    }

    public bool TakeDamage(float dmg)
    {
        hitPoints -= dmg;
        if (hitPoints <= 0f)
        {
            return true;
        }
        else return false;
    }
}
