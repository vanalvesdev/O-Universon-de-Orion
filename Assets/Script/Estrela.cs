using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class Estrela : MonoBehaviour {

    private SpriteRenderer spriteRenderer;
    private SpriteRenderer spriteChild;
    private SpriteRenderer spriteChild1;
    private SpriteRenderer spriteChild2;
    public float timeToInit;
    private float timer;
    public float blinkSpeed;
    public bool down;
    public string desafio;
    public Controller controller;
	// Use this for initialization
	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteChild = transform.GetChild(0).GetComponent<SpriteRenderer>();
        spriteChild1 = transform.GetChild(1).GetComponent<SpriteRenderer>();
        spriteChild2 = transform.GetChild(2).GetComponent<SpriteRenderer>();
        down = true;
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer >= timeToInit)
        {
            if (down)
            {
                spriteRenderer.color -= new Color(0, 0, 0, blinkSpeed * Time.deltaTime);
                if (Math.Round(spriteRenderer.color.a, 2) <= 0.08f)
                {
                    down = false;
                }
            }
            if (!down)
            {
                spriteRenderer.color += new Color(0, 0, 0, blinkSpeed * Time.deltaTime);
                if (spriteRenderer.color.a >= 1)
                {
                    down = true;
                }
            }
            spriteChild.color = spriteRenderer.color;
            spriteChild1.color = spriteRenderer.color;
            spriteChild2.color = spriteRenderer.color;
        }
        
    }


    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag.Equals("Player"))
        {
            this.gameObject.SetActive(false);
            SceneManager.LoadScene(desafio, LoadSceneMode.Additive);
            controller.CmdactiveStar();
        }
    }
}
