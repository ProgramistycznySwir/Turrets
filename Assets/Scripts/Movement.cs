using UnityEngine;

public class Movement : MonoBehaviour{

    public float movementSpeed = 100f;
    public float jumpForce = 200f;

    public Rigidbody rigidbody;

    public float dragOnGround = 20f, dragInAir = 0f;

    public KeyCode jump;

    void Start()
    {
        rigidbody.drag = 0f;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag == "Enemy" || collision.collider.tag == "MovingSurface")
        {
            if (Input.GetKeyDown(jump))
            {
                rigidbody.AddForce(0f, jumpForce, 0f);
            }
            rigidbody.AddRelativeForce(0f, 0f, Input.GetAxis("Vertical") * 100f);
            rigidbody.AddRelativeForce(Input.GetAxis("Horizontal") * 100f, 0f, 0f);

            rigidbody.drag = dragOnGround;
        }
    }
    
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Enemy" || collision.collider.tag == "MovingSurface")
        {
            rigidbody.drag = dragInAir;
        }
        
    }


}
