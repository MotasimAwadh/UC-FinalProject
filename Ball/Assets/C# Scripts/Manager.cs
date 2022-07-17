using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{

    public bool IsTopGame;
    public bool IsSideGame;
    public bool Is4bricksGame;
    
    [Header("Ball")]
    public GameObject ball;

    // Right-Left Game

    [Header("Right_Player")]
    public GameObject Right_Player_Paddle;
    public GameObject Right_Player_Goal;

    [Header("Left_Player")]
    public GameObject Left_Player_Paddle;
    public GameObject Left_Player_Goal;

    // top down
    [Header("Top_Player")]
    public GameObject Top_Player_Paddle;
    public GameObject Top_Player_Goal;

    [Header("Down_Player")]
    public GameObject Down_PLayer_Paddle;
    public GameObject Down_PLayer_Goal;

    //4 paddles
    [Header("Right_Up_Player")]
    public GameObject RightPaddle;
    public GameObject UpPaddle;
    public GameObject RightGoal;
    public GameObject UpGoal;

    [Header("Left_Down_Player")]
    public GameObject LeftPaddle;
    public GameObject DownPaddle;
    public GameObject LeftGoal;
    public GameObject DownGoal;

    [Header("Score UI")]
    public GameObject Right_Player_Text;
    public GameObject Left_Player_Text;
    public GameObject Top_Player_Text;
    public GameObject Down_Palyer_Text;
    public GameObject RightUp_Text;
    public GameObject LeftDown_Text;

    //=======================
    //=======================

    //right-left
    private int Right_Player_Score;
    private int Left_Player_Score;
    //up-down
    private int Top_Player_Score;
    private int Down_PLayer_Score;
    //4 paddles
    private int RightUpPlayerScore;
    private int LeftDownPlayerScore;

    // Right-Left game Score logic

    public void RPScored() // right player scored
    {
        Right_Player_Score++;
        Right_Player_Text.GetComponent<TextMeshProUGUI>().text = Right_Player_Score.ToString();
        ResetPosition();
    }

    public void LPScored() // left player scored
    {
        Left_Player_Score++;
        Left_Player_Text.GetComponent<TextMeshProUGUI>().text = Left_Player_Score.ToString();
        ResetPosition();
    }
    // up-down game score logic
    public void TPScored() // top (Up) player scored
    {
        Top_Player_Score++;
        Top_Player_Text.GetComponent<TextMeshProUGUI>().text = Top_Player_Score.ToString();
        ResetPosition();
    }
    public void DPScored() // bottom (down) player scored
    {
        Down_PLayer_Score++;
        Down_Palyer_Text.GetComponent<TextMeshProUGUI>().text = Down_PLayer_Score.ToString();
        ResetPosition();
    }

    //4 paddles game score logic
    public void RightUpPlayerScored() // right player (righ-up paddles) scored
    {
        RightUpPlayerScore++;
        RightUp_Text.GetComponent<TextMeshProUGUI>().text = RightUpPlayerScore.ToString();
        ResetPosition();
    }

    public void LeftDownPlayerScored() // left player (left-down paddles) scored
    {
        LeftDownPlayerScore++;
        LeftDown_Text.GetComponent<TextMeshProUGUI>().text = LeftDownPlayerScore.ToString();
        ResetPosition();
    }

    // reset paddles & ball position
    private void ResetPosition()
    {
        ball.GetComponent<Ball>().reset();
        if (IsSideGame)
        {
            Right_Player_Paddle.GetComponent<Paddle>().reset();
            Left_Player_Paddle.GetComponent<Paddle>().reset();
        }
        if (IsTopGame)
        {
            Top_Player_Paddle.GetComponent <Paddle>().reset();
            Down_PLayer_Paddle.GetComponent<Paddle>().reset();
        }
        if (Is4bricksGame)
        {
            RightPaddle.GetComponent<Paddle>().reset();
            UpPaddle.GetComponent<Paddle>().reset();
            LeftPaddle.GetComponent<Paddle>().reset();
            DownPaddle.GetComponent<Paddle>().reset();
        }
    }

    private void Update()
    {
        if (IsSideGame)
        {
            if(Right_Player_Score == 10 || Left_Player_Score == 10)
            {
                ball.GetComponent<Ball>().SpeedUpBall();
            }
            if(Right_Player_Score == 20 || Left_Player_Score == 20)
            {
                Right_Player_Paddle.GetComponent<Paddle>().SlowDownSpeed();
                Left_Player_Paddle.GetComponent<Paddle>().SlowDownSpeed();
            }
        }
        if (IsTopGame)
        {
            if(Top_Player_Score == 10 || Down_PLayer_Score == 10)
            {
                ball.GetComponent<Ball>().SpeedUpBall();
            }
            if(Top_Player_Score == 20 || Down_PLayer_Score == 20)
            {
                Top_Player_Paddle.GetComponent<Paddle>().SlowDownSpeed();
                Down_PLayer_Paddle.GetComponent <Paddle>().SlowDownSpeed();
            }
        }
        if (Is4bricksGame)
        {
            if(RightUpPlayerScore == 10 || LeftDownPlayerScore == 10)
            {
                ball.GetComponent<Ball>().SpeedUpBall();
            }
            if(RightUpPlayerScore == 20 || LeftDownPlayerScore == 20)
            {
                LeftPaddle.GetComponent<Paddle>().SlowDownSpeed();
                RightPaddle.GetComponent<Paddle>().SlowDownSpeed();
                UpPaddle.GetComponent<Paddle>().SlowDownSpeed();
                DownPaddle.GetComponent<Paddle>().SlowDownSpeed();
            }
        }
        //you win scene
        if (IsSideGame)
        {
            if(Right_Player_Score == 30 || Left_Player_Score == 30)
            {
                SceneManager.LoadScene("YouWin");
            }
        }
        if (IsTopGame)
        {
            if(Top_Player_Score == 30 || Down_PLayer_Score == 30)
            {
                SceneManager.LoadScene("YouWin");
            }
        }
        if (Is4bricksGame)
        {
            if(RightUpPlayerScore == 30 || LeftDownPlayerScore == 30)
            {
                SceneManager.LoadScene("YouWin");
            }
        }
    }
}