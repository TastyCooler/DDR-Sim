using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {
   
    #region Public fields
    public Animator animator;
    public Text nameText;
    public Text dialogueText;
    public Button yes;
    public Button no;
    public bool dialogended;
    public bool waitForItem;

    Cola cola;
    GameObject col;
    #endregion
    #region Private Fields
    private Queue<string> sentences;
    private Queue<string> endsentences;
    #endregion
    #region Unity Functions
    // Use this for initialization
    void Start()
    {
        sentences = new Queue<string>(); //initializing a new string Queue
        endsentences = new Queue<string>();

        col = GameObject.Find("Cola");
        cola = col.GetComponent<Cola>();
    }
    #endregion
    #region Class Functions
    public void StartDialogue(Dialogue dialogue)
    {
        InitDialogue(dialogue);
        animator.SetBool("IsOpen", true); // Sets the param. IsOpen to true, because the dialogue started
                                          // Debug.Log("Starting conversation with " + dialogue.name);

        nameText.text = dialogue.name; //Inserts the Name from the *inspector*, from the dialogue script

        sentences.Clear(); //removes all object from the queue
        endsentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence); //adds an object to the end of the queue; bzw. add objects to all elements
        }
        foreach(string endsentence in dialogue.endsentences)
        {
            endsentences.Enqueue(endsentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextEndSentence()
    {
        
        if (endsentences.Count == 0) //.Count gets the number of elements in the queue. If no elemenets then the dialogue ends
        {
            EndDialogue();
            return;
        }

        string endsentence = endsentences.Dequeue(); //removes and returns the object at the beginning of the queue
        // Debug.Log(sentence);
        StopAllCoroutines();  // stops the TypeSentence coroutine, so the animation can finish
        StartCoroutine(TypeSentence(endsentence)); // starts the coroutine
    }

    public void DisplayNextSentence()
    {
        
        if (sentences.Count == 1)
        {
            waitForItem = true;
        }
        if (sentences.Count == 0 && cola.destroyed) //.Count gets the number of elements in the queue. If no elemenets then the dialogue ends
        {
            Debug.Log("dialog ended");
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
            yield return new WaitForSeconds(0.06f); //after each letter 1 frame passes
        }
    }

    void EndDialogue()
    {
        //Debug.Log("End of conversation.");
        if (endsentences.Count == 0 || sentences.Count == 0)
        {
            animator.SetBool("IsOpen", false); //sets the animator parameter "IsOpen" to false
            dialogended = true;

        }
        
    }


    #endregion

    void InitDialogue(Dialogue dialogue)
    {
        dialogue.sentences = new string[4] { "Ohaio Gozaimasu!", "My Husband went on ''vacation'', without telling me","I feel so lonely... ","Can I get some eggs please?" };

        dialogue.endsentences = new string[2] { "I HATE YOU!", "WHY DO I GET NO EGGS?" };

    }

    public void DisableNoButton()
    {
            no.gameObject.SetActive(false);
    }
    public void DisableYesButton()
    {
        yes.gameObject.SetActive(false);
    }

   
}
