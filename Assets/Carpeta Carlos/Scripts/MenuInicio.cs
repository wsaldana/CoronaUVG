using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicio : MonoBehaviour
{
    public void CambioEscena()
    {
        SceneManager.LoadScene("CanvasMessage");
    }

    public void Salir()
    {
        Application.Quit();
        Debug.Log("Has Salido");

    }
}
