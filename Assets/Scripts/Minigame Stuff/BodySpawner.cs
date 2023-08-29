using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodySpawner : MonoBehaviour
{
    public Material[] Robo;
    public Material[] MDoll;
    public Material[] FDoll;

    public GameObject[] spawnPoints;
    public GameObject HUD;
    public bool minigameOnOff;
    public string whichBody;

    // Start is called before the first frame update
    void Start()
    {
        minigameOnOff = false;
        whichBody = null;
    }

    // Update is called once per frame
    void Update()
    {
        minigameOnOff = HUD.GetComponent<MinigameMode>().ReturnMinigameStatus();

        whichBody = HUD.GetComponent<MinigameMode>().ReturnBodyCode();

        if (minigameOnOff)
        {
            if (whichBody.Equals("R"))
            {
                for (int i = 0; i < spawnPoints.Length; i++)
                {
                    spawnPoints[i].GetComponent<MeshRenderer>().material = Robo[i];
                }
            }
            else if (whichBody.Equals("M"))
            {
                for (int i = 0; i < spawnPoints.Length; i++)
                {
                    spawnPoints[i].GetComponent<MeshRenderer>().material = MDoll[i];
                }
            }
            else if (whichBody.Equals("F"))
            {
                for (int i = 0; i < spawnPoints.Length; i++)
                {
                    spawnPoints[i].GetComponent<MeshRenderer>().material = FDoll[i];
                }
            }
        }
    }
}
