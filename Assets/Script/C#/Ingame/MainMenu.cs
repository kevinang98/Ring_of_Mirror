using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    public void OnMouseDown()
    {
        FindObjectOfType<Movement>().destroy = true;
        transform.localScale *= 0.9F;
        Application.LoadLevel(0);
        FindObjectOfType<PauseMenu>().pauseClickable = true;
        FindObjectOfType<PauseMenu>().backpackClickable = true;
    }
}
