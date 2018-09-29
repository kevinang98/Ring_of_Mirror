using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorToiletIn : MonoBehaviour {

    private Movement player;
    public Animator animator;
    public AudioSource sfx;

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
        Application.LoadLevel(3);
        player.canWalk = true;
        animator.SetBool("Open", false);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                sfx.Play();
                StartCoroutine("Wait");
            }
        }
    }
}
