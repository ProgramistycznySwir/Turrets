using UnityEngine;

public class DriveHover : MonoBehaviour {

    private Vector3 target;
    public Transform entityModel;
    public float speed = 10f;
    public int currentTargetIndex = 1;
    public float maxDislocationOfTarget = 5f;

    // Use this for initialization
    void Start()
    {
        target = NavigationOrganizer.GetWaypointH(currentTargetIndex).position;
        TargetRandomDislocation();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target - transform.position;
        entityModel.LookAt(target);
        transform.Translate(dir.normalized * speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target) <= 1f)
        {
            currentTargetIndex++;
            if (currentTargetIndex > NavigationOrganizer.lastWaypointH - 1)
            {
                Destroy(gameObject);
                return;
            }
            target = NavigationOrganizer.GetWaypointH(currentTargetIndex).position;
            TargetRandomDislocation();
        }
    }

    void TargetRandomDislocation()
    {
        target += new Vector3(Random.Range(-maxDislocationOfTarget, maxDislocationOfTarget), 0f, Random.Range(-maxDislocationOfTarget, maxDislocationOfTarget));
    }
}
