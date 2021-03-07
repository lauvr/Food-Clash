using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneration : MonoBehaviour
{
    public GameObject[] enemies;

    private void Start()
    {       
        Vector3 pos = new Vector3(Random.Range(-2.0f, 2.0f), Random.Range(-2.0f, 2.0f), 0);

        for (int i = 0; i < 4; i++)
        {
            int rand = Random.Range(0, enemies.Length);
            Instantiate(enemies[rand], pos, Quaternion.identity);
        }
    }
}
