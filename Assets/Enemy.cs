using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public GameObject explode;
    public GameObject die;
    public GameObject enemy;
   

    private int random;

   
    // Use this for initialization
    void Start()
    {
       
        // Pick random number to activate Gameobject
        random = Random.Range(1, 3);
    }

    

    // Update is called once per frame
    void Update()
    {

    }

   

        // If enemy hit by bullet
        void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {

            enemy.SetActive(false);

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

}
