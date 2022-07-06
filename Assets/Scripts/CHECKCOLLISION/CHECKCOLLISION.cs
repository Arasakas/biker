using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CHECKCOLLISION : MonoBehaviour
{

    Rigidbody m_Rigidbody;
    public float m_Thrust = 20f;
    // Start is called before the first frame update
    void Start()
    {

        m_Rigidbody = GetComponent<Rigidbody>();
        //GetComponent<Collider>().attachedRigidbody.AddForce(0, 1, 0);
    }

    // Update is called once per frame
    void FixeUpdate()
    {
        m_Rigidbody.AddForce(transform.up * m_Thrust);
    }

    // fonction solides
    private static void OnCollisionEnter(Collision collision)
    {
      

        Debug.Log("Meme pas mal");
    }

   
       
    
}
