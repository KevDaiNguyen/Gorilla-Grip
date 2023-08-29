using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutletLogic : MonoBehaviour
{
    public GameObject outletPlate;
    public GameObject plug;
    public int numOfDestroyedScrews;

    // Start is called before the first frame update
    void Start()
    {
        numOfDestroyedScrews = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (numOfDestroyedScrews >= 4)
        {
            Destroy(outletPlate);
            Destroy(plug);
        }
    }

    public void IncreaseCount()
    {
        numOfDestroyedScrews++;
    }
}
