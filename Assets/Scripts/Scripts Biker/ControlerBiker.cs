using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class ControlerBiker : MonoBehaviour
{

    [SerializeField]
    private float RSpeed = 10.0f;
    [SerializeField]
    private float deplaceSpeed;
    private float currentSpeed = 0;
   
   
    void Start()
    {

        
        // se remet la position lorsque on le déplace sur le montage
        transform.position = new Vector3(0, 0.1f, 0);
    }

   
    void Update()
    {

        //// vas de droite à gauche pour le déplacement avec le clavier
        float horizontalMove = Input.GetAxis("Horizontal") * RSpeed * Time.deltaTime;
        transform.position += transform.right * horizontalMove;
        

        // Evite de traverser la map
        if (transform.position.y < 1)
        {
            transform.position = new Vector3(transform.position.x, 0.1f, transform.position.z);
        }

        //Limite les déplacements horiaontaux vers la gauche
        if (transform.position.x < -4)
        {
            transform.position = new Vector3(-4, transform.position.y, transform.position.z);
        }

        //Limite les déplacements horiaontaux vers la droite
        if (transform.position.x > 4)
        {
            transform.position = new Vector3(4, transform.position.y, transform.position.z);
        }

        //Déplacement vers l'avant
        if (Input.GetButton("Fire1"))
        {
            currentSpeed += 0.1f * Time.deltaTime;
            if (currentSpeed > deplaceSpeed)
            {
                currentSpeed = deplaceSpeed;
            }
                       
        }
        else
        {
            if (currentSpeed > 0)
            {
                currentSpeed -= 0.1f * Time.deltaTime;
                if (currentSpeed < 0)
                {
                    currentSpeed = 0;
                }
            }

        }

        //Déplacement marche arrière de la moto
        if (Input.GetButton("Fire2"))
        {
            currentSpeed -= 0.1f * Time.deltaTime;
            if (currentSpeed > deplaceSpeed)
            {
                currentSpeed = deplaceSpeed;
            }
        }

        //axe bleu
        transform.position += transform.forward * currentSpeed;

    }


    

    private void OnCollisionEnter(Collision collision)
    {
        
        if (ControlerGame.Direct.ChocVitesse > 0)
        {
            ControlerGame.Direct.ChocVitesse -= 10;
            if (ControlerGame.Direct.ChocVitesse <= 0)
            {
                
            }
        }

    }

}
