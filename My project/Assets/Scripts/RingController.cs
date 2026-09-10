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

    // Can the player ENTER this ring with this movement?
    public bool CanEnter(Vector2 movementDirection)
    {
        Vector2 openingVector = GetOpeningVector();

        // If the opening is on the left,
        // the player must move RIGHT to enter it.
        return movementDirection == -openingVector;
    }

    // Can the player EXIT this ring with this movement?
    public bool CanExit(Vector2 movementDirection)
    {
        Vector2 openingVector = GetOpeningVector();

        // If the opening is on the left,
        // the player must move LEFT to exit it.
        return movementDirection == openingVector;
    }

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