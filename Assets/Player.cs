using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float movementSpeed = 2f;
   
    

    // Use this for initialization
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {

        

        // Get Horizontal input
        float inputH = Input.GetAxis("Horizontal");

        // Direction X Input(sign) X Speed X DeltaTime
        transform.position += transform.right * inputH * movementSpeed * Time.deltaTime;     

    }

    
}
