using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;   

public class ArmContacts : MonoBehaviour
{
    private NavMeshAgent enemy;
    public Transform camera;

    public float damageValue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            if (collision.gameObject.GetComponentInParent<NavMeshAgent>())
            {
                enemy = collision.gameObject.GetComponentInParent<NavMeshAgent>();

                collision.gameObject.GetComponentInParent<EnemyHealth>().EnemyHit(damageValue);
            }

        }
        else if(collision.gameObject.CompareTag("Interactable") || collision.gameObject.CompareTag("Jars"))
        {
            collision.rigidbody.AddForce(new Vector3(0, 250, 0) + camera.forward * 250, ForceMode.Impulse);
        }
    }
}
