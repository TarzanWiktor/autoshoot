using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasherController : MonoBehaviour
{
    //gracz
    GameObject player;
    //prędkość podążania za graczem
    public float walkSpeed;
    //odwolanie do levelManager
    GameObject levelManager;
    //flaga, która mówi czy został już trafiony i został za niego policzony punkt
    bool hasBeenHit = false;

    // Start is called before the first frame update
    void Start()
    {
        walkSpeed = 3;
        player = GameObject.FindGameObjectWithTag("Player");
        levelManager = GameObject.Find("LevelManager");
    }

    // Update is called once per frame
    void Update()
    {
        //patrz się na gracza
        transform.LookAt(player.transform.position);
        //idz do przodu
        transform.position += transform.forward * Time.deltaTime * walkSpeed;
    }
    private void OnCollisionEnter(Collision collision)
    {

        Debug.Log("Trafiony");

        GameObject projectile = collision.gameObject;

        if (projectile.CompareTag("PlayerProjectile"))
        {
            hasBeenHit = true;

            levelManager.GetComponent<LevelManager>().AddPoints(1);

            Destroy(projectile);

            Destroy(transform.gameObject);
        }
    }
}
