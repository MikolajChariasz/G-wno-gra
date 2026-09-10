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

    public OpeningDirection openingDirection;

    public bool IsPlayerInside;


    // -----------------------------------------
    // Can enter through opening?
    // -----------------------------------------

    public bool CanEnter(Vector2 movementDirection)
    {
        Vector2 openingVector = GetOpeningVector();

        return movementDirection == -openingVector;
    }


    // -----------------------------------------
    // Can leave through opening?
    // -----------------------------------------

    public bool CanExit(Vector2 movementDirection)
    {
        Vector2 openingVector = GetOpeningVector();

        return movementDirection == openingVector;
    }


    // -----------------------------------------
    // Player entered
    // -----------------------------------------

    public void PlayerEntered()
    {
        IsPlayerInside = true;
    }


    // -----------------------------------------
    // Player exited
    // -----------------------------------------

    public void PlayerExited()
    {
        IsPlayerInside = false;
    }


    // -----------------------------------------
    // Move the U
    // -----------------------------------------

    public void MoveRing(Vector2 direction)
    {
        
        transform.position += (Vector3)direction;

    }


    // -----------------------------------------
    // Get opening direction
    // -----------------------------------------

    private Vector2 GetOpeningVector()
    {
        switch (openingDirection)
        {
            case OpeningDirection.Up:
                return Vector2.up;

            case OpeningDirection.Down:
                return Vector2.down;

            case OpeningDirection.Left:
                return Vector2.left;

            case OpeningDirection.Right:
                return Vector2.right;
        }

        return Vector2.zero;
    }
}