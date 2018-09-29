using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour {

    public void OnMouseDown()
    {
        FindObjectOfType<Movement>().destroy = true;
        Application.LoadLevel(0);
    }
}
