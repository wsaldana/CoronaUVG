using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CoronaController : MonoBehaviour{

    private Animator animator;
    private float velocity;
    private float distance;
    private bool dead;
    private bool boss;
    private float lifepoints;

    private NavMeshAgent agent;
    private GameObject player;

    private float attackRate = 5f;
    private float nextAttackTime = 0f;

    void Start(){
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        velocity = 0;
        distance = 10;
        dead = false;
        boss = false;
        lifepoints = 20;
    }

    void Update(){
        //animator.SetFloat("velocity", velocity);
        //animator.SetFloat("distance", distance);
        //animator.SetBool("boss", boss);
        //animator.SetBool("dead", dead);
        agent.SetDestination(player.transform.position);
        animator.SetFloat("velocity", agent.velocity.magnitude);
        animator.SetFloat("distance", agent.remainingDistance);
        Vector3 d = agent.transform.position - player.transform.position;
        if (d.magnitude <= 1.6) {
            attack();
        }
        if (lifepoints <= 0)
            Destroy(gameObject);
    }

    private void attack() {
        if(Time.time >= nextAttackTime) {
            player.GetComponent<MainPlayer>().getDamage();
            nextAttackTime = Time.time + attackRate;
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if((collision.gameObject.name == "Bullet_Prefab") || (collision.gameObject.name == "Bullet_Prefab(Clone)")) {
            lifepoints -= 2;
        }
    }


    IEnumerator Attack() {
        yield return new WaitForSeconds(4000);
        
    }
}
