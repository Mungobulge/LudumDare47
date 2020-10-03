using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float thrust = 1.0f;

    private Rigidbody2D rb2D;

    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        rb2D.AddForce(transform.right * thrust);
    }
}
