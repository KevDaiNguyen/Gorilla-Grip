using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class MonkeyLeap : MonoBehaviour
{
    public GameObject monkeyObject;
    public Transform mainCamera;

    public ParticleSystem shockWave;

    public float damageAmount;

    private bool ifLeaped;
    private bool oldAirCheck;
    private bool oneJump;

    // Start is called before the first frame update
    void Start()
    {
        ifLeaped = false;
        oldAirCheck = false;
        oneJump = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F) && oneJump)
        {
            monkeyObject.GetComponent<Rigidbody>().AddForce(100 * mainCamera.forward + new Vector3(0,50,0), ForceMode.Impulse);
            ifLeaped = true;
            oneJump = false;
        }

        if(monkeyObject.GetComponent<RigidbodyFirstPersonController>().Grounded && !oldAirCheck)
        {
            if (ifLeaped) {
                shockWave.Play();
                ifLeaped = false;
            }
            oneJump = true;
        }
    }

    private void LateUpdate()
    {
        oldAirCheck = monkeyObject.GetComponent<RigidbodyFirstPersonController>().Grounded;
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponentInParent<EnemyHealth>().EnemyHit(damageAmount);
        }
    }
}
