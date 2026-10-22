using UnityEngine;
using UnityEngine.UI;

public class VolumeToggleController : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private Toggle soundToggle;
    [SerializeField] private Image targetImage; // Obrazek, którego sprite ma siê zmieniaæ

    [Header("Sprites")]
    [SerializeField] private Sprite soundOnSprite;   // Sprite dla w³¹czonego dŸwiêku
    [SerializeField] private Sprite soundOffSprite;  // Sprite dla wyciszonego dŸwiêku

    void Start()
    {
        bool isMuted = AudioListener.pause;
        if (soundToggle != null)
        {
            soundToggle.isOn = !isMuted;
        }
        UpdateVisuals(!isMuted);

        // Nas³uchiwanie zmian w toggle
        if (soundToggle != null)
        {
            soundToggle.onValueChanged.AddListener(OnToggleValueChanged);
        }
    }

    public void OnToggleValueChanged(bool isOn)
    {
        AudioListener.pause = !isOn;
        UpdateVisuals(isOn);
    }

    void UpdateVisuals(bool isOn)
    {
        if (targetImage != null)
        {
            targetImage.sprite = isOn ? soundOnSprite : soundOffSprite;
        }
    }
}