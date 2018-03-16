using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.UI;

public class IP : MonoBehaviour {

	// Use this for initialization
	void Start () {
        var host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (var ip in host.AddressList)
        {
            if (ip.AddressFamily == AddressFamily.InterNetwork)
            {
                GetComponent<Text>().text = ip.ToString();
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
