using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

    public Transform canvas;
    public bool pauseClickable;
    public bool backpackClickable;
    public Canvas ingame;

    void Start()
    {
        pauseClickable = true;
        backpackClickable = true;
    }

    public void OnMouseDown()
    {
        if (canvas.gameObject.activeInHierarchy == false)
        {
            ingame.gameObject.SetActive(false);
            canvas.gameObject.SetActive(true);
            Time.timeScale = 0;
            pauseClickable = false;
            backpackClickable = false;
        }
        else
        {
            ingame.gameObject.SetActive(true);
            canvas.gameObject.SetActive(false);
            Time.timeScale = 1;
            pauseClickable = true;
            backpackClickable = true;
        }
    }
}
