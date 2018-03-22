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

    [SerializeField, Range(0.01f, 10.0f)]
    private float speed = 0.01f;

    private float timer;

    private bool triggered;

    ButtonScript bs;
    GameObject buttonScript;

    RedButton rb;
    GameObject redButton;

    private void Start()
    {
        buttonScript = GameObject.Find("Button_Green");
        bs = buttonScript.GetComponent<ButtonScript>();

        redButton = GameObject.Find("Button_Red");
        rb = redButton.GetComponent<RedButton>();

        savePosition = transform.position;
        previousShakeStrength = shakeStrength;
    }

    // Update is called once per frame
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
            newVectorDirection = new Vector3(Mathf.Sin(Time.time / speed) / shakeStrength, 0.0f, 0.0f);
            transform.position = savePosition + newVectorDirection;

            if (shakeStrength > 100)
            {
                shakeStrength = previousShakeStrength;
                transform.position = savePosition;
                timer = 0;
                triggered = false;
            }

            //Debug.LogFormat("triggered {0}", triggered);
        }

        //Debug.Log("Calling LetItShake() function");
    }
}