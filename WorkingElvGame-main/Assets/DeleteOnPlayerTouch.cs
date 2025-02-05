using UnityEngine;

public class DeleteAndLogOnPlayerTouch : MonoBehaviour
{
    public GameObject Player1Health;
    public GameObject Player2Health;
    // This method is called when the object collides with another object
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object is tagged with "Player1" or "Player2"
        if (collision.gameObject.CompareTag("Player1"))
        {
            // Log a message to the console
            Debug.Log("Touched Player1!");
            Player1Health.GetComponent<Player1Health>().TakeDamage(20);
            // Destroy the object this script is attached to
            GameObject.Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Player2"))
        {
            Debug.Log("Touched Player2!");
            Player2Health.GetComponent<Player2Health>().TakeDamage(10);
            GameObject.Destroy(gameObject);
        }
    }
}