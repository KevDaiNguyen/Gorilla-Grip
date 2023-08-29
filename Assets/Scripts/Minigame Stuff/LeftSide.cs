using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftSide : MonoBehaviour
{
    public GameObject[] leftArms;
    public MinigameMode methodCalls;

    public GameObject mouseCursorLeft;
    public GameObject mouseCurseorRight;

    public int mouseLeftRight = 1;

    private bool headCheck;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       headCheck = methodCalls.headCheck;

       if (Input.GetKeyDown(KeyCode.Q))
       {
            if (headCheck)
            {
                leftArms[0].SetActive(true);
            }
            else
            {
                leftArms[1].SetActive(true);
            }
       }
       else if (Input.GetKeyDown(KeyCode.A))
       {
            leftArms[2].SetActive(true);
       }

        MatchChecking();

        if (Input.GetKeyUp(KeyCode.Q))
        {
            if (headCheck)
            {
                leftArms[0].SetActive(false);
            }
            else
            {
                leftArms[1].SetActive(false);
            }
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            leftArms[2].SetActive(false);
        }

    }

    void MatchChecking()
    {
        if (Input.GetKey(KeyCode.Q) && headCheck)
        {
            if (Input.GetMouseButtonDown(0))
            {
                methodCalls.BodyHit();
                CursorToggle();
            }
        }
        else if (Input.GetKey(KeyCode.Q) && !headCheck)
        {
            if (Input.GetMouseButtonDown(0))
            {
                methodCalls.BodyHit();
                CursorToggle();
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            if (Input.GetMouseButtonDown(0))
            {
                methodCalls.BodyHit();
                CursorToggle();
            }
        }
    }

    public void CursorToggle()
    {
        if (mouseLeftRight > 0)
        {
            mouseCursorLeft.SetActive(true);
            mouseCurseorRight.SetActive(false);
            mouseLeftRight *= -1;
        }
        else if (mouseLeftRight < 0)
        {
            mouseCurseorRight.SetActive(true);
            mouseCursorLeft.SetActive(false);
            mouseLeftRight *= -1;
        }
    }
}
