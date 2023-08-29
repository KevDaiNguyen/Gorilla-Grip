using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldParticles : MonoBehaviour
{
    public ParticleSystem attackLeft;
    public ParticleSystem holdRight;

    public ItemPickup holdingThingy;
    public MinigameMode hudMethodCalls; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (holdingThingy.holdingThing)
        {
            holdRight.Play();

            if (Input.GetMouseButtonDown(0))
            {
                attackLeft.Play();
            }
        }
        else
        {
            holdRight.Stop();

            if (Input.GetMouseButtonDown(0) && !hudMethodCalls.minigameOnOff)
            {
                attackLeft.Play();
            }
        }
    }
}
