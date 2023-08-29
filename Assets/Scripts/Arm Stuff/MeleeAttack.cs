using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public GameObject leftObject;
    public GameObject rightObject;

    public Animation leftArm;
    public Animation rightArm;

    public int leftSwing = 1;
    public float swingDelay;
    public bool canSwing;

    // Start is called before the first frame update
    void Start()
    {
        canSwing = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canSwing)
        {
            if(leftSwing > 0)
            {
                leftObject.GetComponent<Animator>().enabled = true;
                leftObject.GetComponentInChildren<ArmContacts>().enabled = true;
                StartCoroutine(SwingTime(swingDelay, leftObject, "Leftarm", leftArm));
                leftSwing *= -1;
            }
            else if (leftSwing < 0)
            {
                leftObject.GetComponent<Animator>().enabled = true;
                rightObject.GetComponentInChildren<ArmContacts>().enabled = true;
                StartCoroutine(SwingTime(swingDelay, rightObject, "Rightarm", rightArm));
                leftSwing *= -1;
            }
            
            StartCoroutine(SwingCooldown(swingDelay));
        }
    }

    public IEnumerator SwingTime(float delayTime, GameObject arm, string armType, Animation armAnimation)
    {
        //armAnimation.wrapMode = WrapMode.Once;
        //armAnimation.Play(armType);
        yield return new WaitForSeconds(delayTime);
        arm.GetComponent<Animator>().enabled = false;
        arm.GetComponentInChildren<ArmContacts>().enabled = false;
        canSwing = false;
    }

    public IEnumerator SwingCooldown(float delayTime)
    {
        delayTime *= 2f;
        yield return new WaitForSeconds(delayTime);
        canSwing = true;
    }

}
