using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAtasIn : MonoBehaviour {

    private Movement player;
    public Animator animator;
    public AudioSource sfx;
    public Dialogue dialogue;

    private void Start()
    {
        player = FindObjectOfType<Movement>();
        sfx = GetComponent<AudioSource>();
    }

    IEnumerator Wait()
    {
        animator.SetBool("Open", true);
        player.canMove = false;
        yield return new WaitForSeconds(1);
        Application.LoadLevel(6);
        player.canMove = true;
        animator.SetBool("Open", false);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E) && FindObjectOfType<Movement>().key1 == true)
            {
                sfx.Play();
                StartCoroutine("Wait");
            }
            else if(Input.GetKeyDown(KeyCode.E) && FindObjectOfType<Movement>().key1 == false)
            {
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            }
        }
    }
}
