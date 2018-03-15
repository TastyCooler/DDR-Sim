using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    #region Public fields
    public Animator animator;
    public Text nameText;
    public Text dialogueText;
    #endregion
    #region Private Fields
    private Queue<string> sentences;
    #endregion
    #region Unity Functions
    // Use this for initialization
    void Start()
    {
        sentences = new Queue<string>(); //initializing a new string Queue
    }
    #endregion
    #region Class Functions
    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true); // Sets the param. IsOpen to true, because the dialogue started
                                          // Debug.Log("Starting conversation with " + dialogue.name);

        nameText.text = dialogue.name; //Inserts the Name from the *inspector*, from the dialogue script

        sentences.Clear(); //removes all object from the queue

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence); //adds an object to the end of the queue; bzw. add objects to all elements
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0) //.Count gets the number of elements in the queue. If no elemenets then the dialogue ends
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue(); //removes and returns the object at the beginning of the queue
                                               // Debug.Log(sentence);
        StopAllCoroutines();  // stops the TypeSentence coroutine, so the animation can finish
        StartCoroutine(TypeSentence(sentence)); // starts the coroutine
    }

    IEnumerator TypeSentence(string sentence) //character animation
    {
        dialogueText.text = ""; //clears the text before adding new text
        foreach (char letter in sentence.ToCharArray()) //ToCharArray converts a string into a char array
        {
            dialogueText.text += letter; //loops through all texts
            yield return null; //after each letter 1 frame passes
        }
    }

    void EndDialogue()
    {
        //Debug.Log("End of conversation.");
        animator.SetBool("IsOpen", false); //sets the animator parameter "IsOpen" to false
    }
    #endregion
}
