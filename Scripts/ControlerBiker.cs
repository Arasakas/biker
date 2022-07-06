using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlerBiker : MonoBehaviour
{

    [SerializeField]
    private float Speed = 10.0f;
    [SerializeField]
    private float toSpeed;
    private float currentSpeed = 0;

    // Start is called before the first frame update
    void Start()
    {
        // se remet la position lorsque on le déplace sur le montage
        transform.position = new Vector3(0, 0f, 0);
    }

    // Update is called once per frame
    void Update()
    {

        // vas de droite à gauche pour le déplacement avec le clavier
        float horizontalMove = Input.GetAxis("Horizontal") * Speed * Time.deltaTime;
        transform.position += transform.right * horizontalMove;

        //Limite les déplacements horiaontaux vers la gauche
        if (transform.position.x<-4)
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
            if(currentSpeed>toSpeed)
            {
                currentSpeed = toSpeed;
            }
          
        }
        else
        {
            if (currentSpeed>0)
            {
                currentSpeed -= 0.1f * Time.deltaTime;
                if(currentSpeed<0)
                {
                    currentSpeed = 0;
                }
            }
        }

        transform.position += transform.forward * currentSpeed;
     
    }
}
