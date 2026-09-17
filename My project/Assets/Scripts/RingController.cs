using UnityEngine;

public class RingController : MonoBehaviour
{
    public enum OpeningDirection
    {
        Up,
        Down,
        Left,
        Right
    }

    [HideInInspector]
    public OpeningDirection openingDirection;

    [HideInInspector]
    public LayerMask sameRingLayer;

    [HideInInspector]
    public LayerMask wallLayer;

    public bool isRedRing = false; // Check this box in the Inspector for your Red Ring prefabs/objects

    private void Awake()
    {
        sameRingLayer = 1 << gameObject.layer;
        wallLayer = LayerMask.GetMask("Walls");
    }

    private void Update()
    {
        UpdateOpeningDirection();
    }

    private void UpdateOpeningDirection()
    {
        // Get the Z rotation normalized between 0 and 360
        float zRotation = transform.eulerAngles.z % 360f;
        if (zRotation < 0) zRotation += 360f;

        // Round to nearest 90-degree increment to prevent precision issues
        int roundedZ = Mathf.RoundToInt(zRotation / 90f) * 90 % 360;

        switch (roundedZ)
        {
            case 0:
                openingDirection = OpeningDirection.Up;
                break;
            case 90:
                openingDirection = OpeningDirection.Left;
                break;
            case 180:
                openingDirection = OpeningDirection.Down;
                break;
            case 270:
                openingDirection = OpeningDirection.Right;
                break;
        }
    }

    public bool CanEnter(Vector2 movementDirection)
    {
        return movementDirection == -GetOpeningVector();
    }

    public bool CanExit(Vector2 movementDirection)
    {
        return movementDirection == GetOpeningVector();
    }

    public Vector2 GetOpeningVector()
    {
        switch (openingDirection)
        {
            case OpeningDirection.Up: return Vector2.up;
            case OpeningDirection.Down: return Vector2.down;
            case OpeningDirection.Left: return Vector2.left;
            case OpeningDirection.Right: return Vector2.right;
        }
        return Vector2.zero;
    }

    public bool CanMoveTo(Vector2 targetPos)
    {
        if (Physics2D.OverlapPoint(targetPos, wallLayer) != null)
            return false;

        Collider2D col = Physics2D.OverlapPoint(targetPos, sameRingLayer);
        if (col != null && col.gameObject != gameObject)
            return false;

        return true;
    }

    public void MoveRing(Vector2 direction)
    {
        transform.position += (Vector3)direction;
    }
}