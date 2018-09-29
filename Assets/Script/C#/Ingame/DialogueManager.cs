using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public Text nameText;
    public Text dialogueText;
    public Animator animator;
    public AudioSource sfx;

    private Movement player;
    public bool isClickable;
    private Queue<string> sentences;

    void Start () {
        sentences = new Queue<string>();
        player = FindObjectOfType<Movement>();
        sfx = GetComponent<AudioSource>();
        isClickable = true;
    }

     void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DisplayNextSentence();
        }
    }

    public void StartDialogue(Dialogue dialog)
    {
        isClickable = false;
        player.canMove = false;
        animator.SetBool("Open", true);

        nameText.text = dialog.name;
        sentences.Clear();

        foreach (string text in dialog.sentences)
        {
            sentences.Enqueue(text);
        }
            DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
            if (sentences.Count == 0)
            {
                EndDialogue();
                return;
            }
            string sentence = sentences.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        sfx.Play();
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
        sfx.Stop();
    }

    void EndDialogue()
    {
        isClickable = true;
        animator.SetBool("Open", false);
        player.canMove = true;
    }
}
