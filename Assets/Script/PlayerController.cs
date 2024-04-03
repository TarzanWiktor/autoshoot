using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*float x = Input.GetAxisRaw("Horizontal");

        Vector3 movement = Vector3.right * x;


        float y = Input.GetAxisRaw("Vertical");

        movement += Vector3.forward * y ;

        movement = movement.normalized;

        movement *= Time.deltaTime;

        movement *= moveSpeed;*/

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 targetDirection = new Vector3(x, 0, y);
        Vector3 targetPosition = transform.position + targetDirection;
        if (targetDirection.magnitude > Mathf.Epsilon)
        {
            transform.LookAt(targetPosition);
            transform.position += transform.forward * Time.deltaTime * moveSpeed;
        }
    }

    public void Hit(GameObject other)
    {
        Debug.Log("Gracz trafiony");
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Gracz trafiony");
            GameObject.Find("LevelManager").GetComponent<LevelManager>().GameOver();
        }
    }
}
