using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kart : MonoBehaviour
{
    public float speed;
    public float max_speed;
    public float turnSpeed;
    public float gravityMultiplier;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Accelerate();
        Turn();
        Fall();
        max_speed = 15;

    }

    void Accelerate()
    {
        Vector3 locVel = transform.InverseTransformDirection(rb.velocity);
        locVel = new Vector3(0, locVel.y, locVel.z);
        rb.velocity = transform.TransformDirection(locVel);
        if (locVel.z < max_speed)
        {

            if (Input.GetKey(KeyCode.W))
            {
                rb.AddRelativeForce(new Vector3(Vector3.forward.x, 0, Vector3.forward.z) * speed * 10);
                rb.drag = 0;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                rb.AddRelativeForce(-new Vector3(Vector3.forward.x, 0, Vector3.forward.z) * speed * 10);
                rb.drag = 5;
            }
        }
    }

    void Turn()
    {
        if (Input.GetKey(KeyCode.A))
        {
            if(rb.angularVelocity.y > -2)
            {
                rb.AddTorque(-transform.up * turnSpeed * 10);
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (rb.angularVelocity.y < 2)
            {
                rb.AddTorque(transform.up * turnSpeed * 10);
            }
        }
    }

    void Fall()
    {
        rb.AddForce(Vector3.down * gravityMultiplier * 10);
    }
}