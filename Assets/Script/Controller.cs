using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Controller : NetworkBehaviour {

    // Use this for initialization
    public int starsNum = 0;
    public GameObject[] stars;
    public GameObject nivel1;
    public GameObject nivel2;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void CmdactiveStar()
    {
        stars[starsNum].SetActive(true);
        starsNum++;

        if(starsNum == 3)
        {
            nivel1.SetActive(false);
            nivel2.SetActive(true);
            for (int i = 0; i < 3; i++)
            {
                nivel2.transform.GetChild(i).gameObject.SetActive(true);
                for (int j = 0; j < 3; j++)
                {
                    nivel2.transform.GetChild(j).gameObject.SetActive(true);
                }
            }
        }
    }
}
