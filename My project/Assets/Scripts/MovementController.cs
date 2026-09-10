using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public Sprite playerLeft;
    public Sprite playerRight;

    public LayerMask wallLayer;

    void Start()
    {

    }

    void Update()
    {
        Vector2 pos = transform.position;
        Vector2 newPos = pos;

        if (Input.GetKeyDown("up"))
        {
            newPos.y += 1;
        }
        else if (Input.GetKeyDown("down"))
        {
            newPos.y -= 1;
        }
        else if (Input.GetKeyDown("right"))
        {
            newPos.x += 1;
            gameObject.GetComponent<SpriteRenderer>().sprite = playerRight;
        }
        else if (Input.GetKeyDown("left"))
        {
            newPos.x -= 1;
            gameObject.GetComponent<SpriteRenderer>().sprite = playerLeft;
        }

        // Punkt na granicy pomiêdzy obecnym i docelowym polem
        Vector2 wallCheckPosition = (pos + newPos) / 2f;

        // Przesuñ gracza tylko jeœli na granicy nie ma œciany
        if (!Physics2D.OverlapPoint(wallCheckPosition, wallLayer))
        {
            transform.position = newPos;
        }
    }
}
