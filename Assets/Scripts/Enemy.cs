using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{    
    public float movementSpeed = .1f;



    public GameObject youWin;
    public GameObject gameOver;
    public GameObject explode;
    public GameObject die;
    public GameObject enemy;
   

    private int alive;

    public Collider2D enemyCol;  
            
    private bool moving;    
    private bool timerActiveWin;
    
    private int dead;    
    private int random;

    private float timerWin;


    // Use this for initialization
    void Start()
    {
        youWin.SetActive(false);
        gameOver.SetActive(false);
        enemyCol.enabled = true;     
              
        moving = true;

        // Pick random number to activate Gameobject
        random = Random.Range(1, 3);
    }

    

    // Update is called once per frame
    void Update()
    {
        Movement();
        
    }

   

        // If enemy hit by bullet
        void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            dead += 1;

            enemyCol.enabled = false;
            enemy.SetActive(false);
            moving = false;                      


            if (random ==  1)
            {
                explode.SetActive(true);
            } 
            if (random == 2)
            {
                die.SetActive(true);
            }
        }
    }
    void Movement()
    {
        
        if (moving == true)
        {
            // Direction X Speed X DeltaTime
            transform.position += -transform.up * movementSpeed * Time.deltaTime;
        }
    }

    

}
