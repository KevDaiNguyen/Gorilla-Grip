using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBodyParts : MonoBehaviour
{
    public Material[] Robo;
    public Material[] MDoll;
    public Material[] FDoll;

    public MinigameMode methodCalls;
    

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < Robo.Length; i++)
        {
            MDoll[i].SetColor("_Color", Color.white);
            Robo[i].SetColor("_Color", Color.white);
            FDoll[i].SetColor("_Color", Color.white);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < methodCalls.weakPointList.Length; i++)
        {
            if (methodCalls.bodyCode.Equals("R"))
            {
                switch (methodCalls.weakPointList[i])
                {
                    case "Head":
                        Robo[0].SetColor("_Color", Color.yellow);
                        break;
                    case "Torso":
                        Robo[1].SetColor("_Color", Color.yellow);
                        break;
                    case "Right Arm":
                        Robo[2].SetColor("_Color", Color.yellow);
                        break;
                    case "Left Arm":
                        Robo[3].SetColor("_Color", Color.yellow);
                        break;
                    case "Right Leg":
                        Robo[4].SetColor("_Color", Color.yellow);
                        break;
                    case "Left Leg":
                        Robo[5].SetColor("_Color", Color.yellow);
                        break;
                }
            }
            else if (methodCalls.bodyCode.Equals("M"))
            {
                switch (methodCalls.weakPointList[i])
                {
                    case "Head":
                        MDoll[0].SetColor("_Color", Color.red);
                        break;
                    case "Torso":
                        MDoll[1].SetColor("_Color", Color.red);
                        break;
                    case "Right Arm":
                        MDoll[2].SetColor("_Color", Color.red);
                        break;
                    case "Left Arm":
                        MDoll[3].SetColor("_Color", Color.red);
                        break;
                    case "Right Leg":
                        MDoll[4].SetColor("_Color", Color.red);
                        break;
                    case "Left Leg":
                        MDoll[5].SetColor("_Color", Color.red);
                        break;
                }
            }
            else if (methodCalls.bodyCode.Equals("F"))
            {
                switch (methodCalls.weakPointList[i])
                {
                    case "Head":
                        MDoll[0].SetColor("_Color", Color.red);
                        break;
                    case "Torso":
                        MDoll[1].SetColor("_Color", Color.red);
                        break;
                    case "Right Arm":
                        MDoll[2].SetColor("_Color", Color.red);
                        break;
                    case "Left Arm":
                        MDoll[3].SetColor("_Color", Color.red);
                        break;
                    case "Right Leg":
                        MDoll[4].SetColor("_Color", Color.red);
                        break;
                    case "Left Leg":
                        MDoll[5].SetColor("_Color", Color.red);
                        break;
                }
            }
        }

        if (methodCalls.finishedMinigame)
        {
            for (int i = 0; i < Robo.Length; i++)
            {
                MDoll[i].SetColor("_Color", Color.white);
                Robo[i].SetColor("_Color", Color.white);
                FDoll[i].SetColor("_Color", Color.white);
            }
        }
    }

    public void OnApplicationQuit()
    {
        for (int i = 0; i < Robo.Length; i++)
        {
            MDoll[i].SetColor("_Color", Color.white);
            Robo[i].SetColor("_Color", Color.white);
            FDoll[i].SetColor("_Color", Color.white);
        }
    }
}
