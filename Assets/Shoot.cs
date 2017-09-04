using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    public GameObject bullet;
    // Speed at which the projectile will be flung
    public float projectileSpeed = 20f;
    // Rate of fire
    public float shootRate = .1f;

    // Timer to count up to shootRate
    private float shootTimer = 0f;
   

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        shootTimer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && shootTimer >= shootRate)
        {
            // CALL Shoot()
            Fire();
            // RESET shootTimer = 0
            shootTimer = 0;
        }
    }

    void Fire()
    {
        // Instantiate a new copy of projectilePrefab
        GameObject projectile = Instantiate(bullet);
        // Position of projectile = transform position
        projectile.transform.position = transform.position;
        // Apply a force to the projectile
        Rigidbody2D projectileRigid = projectile.GetComponent<Rigidbody2D>();
        projectileRigid.AddForce(transform.up * projectileSpeed, ForceMode2D.Impulse);
    }

}
