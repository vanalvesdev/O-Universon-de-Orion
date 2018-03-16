using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerNetworking : NetworkBehaviour {

    // Use this for initialization
    private Canvas canvas;
    public float maxLife;
    public GameObject barLife;
    [SyncVar]
    public float currentLife;
    void Awake()
    {
        currentLife = maxLife;
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        DontDestroyOnLoad(this.gameObject);
    }

    void Start () {
        if(isLocalPlayer)
            GetComponent<Player>().canMove = true;
        GetComponent<Player>().setupShip(isLocalPlayer && isServer || !isLocalPlayer && !isServer);
        barLife = transform.GetChild(0).GetChild(0).gameObject;
    }

    // Update is called once per frame
    void FixedUpdate () {
        barLife.transform.localScale = new Vector3(currentLife / maxLife, barLife.transform.localScale.y, barLife.transform.localScale.z);
        if(currentLife <= 0)
        {
            SceneManager.LoadScene("Perdeu", LoadSceneMode.Single);
        }
    }


    public void CmdRespawn()
    {
        GetComponent<Player>().respawnPlayer();
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (!scene.name.Equals("Fase1") && !scene.name.Equals("Nivel3") && isLocalPlayer)
        {
            GetComponent<Player>().canMove = false;
            GetComponent<Player>().canShoot = false;
            if (canvas != null)
                canvas.enabled = false;
        }

        if(scene.name.Equals("Nivel3"))
        {
            GetComponent<Player>().setupShipNivel3(isLocalPlayer && isServer || !isLocalPlayer && !isServer);
            if (isLocalPlayer) { 
                GetComponent<Player>().canMove = false;
                GetComponent<Player>().sideMove = true;
                GetComponent<Player>().respawn = true;
                GetComponent<Player>().freezeY = true;
                GetComponent<Player>().canShoot = true;
            }
        }
            
    }

    private void OnSceneUnloaded(Scene scene)
    {
        if(!scene.name.Equals("Fase1") && !scene.name.Equals("Nivel3") && isLocalPlayer) {
            GetComponent<Player>().canMove = true;
            if (canvas != null)
                canvas.enabled = true;
        }
    }


    public void takeDamage(int damage)
    {
        if (isLocalPlayer)
        {
            currentLife -= damage;
            CmdLife(currentLife);

        }
            
    }

    [Command]
    public void CmdLife(float life)
    {
        this.currentLife = life;
    }

}
