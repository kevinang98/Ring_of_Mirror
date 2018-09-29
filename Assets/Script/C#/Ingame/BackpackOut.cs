using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackpackOut : MonoBehaviour {

    public Transform canvas;

    public void OnMouseDown()
    {
        canvas.gameObject.SetActive(false);
        FindObjectOfType<Backpack>().backpackClickable = true;
        FindObjectOfType<Backpack>().inbackpack.gameObject.SetActive(true);
    }
}
