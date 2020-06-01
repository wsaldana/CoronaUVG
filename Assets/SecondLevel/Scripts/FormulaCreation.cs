using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FormulaCreation : MonoBehaviour
{
    public GameObject BarProgress;
    public GameObject RadialProgress;
    public Transform textIndicator;
    public Transform textLoading;
    public GameObject PrecautionText;
    public AudioSource potionEffectFX;
    public Light tableLight;

    public GameObject missions;

    [SerializeField] private float currentAmount;
    [SerializeField] private float speed;

    private bool show;

    private void Start()
    {
        RadialProgress.SetActive(false);
        show = false;
        potionEffectFX = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.C))
        {
            show = true;
        }
        else
        {
            show = false;
        }
    }
    
   private void OnTriggerStay(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            potionEffectFX.Play();
            if (show == true)
            {
                PrecautionText.SetActive(false);
                RadialProgress.SetActive(true);
                tableLight.color = Color.green;
                if (currentAmount < 100)
                {
                    currentAmount += speed * Time.time;
                    textIndicator.GetComponent<Text>().text = ((int)currentAmount).ToString() + "%";
                    textLoading.gameObject.SetActive(true);
                }
                else
                {
                    textLoading.gameObject.SetActive(false);
                    textIndicator.GetComponent<Text>().text = "DONE";
                    missions.GetComponent<win>().setCura();
                }
                BarProgress.GetComponent<Image>().fillAmount = currentAmount / 100;
            }
            else
            {
                tableLight.color = Color.blue;
                PrecautionText.SetActive(true);
                RadialProgress.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        tableLight.color = Color.red;
        PrecautionText.SetActive(false);
        RadialProgress.SetActive(false);
        currentAmount = 0;
        potionEffectFX.Stop();
    }
}
