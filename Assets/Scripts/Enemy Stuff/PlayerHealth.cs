using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public GameObject player;
    public GameObject healthbar;
    private Rigidbody methodCalls;

    public AudioSource pain;

    public Sprite[] barList;

    private int prevHealth;
    public int healthNum;

    public bool inMinigame;

    // Start is called before the first frame update
    void Start()
    {
        methodCalls = player.GetComponent<Rigidbody>();

        inMinigame = false;
        healthNum = 8;
        prevHealth = healthNum;
        healthbar.gameObject.GetComponent<Image>().overrideSprite = barList[healthNum];
    }

    // Update is called once per frame
    void Update()
    {
        if (prevHealth > healthNum && healthNum > 0)
        {
            healthbar.gameObject.GetComponent<Image>().overrideSprite = barList[healthNum];
            prevHealth = healthNum;
        }
        else if (healthNum <= 0)
        {
            healthbar.gameObject.GetComponent<Image>().overrideSprite = barList[0];
            Cursor.visible = true;
            Cursor.lockState = 0;
            SceneManager.LoadScene("GameOver");
        }
    }

    public void TakeDamage()
    {
        if (!inMinigame)
        {
            healthNum--;
            pain.Play();
        }
    }

    public void MinigameReset()
    {
        healthNum = 8;
        prevHealth = 8;
        healthbar.gameObject.GetComponent<Image>().overrideSprite = barList[healthNum];
    }

    public void DamageKnockback(Vector3 direciton)
    {
        methodCalls.AddForce(direciton * 40 + new Vector3(0,20,0), ForceMode.Impulse);
    }
}
