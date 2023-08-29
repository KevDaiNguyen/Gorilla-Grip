using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrewdriverJoin : MonoBehaviour
{
    private GameObject screwdriverHandle;
    public GameObject screwdriverTip;

    public bool handleFound;

    public GameObject fixedScrewdriver;

    public GameObject[] storedItems;
    public GameObject jarObject;
    public GameObject jarSpawner;
    public GameObject player;
    public PlayerHealth healthBar;
    public MinigameMode HUD;
    public int countDown;

    // Start is called before the first frame update
    void Start()
    {
        handleFound = false;
        countDown = 0;
    }

    // Update is called once per frame
    void Update()
    {
        screwdriverHandle = GameObject.FindGameObjectWithTag("Screwdriver");

        if (screwdriverHandle != null)
        {
            handleFound = true;

            if (Vector3.Distance(screwdriverTip.transform.position, screwdriverHandle.transform.position) < 5)
            {
                GameObject joinedScrewdriver = Instantiate(fixedScrewdriver, screwdriverTip.transform.position + new Vector3(0,3,0), screwdriverTip.transform.rotation);
                Destroy(screwdriverHandle);
                Destroy(screwdriverTip);
            }

            countDown = Random.Range(0, 1000000);
            if (countDown == 8888)
            {
                //SummonJars();
            }
            
        }
    }

    void SummonJars()
    {
        int randomNum = Random.Range(0, 3); 
        
        storedItems[randomNum].GetComponent<EnemyMovement>().gorillaTarget = player;
        storedItems[randomNum].GetComponent<EnemyMovement>().HUD = HUD;
        storedItems[randomNum].GetComponent<EnemyMovement>().methodCalls = healthBar;
        
        jarObject.GetComponent<JarFalling>().storedItem = storedItems[randomNum];
  
       Instantiate(jarObject, jarSpawner.transform.position, jarObject.transform.rotation);
    }
}
