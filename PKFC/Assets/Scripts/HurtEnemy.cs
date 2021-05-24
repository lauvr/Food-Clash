using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HurtEnemy : MonoBehaviour
{

    public static int damageToGive = 20;
    [SerializeField]
    private Potions potions;
    public int currentDmg;
    private EnemyHealthManager ehm;

    void Start()
    {
        damageToGive = 20;
        ehm = GetComponent<EnemyHealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        currentDmg = damageToGive;
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
        else if(other.tag == "Boss")
        {
            BossHealth eHealthMan;
            eHealthMan = other.gameObject.GetComponent<BossHealth>();
            Debug.Log("Hit boss");
            eHealthMan.HurtEnemy(damageToGive);
        }
    }




}
