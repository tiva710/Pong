using System.Linq.Expressions;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int scoreLeft = 0;
    public int scoreRight = 0;
    public int winScore = 11;
    private GameObject currentBall;
    
    public TextMeshProUGUI LeftScore; 
    public TextMeshProUGUI RightScore;
    public TextMeshProUGUI WinText;

    public Color color1 = Color.black;
    public Color color2 = Color.gray;
    public bool isColor1 = true;

    public Camera mainCamera;

    private void ChangeBackgroundColor()
    {
        isColor1 = !isColor1;
        mainCamera.backgroundColor = isColor1 ? color1 : color2; 
    }
    private void UpdateScoreText()
    {
        LeftScore.text = "Left Score: " + scoreLeft;
        RightScore.text = "Right Score: " + scoreRight;
        
        //Random color
        LeftScore.color = GetRandomColor();
        RightScore.color = GetRandomColor();
    }
    
    private Color GetRandomColor()
    {
        return new Color(
            Random.Range(0f, 1f), 
            Random.Range(0f, 1f), 
            Random.Range(0f, 1f)
        );
    }
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
        
        UpdateScoreText();
        Debug.Log($"Score Update - Left: {scoreLeft}, Right: {scoreRight}");

        WinText.enabled = false; 

        if (scoreLeft >= winScore || scoreRight >= winScore)
        {
            string winner = scoreLeft >= winScore ? "Left" : "Right";
            DisplayWinner(winner);
            Debug.Log($"Game Over, {winner} Paddle Wins!");
            scoreLeft = 0;
            scoreRight = 0;
            WinText.enabled = true; 
        }
        
        ChangeBackgroundColor();
    }

    private void DisplayWinner(string winnerSide)
    {
        WinText.text = winnerSide + " Player Wins!!";
    }
}
