using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float movementSpeed = .1f;

    public GameObject explode;
    public GameObject die;
    public GameObject enemy;
    public Collider2D enemyCol;

    private bool moving;   

    private int random;

   
    // Use this for initialization
    void Start()
    {
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
