using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume : MonoBehaviour {

    public Transform canvas;

    public void OnMouseDown()
    {
        transform.localScale *= 0.9F;
        canvas.gameObject.SetActive(false);
        Time.timeScale = 1;
        FindObjectOfType<PauseMenu>().pauseClickable = true;
        FindObjectOfType<PauseMenu>().backpackClickable = true;
        FindObjectOfType<PauseMenu>().ingame.gameObject.SetActive(true);
    }
}