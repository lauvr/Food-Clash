using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CinematicSceneChange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(NextScene()); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   

    IEnumerator NextScene()
    {
        Debug.Log("corriendo cinematica");
        yield return new WaitForSeconds(82f);
        SceneManager.LoadScene("Tutorial");
    }
}
