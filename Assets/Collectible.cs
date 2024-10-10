using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public enum CollectibleType { Type1, Type2 }  // Enum to differentiate collectible types
    public CollectibleType collectibleType;       // Type of this collectible

    public float rotationSpeed;                   // Rotation speed for visual effect
    public GameObject onCollectEffect;            // Particle effect when collected
    private CollectibleManager collectibleManager;

    void Start()
    {
        collectibleManager = FindObjectOfType<CollectibleManager>();
    }

    void Update()
    {
        // Rotate the collectible for visual effect
        transform.Rotate(0, rotationSpeed, 0); 
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Destroy the collectible
            Destroy(gameObject);

            // Instantiate the particle effect
            //Instantiate(onCollectEffect, transform.position, transform.rotation);

            // Increment the collectible counter based on type
            if (collectibleType == CollectibleType.Type1)
            {
                collectibleManager.IncrementType1Count();
            }
            else if (collectibleType == CollectibleType.Type2)
            {
                collectibleManager.IncrementType2Count();
            }
        }
    }
}
