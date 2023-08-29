using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightSwing : MonoBehaviour
{
    public GameObject rightArm;
    public GameObject rightArmObject;

    public ItemPickup methodCalls;

    public Vector3 originalArms;
    public Vector3 originalRotation;
    public Vector3 holdingArms;
    public Vector3 holdingRotation;

    // Start is called before the first frame update
    void Start()
    {
        originalArms.Set(0,-0.5f,0.3f);
        originalRotation.Set(-50,0,0);
        holdingArms.Set(1.2f, -1.5f, -0.15f);
        holdingRotation.Set(-100, -150, 50);

    }

    // Update is called once per frame
    void Update()
    {
        if (methodCalls.holdingThing)
        {
            rightArm.transform.localPosition = holdingArms;
            rightArm.transform.localRotation = Quaternion.Euler(holdingRotation);
            //rightArmObject.GetComponent<BoxCollider>().enabled = false;
        }
        else
        {
            rightArm.transform.localPosition = originalArms;
            rightArm.transform.localRotation = Quaternion.Euler(originalRotation);
            //rightArmObject.GetComponent<BoxCollider>().enabled = true;
        }
    }
}
