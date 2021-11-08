using UnityEngine;

public class LoseCollider : MonoBehaviour
{
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<GameSession>().ResetStuckCounter();
        FindObjectOfType<GameSession>().LivesCheck();
    }
}
