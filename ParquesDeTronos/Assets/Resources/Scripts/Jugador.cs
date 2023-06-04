using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador: MonoBehaviour
{
    public Nombre nombre;
    public List<GameObject> fichas;

    public GameObject nodo;
    public bool turno = false;
    public int puntaje = 0;
}
