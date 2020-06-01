using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;

public class BossController : MonoBehaviour
{
    private Animator animator;
    private float velocity;
    private float distance;
    private bool dead;
    private bool boss;
    private float lifepoints;

    private NavMeshAgent agent;
    private GameObject player;

    private float attackRate = 7f;
    private float nextAttackTime = 0f;

    public Slider healthBar;
    public TextMeshProUGUI healthValue;

    private bool cura;

    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        velocity = 0;
        distance = 10;
        dead = false;
        boss = true;
        lifepoints = 100;
        cura = false;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.transform.position);
        if (agent.remainingDistance <= 1) {
            //StartCoroutine(Attack());
            attack();
        }
        if (lifepoints <= 0) {
            Destroy(gameObject);
            //Ganar
        }
            

        healthBar.value = lifepoints;
        healthValue.text = lifepoints.ToString() + " / 100";
    }

    private void OnCollisionEnter(Collision collision) {
        if ((collision.gameObject.name == "Bullet_Prefab") || (collision.gameObject.name == "Bullet_Prefab(Clone)")) {
            if(cura) lifepoints -= 2;
        }
    }

    private void attack() {
        if (Time.time >= nextAttackTime) {
            player.GetComponent<MainPlayer>().getDamage();
            nextAttackTime = Time.time + attackRate;
        }
    }

    public void isCura() {
        cura = true;
    }
}
