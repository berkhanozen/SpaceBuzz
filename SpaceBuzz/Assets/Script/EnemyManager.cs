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

        }
        else if (Oxygen.isDamaged == false)
        {
            enemiesList.Add(enemy0);
            enemiesList.Add(enemy1);
            enemiesList.Add(enemy2);
            enemiesList.Add(enemy3);
            enemiesList.Add(enemy4);

        }

        //Listedeki obleleri konsola yazdırma
        //enemiesList.ForEach(Debug.Log);

        if (Oxygen.isDamaged)
        {
            for (int i = 0; i < 2; i++)
            {
                GameObject enemy = Instantiate(enemiesList[Random.Range(0, 6)], gameObject.transform.position + (transform.forward * enemyDistance) + (transform.right * Random.Range(-1.60f, 1.60f)), Quaternion.Euler(0f, 180f, 0f));
                enemyDistance += 10;
                enemy.transform.parent = gameObject.transform;
            }
        }
        else if (Oxygen.isDamaged == false)
        {
            for (int i = 0; i < 2; i++)
            {
                GameObject enemy = Instantiate(enemiesList[Random.Range(0, 5)], gameObject.transform.position + (transform.forward * enemyDistance) + (transform.right * Random.Range(-1.60f, 1.60f)), Quaternion.Euler(0f, 180f, 0f));
                enemyDistance += 10;
                enemy.transform.parent = gameObject.transform;
            }
        }

        
    }

    
    
}
