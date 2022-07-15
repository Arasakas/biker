using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPowerUp : MonoBehaviour
{

    public int healthPoints;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //rendre de la vie au joueur
            if (BikerHealth.instance.currentHealth != BikerHealth.instance.maxHealth)
            {
                // ne detroye pas le points de la scene
                BikerHealth.instance.HealPlayer(healthPoints);
                Destroy(gameObject);
            }
        }
           
    }
}
