using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightSide : MonoBehaviour
{
    public GameObject[] rightArms;
    public MinigameMode methodCalls;

    public LeftSide leftMethodCalls;

    private bool headCheck;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        headCheck = methodCalls.headCheck;

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (headCheck)
            {
                rightArms[0].SetActive(true);
            }
            else
            {
                rightArms[1].SetActive(true);
            }
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            rightArms[2].SetActive(true);
        }

        MatchChecking();

        if (Input.GetKeyUp(KeyCode.E))
        {
            if (headCheck)
            {
                rightArms[0].SetActive(false);
            }
            else
            {
                rightArms[1].SetActive(false);
            }
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            rightArms[2].SetActive(false);
        }
    }

    void MatchChecking()
    {
        if (Input.GetKey(KeyCode.E) && headCheck)
        {
            if (Input.GetMouseButtonDown(0))
            {
                methodCalls.BodyHit();
                leftMethodCalls.CursorToggle();
            }
        }
        else if (Input.GetKey(KeyCode.E) && !headCheck)
        {
            if (Input.GetMouseButtonDown(0))
            {
                methodCalls.BodyHit();
                leftMethodCalls.CursorToggle();
            }
        }

        if (Input.GetKey(KeyCode.D))
        {
            if (Input.GetMouseButtonDown(0))
            {
                methodCalls.BodyHit();
                leftMethodCalls.CursorToggle();
            }
        }
    }
}
