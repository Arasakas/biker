using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{

    public float speed;
    public Transform[] waypoints;

    public int damageOnCollision = 20;

    // signification position de point
    private Transform target;
    // point de destination
    private int desPoint = 0;

    void Start()
    {
        target = waypoints[0];
    }

    
    void Update()
    {
        // la direction de l'ennemi
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        //Si l'ennemi est quasiment arrivé à sa destination
        if (Vector3.Distance(transform.position,target.position)<0.3f)
        {
            desPoint = (desPoint + 1) % waypoints.Length;
            target = waypoints[desPoint];
        }
    }

    // pour la 3D
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            BikerHealth bikerHealth = collision.transform.GetComponent<BikerHealth>();
            bikerHealth.TakeDamage(damageOnCollision);
        }
    }
}
