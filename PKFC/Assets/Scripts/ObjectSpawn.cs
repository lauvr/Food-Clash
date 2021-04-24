using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawn : MonoBehaviour
{

    public GameObject[] objects;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 pos = new Vector3(Random.Range(-2.0f, 2.0f), Random.Range(-2.0f, 2.0f), 0);
        int rand = Random.Range(0, objects.Length);
        Instantiate(objects[rand], transform.position + pos, Quaternion.identity);
    }

}
