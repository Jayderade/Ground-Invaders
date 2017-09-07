﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int hit = 0;

    public float movementSpeed = 2f;
    public float waitTime = 3f;

    public bool moving;

    public Image bGround;
        
    public GameObject explode;
    public GameObject die;      
    public GameObject fullHealth;
    public GameObject halfHealth;    
    public GameObject littleHealth;
    public GameObject lotsHealth;
    public GameObject gameOver;
    public GameObject youLose;

    private bool timerActive;

    private SpriteRenderer sprite;

    private float timer;

    private int random;
    
    // Use this for initialization
    void Start()
    {
        timerActive = false;
        gameOver.SetActive(false);
        youLose.SetActive(false);
        bGround.enabled = false;

        hit = 0;
        moving = true;

        sprite = GetComponent<SpriteRenderer>();
                        
        fullHealth.SetActive(true);
        halfHealth.SetActive(false);        
        littleHealth.SetActive(false);
        lotsHealth.SetActive(false);

        // Pick random number to activate Gameobject
        random = Random.Range(1, 3);
    }

    // Update is called once per frame
    void Update()
    {
        IfHit();
        Movement();

        if (timerActive)
        {
            timer += 3 * Time.deltaTime;
        }

        if (timer > waitTime)
        {
            gameOver.SetActive(false);
            youLose.SetActive(true);
        }

    }

    // If hit by enemy bullet
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            
            hit += 1;
        }              
    }
   
    void IfHit()
    {
        if (hit == 1)
        {
            fullHealth.SetActive(false);
            lotsHealth.SetActive(true);
        }

        if (hit == 2)
        {
            lotsHealth.SetActive(false);
            halfHealth.SetActive(true);
        }

        if (hit == 3)
        {
            halfHealth.SetActive(false);
            littleHealth.SetActive(true);
        }

        if (hit == 4)
        {
            littleHealth.SetActive(false);            
            sprite.enabled = false;
            moving = false;

            if (random == 1)
            {
                explode.SetActive(true);
                gameOver.SetActive(true);
                timerActive = true;
                bGround.enabled = true;
            }
            if (random == 2)
            {
                die.SetActive(true);
                gameOver.SetActive(true);
                timerActive = true;
                bGround.enabled = true;
            }
            
        }
        

    }       
    void Movement()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (moving)
        {
            // Get Horizontal input
            float inputH = Input.GetAxis("Horizontal");

            // Direction X Input(sign) X Speed X DeltaTime
            transform.position += transform.right * inputH * movementSpeed * Time.deltaTime;
        }
    }
}
