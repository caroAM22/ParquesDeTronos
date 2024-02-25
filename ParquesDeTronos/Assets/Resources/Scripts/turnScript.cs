using UnityEngine;
using System.Collections;
using TMPro;

public class turnScript : MonoBehaviour
{
    [SerializeField] private TMP_Text turnoText;
    public void ActualizarTurno(int jugadorActual)
    {
        if (jugadorActual == 1)
            turnoText.text = "TURNO DE LA CASA STARK";
        else if (jugadorActual == 2)
            turnoText.text = "TURNO DE LA CASA LANNISTER";
        else if (jugadorActual == 3)
            turnoText.text = "TURNO DE LA CASA TARGARYEN";
        else if (jugadorActual == 4)
            turnoText.text = "TURNO DE LA CASA BARATHEON";
        GameManager.Instance.StartCoroutine(EsperarYActualizarTurno(jugadorActual)); // Llama a la corrutina
    }

    IEnumerator EsperarYActualizarTurno(int jugadorActual)
    {
        yield return new WaitForSeconds(5f); // Espera 5 segundos
        // Actualiza el turno nuevamente después de 5 segundos
        turnoText.text = "";
    }
}
