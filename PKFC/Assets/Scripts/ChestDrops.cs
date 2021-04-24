using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestDrops : MonoBehaviour
{

    private Inventory inv;
    public int rand;
    // Start is called before the first frame update
    void Start()
    {
        rand = Random.Range(1, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            inv.rdrop += rand;
            inv.bdrop += rand;
            inv.gdrop += rand;
        }
    }
    */
}
