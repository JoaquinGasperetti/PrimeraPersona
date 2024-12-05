using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject jugadorPrefab;
    public GameObject canvasMenu;
    public GameObject canvasTimerPrefab;
    public AudioSource MusicaMenu;
    public AudioClip MenuClip;
    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        MusicaMenu.PlayOneShot(MenuClip);
    }

    public void VolverMenu()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }

    public void Jugar()
    {
        Destroy(canvasMenu);
        Instantiate(canvasTimerPrefab);

        Vector3 spawnPosition = new Vector3(-45.27f, 4.4f, -82.76f);

        if (GameManager.Instance.jugador == null)
        {
            GameObject jugador = Instantiate(jugadorPrefab, spawnPosition, Quaternion.identity);
            GameManager.Instance.SetJugador(jugador.transform);
        }

        Camera jugadorCamera = GameManager.Instance.jugador.GetComponent<PlayerController>().playerCamera;
        if (jugadorCamera != null)
        {
            jugadorCamera.gameObject.SetActive(true);

            Camera menuCamera = Camera.main;
            if (menuCamera != null)
            {
                menuCamera.gameObject.SetActive(false);
            }
        }
    }

    public void CambiarNivel()
    {
        SceneManager.LoadScene("demo_city_night");
    }

    public void Links()
    {
        Application.OpenURL("https://youtu.be/zjUsoseu1Tk?si=wXpQw7Wi82d6ilSc");
    }
}
