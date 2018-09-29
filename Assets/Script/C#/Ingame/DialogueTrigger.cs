using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Dialogue
{
    public string name;

    [TextArea(3, 10)]
    public string[] sentences;

}

public class DialogueTrigger : MonoBehaviour {

    public Dialogue dialog;
    public Button button;
    public bool isclick;
    public bool pauseclick;
    public bool backpackclick;

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
        if (!isclick || !pauseclick || !backpackclick)
        {
            button.interactable = false;
        }
        else
        {
            button.interactable = true;
        }
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialog);
    }
}