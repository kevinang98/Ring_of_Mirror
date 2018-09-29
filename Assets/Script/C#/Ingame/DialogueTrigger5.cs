using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger5 : MonoBehaviour
{
    public Transform canvas;
    public AudioSource sfx;
    public Dialogue dialog;
    public Dialogue dialogue;
    public Button button;
    public bool isclick;
    public bool pauseclick;
    public bool backpackclick;
    bool check;

    void Start()
    {
        button = GetComponent<Button>();
        button.interactable = true;
        sfx = GetComponent<AudioSource>();
    }

    void Update()
    {
        isclick = FindObjectOfType<DialogueManager>().isClickable;
        pauseclick = FindObjectOfType<PauseMenu>().pauseClickable;
        backpackclick = FindObjectOfType<Backpack>().backpackClickable;
        check = FindObjectOfType<Movement>().ring;
        if (!isclick || !pauseclick || !backpackclick)
        {
            button.interactable = false;
        }
        else
        {
            button.interactable = true;
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(4);
        canvas.gameObject.SetActive(true);
        sfx.Play();
    }

    public void TriggerDialogue()
    {
        if (check == false && FindObjectOfType<Movement>().key3 == true)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialog);
            FindObjectOfType<Movement>().ring = true;
            StartCoroutine("Wait");
        }
        if (check == true || FindObjectOfType<Movement>().key3 == false)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }
    }
}