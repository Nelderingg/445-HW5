using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayer : MonoBehaviour
{
    public Transform player; // Reference to the player object
    public Vector3 respawnPosition; // Position to reset the player to

    // Trigger event for player collision
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Check if the colliding object is the player
        {
            // Reset player's position to the respawn point
            player.position = respawnPosition;
        }
    }
}

