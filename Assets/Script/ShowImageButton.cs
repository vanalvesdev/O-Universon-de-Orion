using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowImageButton : MonoBehaviour {

    // Use this for initialization
    private GameObject vermelho;
    private GameObject azul;
	void Start () {
        vermelho = transform.GetChild(0).gameObject;
        azul = transform.GetChild(1).gameObject;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Errou()
    {
        vermelho.SetActive(true);
    }

    public void Acertou()
    {
        azul.SetActive(true);
    }
}
