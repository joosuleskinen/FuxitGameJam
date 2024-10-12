using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadSceneAsync(2);
    }

    public void Home()
    {
        SceneManager.LoadScene(0);
    }
}
