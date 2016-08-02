using UnityEngine;
using System.Collections;

public class ParticlesManager : MonoBehaviour {

	public GameObject particlesObj;
	//public static ParticlesManager instance;

	// Use this for initialization
	void Start () {
				
	}
	
	
	public void SpawnWater(){
		Vector2 cloudPos = GameObject.FindGameObjectWithTag("Enemy").transform.position;
		Instantiate(particlesObj,cloudPos,Quaternion.identity);
	}

	void Update () {
		//check if cloud dies, then instantiate water particlesObj
		
	}
}
