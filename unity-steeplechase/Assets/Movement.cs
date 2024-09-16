using System.Threading;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody rb;
    public float zForce = 10f;
    public float sideForce = 10f;
    public float jumpForce = 40f;
    // Start is called before the first frame update
    void Start()
    {
        rb.AddForce(0, 200, 500);
        Debug.LogWarning("Movement Start Test");
    }

    // Update is called once per frame
    void FixedUpdate()  // used when work with physics
    {
        // rb.AddForce(0, 0, zForce + Time.deltaTime);  // ensure that the updated happens in the same interval
        // // rb.AddForce(0, 0, 200);

        if (Input.GetKey("a")) {
            rb.AddForce(-sideForce + Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("d")) {
            rb.AddForce(sideForce + Time.deltaTime, 0, 0);
        }

        if (Input.GetKey("w")) {
            rb.AddForce(0, 0, sideForce + Time.deltaTime);
        }
        if (Input.GetKey("s")) {
            rb.AddForce(0, 0, -sideForce + Time.deltaTime);
        }
        if (Input.GetButtonDown("Jump")) {
            rb.AddForce(Vector3.up * jumpForce);
        }
        
    }
}
