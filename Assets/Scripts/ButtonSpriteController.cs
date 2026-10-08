using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSpriteController : MonoBehaviour
{
    public Sprite sprite;
    public Sprite highlightSprite;
    void OnMouseOver()
    {
        transform.GetComponent<SpriteRenderer>().sprite = highlightSprite;
    }

    void OnMouseExit()
    {
        transform.GetComponent<SpriteRenderer>().sprite = sprite;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
