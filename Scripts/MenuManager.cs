using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void Leveltransition(string levelString)
    {
        SceneManager.LoadScene(levelString);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
