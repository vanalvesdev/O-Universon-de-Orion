using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Launcher : MonoBehaviour {
    public float timeToLaunch;
    private float currentTime;
    public GameObject prefab;
    private bool canLauncher = true;
    public int launchCount;
	// Use this for initialization
	void Start () {
        currentTime = 5f;

        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }
	
	// Update is called once per frame
	void Update () {
        if (canLauncher) { 
            currentTime += Time.deltaTime;
            if(currentTime >= timeToLaunch)
            {
                currentTime = 0;
                int i = Random.Range(0, launchCount);
                Transform launchPoint = transform.GetChild(i);
                GameObject bullet = Instantiate(prefab, launchPoint.position, launchPoint.rotation);
                bullet.GetComponent<Cometa>().x = launchPoint.GetComponent<LaunchPoint>().x;
                bullet.GetComponent<Cometa>().y = launchPoint.GetComponent<LaunchPoint>().y;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag.Equals("Player"))
        {
            coll.gameObject.GetComponent<PlayerNetworking>().takeDamage(20);
            Destroy(this.gameObject);
        }
    }
    
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        canLauncher = false;
        GameObject[] cometas = GameObject.FindGameObjectsWithTag("Asteroid");
        foreach (GameObject item in cometas)
        {
            Destroy(item);
        }
    }

    private void OnSceneUnloaded(Scene scene)
    {
        canLauncher = true;
    }


}
