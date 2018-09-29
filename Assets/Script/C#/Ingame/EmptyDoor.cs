using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmptyDoor : MonoBehaviour {

    public Dialogue dialog;

    private void OnTriggerStay2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                FindObjectOfType<DialogueManager>().StartDialogue(dialog);
            }
        }
    }
}
