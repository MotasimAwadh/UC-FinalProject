using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public bool IsTopGame;
    public bool IsRightLeftGame;
    public bool Is4BricksGame;

    public bool IsRightPlayer;
    public bool IsTopPlayer;
    public bool IsRightUpPlayer;

    bool SideGameBot;
    bool TopGameBot;
    bool Bricks4Bot;

    float speed;
    public Rigidbody2D Paddles;
    public Rigidbody2D Paddles2;
    public Rigidbody2D Ball;
    private float movement;
    private float movement2;
    public Vector3 StartPosition;
    
    void Start()
    {
        SideGameBot = false;
        TopGameBot = false;
        Bricks4Bot = false;
        StartPosition = transform.position;
        speed = 7;
    }

    public void SlowDownSpeed()
    {
        if (Is4BricksGame)
        {
            speed = 6.2f;
        }
        else
        {
            speed = 5;
        }
    }

    void Update()
    {
        //enable AI
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (IsTopGame)
            {
                TopGameBot = true;
            }
            if (IsRightLeftGame)
            {
                SideGameBot = true;
            }
            if (Is4BricksGame)
            {
                Bricks4Bot = true;
            }
        }
        //disable AI 
        if (Input.GetKeyDown(KeyCode.V))
        {
            if (IsTopGame)
            {
                TopGameBot = false;
            }
            if (IsRightLeftGame)
            {
                SideGameBot = false;
            }
            if (Is4BricksGame)
            {
                Bricks4Bot = false;
            }
        }

        // Right-Left Game
        if (IsRightLeftGame)
        {
            //Right Player Control
            if (IsRightPlayer)
            {
                movement = Input.GetAxis("Vertical");
                Paddles.velocity = new Vector2(Paddles.velocity.x, movement * speed);
            }
            //Left Player Control
            else
            {
                if(SideGameBot == false)
                {
                    movement = Input.GetAxis("Vertical2");
                    Paddles.velocity = new Vector2(Paddles.velocity.x, movement * speed);
                }
                //Bot ctrl
                if(SideGameBot == true)
                {
                    Paddles.transform.position = new Vector2(Paddles.position.x, Ball.transform.position.y);
                }
            }
        }
        //Up-Down Game
        if(IsTopGame)
        {
            //Top Player control
            if (IsTopPlayer)
            {
                movement = Input.GetAxis("Horizontal");
                Paddles.velocity = new Vector2(movement * speed, Paddles.velocity.y);
            }
            //Down Player control
            else
            {
                if(TopGameBot == false)
                {
                    movement = Input.GetAxis("Horizontal2");
                    Paddles.velocity = new Vector2(movement * speed, Paddles.velocity.y);
                }
                if(TopGameBot == true)
                {
                    Paddles.transform.position = new Vector2(Ball.transform.position.x, Paddles.position.y);
                } 
            }
        }
        // 4 paddels game
        if (Is4BricksGame)
        {
            // right-Up paddles
            if (IsRightUpPlayer)
            {
                movement = Input.GetAxis("Vertical"); 
                movement = Input.GetAxis("Horizontal");
                Paddles.velocity = new Vector2(Paddles.velocity.x, movement * speed);
                Paddles2.velocity = new Vector2(movement * speed, Paddles2.velocity.y);
            }
            // left-down paddles
            else
            {
                if (Bricks4Bot == false)
                {
                    movement = Input.GetAxis("Vertical2");
                    movement = Input.GetAxis("Horizontal2");
                    Paddles.velocity = new Vector2(Paddles.velocity.x, movement * speed);
                    Paddles2.velocity = new Vector2(movement * speed, Paddles2.velocity.y);
                }
                if(Bricks4Bot == true)
                {
                    Paddles.transform.position = new Vector2(Paddles.position.x, Ball.transform.position.y);
                    Paddles2.transform.position = new Vector2(Ball.transform.position.x, Paddles2.position.y);
                }
            }
        }
    }
    //reset
    public void reset()
    {
        Paddles.velocity = Vector2.zero;
        if (Is4BricksGame)
        {
            Paddles2.velocity = Vector2.zero;
        }
        transform.position = StartPosition;
    }
}