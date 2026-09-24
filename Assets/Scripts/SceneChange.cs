using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChange : MonoBehaviour
{
    [SerializeField] private string newGameLevel = "Level1";
    public void Levele()
    {
        SceneManager.LoadScene("Levele");
    }
    

}
