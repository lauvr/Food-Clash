using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tptriggertwo : MonoBehaviour
{
    private GameObject trigger;
    
    // Start is called before the first frame update
    void Start()
    {
        trigger = GameObject.Find("triggerpls");
        Instantiate(trigger, transform.position, Quaternion.identity);
    }


}
