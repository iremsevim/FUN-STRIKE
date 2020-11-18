using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{// Start is called before the first frame update
    public static GameManager instance;
    public bool IsGameStarted = false;
    public Vector3 ballfirspos;

    private void Awake()
    {
        instance = this;
    }
    void Start()
        
    {
        ballfirspos = BallController.instance.transform.position;
        IsGameStarted = true;
        ShowADS.instance.AddAD();
      
    }


    public void GameOver()
    {
        IsGameStarted = false;
        ShowADS.instance.ShowAd();
        BallController.instance.movementspeed = 0;


    }
    public void Restart()
    {
        CreaterPlan.instance.Start();      
        BallController.instance.transform.position = ballfirspos;
        IsGameStarted = true;

    }
}
