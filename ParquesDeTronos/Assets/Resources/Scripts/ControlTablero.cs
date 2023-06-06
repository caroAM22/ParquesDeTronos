using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlTablero : MonoBehaviour
{

    //Inicializar referencias
    private int N_Jugadores = Information.N_Jugadores;
    private int N_Fichas=Information.N_Fichas;
    private int N_Dados=Information.N_Dados;
    public int N_Caras=Information.N_Caras;
    public GameObject assetTablero;
    public GameObject assetFicha;
    public GameObject assetJugador;
    public List<GameObject> jugadores;
    public List<GameObject> nodos;

    void Start()
    {
        StartCoroutine(PartyLoader());
    }

    public void setN_Jugadores(int N_Jugadores)
    {
        this.N_Jugadores = N_Jugadores;
    }

    IEnumerator PartyLoader(){

        //Crear los nodos en las posiciones establecidas
        //Añadir referencias a jugadores y nodos

        for(int i = 0; i < N_Jugadores; i++){

            GameObject instance = Instantiate(assetTablero, new Vector3(0, 1.21f, 0), Quaternion.Euler(0, i*(360f/N_Jugadores), 0));

            instance.transform.localScale = new Vector3(Mathf.Tan(180f/N_Jugadores*(Mathf.PI/180)), 1, 1);

            nodos.Add(instance);
            
        }

        //Acceder a las casillas de los nodos y cambiar su material
        for(int i = 0; i < N_Jugadores; i++){

            // Confirmar existencia de objetos
            nodos[i].GetComponent<Nodo>().casillasTematicas.ForEach(x => Debug.Log(x));

            //Esperar hasta que se hayan realizado las referencias a los objetos Material de las casillas
            foreach(GameObject x in nodos[i].GetComponent<Nodo>().casillasTematicas){

                yield return new WaitUntil(() => x.GetComponent<Casilla>().material != null);
            }

            foreach(GameObject x in nodos[i].GetComponent<Nodo>().bases){

                yield return new WaitUntil(() => x.GetComponent<Base>().material != null);
            }
            

            // Cambia la textura por un color al azar CAMBIAR A TEXTURA DE TEMATICA
            Color newColor = new Color( Random.value, Random.value, Random.value, 1.0f);

            nodos[i].GetComponent<Nodo>().casillasTematicas.ForEach(x => x.GetComponent<Casilla>().material.color = newColor);
            nodos[i].GetComponent<Nodo>().bases.ForEach(x => x.GetComponent<Base>().material.color = newColor);

            
            List<GameObject> fichas = new List<GameObject>();

            // Crea cada ficha, Espera a que tenga referencia a su Material y lo cambia segun el color anteriormente definido
            for(int j = 0; j < N_Fichas; j++){

                GameObject instanceFicha = Instantiate(assetFicha, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));

                yield return new WaitUntil(() => instanceFicha.GetComponent<Ficha>().material != null);
                instanceFicha.GetComponent<Ficha>().material.color = newColor;
                
                fichas.Add(instanceFicha);
            }
            
            GameObject jugador = Instantiate(assetJugador, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));

            jugador.GetComponent<Jugador>().fichas = fichas;

            jugador.GetComponent<Jugador>().nombre = (Nombre)i;

            jugador.GetComponent<Jugador>().nodo = nodos[i];

            jugadores.Add(jugador);

            for(int j = 0; j < N_Fichas; j++){

                fichas[j].transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
                fichas[j].transform.rotation = Quaternion.Euler(-90, 0, 0);

                fichas[j].transform.position = jugador.GetComponent<Jugador>().nodo.GetComponent<Nodo>().bases[j].GetComponent<Base>().render.bounds.center;
            }
            

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
