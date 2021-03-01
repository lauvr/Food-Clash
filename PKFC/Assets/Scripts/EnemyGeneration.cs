using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneration : MonoBehaviour
{
    public GameObject[] enemies;

    private void Start()
    {
        int rand = Random.Range(0, enemies.Length);
        Instantiate(enemies[rand], transform.position, Quaternion.identity);
    }
}
