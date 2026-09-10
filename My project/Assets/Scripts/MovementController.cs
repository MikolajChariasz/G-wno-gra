using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public Sprite playerLeft;
    public Sprite playerRight;

    public LayerMask wallLayer;
    public LayerMask ringLayer;

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
        else
        {
            // No movement key was pressed
            return;
        }

        // Direction of the attempted movement
        Vector2 movementDirection = newPos - pos;

        // -----------------------------------
        // 1. Check walls
        // -----------------------------------

        // Point halfway between current and destination cell
        Vector2 wallCheckPosition = (pos + newPos) / 2f;

        if (Physics2D.OverlapPoint(wallCheckPosition, wallLayer))
        {
            return;
        }

        // -----------------------------------
        // 2. Check ring at current position
        // -----------------------------------

        Collider2D currentRingCollider =
            Physics2D.OverlapPoint(pos, ringLayer);

        if (currentRingCollider != null)
        {
            RingController currentRing =
                currentRingCollider.GetComponent<RingController>();

            if (currentRing != null)
            {
                // If we're inside a ring, we can only leave
                // through its opening.
                if (!currentRing.CanExit(movementDirection))
                {
                    return;
                }
            }
        }

        // -----------------------------------
        // 3. Check ring at destination
        // -----------------------------------

        Collider2D destinationRingCollider =
            Physics2D.OverlapPoint(newPos, ringLayer);

        if (destinationRingCollider != null)
        {
            RingController destinationRing =
                destinationRingCollider.GetComponent<RingController>();

            if (destinationRing != null)
            {
                // We can only enter the ring through its opening.
                if (!destinationRing.CanEnter(movementDirection))
                {
                    return;
                }
            }
        }

        // -----------------------------------
        // 4. Everything is allowed
        // -----------------------------------

        transform.position = newPos;
    }
}