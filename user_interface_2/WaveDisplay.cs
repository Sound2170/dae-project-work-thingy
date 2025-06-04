using UnityEngine;
using TMPro;  

public class WaveDisplay : MonoBehaviour
{
    // Drag WaveText (TextMeshProUGUI) into this slot in the Inspector
    [SerializeField] private TMP_Text waveText;  

    // For now, we’ll start with a static wave count. Later you can hook this up to your enemy spawner.
    private int currentWave = 1;

    void Start()
    {
        UpdateWaveText();
    }

    // Call this whenever the wave number changes
    public void SetWave(int waveNumber)
    {
        currentWave = waveNumber;
        UpdateWaveText();
    }

    private void UpdateWaveText()
    {
        waveText.text = "Wave: " + currentWave;
    }
}
