using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    // Cargar Escenario 1
    public void LoadEscenario1()
    {
        SceneManager.LoadScene("Kitchen Scene");
    }

    // Cargar Escenario 2
    public void LoadEscenario2()
    {
        SceneManager.LoadScene("Classroom Scene");
    }

    public void LoadEscenario3()
    {
        SceneManager.LoadScene("Living room");
    }

    // Salir del juego
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Player Said I quit");
    }
}
