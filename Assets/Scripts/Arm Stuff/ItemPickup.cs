using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public GameObject player;
    public GameObject camObject;
    public GameObject rightArm;

    public GameObject crosshair;
    public GameObject prompt;
    
    public RaycastHit hitObject;
    private RaycastHit pickableItem;

    public bool holdingThing;

    private Vector3 oldScaling = Vector3.zero;
    private Transform cameraTransform;
    private bool screwdriver;
    private bool pickUpAble;

    // Start is called before the first frame update
    void Start()
    {
        holdingThing = false;
        screwdriver = false;
        pickUpAble = false;
        cameraTransform = camObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        bool hitThing = Physics.SphereCast(player.transform.position, 3, camObject.transform.forward, out hitObject);

        if (hitThing)
        {
            screwdriver = hitObject.collider.CompareTag("Screwdriver");

            pickUpAble = hitObject.collider.CompareTag("PickUp");
        }

        if (screwdriver || pickUpAble)
        {
            pickableItem = hitObject;
            
            if (hitObject.distance < 1 && !holdingThing)
            {
                prompt.gameObject.SetActive(true); 
                
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Vector3 holdingPosition = cameraTransform.position;

                    hitObject.transform.position.Set(holdingPosition.x, holdingPosition.y, holdingPosition.z);
                    
                    oldScaling.Set(hitObject.transform.localScale.x, hitObject.transform.localScale.y, hitObject.transform.localScale.z);

                    hitObject.transform.localScale = new Vector3(hitObject.transform.localScale.x * 0.2f, hitObject.transform.localScale.y * 0.2f, hitObject.transform.localScale.z * 0.2f);
                    hitObject.collider.gameObject.AddComponent<FixedJoint>();
                    hitObject.collider.GetComponent<FixedJoint>().connectedBody = rightArm.GetComponent<Rigidbody>();

                    holdingThing = true;
                    crosshair.gameObject.SetActive(true);
                    prompt.gameObject.SetActive(false); 
                }
            }
            else
            {
                prompt.gameObject.SetActive(false);
            }
        }
        
        if (Input.GetMouseButtonDown(1) && holdingThing)
        {
            hitObject.rigidbody.isKinematic = false;
            crosshair.gameObject.SetActive(false);
            ThrowItem(oldScaling, pickableItem);
        }
    }

    public void ThrowItem(Vector3 originalSize, RaycastHit objectHit)
    {
        rightArm.transform.DetachChildren();
        FixedJoint objectsJoint = objectHit.collider.GetComponent<FixedJoint>();
        Destroy(objectsJoint);
        objectHit.transform.localScale = originalSize;
        objectHit.rigidbody.AddForce(new Vector3(0, 150, 0) + camObject.GetComponent<Transform>().forward * 800, ForceMode.Impulse);

        holdingThing = false;
    }
}
