using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ContadorSoma : MonoBehaviour
{

    public int maxTempo;
    private float currentTempo;
    public Text relogio;
    private PlayerNetworking pn;
    public Sprite childTask;
    private int errornum;
    void Awake()
    {
        if (FindObjectOfType<PlayerNetworking>().isServer)
        {
            Image image = GetComponent<Image>();
            if (image != null)
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
    void Start()
    {
        errornum = 0;
        relogio.text = maxTempo.ToString();
        currentTempo = maxTempo;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTempo > 0)
        {
            currentTempo -= Time.deltaTime;
            relogio.text = Mathf.RoundToInt(currentTempo).ToString();
        }
        else
        {
            SceneManager.LoadScene("Perdeu");
        }
    }

    public void Errou()
    {
        errornum++;
        if (errornum < 4)
            GameObject.Find("Error " + errornum).GetComponent<Image>().enabled = true;
        if (errornum == 3)
        {
            GameObject[] opcoes = GameObject.FindGameObjectsWithTag("Opcao");
            foreach (GameObject o in opcoes)
            {
                o.GetComponent<Button>().enabled = false;
            }
            SceneManager.LoadScene("Perdeu");
        }
    }

    public void Acertou()
    {
        SceneManager.LoadScene("Ganhou");
    }
}
