﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PlayerControllerMobile : MonoBehaviour
{
    //Components
    Animator rotateAnimator;

    //Handling
    public Transform rotateChild;
	public int bulletAmmo;
	public int totalBullet;

    //GameObject
    public GameObject bulletPrefab;
	GameObject bulletObj;
    public GameObject bulletSpawn;
    public float bulletSpeed;

	private int pointerID = -1;
	float doubleTapTime; 

	bool canShoot = false;

	//public float shootingRate = 3.5f; //
	//private float shootCooldown; //

    void Start()
    {
		if (Application.isMobilePlatform) {
			pointerID = 0; //for mobile and unity
		}
        rotateAnimator = rotateChild.GetComponent<Animator>();
		totalBullet = bulletAmmo;

		//shootCooldown = 0; //
    }

    void Update()
    {
		
		MousePosition ();
		//Debug.Log("shootCooldown "+shootCooldown);
		/*if (shootCooldown > 0)  //
		{ //
			shootCooldown -= Time.deltaTime; //
			//Debug.Log("shootCooldown "+shootCooldown);
		} //
		*/
    }
		

	void MousePosition()
	{
		

		if (Input.GetMouseButton (0) && Time.timeScale != 0) 
		{
			//For Block click through UI 
			if(EventSystem.current.IsPointerOverGameObject(pointerID)){
				return; //Not Shoot
			}

			if(GameObject.FindGameObjectWithTag("Bullet")==null){
				rotateChild.gameObject.SetActive(true);
				Vector3 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				rotateChild.rotation = Quaternion.LookRotation (Vector3.forward,transform.position - mousePos);
			}
			else if(GameObject.FindGameObjectWithTag("Bullet")!=null)
			{
				rotateChild.gameObject.SetActive(false);
			}
		}
		else if (Input.GetMouseButtonUp (0))  // cooldown check
		{
			bool doubleTapFlag = false;

			//For Block click through UI 
			if(EventSystem.current.IsPointerOverGameObject(pointerID)){
				return; //Not Shoot
			}
			
			//check double tap to restart level
			if (Time.time < doubleTapTime + .3f)
            {
                doubleTapFlag = true;
            }
            doubleTapTime = Time.time;

			if (doubleTapFlag)
			{
				Debug.Log("destroy by double tapping!");
				//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
				GameObject.FindGameObjectWithTag("Bullet").GetComponent<BulletDamage>().BulletDieSplash();
				Destroy(GameObject.FindGameObjectWithTag("Bullet"));
			}
			//----------------------

			//shoot bullet
			Shoot ();
		}
	}

    void Shoot()
    {
		CheckBullet();

		if(canShoot){  //
			//shootCooldown = shootingRate;
			Debug.Log("CanShoot true");
			GameObject bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.transform.position, Quaternion.identity); 
			bullet.transform.rotation = rotateChild.rotation;// this is to follow rotating child 
			bullet.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * bulletSpeed); //to add force according to rotation
			rotateChild.gameObject.SetActive(false);
		}  //		
        
    }

	void CheckBullet(){
		if(GameObject.FindGameObjectWithTag("Bullet") != null){
			canShoot = false;
		}

		else
		{
			canShoot = true;
		}
	}

	/*public bool CanAttack   //
	{   //
		get  //
		{  //
		return shootCooldown <= 0f;   //
		}  //
	}  //
	*/
}
