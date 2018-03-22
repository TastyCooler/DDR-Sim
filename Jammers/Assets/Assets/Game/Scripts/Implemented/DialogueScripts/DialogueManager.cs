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
    GameObject col, cig, choc, beer, ketchup, soup;
    Beer bBeer;
    Ketchup kKetchup;
    Soup sSoup;
    
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

        beer = GameObject.Find("Beer");
        bBeer = beer.GetComponent<Beer>();

        ketchup = GameObject.Find("Ketchup");
        kKetchup = ketchup.GetComponent<Ketchup>();

        soup = GameObject.Find("Soup");
        sSoup = soup.GetComponent<Soup>();
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
        
        if (sentences.Count == 0 && cola.destroyed || cigarettes.destroyed || chocolate.destroyed || bBeer.destroyed || kKetchup.destroyed || sSoup.destroyed) //.Count gets the number of elements in the queue. If no elemenets then the dialogue ends
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
            yield return new WaitForSeconds(0.02f); //after each letter 1 frame passes
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

        dialogue.sentences = new string[11] { "Ohayou Gozaimasu!", "I'm Tuto-chan","I am your best friend!","I know you are new here, let me introduce you to your work...","So most of the time people visit this store and want to buy something","You give them what they want, simple as that...","You have got a register...","Have fun with it","Funny isn't it?","And never trust Stacy","I got thirsty... give me a Cola"};

        dialogue.endsentences = new string[4] { "Why are you pressing no?", "Can you stop pressing no?","Seriously press yes now", "Now you have to press Yes :)" };

        dialogue.othersentences = new string[1] { "Drag and Drop the Cola and not something else... baka..." };
        }
        if (GameObject.Find("Stacy"))
        {
            dialogue.sentences = new string[5] { "Hey I'm Stacy...", "I've heard Tuto was here, how is she? I hope she is fine.","Tuto-chan is befriended with Demo-chan don't forget that","Isn't this place beautiful? I love this place, it's the best place in this country", "Hey can I get some original cigarettes please?" };

            dialogue.endsentences = new string[4] { "What's wrong?", "There's no reason to press no", "Why are you pressing no?", "It's your job so say yes." };

            dialogue.othersentences = new string[1] { "Are the cigarettes so badly drawn? I don't think so."};
        }
        if (GameObject.Find("Tom"))
        {
            dialogue.sentences = new string[7] { "Hi", "I'm glad Stacy left this shop", "How can she like this place that much?", "It ain't even that great...","Many friends of mine went on ''Vacation'', maybe you should come with me some day","It's much better out there","Give me some chocolate please" };

            dialogue.endsentences = new string[7] { "Hmmm...?", "I have no time for that","You also don't have time for that.","Or do you?","You really think there might be something funny, if you keep pressing no, right?","I'll tell my friend Benedikt","Seriously keep pressing yes"};

            dialogue.othersentences = new string[1] { "C-H-O-C-O-L-A-T-E" };
        }
        if (GameObject.Find("Herr Härher"))
        {
            dialogue.sentences = new string[7] { "Gg...Ghg... GUTEN TAG!!", "My w..w...wife went on vacation without telling me", "Why did sh..sh..she leave without m..m..mee?", "I bet we can leave really simple soon", "I heard people don't come back from vacation...", "What do you think? Nevermind...","I need more beer" };

            dialogue.endsentences = new string[2] { "Argh..", "I need to talk with you" };

            dialogue.othersentences = new string[1] { "I need beer" };
        } 
        if (GameObject.Find("Stefan"))
        {
            dialogue.sentences = new string[7] { "Did you see Stacy?", "Ah I know where she is...", "Did you know that people rather stay here instead of going on vacation?", "Yeah I know this is actually pretty obvious", "I'd like some Ketchup", "I want to make some original Pasta today", "Ketchup please" };

            dialogue.endsentences = new string[2] { "You have to work", "There's no way out" };

            dialogue.othersentences = new string[1] { "I need M-A-S-H-E-D T-O-M-A-T-O-E-S" };
        }
        if (GameObject.Find("Bernd"))
        {
            dialogue.sentences = new string[6] { "Mahlzeit!", "I don't like the seperation", "Aren't we all the same?", "I hope this will end soon", "I can't believe it is 1989 already", "Can I get some soup please?" };

            dialogue.endsentences = new string[2] { "Why no?", "I'm a customer as everyone else" };

            dialogue.othersentences = new string[1] { "Onion soup, I have a date later on." };
        }
        if (GameObject.Find("Demo"))
        {

            dialogue.sentences = new string[7] { "It's the 9th November 1989", "What are you doing here?", "Go outside", "We are free now!", "Can you believe it?", "I don't understand how a wall could seperate us that simple.", "Give me that delicious chocolate bar, so we can leave already" };

            dialogue.endsentences = new string[2] { "F-R-E-E-D-O-M is waiting", "You rather keep pressing no, instead of finishing the game?" };

            dialogue.othersentences = new string[1] { "I'VE BEEN LOOKING FOR FREEDOM!" };
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
