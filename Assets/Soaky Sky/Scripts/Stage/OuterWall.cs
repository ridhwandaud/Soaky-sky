using UnityEngine;
using System.Collections;

public class OuterWall : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.tag == "Bullet"){
			Debug.Log("bullet hit outer wall");
			Destroy(col.gameObject,0);
		}
	}
}
