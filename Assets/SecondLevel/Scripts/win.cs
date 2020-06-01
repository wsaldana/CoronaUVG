using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class win : MonoBehaviour
{
    private bool cura;
    private bool bossDied;

    public GameObject boss;

    void Start()
    {
        cura = false;
        bossDied = false;
    }

    // Update is called once per frame
    void Update(){
        if (cura)
            boss.GetComponent<BossController>().isCura();
        if(cura && bossDied) {
            Debug.Log("GANASTEEE");
            SceneManager.LoadScene(6);
        }
    }

    public void setCura() {
        cura = true;
    }
}
