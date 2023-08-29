using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JarItems : MonoBehaviour
{
    public GameObject screwdriverHandle;
    public GameObject[] spawnItems;
    public GameObject[] jarList;

    public GameObject player;
    public PlayerHealth healthbar;
    public MinigameMode HUD;

    public int screwJar;

    // Start is called before the first frame update
    void Start()
    {
        screwJar = Random.Range(0,12);

        jarList[screwJar].GetComponent<JarFalling>().storedItem = screwdriverHandle;

        for (int i = 0; i < jarList.Length; i++)
        {
            if (i != screwJar)
            {
                jarList[i].GetComponent<JarFalling>().storedItem = spawnItems[Random.Range(0, 3)];
            }
        }
    }
}
