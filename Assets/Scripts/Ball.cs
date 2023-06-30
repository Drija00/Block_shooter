using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    float speed = 20f;
    Rigidbody rigidbody;
    Vector3 velocity;
    Renderer renderer;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        renderer = GetComponent<Renderer>();
        Invoke("Launch",0.5f);
    }

    void Launch() {
        rigidbody.velocity = Vector3.up * speed;
    }

    void FixedUpdate()
    {
        rigidbody.velocity = rigidbody.velocity.normalized * speed;
        velocity = rigidbody.velocity;

        if (!renderer.isVisible) {
            GameManager.Instance.Balls--;
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        rigidbody.velocity = Vector3.Reflect(velocity, collision.contacts[0].normal);
    }
}
