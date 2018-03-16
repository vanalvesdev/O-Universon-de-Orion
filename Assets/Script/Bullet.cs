using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed;
    private Rigidbody2D rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        rb.velocity = Vector2.zero;
        transform.position += Vector3.up * speed * Time.deltaTime;
	}

    void OnCollisionStay2D(Collision2D coll)
    {
        Debug.Log(coll.gameObject.tag);
        if (coll.gameObject.tag.Equals("Player"))
        {
            Debug.Log("Achou o player");
        }
        if (coll.gameObject.tag.Equals("Boundary"))
        {
            Destroy(this.gameObject);
        }
        if (coll.gameObject.tag.Equals("Asteroid"))
        {
            Debug.Log("Achou o Asteroid");
            FindObjectOfType<Contador>().Ponto();
            Destroy(coll.gameObject);
            Destroy(this.gameObject);
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag.Equals("Player"))
        {

        }
            

    }
}
