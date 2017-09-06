using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarricadeHealth : MonoBehaviour {

    public int hit = 0;

    public GameObject fullHP;
    public GameObject moreHP;
    public GameObject lessHP;
    public GameObject littleHP;

    // Use this for initialization
    void Start () {
        hit = 0;

        fullHP.SetActive(true);
        moreHP.SetActive(false);
        lessHP.SetActive(false);
        littleHP.SetActive(false);

	}
	
	// Update is called once per frame
	void Update () {
        IfHit();
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("EnemyBullet"))
        {

            hit += 1;
        }

        if (other.gameObject.CompareTag("Enemy"))
        {

            Destroy(gameObject);
        }

    }

    void IfHit()
    {
        if(hit == 5)
        {
            fullHP.SetActive(false);
            moreHP.SetActive(true);
        }

        if(hit == 10)
        {
            moreHP.SetActive(false);
            lessHP.SetActive(true);
        }
        
        if(hit == 15)
        {
            lessHP.SetActive(false);
            littleHP.SetActive(true);
        }

        if(hit == 20)
        {
            Destroy(gameObject);
        }
    }

}
