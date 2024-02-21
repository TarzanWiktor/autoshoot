using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        
        Vector3 movement = Vector3.right * x ;

        movement += Vector3.forward * y ;

        movement = movement.normalized;

        movement *= Time.deltaTime;

        movement *= moveSpeed;

        transform.position += movement;
    }
}
