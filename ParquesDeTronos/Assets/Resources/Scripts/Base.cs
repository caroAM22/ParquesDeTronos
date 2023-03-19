using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    public Material material;

    public Renderer render;

    void Start()
    {
        material = GetComponent<Renderer>().material;

        render =  GetComponent<Renderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
