using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegisterBase : MonoBehaviour
{
    Vector3 newVectorDirection;
    Vector3 savePosition;

    [SerializeField, Range(50, 100)]
    private float shakeStrength = 50;
    private float previousShakeStrength;
    private float maxRange = 500.0f;
    
    [SerializeField]
    private float shakeTime = 0.01f;

    private float timer;

    public bool triggered;

    ButtonScript bs;
    GameObject buttonScript;

    RedButton rb;
    GameObject redButton;

    MoneyClicker mc;

    static RegisterBase instance = null;
    private void Start()
    {
        buttonScript = GameObject.Find("Button_Green");
        bs = buttonScript.GetComponent<ButtonScript>();

        redButton = GameObject.Find("Button_Red");
        rb = redButton.GetComponent<RedButton>();

        mc = GetComponent<MoneyClicker>();

        savePosition = transform.position;
        previousShakeStrength = shakeStrength;
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
          

        }
    }

    
    void Update()
    {
        if (bs.ToggledGreen || rb.ToggledRed)
        {
            triggered = true;
        }

        LetItShake();
    }

    public void LetItShake()
    {
        if (triggered)
        {
            timer += Time.deltaTime;
            shakeStrength = timer % 60 * 100;
            newVectorDirection = new Vector3(Mathf.Sin(Time.time / shakeTime) / shakeStrength, 0.0f, 0.0f);
            transform.position = savePosition + newVectorDirection;

            if (shakeStrength > 100 || Input.GetMouseButtonDown(0))
            {
                shakeStrength = previousShakeStrength;
                transform.position = savePosition;
                timer = 0;
                triggered = false;
            }
        }
    }
}