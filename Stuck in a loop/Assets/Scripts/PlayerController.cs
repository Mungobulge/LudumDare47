using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private float thrust = 10.0f;

    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        transform.position = new Vector3(0.0f, 0.0f, 0.0f);
    }

    void FixedUpdate()
    {
        rb2D.AddForce(transform.right * thrust);
    }
}
