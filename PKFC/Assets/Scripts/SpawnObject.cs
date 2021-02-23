using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject oceanTile;

    private void Start()
    {
        GameObject instance = (GameObject)Instantiate(oceanTile, transform.position, Quaternion.identity);
        instance.transform.parent = transform;
    }
}
