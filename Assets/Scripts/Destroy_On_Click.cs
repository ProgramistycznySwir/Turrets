using UnityEngine;

public class Destroy_On_Click : MonoBehaviour {

    public KeyCode key;

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(key))
        {
            Destroy(gameObject);
        }
	}
}
