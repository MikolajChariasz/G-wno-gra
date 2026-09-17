using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public Sprite playerLeft;
    public Sprite playerRight;

    [HideInInspector]
    public LayerMask wallLayer;
    [HideInInspector]
    public LayerMask smallRingLayer;
    [HideInInspector]
    public LayerMask bigRingLayer;

    private void Awake()
    {
        smallRingLayer = LayerMask.GetMask("SmallRings");
        bigRingLayer = LayerMask.GetMask("BigRings");
        wallLayer = LayerMask.GetMask("Walls");
    }
    void Update()
    {
        Vector2 movementDirection = Vector2.zero;

        if (Input.GetKeyDown(KeyCode.UpArrow)) movementDirection = Vector2.up;
        else if (Input.GetKeyDown(KeyCode.DownArrow)) movementDirection = Vector2.down;
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
        else return;

        Vector2 pos = transform.position;
        Vector2 targetPos = pos + movementDirection;

        // 1. Get rings at current and target positions
        RingController currentSmall = GetRingAt(pos, smallRingLayer);
        RingController currentBig = GetRingAt(pos, bigRingLayer);

        RingController targetSmall = GetRingAt(targetPos, smallRingLayer);
        RingController targetBig = GetRingAt(targetPos, bigRingLayer);

        List<RingController> ringsToMove = new List<RingController>();

        // 2. Evaluate Nested Ring Mechanics
        bool smallIsExiting = currentSmall != null && currentSmall.CanExit(movementDirection);
        bool bigIsExiting = currentBig != null && currentBig.CanExit(movementDirection);

        // BOTH RINGS PRESENT
        if (currentSmall != null && currentBig != null)
        {
            if (smallIsExiting && !bigIsExiting)
            {
                // Small ring opening is clear, but big ring's wall blocks exit.
                // Trapped by outer ring: move BOTH rings together with player.
                ringsToMove.Add(currentSmall);
                ringsToMove.Add(currentBig);
            }
            else
            {
                if (!smallIsExiting) ringsToMove.Add(currentSmall);
                if (!bigIsExiting) ringsToMove.Add(currentBig);
            }
        }
        // ONLY SMALL RING PRESENT
        else if (currentSmall != null)
        {
            if (!smallIsExiting) ringsToMove.Add(currentSmall);
        }
        // ONLY BIG RING PRESENT
        else if (currentBig != null)
        {
            if (!bigIsExiting) ringsToMove.Add(currentBig);
        }

        // 3. Evaluate Entering New Rings
        if (currentSmall == null && targetSmall != null && !targetSmall.CanEnter(movementDirection))
        {
            return;
        }

        if (currentBig == null && targetBig != null && !targetBig.CanEnter(movementDirection))
        {
            return;
        }

        // 4. Wall Check for Player
        Vector2 wallCheckPosition = (pos + targetPos) / 2f;
        if (Physics2D.OverlapPoint(wallCheckPosition, wallLayer) != null)
        {
            return;
        }

        // 5. Validate Movement for All Pushed Rings
        foreach (RingController ring in ringsToMove)
        {
            Vector2 ringTargetPos = (Vector2)ring.transform.position + movementDirection;
            if (!ring.CanMoveTo(ringTargetPos))
            {
                return;
            }
        }

        // 6. Execute Movement
        transform.position = targetPos;
        foreach (RingController ring in ringsToMove)
        {
            ring.MoveRing(movementDirection);
        }
    }

    private RingController GetRingAt(Vector2 position, LayerMask layer)
    {
        Collider2D col = Physics2D.OverlapPoint(position, layer);
        return col != null ? col.GetComponent<RingController>() : null;
    }
}