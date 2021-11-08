using UnityEngine;

public class Ball : MonoBehaviour
{
    //config
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 2f;
    [SerializeField] float ballRandomness;

    //object refference
    [SerializeField] Paddle paddle1;
    [SerializeField] AudioClip[] ballSounds;

    //cached refference
    AudioSource myAudioSource;
    Rigidbody2D myRigBody2D;

    //variables
    Vector2 paddleToBallVector;
    bool hasBeenLaunched = false;

    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigBody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!hasBeenLaunched)
        {
            LockBallToPaddle();
            LaunchBallOnClick();
        }
        myRigBody2D.velocity = 15f * (myRigBody2D.velocity.normalized);
    }

    private void LaunchBallOnClick()
    {
        if (Input.GetMouseButtonUp(0))
        {
            hasBeenLaunched = true;
            myRigBody2D.velocity = new Vector2(xPush, yPush);
        }
    }

    private void LockBallToPaddle()
    {
        if (hasBeenLaunched == false)
        {
            Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
            transform.position = paddlePos + paddleToBallVector;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(Random.Range(0f - ballRandomness, ballRandomness), Random.Range(0f - ballRandomness, ballRandomness));
        if (hasBeenLaunched)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
            myRigBody2D.velocity += velocityTweak;
        }

    }

    public void ResetBallPosition()
    {
        hasBeenLaunched = false;
    }

    public void UnstuckBall()
    {
        Vector2 unstuckTweak = new Vector2(0, 2f);
        myRigBody2D.velocity += unstuckTweak;
    }
}
