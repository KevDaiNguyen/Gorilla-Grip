using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class MinigameMode : MonoBehaviour
{
    public GameObject minigameScreen;
    public GameObject player;
    public PlayerHealth methodCallsPlayer;
    public GameObject leftArm;
    public GameObject rightArm;

    public bool minigameOnOff;
    public string[] weakPointList;

    public bool headCheck;
    public string bodyCode;

    public bool finishedMinigame;

    public int bodyHealth;

    // Start is called before the first frame update
    void Start()
    {
        bodyHealth = 20 * Random.Range(1,2);
        finishedMinigame = false;
        minigameOnOff = false;
        bodyCode = "M";
    }

    // Update is called once per frame
    void Update()
    {
        if (minigameOnOff)
        {
            minigameScreen.SetActive(true);
            player.GetComponent<RigidbodyFirstPersonController>().enabled = false;
            player.GetComponent<Rigidbody>().isKinematic = true;
            methodCallsPlayer.inMinigame = true;

            BeginMinigame();
        }
        else
        {
            minigameScreen.SetActive(false);
            player.GetComponent<RigidbodyFirstPersonController>().enabled = true;
            player.GetComponent<Rigidbody>().isKinematic = false;
            methodCallsPlayer.inMinigame = false;
        }
    }

    public void ActivateMinigame()
    {
        minigameScreen.SetActive(true);
        minigameOnOff = true;
        leftArm.GetComponent<ArmContacts>().enabled = false;
        leftArm.GetComponent<BoxCollider>().enabled = false;
        rightArm.GetComponent<ArmContacts>().enabled = false;
        rightArm.GetComponent<BoxCollider>().enabled = false;
    }

    public void StopMinigame()
    {
        minigameScreen.SetActive(false);
        minigameOnOff = false;
        finishedMinigame = true;
    }

    public void BodyType(string bodyString)
    {
        bodyCode = bodyString;
    }

    public bool ReturnMinigameStatus()
    {
        return minigameOnOff;
    }

    public string ReturnBodyCode()
    {
        return bodyCode;
    }

    public void WeakPointListGet(string[] importedList)
    {
        weakPointList = new string[importedList.Length];

        if (importedList.Length == 2)
        {
            weakPointList[0] = importedList[0];
            weakPointList[1] = importedList[1];
        }
        else if (importedList.Length == 1)
        {
            weakPointList[0] = importedList[0];
        }
    }

    public string[] ReturnWeakPointList()
    {
        return weakPointList;
    }

    public bool HeadCheck()
    {
        headCheck = false;

        for (int i = 0; i < weakPointList.Length; i++)
        {
            if (weakPointList[i].Equals("Head"))
            {
                headCheck = true;
            }
        }

        return headCheck;
    }

    void BeginMinigame()
    {
        HeadCheck();
        
        if (bodyHealth <= 0)
        {
            StopMinigame();
        }
    }

    public void BodyHit()
    {
        bodyHealth--;
    }
}
