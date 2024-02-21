using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Transform player;

    Vector3 offset;

    Vector3 cameraSpeed;
    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player").transform;
    
        offset = transform.position - player.position; 
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = player.position + offset;

       // transform.position = Vector3.Lerp(transform.position, offset, Time.deltaTime);

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref cameraSpeed, 0.3f);
    }
}
