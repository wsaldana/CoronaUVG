using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MainPlayer : MonoBehaviour{

    private float lifepoint;

    public Slider healthBar;
    public TextMeshProUGUI healthValue;

    void Start(){
        lifepoint = 50;
    }

    
    void Update(){
        if (lifepoint <= 0) {
            SceneManager.LoadScene(5);
        }
    }

    public void getDamage() {
        lifepoint -= 5;
        healthBar.value = lifepoint;
        healthValue.text = lifepoint.ToString() + " / 50";
    }
}
