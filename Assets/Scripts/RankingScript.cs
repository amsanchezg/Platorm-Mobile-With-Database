using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Librería UI Unity
using UnityEngine.UI;

public class RankingScript : MonoBehaviour
{
    //Variables para acceder a los objetos Text
    public Text Puntos;

    //Método para poner los puntos en la UI
    public void PonerPuntos( string puntos)
    {
        Puntos.text = puntos;
    }
}
