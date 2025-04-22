using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalTeleporterScript : MonoBehaviour
{
    public Transform player; // Reference to the player object
    public Transform reciever; // Reference to the destination object

    private bool playerIsOverlapping = false;

    // Update is called once per frame
    void Update()
    {
        if (playerIsOverlapping)
        {
            Vector3 portalToPlayer = player.position - transform.position;
            float dotProduct = Vector3.Dot(transform.up, portalToPlayer);

            Debug.Log("Dot Product: " + dotProduct);

            // If this is true, the player has moved across the portal
            if (dotProduct < 0f)
            {
                Debug.Log("Teleporting player...");
                //teleport the player to the receiver
                float rotationDiff = -Quaternion.Angle(transform.rotation, reciever.rotation);
                rotationDiff += 180;
                player.Rotate(Vector3.up, rotationDiff);

                Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer;
                player.position = reciever.position + positionOffset;

                //playerIsOverlapping = false;
            }

        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player is overlapping with the portal.");

            playerIsOverlapping = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player has exited the portal.");

            playerIsOverlapping = false;
        }
    }

}
