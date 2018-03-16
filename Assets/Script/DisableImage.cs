using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableImage : MonoBehaviour {

    // Use this for initialization
    private float contador;
    public bool keepEnable;
		
	// Update is called once per frame
	void Update () {
        if (!keepEnable)
        {
            contador += Time.deltaTime;
            if (Mathf.RoundToInt(contador) >= 1f)
                this.gameObject.SetActive(false);
        }
	}

    private void OnEnable()
    {
        contador = 0;
    }
}
