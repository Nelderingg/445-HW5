using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene management

public class Door : MonoBehaviour
{
    // Specify the name of the scene to load
    public string sceneToLoad;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Check if the player collided with the door
        {
            SceneManager.LoadScene(sceneToLoad); // Load the specified scene
        }
    }
}
