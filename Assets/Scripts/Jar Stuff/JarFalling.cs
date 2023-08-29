using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JarFalling : MonoBehaviour
{
    public GameObject regularJar;
    public GameObject brokenJar;
    public GameObject storedItem;

    public JarItems methodCalling;

    public float despawnTime;
    public bool shouldBreak;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldBreak)
        {
            if (!storedItem.CompareTag("Screwdriver"))
            {
                GameObject spawnedEnemy = Instantiate(storedItem);
                spawnedEnemy.GetComponent<EnemyMovement>().warpedPosition = regularJar.transform.position;
                spawnedEnemy.GetComponent<EnemyMovement>().gorillaTarget = methodCalling.player;
                spawnedEnemy.GetComponent<EnemyMovement>().HUD = methodCalling.HUD;
                spawnedEnemy.GetComponent<EnemyMovement>().methodCalls = methodCalling.healthbar;
            }
            else
            {
                Instantiate(storedItem, regularJar.transform.position, regularJar.transform.rotation);
            }
            

            GameObject newJar = Instantiate(brokenJar, regularJar.transform.position, regularJar.transform.rotation);
            Destroy(regularJar);
            Destroy(newJar, despawnTime);

        }
    }

    public void BreakCheck()
    {
        shouldBreak = true;
    }
}
