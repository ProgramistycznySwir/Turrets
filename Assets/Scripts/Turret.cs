using UnityEngine;

public class Turret : MonoBehaviour {

    private Vector3 target;
    public GameObject targetMarker;
    public GameObject projectile;
    public Transform barrelEnd;
    public float projectileSpeed;

	// Update is called once per frame
	void Update ()
    {
        transform.LookAt(target);
        Fire();
    }

    public void SetTarget(Vector3 _target)
    {
        target = _target;
    }

    public void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject instance = Instantiate(projectile, barrelEnd.position, barrelEnd.rotation);
            instance.GetComponent<Rigidbody>().AddRelativeForce( 0, 0, projectileSpeed);
        }
    }
}
