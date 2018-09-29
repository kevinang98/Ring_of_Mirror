using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorToiletOut : MonoBehaviour {

    private Movement player;
    public Animator animator;
    public AudioSource sfx;
    public bool check;
    float live;

    private void Start()
    {
        player = FindObjectOfType<Movement>();
        sfx = GetComponent<AudioSource>();
    }

    private void Update()
    {
        check = FindObjectOfType<Movement>().checks;
    }

    IEnumerator Wait()
    {
        animator.SetBool("Open", true);
        player.canMove = false;
        yield return new WaitForSeconds(1);
        Application.LoadLevel(2);
        if (FindObjectOfType<Movement>().key3 == true && check == true)
        {
            FindObjectOfType<Movement>().dialogues = true;
            FindObjectOfType<Movement>().checks = false;
        }
        player.canMove = true;
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