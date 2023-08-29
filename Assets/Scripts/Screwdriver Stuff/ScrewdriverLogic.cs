using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrewdriverLogic : MonoBehaviour
{
    public GameObject screwdriver;
    public List<GameObject> screwList;
    public GameObject[] conversionList;

    // Start is called before the first frame update
    void Start()
    {
        conversionList = GameObject.FindGameObjectsWithTag("Screws");

        for (int i = 0; i < conversionList.Length; i++)
        {
            screwList.Add(conversionList[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < screwList.Count; i++)
        {
            if (Vector3.Distance(screwList[i].transform.position, screwdriver.transform.position) < 5.5f)
            {
                Destroy(screwList[i]);
                screwList.RemoveAt(i);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Screws"))
        {
            Destroy(collision.gameObject);
        }
    }
}
