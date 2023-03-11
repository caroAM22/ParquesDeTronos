using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlTablero : MonoBehaviour
{

    public int N_Jugadores;
    public GameObject assetTablero;

    void Start()
    {

        for(int i = 0; i < N_Jugadores; i++){

            GameObject instance = Instantiate(assetTablero, new Vector3(0,0,0), Quaternion.Euler(0,i*(360f/N_Jugadores),0));

            instance.transform.localScale = new Vector3(1,1,Mathf.Tan(180f/N_Jugadores*(Mathf.PI/180)));

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
