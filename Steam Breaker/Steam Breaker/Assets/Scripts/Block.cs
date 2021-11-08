using UnityEngine;

public class Block : MonoBehaviour
{
    //config
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] int maxHits=2;
    [SerializeField] Sprite hitSprite;

    BlockTracker blockTracker;
    GameSession gameStatus;

    //state variables
    [SerializeField] int timesHit; //debug

    private void Start()
    {
        blockTracker = FindObjectOfType<BlockTracker>();
        if (tag == "Breakable")
        {
            
            blockTracker.BlockCounter();
        }
        gameStatus = FindObjectOfType<GameSession>();
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            HandleHit();
            gameStatus.ResetStuckCounter();
        }
       else
        {
            ShowNextHitSprite();
        }
    }

    private void HandleHit()
    {
        timesHit++;
        ScoreHandler();
        if (timesHit == maxHits)
        {
            BlockDestruction();
            TriggerSparklesVFX();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        string sprName = GetComponent<SpriteRenderer>().sprite.name;
        if (timesHit == 1)
        {   
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Hit Sprites/d" + sprName);
        }
        if (timesHit == 2)
        {
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Hit Sprites/d" + sprName);
        }

    }

    private void BlockDestruction()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        Destroy(gameObject);
        blockTracker.BlockDestroyed();

    }

    private void ScoreHandler()
    {
        gameStatus.AddToScore();
        gameStatus.AddToMultiplier();
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
   
}
