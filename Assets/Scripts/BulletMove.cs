using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 0.5f;
    // Vector3 fwd = Vector3.forward;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        //transform.Translate(Vector3.forward * speed *Time.deltaTime);
        rb.AddForce(0f, 0f, speed * Time.deltaTime);
    }
}
