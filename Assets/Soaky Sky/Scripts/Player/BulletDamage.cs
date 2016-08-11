﻿using UnityEngine;
using System.Collections;

public class BulletDamage : MonoBehaviour {

    public int bulletDamage;
    bool prepareSplash = true;
	// Use this for initialization
	void Start () {
        Destroy(gameObject, 3.5f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<EnemyHealth>().TakeDamage(bulletDamage);
            Destroy(gameObject);
        }
       
    }

    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag =="Thorn"){
            BulletDieSplash();
            Destroy(gameObject);
        }
    }

    void BulletDieSplash(){
        if(prepareSplash){
            Transform particMan = GameObject.FindGameObjectWithTag("ParticlesManager").transform;
            particMan.GetComponent<ParticlesManager>().Splash();
            prepareSplash = false;
        }
    }
}
