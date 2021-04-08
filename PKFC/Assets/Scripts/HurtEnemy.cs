using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour
{

    public int damageToGive;
    [SerializeField]
    private Potions potions;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            EnemyHealthManager eHealthMan;
            eHealthMan = other.gameObject.GetComponent<EnemyHealthManager>();
            Debug.Log("Hit");
            eHealthMan.HurtEnemy(damageToGive);
           /*
            if (potions.isRunning == true)
            {
                eHealthMan.HurtEnemy(damageToGive + 10);
            }
            else
            {
                eHealthMan.HurtEnemy(damageToGive);
            }
            */
        }
    }

}
