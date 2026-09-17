using UnityEngine;

public class LevelGoal : MonoBehaviour
{
    [Header("Door Target")]
    public GameObject doorObject;

    [Header("Ring Layers")]
    public LayerMask smallRingLayer;
    public LayerMask bigRingLayer;

    private bool doorUnlocked = false;

    void Update()
    {
        // Stop checking once the door is already opened
        if (doorUnlocked) return;

        CheckWinCondition();
    }

    private void CheckWinCondition()
    {
        // Find all small rings in the scene
        RingController[] smallRings = FindObjectsByType<RingController>(FindObjectsSortMode.None);

        foreach (RingController smallRing in smallRings)
        {
            // Only evaluate the small red ring
            if (smallRing.isRedRing && (1 << smallRing.gameObject.layer) == smallRingLayer.value)
            {
                // Check if a big ring shares the exact same position as the small red ring
                Collider2D bigRingCollider = Physics2D.OverlapPoint(smallRing.transform.position, bigRingLayer);

                if (bigRingCollider != null)
                {
                    RingController bigRing = bigRingCollider.GetComponent<RingController>();

                    // Verify the overlapping big ring is also a red ring
                    if (bigRing != null && bigRing.isRedRing)
                    {
                        OpenDoor();
                        break;
                    }
                }
            }
        }
    }

    private void OpenDoor()
    {
        doorUnlocked = true;

        if (doorObject != null)
        {
            doorObject.SetActive(false); // Hides the door wall completely
        }
    }
}