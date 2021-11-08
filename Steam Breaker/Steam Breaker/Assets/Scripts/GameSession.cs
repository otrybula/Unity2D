using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    //config
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] bool autoP = false; //autoplay for testing
    [SerializeField] int livesAddedPerLevel = 1;
    [SerializeField] int stuckHitTreshold = 10;
    [SerializeField] float pointsPerBlock = 10f;
    [SerializeField] float pointMultiplierPerHit = 0.5f;

    //object refference
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI multiplierText;
    [SerializeField] TextMeshProUGUI playerLivesText;

    //variables
    [SerializeField] float currentScore = 0f;
    [SerializeField] float currentPointMultiplier = 1f;
    [SerializeField] int playerLives = 5;
    [SerializeField] int currentLevel = 1;
    [SerializeField] int stuckCounter = 0;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        Time.timeScale = gameSpeed;
        scoreText.text = currentScore.ToString();
        multiplierText.text = "1.0";
        playerLivesText.text = playerLives.ToString();
        if (autoP == true)
        {
            FindObjectOfType<Paddle>().AutoStart();
        }
    }

    void Update()
    {
        Time.timeScale = gameSpeed;

    }

    public void AddToScore() 
    {
        currentScore = pointsPerBlock * currentPointMultiplier + currentScore;
        scoreText.text = currentScore.ToString();
    }

    public void AddToMultiplier()
    {
        currentPointMultiplier = currentPointMultiplier + pointMultiplierPerHit;
        multiplierText.text = currentPointMultiplier.ToString("F2");
    }

    public void ResetMultiplier()
    {
        currentPointMultiplier = 1f;
        multiplierText.text = currentPointMultiplier.ToString("F2");
    }

    public void DestroyItself()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }

    public void LivesCheck()
    {
        playerLives--;
        playerLivesText.text = playerLives.ToString();
        FindObjectOfType<Ball>().ResetBallPosition();
        if (playerLives == 0)
            {
            SceneManager.LoadScene("Game Lost");
        }

    }

    public void NextLevel()
    {
        currentLevel++;
        SceneManager.LoadScene("Level " + currentLevel);
    }

    public void StuckCounter()
    {
        stuckCounter++;
        if (stuckCounter == stuckHitTreshold)
        {
            FindObjectOfType<Ball>().UnstuckBall();
            ResetStuckCounter();
        }
    }

    public void ResetStuckCounter()
    {
        stuckCounter = 0;
    }

    public void SendInfo()
    {
        
        FindObjectOfType<StatDisplay>().RecieveInfo(currentScore, playerLives, livesAddedPerLevel);
        playerLives += livesAddedPerLevel;
        playerLivesText.text = playerLives.ToString();
    }
}
