using UnityEngine;
using UnityEngine.UI;
using Unity.Mathematics;

public class highScoreScript : MonoBehaviour
{
    public Text highScoreText, currentScore;
    public GameObject Player;
    float newScore, oldScore;
    void Update()
    {
        if (Player == null)
        {
            return;
        }
        else
        {
            oldScore = newScore;
            newScore = math.round(Player.transform.position.y); ;
            if (oldScore > newScore)
            {
                return;
            }
            else
            {
                currentScore.text = newScore.ToString();
            }
        }
    }
}
