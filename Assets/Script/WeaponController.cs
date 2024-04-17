using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class WeaponController : MonoBehaviour
{

    public float range = 15f;

    Transform player;

    public GameObject projectilePrefab;

    Transform projectileSpawn;

    public float rateOfFire = 1;

    float timeSinceLastFire = 0;

    public float projectileForce = 20;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;

        projectileSpawn = transform.Find("ProjectileSpawn").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Transform target = TagTargeter("Enemy");
        if(target != transform)
        {
            //sworz target w miecu celu ale na wysokosci wierzyczki
            Vector3 newTarget = new Vector3(target.position.x, projectileSpawn.position.y, target.position.z);
            // Debug.Log(target.gameObject.name);
            transform.LookAt(newTarget);

            if(timeSinceLastFire > rateOfFire)
            {
                GameObject projectile = Instantiate(projectilePrefab, projectileSpawn.position, Quaternion.identity);


                Rigidbody projectileRB = projectile.GetComponent<Rigidbody>();

                projectileRB.AddForce(projectileSpawn.transform.forward * projectileForce, ForceMode.VelocityChange);

                timeSinceLastFire = 0;

                Destroy(projectile, 5);
            } else
            {
                timeSinceLastFire += Time.deltaTime;
            }
        }
    }

    Transform TagTargeter(string tag)
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag(tag);

        Transform closestTarget = transform;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject target in targets)
        {
            Vector3 difference = target.transform.position - player.position;

            float distance = difference.magnitude;
            if (distance<closestDistance && distance < range)
            {
                closestTarget = target.transform;
                closestDistance = distance;
            }
        }

        return closestTarget;
    }



    Transform LegacyTargeter()
{
     Collider[] collidersInRange = Physics.OverlapSphere(transform.position, range);


    Transform target = transform;
    float targetDistance = Mathf.Infinity;

        foreach (Collider collider in collidersInRange)
        {
            GameObject model = collider.gameObject;


            if (model.transform.parent != null)
            {
                GameObject enemy = model.transform.parent.gameObject;

                if (enemy.CompareTag("Enemy"))
                {
                    Vector3 diference = player.position - enemy.transform.position;

                    float distance = diference.magnitude;
                    if (distance<targetDistance)
                    {
                        target = enemy.transform;
                        targetDistance = distance;
                    }
                }
            }


        }

        // Debug.Log("Ilo�� collider�w w zasi�gu broni: " + collidersInRange.Length);
        // Debug.Log("Celuje do:" + target.gameObject.name);
    return target;
    }
}


