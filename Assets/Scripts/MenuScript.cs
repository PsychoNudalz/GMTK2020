using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public void LoadScene(string levelName)
    {
        SceneManager.LoadScene(levelName);
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void nextLevel()
    {
        string currentLevelString = SceneManager.GetActiveScene().name;
        int nextLevelInt = int.Parse(currentLevelString.Substring(currentLevelString.Length - 1));
        nextLevelInt++;
        string nextlevelString = "Level" + nextLevelInt;
        //print(nextlevelString);
        SceneManager.LoadScene(nextlevelString);
        Time.timeScale = 1f;
    }

}
