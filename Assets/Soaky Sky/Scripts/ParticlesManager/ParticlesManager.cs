using UnityEngine;
using System.Collections;

public class ParticlesManager : MonoBehaviour {

	public GameObject particlesObj;
	public GameObject backgroundRain;
	public GameObject bulletSplash;
	//public static ParticlesManager instance;

	// Use this for initialization
	void Start () {
				
	}
	
	
	public void SpawnWater(){
		Vector2 cloudPos = GameObject.FindGameObjectWithTag("Enemy").transform.position;
		Instantiate(particlesObj,cloudPos,Quaternion.identity);
		Vector2 bckRainPos = new Vector2(0,14.4f);
		Instantiate(backgroundRain,bckRainPos,Quaternion.identity);
	}

	public void Splash(){
		Vector2 bulPos = GameObject.FindGameObjectWithTag("Bullet").transform.position;
		Instantiate(bulletSplash,bulPos,Quaternion.identity);
	}

	void Update(){
		if(GameObject.FindGameObjectWithTag("Bullet")==null && GameObject.FindGameObjectWithTag("BulletSplash")!=null){
			Destroy(GameObject.FindGameObjectWithTag("BulletSplash"),1.5f);
			//Debug.Log("splash exist while no there is no bullet");
		}
	}
}
