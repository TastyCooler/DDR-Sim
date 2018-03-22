using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
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
    GameObject money;

    private void Start()
    {
        buttonScript = GameObject.Find("Button_Green");
        bs = buttonScript.GetComponent<ButtonScript>();

        redButton = GameObject.Find("Button_Red");
        rb = redButton.GetComponent<RedButton>();

        money = GameObject.Find("Money");
        mc = money.GetComponent<MoneyClicker>();

        savePosition = transform.position;
        previousShakeStrength = shakeStrength;
    }

    void Update()
    {
        if(mc.score >= 50)
        {
            if (bs.ToggledGreen || rb.ToggledRed)
            {
                triggered = true;
            }
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