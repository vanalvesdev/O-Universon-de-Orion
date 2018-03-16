using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SomConfig : MonoBehaviour {

    private AudioSource audiosource;
    private Slider slider;
    // Use this for initialization
    private void Awake()
    {
        audiosource = FindObjectOfType<AudioSource>();
        slider = GetComponent<Slider>();
    }


    void Start () {
        slider.value = audiosource.volume;
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void ChangeVolume()
    {
        audiosource.volume = slider.value;
    }
}
