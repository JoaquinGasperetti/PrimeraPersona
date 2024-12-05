using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject jugadorPrefab; // Asigna el prefab del jugador en el Inspector.
    public GameObject canvasMenu; // Asigna el canvas del men� en el Inspector.
    public GameObject canvasTimerPrefab; // Asigna el prefab del canvas del timer en el Inspector.

    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void VolverMenu()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }

    public void Jugar()
    {
        // Destruir el canvas del men�.
        Destroy(canvasMenu);

        // Instanciar el canvas del timer.
        Instantiate(canvasTimerPrefab);

        // Coordenadas espec�ficas para instanciar al jugador.
        Vector3 spawnPosition = new Vector3(-45.27f, 4.4f, -82.76f); // Coordenadas especificadas.

        // Instanciar el jugador en las coordenadas espec�ficas.
        GameObject jugador = Instantiate(jugadorPrefab, spawnPosition, Quaternion.identity);

        // Cambiar la c�mara activa a la del jugador.
        Camera jugadorCamera = jugador.GetComponent<PlayerController>().playerCamera;
        if (jugadorCamera != null)
        {
            jugadorCamera.gameObject.SetActive(true);

            // Desactivar la c�mara del men�.
            Camera menuCamera = Camera.main;
            if (menuCamera != null)
            {
                menuCamera.gameObject.SetActive(false);
            }
        }
    }

    public void Links()
    {
        Application.OpenURL("https://youtu.be/zjUsoseu1Tk?si=wXpQw7Wi82d6ilSc");
    }
}
