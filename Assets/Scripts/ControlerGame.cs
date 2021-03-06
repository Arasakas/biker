using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ControlerGame : MonoBehaviour
{
    public static ControlerGame Direct;

    [SerializeField]
    private GameObject[] SolPrefabs;

    private GameObject[] SolGames;

    [SerializeField]
    public int ChocVitesse;

    private GameObject Biker;

    private float SolSize;

    private int NumberSol = 4;

   
    private void Awake()
    {
        if (Direct != null)
        {
            Destroy(gameObject);
        }
        Direct = this;

        ChocVitesse = 10;
    }

   
    void Start()
    {
        Biker = GameObject.Find("Biker");

        SolGames = new GameObject[NumberSol];

        for (int i = 0; i < NumberSol; i++)
        {
            //entre 0 et 4
            int n = Random.Range(0, SolPrefabs.Length);
            SolGames[i] = Instantiate(SolPrefabs[n]);
        }

        //taille de la route
        SolSize = SolGames[0].GetComponentInChildren<Transform>().Find("Terrain").localScale.z;

        float pos = Biker.transform.position.z + SolSize / 2 - 1.5f;
        foreach (var sol in SolGames)
        {
            sol.transform.position = new Vector3(0, 0f, pos);
            pos += SolSize;//avance de 30 cases
        }

    }

    
    void Update()
    {
        for (int i = SolGames.Length - 1; i >= 0; i--)
        {
            GameObject sol = SolGames[i];

            if (sol.transform.position.z + SolSize / 2 < Biker.transform.position.z - 6f)
            {
                float z = sol.transform.position.z;
                Destroy(sol);
                int n = Random.Range(0, SolPrefabs.Length);
                sol = Instantiate(SolPrefabs[n]);
                sol.transform.position = new Vector3(0, 0.2f, z + SolSize * NumberSol);
                SolGames[i] = sol;
            }
        }
    }

    private void OnDestroy()
    {
        Direct = null;
    }
   
   

}
