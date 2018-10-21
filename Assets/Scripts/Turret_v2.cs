using UnityEngine;

public class Turret_v2 : MonoBehaviour {

    public float elevationSpeed, rotationSpeed;
    public float elevationLimitUp, elevationLimitDown;
    public Transform targettingComputer, cannon, turretBody;
    private float targettingComputerFix, cannonFix, turretBodyFix;
    private Vector3 target;
    public bool TEST;
    

	void FixedUpdate ()
    {

        targettingComputer.LookAt(target);
        GunElevation();
        TurretRotation();
        

    }

    private void TurretRotation()
    {
        if (targettingComputer.eulerAngles.y > 90 && TEST)
        {
            targettingComputerFix = targettingComputer.eulerAngles.y - 360;
            Debug.Log("Doin' The Shit for ya");
        }
        else
        {
            targettingComputerFix = targettingComputer.eulerAngles.y;
        }

        if (turretBody.eulerAngles.y > 90 && TEST)
        {
            turretBodyFix = turretBody.eulerAngles.y - 360;
        }
        else
        {
            turretBodyFix = turretBody.eulerAngles.y;
        }


        if (targettingComputerFix - turretBodyFix <= rotationSpeed * Time.deltaTime + 0.1f)
        {
            turretBody.eulerAngles = new Vector3(turretBody.eulerAngles.x, turretBody.eulerAngles.y - rotationSpeed * Time.deltaTime, turretBody.eulerAngles.z);
        }

        if (turretBodyFix < targettingComputerFix)
        {
            turretBody.eulerAngles = new Vector3(turretBody.eulerAngles.x, turretBody.eulerAngles.y + rotationSpeed * Time.deltaTime, turretBody.eulerAngles.z);
        }
        if (turretBodyFix > targettingComputerFix)
        {
            turretBody.eulerAngles = new Vector3(turretBody.eulerAngles.x, turretBody.eulerAngles.y - rotationSpeed * Time.deltaTime, turretBody.eulerAngles.z);
        }
        //Debug.Log("Turret: " + turretBody.eulerAngles.y + " | " + turretBodyFix + "\n TC: " + targettingComputer.eulerAngles.y + " | " + targettingComputerFix);
    }

    private void GunElevation()
    {
        //Debug.Log("CannonPRE: " + cannon.eulerAngles.x);
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

        if (targettingComputerFix - cannonFix <= elevationSpeed * Time.deltaTime + 0.1f)
        {
            cannon.eulerAngles = new Vector3(cannon.eulerAngles.x - elevationSpeed * Time.deltaTime, cannon.eulerAngles.y, cannon.eulerAngles.z);
        }

        if (cannonFix < targettingComputerFix)
        {
            cannon.eulerAngles = new Vector3(cannon.eulerAngles.x + elevationSpeed * Time.deltaTime, cannon.eulerAngles.y, cannon.eulerAngles.z);
        }
        if (cannonFix > targettingComputerFix)
        {
            cannon.eulerAngles = new Vector3(cannon.eulerAngles.x - elevationSpeed * Time.deltaTime, cannon.eulerAngles.y, cannon.eulerAngles.z);
        }

        ///idk why but doesn't work :/
        //if (cannonFix <= -elevationLimitUp)
        //{
        //    Debug.Log("Doin' ma part");
        //    cannon.eulerAngles = new Vector3(cannon.eulerAngles.x + elevationSpeed * Time.deltaTime, cannon.eulerAngles.y, cannon.eulerAngles.z);
        //}

        if (cannonFix >= -elevationLimitDown)
        {
            cannon.eulerAngles = new Vector3(cannon.eulerAngles.x - elevationSpeed * Time.deltaTime, cannon.eulerAngles.y, cannon.eulerAngles.z);
        }

        //Debug.Log("Cannon: " + cannon.eulerAngles.x + " | " + cannonFix + "\n TC: " + targettingComputer.eulerAngles.x + " | " + targettingComputerFix);
    }

    public void SetTarget(Vector3 _target)
    {
        target = _target;
    }
}
