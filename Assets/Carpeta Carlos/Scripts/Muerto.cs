using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Muerto : MonoBehaviour
{

    public float tiempoInicio = 0;
    public float tiempoFinal = 5;
    // Update is called once per frame
    void Update()
    {
        tiempoInicio += Time.deltaTime;
        if (tiempoInicio >= tiempoFinal)
        {
            SceneManager.LoadScene(2);
        }
    }
}
