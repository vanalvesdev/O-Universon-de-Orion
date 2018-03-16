using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckLetter : MonoBehaviour {

    public string letter;
    private Transform letterT;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(letterT != null)
        {
            letterT.position = transform.position;
        }
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name.Equals(letter))
        {
            letterT = coll.gameObject.GetComponent<Transform>();
            coll.gameObject.GetComponent<DragDrop>().canMove = false;
            coll.gameObject.GetComponent<DragDrop>().enabled = false;
            coll.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            FindObjectOfType<Contador>().LetraAcertou();
        }
    }
}
