using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public PlayerController playerController;
    public Transform player;
    public Transform reciever;
    public string recieverName;

    private bool playerIsOverlapping = false;
    private bool IsTrigger;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerIsOverlapping)
        {
            Vector3 portalToPlayer = player.position - transform.position;
            float dotProduct = Vector3.Dot(transform.up, portalToPlayer);


            float rotationDiff = -Quaternion.Angle(transform.rotation, reciever.rotation);
            rotationDiff += 180;
            player.Rotate(Vector3.up, rotationDiff);

            Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer;
            player.position = reciever.position + positionOffset;

            playerIsOverlapping = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && playerController.lastTeleportName != recieverName)
        {
            playerController.lastTeleportName = gameObject.name;
            playerIsOverlapping = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
           playerIsOverlapping = false;
        }
    }
}
