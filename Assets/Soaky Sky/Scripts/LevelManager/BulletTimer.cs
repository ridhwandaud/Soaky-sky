using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BulletTimer : MonoBehaviour {
	
	public Slider bulSlider;
	float timeLeft = 3.5f;
	// Use this for initialization
	void Start () {
		bulSlider.value = timeLeft;
	}
	
	// Update is called once per frame
	void Update () {
		if(GameObject.FindGameObjectWithTag("Bullet")!=null){
			if(timeLeft <= 0){
				timeLeft = 3.5f;
			}
			timeLeft -= Time.deltaTime;
			bulSlider.value = timeLeft;
		}
		else
		{
			timeLeft = 3.5f;
			bulSlider.value = timeLeft;
		}
	}
}
