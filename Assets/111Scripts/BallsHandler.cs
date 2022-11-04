using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsHandler : MonoBehaviour
{
    [SerializeField] private List<GameObject> balls = new List<GameObject>();
    [SerializeField] private List<GameObject> UiBalls = new List<GameObject>();
    private int ballsCount = 0;

    public void PlayBallAnimation(bool whiteOrBlack)
    {
        if (ballsCount < 6)
        { 
            balls[ballsCount].GetComponent<Animator>().SetTrigger(whiteOrBlack ? "White" : "Black");
            ballsCount++;
        }
    }
    public void PlayUIBallAnimation(bool whiteOrBlack)
    {
        if (ballsCount < 6)
        { 
            UiBalls[ballsCount].GetComponent<Animator>().SetTrigger(whiteOrBlack ? "White" : "Black");
        }
    }
}
