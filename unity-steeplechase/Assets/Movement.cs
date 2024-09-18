
using UnityEngine;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody rb;
    public float sideForce = 500f;
    public float jumpForce = 7f;
    public LayerMask groundLayer; // To specify what layer the ground is on
    public Transform groundCheck; // A reference to a transform used to check if the player is grounded


    void FixedUpdate()
    {
        // Movement
        if (Input.GetKey("a")) {
            rb.AddForce(-sideForce * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("d")) {
            rb.AddForce(sideForce * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("w")) {
            rb.AddForce(0, 0, sideForce * Time.deltaTime);
        }
        if (Input.GetKey("s")) {
            rb.AddForce(0, 0, -sideForce * Time.deltaTime);
        }

        // Jump logic - only jump if grounded
        if (Input.GetKeyDown(KeyCode.Space)) {
            Debug.Log("Jump!");
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

}
