using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    Transform player;


    public GameObject basherPrefab;

    public float spawnInterval = 1;

    float spawnDistance = 20;

    float timeSinceSpawn;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceSpawn += Time.deltaTime;

        if(timeSinceSpawn > spawnInterval) 
        {
            Vector2 random = Random.insideUnitCircle.normalized;

            Vector3 randomPosition = new Vector3(random.x, 0, random.y);


            // Vector3 randomPosition = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));

            randomPosition *= spawnDistance;

            randomPosition += player.position;

            if(Physics.CheckSphere(new Vector3(randomPosition.x, 1, randomPosition.z), 0.5f))
            {
                Instantiate(basherPrefab, randomPosition, Quaternion.identity);

                timeSinceSpawn = 0;
            }


        }
        
        //TODO: opracowaæ sposób na przyspieszenie spawnu w nieskoñczonoœæ

    }
}
