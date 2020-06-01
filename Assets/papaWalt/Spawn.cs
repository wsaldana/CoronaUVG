using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

    private float spawnRate = 10f;
    private float nextSpawn = 0;
    public GameObject prefab;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update(){
        if (Time.time >= nextSpawn) {
            Instantiate(prefab, gameObject.transform.position, Quaternion.identity);
            nextSpawn = Time.time + spawnRate;
        }
    }
}
