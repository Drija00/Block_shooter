using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    float speed = 20f;
    Rigidbody rigidbody;
    Vector3 velocity;
    

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = Vector3.down * speed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigidbody.velocity = rigidbody.velocity.normalized * speed;
        velocity = rigidbody.velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        rigidbody.velocity = Vector3.Reflect(velocity, collision.contacts[0].normal);
    }
}
