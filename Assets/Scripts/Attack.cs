using UnityEngine;

public class Attack : MonoBehaviour {

    private float damage = 50f;

    private void OnTriggerEnter(Collider other)
    {
        DealDamage(other.gameObject);
        Destroy(gameObject);
    }

    public void DealDamage(GameObject go)
    {
        if (gameObject.GetComponent<Stats>().TakeDamage(damage))
        {
            Destroy(go);
        }
    }

    public void SetDamage(float dmg)
    {
        damage = dmg;
    }
}
