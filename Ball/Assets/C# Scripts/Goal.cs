using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public bool IsTopDownGame;
    public bool IsRightLeftGame;
    public bool Is4PaddlesGame;

    public bool IsRPGoal;
    public bool IsTopPlayerGoal;
    public bool IsUpRightPlayerGoal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsRightLeftGame)
        {
            if (collision.gameObject.CompareTag("Ball"))
            {
                if (!IsRPGoal)
                {
                    GameObject.Find("GameManager").GetComponent<Manager>().RPScored();
                }
                else
                {
                    GameObject.Find("GameManager").GetComponent<Manager>().LPScored();
                }
            }
        }

        if (IsTopDownGame)
        {
            if (collision.gameObject.CompareTag("Ball"))
            {
                if (!IsTopPlayerGoal)
                {
                    GameObject.Find("TopGameManager").GetComponent<Manager>().TPScored();
                }
                else
                {
                    GameObject.Find("TopGameManager").GetComponent<Manager>().DPScored();
                }
            }
        }
        if (Is4PaddlesGame)
        {
            if (collision.gameObject.CompareTag("Ball"))
            {
                if (IsUpRightPlayerGoal)
                {
                    GameObject.Find("4PaddlesManager").GetComponent<Manager>().RightUpPlayerScored();
                }
                else
                {
                    GameObject.Find("4PaddlesManager").GetComponent<Manager>().LeftDownPlayerScored();
                }
            }
        }

    }
}