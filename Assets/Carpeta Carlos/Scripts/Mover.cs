using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Mover : MonoBehaviour
{
    public float force = 0;
    public float JumpForce = 0;
    int obj = 9;
    Vector3 posicionInicial;
    Rigidbody rb;
    public Text mitexto;
    public GameObject prefab;
    public static bool GameisPaused = false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        posicionInicial = transform.position;

    }
    void Update()
    {
        if (mitexto)
            mitexto.text = "Objetos Faltantes: " + obj.ToString();
    }

    void OnTriggerEnter(Collider otro)
    {
        /*if (otro.CompareTag("salida"))
        {
            Debug.Log("Has salido, felicidades. Has recogido " + obj + " objetos");
        }*/
         if (otro.CompareTag("obj"))
        {
           // if (coin) coin.Play();
            otro.gameObject.SetActive(false);
            // if (coin) coin.Play();
            obj -= 1;
            if (obj == 0) 
            {
                SceneManager.LoadScene("CanvasFin");
                
            }
           
        }

    }
}
