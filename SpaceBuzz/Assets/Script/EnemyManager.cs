using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject[] enemies;
    int enemyDistance = 6;

    void Start()
    {

        for (int i = 0; i < 2; i++)
        {
            GameObject enemy = Instantiate(enemies[Random.Range(0, 6)], gameObject.transform.position + (transform.forward * enemyDistance) + (transform.right * Random.Range(-4f, 4f)), Quaternion.Euler(0f, 180f, 0f));
            enemyDistance += 10;
            enemy.transform.parent = gameObject.transform;
        }
    }

    
    void Update()
    {
        
    }
}
