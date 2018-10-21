using UnityEngine;

public class TurretRotation_Instant : MonoBehaviour {

    
    public float elevationLimitUp, elevationLimitDown;
    public Transform targettingComputer, cannon, turretBody;
    private float targettingComputerFix, cannonFix;
    private Vector3 target;

    public float range = 75f;


    void FixedUpdate()
    {
        targettingComputer.LookAt(target);
        GunElevation();
        TurretRotation();
    }

    ///

    private void TurretRotation()
    {
        turretBody.eulerAngles = new Vector3(0f, targettingComputer.eulerAngles.y, 0f);
    }

    private void GunElevation()
    {
        if (targettingComputer.eulerAngles.x > 90)
        {
            targettingComputerFix = targettingComputer.eulerAngles.x - 360;
        }
        else
        {
            targettingComputerFix = targettingComputer.eulerAngles.x;
        }

        if (cannon.eulerAngles.x > 90)
        {
            cannonFix = cannon.eulerAngles.x - 360;
        }
        else
        {
            cannonFix = cannon.eulerAngles.x;
        }

        //cannon.eulerAngles = new Vector3(targettingComputer.eulerAngles.x, cannon.eulerAngles.y, cannon.eulerAngles.z);

        if (targettingComputerFix < -elevationLimitUp)
        {
            cannon.eulerAngles = new Vector3(-elevationLimitUp, cannon.eulerAngles.y, cannon.eulerAngles.z);
        }
        else if (targettingComputerFix > -elevationLimitDown)
        {
            cannon.eulerAngles = new Vector3(-elevationLimitDown, cannon.eulerAngles.y, cannon.eulerAngles.z);
        }
        else
        {
            cannon.eulerAngles = new Vector3(targettingComputer.eulerAngles.x, cannon.eulerAngles.y, cannon.eulerAngles.z);
        }
    }

    public void SetTarget(Vector3 _target)
    {
        target = _target;
    }

    public void TargetNearestEnemy()
    {
        float distance;
        foreach(GameObject enemy in TargetsIndexer.enemies)
        {
            distance = Vector3.Distance(targettingComputer.position, enemy.transform.GetChild(0).transform.position);
            if(distance <= range)
            {

            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(targettingComputer.position, range);
    }
}
