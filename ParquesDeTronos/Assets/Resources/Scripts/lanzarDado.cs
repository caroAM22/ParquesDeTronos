using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class lanzarDado : MonoBehaviour
{
    [SerializeField] private Button _lanzarButton;
    private turnScript _turnScript;
    private float tiempoEspera = 5f; // Tiempo de espera en segundos
    private void Start()
    {
        _lanzarButton.onClick.AddListener(lanzarButtonClicked);
        _turnScript = GetComponent<turnScript>();
    }

    public void lanzarButtonClicked()
    {
        _lanzarButton.interactable = false;
        GameManager.Instance.movimiento();
        StartCoroutine(EsperarYActivarBoton(tiempoEspera)); // Llamar a la corrutina para esperar y activar el botón
    }

    IEnumerator EsperarYActivarBoton(float tiempo)
    {
        yield return new WaitForSeconds(tiempo); // Esperar el tiempo especificado
        _turnScript.ActualizarTurno(GameManager.Instance.getJugadorActual()); // Actualizar el turno
        _lanzarButton.interactable = true; // Activar el botón nuevamente
    }
}