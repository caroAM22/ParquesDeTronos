using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casilla : MonoBehaviour
{
    public int position;
    public Material material;

    // Start is called before the first frame update
    void Start()
    {

        material = GetComponent<Renderer>().material;
        Debug.Log("READY");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
