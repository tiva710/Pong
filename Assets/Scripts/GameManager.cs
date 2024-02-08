using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int scoreLeft = 0;
    public int scoreRight = 0;
    public int winScore = 11;
    private GameObject currentBall;

    public void ScoreGoal(string side)
    {
        if (side == "Left")
        {
            scoreLeft++;
        }
        else
        {
            scoreRight++;
        }
        
        Debug.Log($"Score Update - Left: {scoreLeft}, Right: {scoreRight}");

        if (scoreLeft >= winScore || scoreRight >= winScore)
        {
            string winner = scoreLeft >= winScore ? "Left" : "Right";
            Debug.Log($"Game Over, {winner} Paddle Wins!");
            scoreLeft = 0;
            scoreRight = 0;
        }
    }
    
}
