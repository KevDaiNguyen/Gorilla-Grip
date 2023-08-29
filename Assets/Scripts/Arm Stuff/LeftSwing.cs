using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftSwing : MonoBehaviour
{
    public GameObject leftArm;
    public GameObject rightArm;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            leftArm.GetComponent<BoxCollider>().enabled = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            leftArm.GetComponent<BoxCollider>().enabled = false;
        }
    }

}
