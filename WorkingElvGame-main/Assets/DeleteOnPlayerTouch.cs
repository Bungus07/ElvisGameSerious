using UnityEngine;

public class DeleteAndLogOnPlayerTouch : MonoBehaviour
{
    // This method is called when the object collides with another object
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object is tagged with "Player1" or "Player2"
        if (collision.gameObject.CompareTag("Player1") || collision.gameObject.CompareTag("Player2"))
        {
            // Log a message to the console
            Debug.Log("Touched Player1 or Player2!");

            // Destroy the object this script is attached to
            GameObject.Destroy(gameObject, 1);
        }
    }
}