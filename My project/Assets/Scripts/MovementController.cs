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
        Vector2 movementDirection = Vector2.zero;

        // -----------------------------------------
        // Get input
        // -----------------------------------------

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            movementDirection = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            movementDirection = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            movementDirection = Vector2.right;
            GetComponent<SpriteRenderer>().sprite = playerRight;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            movementDirection = Vector2.left;
            GetComponent<SpriteRenderer>().sprite = playerLeft;
        }
        else
        {
            return;
        }


        Vector2 newPos = pos + movementDirection;


        // -----------------------------------------
        // Find U at player's current position
        // -----------------------------------------

        Collider2D ringCollider =
            Physics2D.OverlapPoint(pos, ringLayer);

        RingController currentRing = null;

        Collider2D destinationRingCollider =
            Physics2D.OverlapPoint(newPos, ringLayer);

        RingController destinationRing = null;

        if (ringCollider != null)
        {
            currentRing =
                ringCollider.GetComponent<RingController>();
        }

        if (destinationRingCollider != null)
        {
            destinationRing =
                destinationRingCollider.GetComponent<RingController>();
        }

        // -----------------------------------------
        // Check wall between player and destination
        // -----------------------------------------

        Vector2 wallCheckPosition =
            (pos + newPos) / 2f;

        bool wallExists =
            Physics2D.OverlapPoint(
                wallCheckPosition,
                wallLayer
            );


        // -----------------------------------------
        // WALL + PLAYER INSIDE U
        // -----------------------------------------



        // -----------------------------------------
        // WALL + PLAYER NOT INSIDE U
        // -----------------------------------------

        if (wallExists)
        {
            return;
        }


        // -----------------------------------------
        // Check if leaving current U
        // -----------------------------------------

        if (currentRing != null)
        {
            if (!currentRing.CanExit(movementDirection))
            {
                if(destinationRing == null)
                {
                    currentRing.MoveRing(movementDirection);
                }
                else
                {
                    return;
                }
                
            }
        }


        // -----------------------------------------
        // Check if entering another U
        // -----------------------------------------

        
        


        if (destinationRing != null)
        {
            if (!destinationRing.CanEnter(movementDirection))
            {
                return;
            }
        }


        // -----------------------------------------
        // Move player
        // -----------------------------------------

        transform.position = newPos;
        if (currentRing != null && destinationRing != currentRing)
        {
            currentRing.PlayerExited();
        }

        if (destinationRing != null && destinationRing != currentRing)
        {
            destinationRing.PlayerEntered();
        }
    }
}