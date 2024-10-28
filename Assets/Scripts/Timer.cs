using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TextoPuntos;
    float puntos;

    // Update is called once per frame
    void Update()
    {
        puntos += Time.deltaTime;
        int minutos = Mathf.FloorToInt(puntos / 60);
        int segundos = Mathf.FloorToInt(puntos % 60);
        TextoPuntos.text = "Tiempo sobrevivido: " + string.Format("{0:00}:{1:00}", minutos, segundos);
    }
}
