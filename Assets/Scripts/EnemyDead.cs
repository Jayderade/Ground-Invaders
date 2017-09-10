using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class EnemyDead : MonoBehaviour {

   
    public float waitTime = 4f;
    public float extraWaitTime = 2f;
    
    public Image bGround;


    public GameObject youWin;
    public GameObject gameOver;
    
    
    

    

    
    private bool timerActiveWin;

    public int aliveCount;
    

    public float timerWin;


    // Use this for initialization
    void Start()
    {

        
        timerActiveWin = false;

        timerWin = 0;

        aliveCount = GameObject.FindGameObjectsWithTag("Alive").Length;
        
    }
        

       



    // Update is called once per frame
    void Update()
    {
        aliveCount = GameObject.FindGameObjectsWithTag("Alive").Length;

        if (aliveCount == 2)
        {            
            timerActiveWin = true;            
        }

        if (timerActiveWin)
        {
            timerWin += 1f * Time.deltaTime;
        }

        if (timerWin > waitTime)
        {
            Debug.Log("works");
            gameOver.SetActive(true);
            bGround.enabled = true;
        }

        if (timerWin > extraWaitTime)
        {
            gameOver.SetActive(false);
            youWin.SetActive(true);
        }
    }  
   
    
}
