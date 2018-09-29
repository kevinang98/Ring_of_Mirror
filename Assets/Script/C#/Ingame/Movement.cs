using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float speed = 5f;
    public bool canMove;
    public bool canWalk;
    public float life = 2;
    public bool hide;
    public Light lilin;
    static Movement character;
    public bool key1 = false;
    public bool key2 = false;
    public bool key3 = false;
    public bool ring = false;
    public bool chicken = true;
    public bool enemy = false;
    public bool destroy = false;
    public Dialogue dialog;
    public Dialogue dialogue;
    public Dialogue dialogue2;
    public bool dialogs;
    public bool dialogues = false;
    public bool checks;

    bool direction = true;
    Animator animate;

    void Start()
    {
        if (character != null)
        {
            Destroy(gameObject);
            return;
        }
        character = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
        animate = GetComponent<Animator>();
        canMove = true;
        canWalk = true;
        animate.SetBool("Die", false);
        hide = false;
        dialogs = true;
        checks = true;
    }

	void Update () {
        float move = Input.GetAxis("Horizontal");
        animate.SetFloat("Speed", 0);

        if (!canMove || !canWalk)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }else if (canMove && canWalk)
        {
            animate.SetFloat("Speed", Mathf.Abs(move));
            GetComponent<Rigidbody2D>().velocity = new Vector2(move * speed, GetComponent<Rigidbody2D>().velocity.y);
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (lilin.intensity == 0)
                {
                    lilin.intensity += 0.8f;
                }
                else if (lilin.intensity != 0)
                {
                    lilin.intensity -= 0.8f;
                }
            }
        }

        if(move > 0 && !direction)
        {
            flip();
        }else if(move < 0 && direction)
        {
            flip();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            if (hide == false)
            {
                hide = true;
                animate.SetBool("Hide", true);
                canMove = false;
                lilin.intensity = 0;
            }
            else if(hide == true)
            {
                hide = false;
                animate.SetBool("Hide", false);
                canMove = true;
            }
        }

        if (dialogs == true){
            FindObjectOfType<DialogueManager>().StartDialogue(dialog);
            dialogs = false;
        }

        if(dialogues == true)
        {
            StartCoroutine("Waits");
            dialogues = false;
        }

        if(destroy == true)
        {
            Destroy(this.gameObject);
        }
    }


    IEnumerator Waits()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        yield return new WaitForSeconds(2);
        canMove = false;
        hide = true;
        animate.SetBool("Hide", true);
        lilin.intensity = 0;
        yield return new WaitForSeconds(3);
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue2);
        hide = false;
        animate.SetBool("Hide", false);
        checks = false;
    }


    void flip()
    {
        direction = !direction;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    IEnumerator Wait()
    {
        animate.SetBool("Die", true);
        canMove = false;
        yield return new WaitForSeconds(3);
        Application.LoadLevel(4); ;
    }

    IEnumerator Wait2()
    {
        canMove = false;
        yield return new WaitForSeconds(1);
        canMove = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy" && hide == false)
        {
            if (life > 1)
            {
                StartCoroutine("Wait2");
                life -= 1;
                animate.Play("Hit");
            }
            else if (life == 1)
            {
                life -= 1;
                StartCoroutine("Wait");
            }
        }
    }
}