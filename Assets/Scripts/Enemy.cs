using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float movementSpeed = .1f;
    public float alive = 0f;
    public float waitTime = 3f;

    public Image bGround;

    public GameObject youWin;
    public GameObject gameOver;
    public GameObject explode;
    public GameObject die;
    public GameObject enemy;
    public Collider2D enemyCol;
    

    private bool timerActive;
    private bool moving;

    private float timer;

    private int random;

   
    // Use this for initialization
    void Start()
    {
        timerActive = false;
        gameOver.SetActive(false);
        youWin.SetActive(false);
        bGround.enabled = false;

        alive = 26;

        enemyCol.enabled = true;

        moving = true;

        // Pick random number to activate Gameobject
        random = Random.Range(1, 3);
    }

    

    // Update is called once per frame
    void Update()
    {
        Movement();

        if (timerActive)
        {
            timer += 3 * Time.deltaTime;
        }

        if (timer > waitTime)
        {
            gameOver.SetActive(false);
            youWin.SetActive(true);
        }

    }

   

        // If enemy hit by bullet
        void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            enemyCol.enabled = false;
            enemy.SetActive(false);
            moving = false;
            alive -= 1;
            
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

    void YouWin()
    {
        if(alive == 0)
        {
            timerActive = true;
            gameOver.SetActive(true);
        }
    }

}
