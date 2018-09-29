using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger2 : MonoBehaviour
{
    public Animator animator;
    public Transform canvas;
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
    }

    void Update()
    {
        isclick = FindObjectOfType<DialogueManager>().isClickable;
        pauseclick = FindObjectOfType<PauseMenu>().pauseClickable;
        backpackclick = FindObjectOfType<Backpack>().backpackClickable;
        check = FindObjectOfType<Movement>().chicken;
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
        yield return new WaitForSeconds(3);
        canvas.gameObject.SetActive(false);
    }

    public void TriggerDialogue()
    {
        if (check == true)
        {
            canvas.gameObject.SetActive(true);
            FindObjectOfType<DialogueManager>().StartDialogue(dialog);
            animator.SetBool("Open", true);
            StartCoroutine("Wait");
            FindObjectOfType<Movement>().chicken = false;
            FindObjectOfType<Movement>().key1 = true;
        }
        if (check == false)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }
    }
}