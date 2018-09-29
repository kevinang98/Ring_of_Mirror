using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackMainMenu : MonoBehaviour {

    public void OnMouseDown()
    { 
        FindObjectOfType<Movement>().destroy = true;
        transform.localScale *= 0.9F;
        Application.LoadLevel(0);
    }
}
