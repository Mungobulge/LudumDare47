using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Transform player;
    public Transform reciever;
    public string recieverName;

    private void Teleport(Transform transformObj)
    {
        Vector3 portalToPlayer = transformObj.position - transform.position;
        float dotProduct = Vector3.Dot(transform.up, portalToPlayer);

        float rotationDiff = -Quaternion.Angle(transform.rotation, reciever.rotation);
        rotationDiff += 360;
        transformObj.Rotate(Vector3.up, rotationDiff);

        Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer;
        transformObj.position = reciever.position + positionOffset;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!ValidTag(other.tag))
        {
            return;
        }

        var teleportPassanger = other.GetComponent<TeleporterPassanger>();

        if (teleportPassanger != null && teleportPassanger.lastTeleportName != recieverName)
        {
            teleportPassanger.RefreshPartcileSystem();
            teleportPassanger.lastTeleportName = gameObject.name;
            Teleport(teleportPassanger.transform);
        }
    }

    bool ValidTag(string tag)
    {
        return tag == "Player" || tag == "Asteroid";
    }
}
