using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChange : MonoBehaviour
{
    [SerializeField] private string newGameLevel = "Level1";
    public static string wybranaScena;
    public void Levele()
    {
        SceneManager.LoadScene("Levele");
        
    }
    public void Level1()
    {
        wybranaScena = "Level1";
        SceneManager.LoadScene("LoadingScreen");
        
    }
    public void Level2()
    {
        wybranaScena = "Level2";
        SceneManager.LoadScene("LoadingScreen");

    }
    public void Level3()
    {
        wybranaScena = "Level3";
        SceneManager.LoadScene("LoadingScreen");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

}
