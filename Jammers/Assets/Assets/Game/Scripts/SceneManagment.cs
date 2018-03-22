using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagment : MonoBehaviour {

    DialogueManager dm;
    GameObject dialogueManager;
    MoneyClicker mC;
    GameObject moneyClicker;
    
    private void Start()
    {
        dialogueManager = GameObject.Find("DialogueManager");
        dm = dialogueManager.GetComponent<DialogueManager>();

        moneyClicker = GameObject.Find("Money");
        mC = moneyClicker.GetComponent<MoneyClicker>();
   
    }
    void Update()
    {
        ChangeScene();
    }

    void ChangeScene()
    {
        if (dm.finish == true)
        {
            //DontDestroyOnLoad(mC);
            LoadNextLevel();
        }

    }

    private void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        

    }
}
