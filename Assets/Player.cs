using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public float movementSpeed = 2f;
    public GameObject explode;
    public GameObject die;
    public GameObject player;
    public GameObject health;
    public SpriteRenderer sprite;
    public SpriteRenderer fullHealth;
    public SpriteRenderer halfHealth;
    public SpriteRenderer noHealth;
    public SpriteRenderer littleHealth;
    public SpriteRenderer lotsHealth;

    private int random;
    
    // Use this for initialization
    void Start()
    {

        sprite = GetComponent<SpriteRenderer>();
        sprite.enabled = true;
        fullHealth.enabled = true;
        halfHealth.enabled = false;
        noHealth.enabled = false;
        littleHealth.enabled = false;
        lotsHealth.enabled = false;
        // Pick random number to activate Gameobject
        random = Random.Range(1, 3);
    }

    // Update is called once per frame
    void Update()
    {

        if (fullHealth.enabled == false)
        {
            lotsHealth.enabled = true;            
        }

        if (halfHealth.enabled == false)
        {           
            littleHealth.enabled = true;
        }

        if (littleHealth.enabled == false)
        {            
            noHealth.enabled = true;
        }

        // Get Horizontal input
        float inputH = Input.GetAxis("Horizontal");

        // Direction X Input(sign) X Speed X DeltaTime
        transform.position += transform.right * inputH * movementSpeed * Time.deltaTime;     

    }

    // If hit by enemy bullet
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            fullHealth.enabled = false;
                        
        }

        if (lotsHealth.enabled == true && other.gameObject.CompareTag("EnemyBullet"))
        {
            lotsHealth.enabled = false;
           
        }

        if (halfHealth.enabled == true && other.gameObject.CompareTag("EnemyBullet"))
        {
            halfHealth.enabled = false;
            
        }

        if (littleHealth.enabled == true && other.gameObject.CompareTag("EnemyBullet"))
        {
            littleHealth.enabled = false;
            
        }

        if (noHealth.enabled == true)
        {

            sprite.enabled = false;

            if (random == 1)
            {
                explode.SetActive(true);
            }
            if (random == 2)
            {
                die.SetActive(true);
            }
        }

    }

}
