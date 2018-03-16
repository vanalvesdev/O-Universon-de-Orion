using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Connector : NetworkBehaviour { 


    private NetworkManager networkManager;
    private string localip;
    private bool isChild;
    // Use this for initialization

    void Start()
    {
        networkManager = GetComponent<NetworkManager>();
    }

    public void Host ()
    {
        networkManager.StartHost();
    }


    public void Client()
    {

        //networkManager.networkAddress = "192.168.1.5";
        networkManager.networkPort = 5000;
        networkManager.StartClient();
    }

    // Update is called once per frame
    void Update () {
        
	}

    public void setIsChild(bool isChild)
    {
        this.isChild = isChild;
    }

    public void setNetworkAddress(Text texto)
    {
        string ip = texto.text.Replace(".", "");
        string novaIp = "";
        for(int i=0; i<ip.Length; i++)
        {
            novaIp += ip[i];
            if(i == 2)
            {
                novaIp += ".";
            }
            if (i == 5)
            {
                novaIp += ".";
            }
            if (i == 6)
            {
                novaIp += ".";
            }
        }
        networkManager.networkAddress = novaIp;
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name.Equals("Fase1"))
        {
            if (isChild)
            {
                Host();
            }
            else
            {
                Client();
            }

            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }


    public void Desconecte()
    {
        if (isChild)
        {
            networkManager.StopHost();
        }
        else
        {
            networkManager.StopClient();
        }
    }

}
