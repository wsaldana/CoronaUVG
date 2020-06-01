using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioDeEscena : MonoBehaviour
{
   public void CambioEscena() 
    {
        SceneManager.LoadScene("Level1Scene");
    }

    public void End()
    {
        Application.Quit();
        Debug.Log("Has ganado");
    }
}
