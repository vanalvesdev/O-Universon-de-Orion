using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Contador : MonoBehaviour {

    public int maxTempo;
    private float currentTempo;
    public Text relogio;
    private PlayerNetworking pn;
    public Sprite childTask;
    public Sprite seisNaves;
    public Sprite quatroNaves;
    public Sprite telaErrou;
    public Sprite telaAcertou;
    public string currentScene;
    private int errornum;
    public bool isNivel3;
    private int pontoCount;
    private int letraCount;
    public int letraMax;
    void Awake()
    {
        pontoCount = 0;
        if (FindObjectOfType<PlayerNetworking>().isServer && !isNivel3)
        {
            Image image =  GetComponent<Image>();
            if(image != null)
            {
                image.sprite = childTask;
            }
            else
            {
                GetComponent<SpriteRenderer>().sprite = childTask;
            }
        }
             
    }

    // Use this for initialization
    void Start () {
        errornum = 0;
        relogio.text = maxTempo.ToString();
        currentTempo = maxTempo;
    }
	
	// Update is called once per frame
	void Update () {
        if(currentTempo > 0) { 
            currentTempo -= Time.deltaTime;
            relogio.text = Mathf.RoundToInt(currentTempo).ToString();
            if (isNivel3)
            {
                if(pontoCount >= 12)
                {
                    SceneManager.LoadScene("Soma", LoadSceneMode.Single);
                }else if (pontoCount >= 6)
                {
                    GetComponent<SpriteRenderer>().sprite = seisNaves;
                }
                else if (pontoCount >= 2)
                {
                    GetComponent<SpriteRenderer>().sprite = quatroNaves;
                }
            }
        }
        else if(!isNivel3)
        {
            if(FindObjectOfType<Controller>().starsNum >= 6)
            {
                SceneManager.LoadScene("Nivel3", LoadSceneMode.Single);
            }
            else if(currentScene != null && currentScene != "")
            {
                SceneManager.UnloadSceneAsync(currentScene);
            }

        }
    }
    
    public void Errou()
    {
        errornum++;
        if(errornum < 4)
            GameObject.Find("Error " + errornum).GetComponent<Image>().enabled = true;
        if(errornum == 3)
        {
            GameObject[] opcoes = GameObject.FindGameObjectsWithTag("Opcao");
            foreach(GameObject o in opcoes)
            {
                o.GetComponent<Button>().enabled = false;
            }
            Image image = GetComponent<Image>();
            if (image != null)
            {
                image.sprite = telaErrou;
            }
            else
            {
                GetComponent<SpriteRenderer>().sprite = telaErrou;
            }
        }
    }


    public void Ponto()
    {
        pontoCount++;
    }


    public void LetraAcertou()
    {
        letraCount++;
        if(letraCount >= letraMax)
        {
            Image image = GetComponent<Image>();
            if (image != null)
            {
                image.sprite = telaAcertou;
            }
            else
            {
                GetComponent<SpriteRenderer>().sprite = telaAcertou;
            }
        }
    }

}
