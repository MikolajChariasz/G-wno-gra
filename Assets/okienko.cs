using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class okienko : MonoBehaviour
{
    public GameObject okno;
    public GameObject tak;
    public GameObject nie;
    public GameObject zakrycie;
    // Start is called before the first frame update
    void Start()
    {
        okno.SetActive(false);
        zakrycie.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Powrot()
    {
        okno.SetActive(false);
        zakrycie.SetActive(false);
    }
    public void Pokazokno()
    {
        okno.SetActive(true);
        zakrycie.SetActive(true);
    }
    public void UsunDane()
    {
        PlayerPrefs.DeleteAll();
        okno.SetActive(false);
        zakrycie.SetActive(false);
    }
    public void Wylacz()
    {
        Application.Quit();
    }
}
