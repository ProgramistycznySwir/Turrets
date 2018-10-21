using UnityEngine;

public class Fire : MonoBehaviour {

    public Transform barrelEnd;
    public GameObject projectile;
    public float projectileSpeed = 500f;
    public float damage = 10f;

    private float cooldown = 0f;

    public float fireRate = 1f;

    void Update()
    {        
        Shoot();
    }    

    public void Shoot()
    {
        if (cooldown > 0)
        {
            cooldown -= fireRate * Time.deltaTime;
        }
        else if (Input.GetButton("Fire1"))
        {
            GameObject instance = Instantiate(projectile, barrelEnd.position, barrelEnd.rotation);

            instance.GetComponent<Rigidbody>().AddRelativeForce(0, 0, projectileSpeed);
            instance.GetComponent<Attack>().SetDamage(damage);

            cooldown = 1f;
        }
    }
}
