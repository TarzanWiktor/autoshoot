using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasherController : MonoBehaviour
{
    GameObject Player;

    public float walkSpeed = 1;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Player.transform.position);

        transform.position += transform.forward * Time.deltaTime * walkSpeed;
        
    }
}
