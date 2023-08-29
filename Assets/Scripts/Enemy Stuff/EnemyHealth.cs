using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    public GameObject enemy;
    private float startingHealth;
    public float enemyHealth;
    private float prevHealth;

    public GameObject torso;
    public AudioSource pain;

    public Image healthbar;

    public GameObject[] weakPointList;
    public GameObject hitEffect;

    public bool stunnedState = false;

    public int headChace = 1;
    public int numOfWeakPoints;
    public int[] weakPoints;
    public string[] weaknessNames;

    // Start is called before the first frame update
    void Start()
    {
        startingHealth = enemyHealth;
        numOfWeakPoints = Random.Range(1, 3);
        weakPoints = new int[numOfWeakPoints];
        for (int i = 0; i < numOfWeakPoints; i++)
        {
            weakPoints[i] = Random.Range(1, weakPointList.Length);
            if (i == 2)
            {
                if (weakPoints[i] == weakPoints[i-1])
                {
                    weakPoints[i] = Random.Range(1, weakPointList.Length);
                }
            }
            else if (numOfWeakPoints == 1)
            {
                if (headChace == Random.Range(0,10)) 
                {
                    weakPoints[i] = 0;
                }
            }
            
            
        }
   
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth < prevHealth)
        {
            hitEffect.GetComponent<ParticleSystem>().Play();
            healthbar.fillAmount = enemyHealth / startingHealth;
            prevHealth = enemyHealth;
        }

        if (enemyHealth <= 0)
        {
            for (int i = 0; i < weakPoints.Length; i++)
            {
                weakPointList[weakPoints[i]].GetComponent<Outline>().enabled = true;
            }

            stunnedState = true;
        }
    }

    private void LateUpdate()
    {
        prevHealth = enemyHealth;
    }

    public void EnemyHit(float damage)
    {
        enemyHealth -= damage;
        pain.Play();
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Screwdriver") || collision.gameObject.CompareTag("PickUp"))
        {
            EnemyHit(100);
            stunnedState = true;
        }
    }*/


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Screwdriver") || other.gameObject.CompareTag("PickUp"))
        {
            EnemyHit(100);
            stunnedState = true;
        }
    }

    public string[] ReturnWeakPointList()
    {
        weaknessNames = new string[weakPoints.Length];

        for (int i = 0; i < weakPoints.Length; i++)
        {
            weaknessNames[i] = weakPointList[weakPoints[i]].name;
        }

        return weaknessNames;
    }

    public void Dead()
    {   
        Destroy(enemy.GetComponent<NavMeshAgent>());
        Destroy(healthbar);

        for (int i = 0; i < weakPointList.Length; i++)
        {
            Destroy(weakPointList[i].GetComponent<FixedJoint>());
            if (weakPointList[i].GetComponent<Outline>().isActiveAndEnabled)
            {
                weakPointList[i].tag = "PickUp";
            }
        }

        for (int i = 0; i < weakPointList.Length; i++)
        {
            if (!weakPointList[i].CompareTag("PickUp"))
            {
                Destroy(weakPointList[i], 3);
            }
        }
        Destroy(torso, 3);
    }
}
