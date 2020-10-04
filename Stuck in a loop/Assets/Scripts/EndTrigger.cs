using UnityEngine;

public class EndTrigger : MonoBehaviour
{

    public GameManager gameManager;

    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "Player")
        {
            gameManager.CompleteLevel();
        }
    }

}
