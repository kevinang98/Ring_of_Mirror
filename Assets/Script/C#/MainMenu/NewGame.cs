using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewGame : MonoBehaviour {

    public Transform canvas;
    public AudioSource sfx;

    IEnumerator Wait()
    {
        canvas.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        Application.LoadLevel(2);
    }

    void Start()
    {
        GetComponent<Button>().interactable = true;
        canvas.gameObject.SetActive(false);
        sfx = GetComponent<AudioSource>();    
    }

    public void OnMouseDown()
    {
        transform.localScale *= 0.9F;
        GetComponent<Button>().interactable = false;
        sfx.Play();
        StartCoroutine("Wait");
    }
}
