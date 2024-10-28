using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{

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
        SceneManager.LoadScene("SampleScene");
    }
}
