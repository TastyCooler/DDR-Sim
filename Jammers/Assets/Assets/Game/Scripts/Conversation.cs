using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conversation : MonoBehaviour {

    public static string currentPos = "Matthias";

    public string MalteA = "Favorite Color?";
    public string MalteAA = "Why do you like it?";
    public string MalteAB = "I thought girls liked pink.";
    public string MalteAC = "That's my favorite too!";
    public string MalteAAA = "Favorite Color?";

    public string MalteReplyA = "Blue";
    public string MalteReplyAA = "It reminds me of the ocean sky";
    public string MalteReplyAB = "Not all girls like pink. That is a stereotype";

    public string MalteB = "Your age?";
    public string MalteBA = "NANI?";
    public string MalteBB = "NANI?";
    public string MalteBC = "NANI?";

    public string MalteReplyB = "17";

    public string MalteC = "ARGH IM A PIRATE!";

    public Transform Atext;
    public Transform Btext;
    public Transform Ctext;

    public static int MalteSync = 0;

    public Transform AIresponse;

    // Use this for initialization
    void Start()
    {
        Atext.GetComponent<TextMesh>().text = MalteA;
        Btext.GetComponent<TextMesh>().text = MalteB;
        Ctext.GetComponent<TextMesh>().text = MalteC;
        AIresponse.GetComponent<TextMesh>().text = MalteReplyA;
    }

    private void OnMouseDown()
    {
        currentPos += gameObject.name;

        if (currentPos == "MalteA")
        {
            Atext.GetComponent<TextMesh>().text = MalteAA;
            Btext.GetComponent<TextMesh>().text = MalteAB;
            Ctext.GetComponent<TextMesh>().text = MalteAC;
            AIresponse.GetComponent<TextMesh>().text = MalteReplyA;
        }

        if (currentPos == "MalteB")
        {
            Atext.GetComponent<TextMesh>().text = MalteBA;
            Btext.GetComponent<TextMesh>().text = MalteBB;
            Ctext.GetComponent<TextMesh>().text = MalteBC;
            AIresponse.GetComponent<TextMesh>().text = MalteReplyB;
        }

        if (currentPos == "MalteC")
        {
            Atext.GetComponent<TextMesh>().text = MalteC;
            Btext.GetComponent<TextMesh>().text = MalteC;
            Ctext.GetComponent<TextMesh>().text = MalteC;

        }
    }
}
