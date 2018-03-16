using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ContagemRegre : MonoBehaviour {

    private float currentTempo;
    public Sprite dois;
    public Sprite um;
    private Image image;
    // Use this for initialization
    void Start () {
        currentTempo = 3.0f;
        image = GetComponent<Image>();

	}
	
	// Update is called once per frame
	void Update () {
        currentTempo -= Time.deltaTime;
        if(Mathf.RoundToInt(currentTempo) > 2)
        {
            return;
        } else if(Mathf.RoundToInt(currentTempo) > 1)
        {
            image.sprite = dois;
        }
        else if (Mathf.RoundToInt(currentTempo) > 0)
        {
            image.sprite = um;
        }
        else
        {
            SceneManager.LoadScene("Fase1");
        }
    }
}
