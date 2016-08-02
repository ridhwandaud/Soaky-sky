using UnityEngine;
using System.Collections;
//using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour {

    public int health;
    bool prepareWater = true;
	void Start()
    {
        
    }

    void Update()
    {
        if(health <= 0)
        {
            health = 0;
            
           // Destroy(gameObject);
            WaterFunc();

            StartCoroutine(GameController.instance.LevelBreak());
            //Scene scene = SceneManager.GetActiveScene();
            //SceneManager.LoadScene(scene.buildIndex + 1);

        }
    }

    void WaterFunc(){
        if(prepareWater){
            Transform particMan = GameObject.FindGameObjectWithTag("ParticlesManager").transform;
            particMan.GetComponent<ParticlesManager>().SpawnWater();
            prepareWater = false;
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    
}
