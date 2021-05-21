using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class levelComplete : MonoBehaviour
{
    [SerializeField]
    private string nextscene;
public void LoadNextLevel()
    {
        SceneManager.LoadScene(nextscene);
    }
}
