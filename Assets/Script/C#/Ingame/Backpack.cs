using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Backpack : MonoBehaviour {

    public Transform canvas;
    public Transform canvas1;
    public Transform canvas2;
    public Transform canvas3;
    public Transform canvas4;
    public Button button;
    public bool backpackClickable;
    public bool backpackclick;
    public Canvas inbackpack;
    public bool kunci1;
    public bool kunci2;
    public bool kunci3;
    public bool cincin;

    void Start()
    {
        backpackClickable = true;
        button = GetComponent<Button>();
        button.interactable = true;
    }

    void Update()
    {
        kunci1 = FindObjectOfType<Movement>().key1;
        kunci2 = FindObjectOfType<Movement>().key2;
        kunci3 = FindObjectOfType<Movement>().key3;
        cincin = FindObjectOfType<Movement>().ring;
        backpackclick = FindObjectOfType<PauseMenu>().backpackClickable;

        if (!backpackclick)
        {
            button.interactable = false;
        }
        else
        {
            button.interactable = true;
        }

        if(kunci1 == true)
        {
            canvas1.gameObject.SetActive(true);
        }
        if (kunci2 == true)
        {
            canvas2.gameObject.SetActive(true);
        }
        if (kunci3 == true)
        {
            canvas3.gameObject.SetActive(true);
        }
        if (cincin == true)
        {
            canvas4.gameObject.SetActive(true);
        }
    }

    public void OnMouseDown()
    {
        inbackpack.gameObject.SetActive(false);
        canvas.gameObject.SetActive(true);
        backpackClickable = false;
    }
    

}