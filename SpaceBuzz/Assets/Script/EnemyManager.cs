using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemy0;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;
    public GameObject enemy5;
    public GameObject enemy6;
    public GameObject enemy7;
    public GameObject enemy8;

    private List<GameObject> enemiesList = new List<GameObject>();

    int enemyDistance = 6;

    void Start()
    {
        if (Oxygen.isDamaged)
        {
            enemiesList.Add(enemy0);
            enemiesList.Add(enemy1);
            enemiesList.Add(enemy2);
            enemiesList.Add(enemy3);
            enemiesList.Add(enemy4);
            enemiesList.Add(enemy5);
            enemiesList.Add(enemy6);
            enemiesList.Add(enemy7);
            enemiesList.Add(enemy8);
        }
        else if (Oxygen.isDamaged == false)
        {
            enemiesList.Add(enemy0);
            enemiesList.Add(enemy1);
            enemiesList.Add(enemy2);
            enemiesList.Add(enemy3);
            enemiesList.Add(enemy4);
            enemiesList.Add(enemy6);
            enemiesList.Add(enemy7);
            enemiesList.Add(enemy8);
        }

        //Listedeki obleleri konsola yazdırma
        //enemiesList.ForEach(Debug.Log);

        if (Oxygen.isDamaged)
        {
            for (int i = 0; i < 2; i++)
            {
                GameObject enemy = Instantiate(enemiesList[Random.Range(0, 9)], gameObject.transform.position + (transform.forward * enemyDistance) + (transform.right * Random.Range(-1.60f, 1.60f)), Quaternion.Euler(0f, 180f, 0f));
                enemyDistance += 10;
                enemy.transform.parent = gameObject.transform;
            }
        }
        else if (Oxygen.isDamaged == false)
        {
            for (int i = 0; i < 2; i++)
            {
                GameObject enemy = Instantiate(enemiesList[Random.Range(0, 8)], gameObject.transform.position + (transform.forward * enemyDistance) + (transform.right * Random.Range(-1.60f, 1.60f)), Quaternion.Euler(0f, 180f, 0f));
                enemyDistance += 10;
                enemy.transform.parent = gameObject.transform;
            }
        }

        
    }

    
    
}
