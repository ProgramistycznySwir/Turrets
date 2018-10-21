using UnityEngine;

public class Targeting : MonoBehaviour {

    public RaycastHit ray;
    public Turret[] turrets = new Turret[2];
    public Turret_v2[] turret = new Turret_v2[2];
    public TurretRotation_Instant[] turretI = new TurretRotation_Instant[2];
    public GameObject hit;
    Quaternion q;
    public bool drawMarkers;
    public KeyCode drawMarkersToggle;

    // Update is called once per frame
    void Update ()
    {
        Physics.Raycast(transform.position, transform.forward, out ray, 1000f);
        for (int a = 0; a < turrets.Length; a++)
        {
            turrets[a].SetTarget(ray.point);
        }
        for (int a = 0; a < turret.Length; a++)
        {
            turret[a].SetTarget(ray.point);
        }
        for (int a = 0; a < turretI.Length; a++)
        {
            turretI[a].SetTarget(ray.point);
        }

        if (Input.GetKeyDown(drawMarkersToggle))
        {
            drawMarkers = !drawMarkers;
        }

        if (Input.GetMouseButton(0)&&drawMarkers)
        {
            q.eulerAngles = Vector3.zero;
            GameObject instance = Instantiate(hit, ray.point, q);
        }
    }
}
