using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject[] enemies;
    int enemyDistance = 5;

    void Start()
    {

        for (int i = 0; i < 2; i++)
        {
            GameObject enemy = Instantiate(enemies[Random.Range(0, 3)], gameObject.transform.position + (transform.forward * enemyDistance) + (transform.right * Random.Range(-1f, 1f)), transform.rotation);
            enemyDistance += 10;
            enemy.transform.parent = gameObject.transform;
        }
    }

    
    void Update()
    {
        
    }
}
