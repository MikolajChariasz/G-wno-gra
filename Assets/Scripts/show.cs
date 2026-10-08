using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class show : MonoBehaviour
{
    public GameObject nextLevel;
    
    // Start is called before the first frame update
    void Start()
    {
        nextLevel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(MovementController.czyWygrana == true)
        {
            Debug.Log("wygrana");
            nextLevel.SetActive(true);
            
        }
    }
}
