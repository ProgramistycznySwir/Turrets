using UnityEngine;

public class REPORT : MonoBehaviour {


    public Transform marker;
	
	// Update is called once per frame
	void Update () {
        Debug.Log(transform.rotation.eulerAngles.y);
        transform.LookAt(marker);
	}
}
