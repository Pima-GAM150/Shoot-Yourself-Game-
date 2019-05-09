using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{

    public int NextLevel;


    public void loadNextLevel(){
        SceneManager.LoadScene(NextLevel++);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(NextLevel++);
    }
}
