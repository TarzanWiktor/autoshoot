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
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        
        Vector3 movement = Vector3.right * x * Time.deltaTime;

        movement += Vector3.forward * y * Time.deltaTime;

        movement = movement.normalized;

        movement *= moveSpeed;

        transform.position += movement;
    }
}
