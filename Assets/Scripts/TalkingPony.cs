using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkingPony : MonoBehaviour
{
    public GameObject pony;
    public GameObject player;

    public Vector3 upwards;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pony.transform.LookAt(player.transform.position, upwards);
    }
}
