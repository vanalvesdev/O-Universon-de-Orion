using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

    private bool salvo;
    public Sprite salvoSprite;
	// Use this for initialization
	void Start () {
        salvo = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (salvo && (Input.touchCount > 0 || Input.GetMouseButtonDown(0))){
            SceneManager.LoadScene("Menu");
        }
	}

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void Sair()
    {
        Application.Quit();
    }

    public void Salvar()
    {
        GameObject.Find("Sim").SetActive(false);
        GameObject.Find("Nao").SetActive(false);
        GetComponent<Image>().sprite = salvoSprite;
        salvo = true;
    }


    public void Desconecte()
    {
        FindObjectOfType<Connector>().Desconecte();
        SceneManager.LoadScene("Menu");
    }
}
