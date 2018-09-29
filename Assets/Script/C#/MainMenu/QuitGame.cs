using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitGame : MonoBehaviour {

    public void OnMouseDown()
    {
        transform.localScale *= 0.9F;
        GetComponent<Button>().interactable = false;
        Application.Quit();
    }
}
