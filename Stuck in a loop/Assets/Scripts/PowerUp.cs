using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    //public GameObject pickupEffect;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup(other);
        }
    }
    void Pickup(Collider2D player)
    {
          player.GetComponent<PlayerController>().isPowerUp = true;
    


        //Instantiate(pickupEffect, transform.position, transform.rotation);

        //isPowerUp = true;
        Destroy(gameObject);
    }

}
