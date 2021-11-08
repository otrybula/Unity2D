using UnityEngine;

public class Paddle : MonoBehaviour
{
    //object refference
    [SerializeField] Ball ball1;

    //cached refference
    GameSession gameStatusResetPoints;

    //config
    [SerializeField] float screenWidthInUnits;
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;

    //variables
    bool autoPlay = false;


    void Start()
    {
        gameStatusResetPoints = FindObjectOfType<GameSession>();
    }

    void Update()
    {
        if(autoPlay == false)
        {
            MouseControl();
        }
        if (autoPlay == true)
        {
            AutoControl();
        }
    }

    private void MouseControl()
    {
        float mouseUnitPos = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        Vector2 paddlePosition = new Vector2(transform.position.y, transform.position.y);
        paddlePosition.x = Mathf.Clamp(mouseUnitPos, minX, maxX);
        transform.position = paddlePosition;
    }

    private void AutoControl()
    {
        Vector2 paddlePosition = new Vector2(ball1.transform.position.x, transform.position.y);
        paddlePosition.x = Mathf.Clamp(paddlePosition.x, minX, maxX);
        transform.position = paddlePosition;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameStatusResetPoints.ResetMultiplier();
    }

    public void AutoStart()
    {
        autoPlay = true;
    }
}
