using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levellock : MonoBehaviour
{
    public GameObject jeden;
    public GameObject dwa;
    public GameObject trzy;
    public GameObject cztery;
    public GameObject piec;
    public GameObject szesc;
    public GameObject siedem;
    public GameObject osiem;
    public GameObject dziewiec;
    // Start is called before the first frame update
    void Start()
    {
        
        Zakryj(jeden);
        Zakryj(dwa);
        Zakryj(trzy);
        Zakryj(cztery);
        Zakryj(piec);
        Zakryj(szesc);
        Zakryj(siedem);
        Zakryj(osiem);
        Zakryj(dziewiec);

        
        string level = PlayerPrefs.GetString("Level");

        if (!PlayerPrefs.HasKey("Level")) Odkryj(jeden);
        if (level == "Tutorial1")
        {
            Odkryj(jeden);
            Odkryj(dwa);
        }
        else if (level == "Tutorial2")
        {
            Odkryj(jeden);
            Odkryj(dwa);
            Odkryj(trzy);
        }
        else if (level == "Tutorial3")
        {
            Odkryj(jeden);
            Odkryj(dwa);
            Odkryj(trzy);
            Odkryj(cztery);
        }
        else if (level == "Level1")
        {
            Odkryj(jeden);
            Odkryj(dwa);
            Odkryj(trzy);
            Odkryj(cztery);
            Odkryj(piec);
        }
        else if (level == "Level2")
        {
            Odkryj(jeden);
            Odkryj(dwa);
            Odkryj(trzy);
            Odkryj(cztery);
            Odkryj(piec);
            Odkryj(szesc);
        }
        else if (level == "Level3")
        {
            Odkryj(jeden);
            Odkryj(dwa);
            Odkryj(trzy);
            Odkryj(cztery);
            Odkryj(piec);
            Odkryj(szesc);
            Odkryj(siedem);
        }
        else if (level == "Level4")
        {
            Odkryj(jeden);
            Odkryj(dwa);
            Odkryj(trzy);
            Odkryj(cztery);
            Odkryj(piec);
            Odkryj(szesc);
            Odkryj(siedem);
            Odkryj(osiem);
        }
        else if (level == "Level5")
        {
            Odkryj(jeden);
            Odkryj(dwa);
            Odkryj(trzy);
            Odkryj(cztery);
            Odkryj(piec);
            Odkryj(szesc);
            Odkryj(siedem);
            Odkryj(osiem);
            Odkryj(dziewiec);
        }
        else if (level == "Level6")
        {
            Odkryj(jeden);
            Odkryj(dwa);
            Odkryj(trzy);
            Odkryj(cztery);
            Odkryj(piec);
            Odkryj(szesc);
            Odkryj(siedem);
            Odkryj(osiem);
            Odkryj(dziewiec);
        }
        
    }

    void Zakryj(GameObject przycisk)
    {
        przycisk.transform.Find("locked").gameObject.SetActive(true);
        przycisk.GetComponent<Button>().interactable = false;
    }

    void Odkryj(GameObject przycisk)
    {
        przycisk.transform.Find("locked").gameObject.SetActive(false);
        przycisk.GetComponent<Button>().interactable = true;
    }
    // Update is called once per frame
    void Update()
    {
        if(!PlayerPrefs.HasKey("Level"))
        {
            Zakryj(dwa);
            Zakryj(trzy);
            Zakryj(cztery);
            Zakryj(piec);
            Zakryj(szesc);
            Zakryj(siedem);
            Zakryj(osiem);
            Zakryj(dziewiec);
        }
    }
}
