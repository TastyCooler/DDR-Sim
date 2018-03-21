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
    public bool nowYouHaveTo;
    public bool wrongItem;
    public bool finish;

    Cola cola;
    Cigarettes cigarettes;
    Chocolate chocolate;
    GameObject col, cig, choc;

    
    #endregion
    #region Private Fields
    public Queue<string> sentences;
    private Queue<string> endsentences;
    private Queue<string> othersentences;
    #endregion
    #region Unity Functions
    // Use this for initialization
    void Start()
    {
        sentences = new Queue<string>(); //initializing a new string Queue
        endsentences = new Queue<string>();
        othersentences = new Queue<string>();

        col = GameObject.Find("Cola");
        cola = col.GetComponent<Cola>();

        cig = GameObject.Find("Cigarettes");
        cigarettes = cig.GetComponent<Cigarettes>();

        choc = GameObject.Find("Chocolate");
        chocolate = choc.GetComponent<Chocolate>();

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
        othersentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence); //adds an object to the end of the queue; bzw. add objects to all elements
        }
        foreach(string endsentence in dialogue.endsentences)
        {
            endsentences.Enqueue(endsentence);
        }
        foreach (string othersentence in dialogue.othersentences)
        {
            othersentences.Enqueue(othersentence);
        }
        DisplayNextSentence();
        
    }

    public void DisplayNextEndSentence()
    {
        if (endsentences.Count == 1)
        {
            nowYouHaveTo = true;
        }
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
        
        if (sentences.Count == 0 && cola.destroyed || cigarettes.destroyed || chocolate.destroyed) //.Count gets the number of elements in the queue. If no elemenets then the dialogue ends
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


    public void DisplayNextOtherSentence()
    {
        if (wrongItem)
        {


            if (othersentences.Count == 0) //.Count gets the number of elements in the queue. If no elemenets then the dialogue ends
            {
                print("dialog ended");
                //EndDialogue();
                return;
            }

            string othersentence = othersentences.Dequeue(); //removes and returns the object at the beginning of the queue
                                                             // Debug.Log(sentence);
            StopAllCoroutines();  // stops the TypeSentence coroutine, so the animation can finish
            StartCoroutine(TypeSentence(othersentence)); // starts the coroutine
        }
    }

    IEnumerator TypeSentence(string sentence) //character animation
    {
        dialogueText.text = ""; //clears the text before adding new text
        foreach (char letter in sentence.ToCharArray()) //ToCharArray converts a string into a char array
        {
            dialogueText.text += letter; //loops through all texts
            yield return new WaitForSeconds(0.2f); //after each letter 1 frame passes
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
        if (GameObject.Find("Matthias"))
        {

        dialogue.sentences = new string[11] { "Ohaio Gozaimasu!", "I'm Tuto-chan","I am your best friend!","I know you are new here, let me introduce you to your work...","So most of the time people visit this store and want to buy something","You give them what they want, simple as that...","You have got a register...","Have fun with it","Funny isn't it?","And never trust Stacie","Ok now give me a cola"};

        dialogue.endsentences = new string[4] { "Why are you pressing no?", "Can you stop pressing no?","Seriously press yes now","Now you have to press Yes :)" };

        dialogue.othersentences = new string[1] { "Come on it ain't that hard" };
        }
        if (GameObject.Find("Stacy"))
        {

            dialogue.sentences = new string[5] { "Hey I'm Stacy...", "I've heard Tuto was here, how is she? I hope she is fine.","Tuto-chan is befriended with Demo-chan don't forget that","Isn't this place beautiful? This place is the best", "Can I get some original cigarettes please?" };

            dialogue.endsentences = new string[4] { "What's wrong?", "You should give me some cigarettes", "Give them now", "You better give them now." };

            dialogue.othersentences = new string[1] { "This aint cigarettes" };
        }
        if (GameObject.Find("Tom"))
        {
            dialogue.sentences = new string[6] { "Hallo", "Glad Stacy left this shop", "How can she like this place that much?", "It ain't even this great...","Many friends of mine went on ''Vacation'', maybe you should come with us some day","Give me some chocolate please" };

            dialogue.endsentences = new string[2] { "Hmmm...?", "I have no time for that" };

            dialogue.othersentences = new string[1] { "C-H-O-C-O-L-A-T-E" };
        }
    }

  

    public void DisableNoButton()
    {
        
            no.gameObject.SetActive(false);
            
    }
    public void DisableYesButton()
    {
        
        yes.gameObject.SetActive(false);
    }

    private void Update()
    {
        
        if(endsentences.Count == 0 && nowYouHaveTo)
        {
            yes.gameObject.SetActive(true);
            no.gameObject.SetActive(false);
        }

      
            DisplayNextOtherSentence();
        

    }

}
