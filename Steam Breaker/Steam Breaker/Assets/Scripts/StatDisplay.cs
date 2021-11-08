using UnityEngine;
using TMPro;

public class StatDisplay : MonoBehaviour
{
    //object refference
    [SerializeField] TextMeshProUGUI scoreDisplay;
    [SerializeField] TextMeshProUGUI livesDisplay;

    private void Start()
    {
        FindObjectOfType<GameSession>().SendInfo();
    }

    public void RecieveInfo(float scoreValue, int livesValue, int livesAdded)
    {
        scoreDisplay.text = scoreValue.ToString();
        if (livesAdded == 0)
        {
            livesDisplay.text = livesValue.ToString();
        }
       else if (livesAdded > 0)
        {
            livesDisplay.text = livesValue.ToString() + " + " + livesAdded;
        }
        else
        {
            livesDisplay.text = livesValue.ToString() + " - " + livesAdded;
        }
    }
}
