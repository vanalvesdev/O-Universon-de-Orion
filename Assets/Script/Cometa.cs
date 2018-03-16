using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cometa : MonoBehaviour {

    public float speed;
    public float x;
    public float y;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(x, y, transform.position.z) * speed * Time.deltaTime);
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag.Equals("Player"))
        {
            this.gameObject.SetActive(false);
            coll.gameObject.GetComponent<PlayerNetworking>().takeDamage(20);
        }
            
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
