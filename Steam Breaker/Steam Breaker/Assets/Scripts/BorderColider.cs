using UnityEngine;

public class BorderColider : MonoBehaviour
{
    //cached refference
    GameSession borderHitCounter;
    
        void Start()
    {
        borderHitCounter = FindObjectOfType<GameSession>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        borderHitCounter.StuckCounter();
    }
}
