using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOut : MonoBehaviour {

    private Movement player;
    public Animator animator;
    public AudioSource sfx;
    public Dialogue dialogue;

    void Start()
    {
        player = FindObjectOfType<Movement>();
        sfx = GetComponent<AudioSource>();
    }

    IEnumerator Wait()
    {
        animator.SetBool("Open", true);
        player.canWalk = false;
        yield return new WaitForSeconds(1);
        Application.LoadLevel(7);
        player.canWalk = true;
        animator.SetBool("Open", false);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player" && FindObjectOfType<Movement>().ring == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                sfx.Play();
                StartCoroutine("Wait");
            }
        }
        else if(other.tag == "Player" && FindObjectOfType<Movement>().ring == false)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            }
        }
    }
}
