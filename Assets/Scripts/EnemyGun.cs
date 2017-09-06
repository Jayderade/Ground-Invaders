using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour {

    public GameObject enemybullet;
    // Speed at which the projectile will be flung
    public float projectileSpeed = 20f;
    // Rate of fire
    public float shootRate = .1f;

    // Timer to count up to shootRate
    private float shootTimer = 0f;
    private int random;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {

        shootTimer += Time.deltaTime;

        random = Random.Range(1, 27);


        if (shootTimer >= shootRate && random == 1)
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
        GameObject projectile = Instantiate(enemybullet);
        // Position of projectile = transform position
        projectile.transform.position = transform.position;
        // Apply a force to the projectile
        Rigidbody2D projectileRigid = projectile.GetComponent<Rigidbody2D>();
        projectileRigid.AddForce(transform.up * projectileSpeed, ForceMode2D.Impulse);
    }

}
