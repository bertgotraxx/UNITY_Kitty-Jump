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
        // If player object doesn't exists, then do nothing
        if (Player == null)
        {
            return;
        }
        // Else update player's score
        else
        {
            oldScore = newScore;
            // Since score is basically a player's height and it's a float, it needs to be rounded first
            // before putting it on screen, to avoid it breaking the boundaries
            newScore = math.round(Player.transform.position.y); ;
            if (oldScore > newScore)
            {
                return;
            }
            // If new score is bigger than old score, then put it on screen
            else
            {
                currentScore.text = newScore.ToString();
            }
        }
    }
}
