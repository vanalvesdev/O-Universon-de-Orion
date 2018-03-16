using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeSprite : MonoBehaviour {

    public Sprite childTask;
    void Awake()
    {
        if (FindObjectOfType<PlayerNetworking>().isServer)
            GetComponent<SpriteRenderer>().sprite = childTask;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
