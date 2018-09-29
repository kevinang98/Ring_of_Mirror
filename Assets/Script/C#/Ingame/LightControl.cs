using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightControl : MonoBehaviour {

    public Light lampu;

	void Update () {
		if(FindObjectOfType<Movement>().enemy == true)
        {
            lampu.intensity -= 0.8f;
        }
	}
}