using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    // temps invincibilité aprés d'être touché
    public float invincibilityTimeAfterHit = 3f;
    public bool isInvincible = false;

   
    public HealthBar healthBar;

    public static BikerHealth instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de BikerHealth dans la scene");
            return;
        }
        instance = this;
    }

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    
    void Update()
    {
        ////teste la barre de vie
        //if (Input.GetKeyDown(KeyCode.H))
        //{
        //    TakeDamage(20);
        //}
    }

    // rendre la vie au joueur
    public void HealPlayer(int amount)
    {
        if((currentHealth+amount)> maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth += amount;
        }

        healthBar.SetHealth(currentHealth);
    }

    // Un dégat peu importe qui le fera
    public void TakeDamage(int damage)
    {

        if(!isInvincible)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);

            //Verifier si le joueur est toujours vivant
            if (currentHealth <= 0)
            {
                Die();
                return;
            }


            isInvincible = true;
            StartCoroutine(HandleInvincibilityDelay());
        }
      
    }

    public void Die()
    {
        //Debug.Log("Le joueur est éliminé");

        //Bloquer les mouvements du personnage
        ControlerBiker.instance.enabled = false;

        //Scene Gameover
        GameOverManager.instance.OnBikerHealth();
       
    }

    public void Respawn()
    {
        //Bloquer les mouvements du personnage
        ControlerBiker.instance.enabled = true;
        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);
    }

    public IEnumerator HandleInvincibilityDelay()
    {
        yield return new WaitForSeconds(invincibilityTimeAfterHit);
        isInvincible = false;
    }
      
}
