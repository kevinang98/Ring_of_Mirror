using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenScene : MonoBehaviour {

	void Start () {
        GetComponent<Animator>().SetBool("Open", false);
        Time.timeScale = 1;
	}
	
	void Update () {
        GetComponent<Animator>().SetBool("Open", true);
    }
}
