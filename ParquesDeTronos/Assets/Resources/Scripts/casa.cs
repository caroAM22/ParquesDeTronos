using System.Collections.Generic;
using UnityEngine;

public class casa : MonoBehaviour
{
    // Define un enum para las casas
    public enum House
    {
        STARK,
        LANNISTER,
        TARGARYEN,
        BARATHEON
    }

    // Define un diccionario que mapea las casas a los colores RGB
    public static Dictionary<House, Color32> houseColors = new Dictionary<House, Color32>()
    {
        { House.STARK, new Color32(169, 169, 169, 255) },   // Gris para Stark
        { House.LANNISTER, new Color32(255, 0, 0, 255) },    // Rojo para Lannister
        { House.TARGARYEN, new Color32(255, 215, 0, 255) },  // Dorado para Targaryen
        { House.BARATHEON, new Color32(0, 128, 0, 255) }     // Verde para Baratheon
    };
}
