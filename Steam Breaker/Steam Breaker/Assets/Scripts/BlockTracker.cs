using UnityEngine;

public class BlockTracker : MonoBehaviour
{
    [SerializeField] int blockCount; 

    public void BlockCounter()
    {
        blockCount++;
    }

    public void BlockDestroyed()
    {
        blockCount--;
        if (blockCount == 0)
        {
            FindObjectOfType<GameSession>().ResetStuckCounter();
            FindObjectOfType<GameSession>().ResetMultiplier();
            FindObjectOfType<SceneLoader>().LevelTransition();
        }
    }
}
