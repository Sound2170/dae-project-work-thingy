using UnityEngine;
using UnityEngine.UI;
using TMPro;  

public class TabletController : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private GameObject tabletPanel;       // Drag TabletPanel here
    [SerializeField] private GameObject tabletHintText;    // Drag TabletHintText here

    [Header("Hold Settings")]
    [SerializeField] private float holdThreshold = 1.0f;   // seconds to hold TAB before opening
    private float holdTimer = 0f;

    private bool isHolding = false;
    private bool tabletOpen = false;

    void Update()
    {
        HandleTabletInput();
    }

    private void HandleTabletInput()
    {
        // Check if TAB is being pressed
        if (Input.GetKey(KeyCode.Tab))
        {
            // First frame that Tab is pressed
            if (!isHolding)
            {
                isHolding = true;
                holdTimer = 0f;
                // Show hint immediately
                tabletHintText.SetActive(true);
            }

            // While holding Tab, accumulate time
            holdTimer += Time.deltaTime;

            // If holdThreshold reached and tablet not already open:
            if (holdTimer >= holdThreshold && !tabletOpen)
            {
                OpenTablet();
            }
        }
        else
        {
            // If Tab is released before threshold, hide hint and reset
            if (isHolding && !tabletOpen)
            {
                tabletHintText.SetActive(false);
            }

            // If Tab is released while tablet is open, close it
            if (tabletOpen)
            {
                CloseTablet();
            }

            isHolding = false;
            holdTimer = 0f;
        }
    }

    private void OpenTablet()
    {
        tabletPanel.SetActive(true);
        tabletHintText.SetActive(false); // hide the hint once tablet is open
        tabletOpen = true;
        Time.timeScale = 0f; // pause game if desired, or remove this line if you want the world to keep running
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void CloseTablet()
    {
        tabletPanel.SetActive(false);
        tabletOpen = false;
        Time.timeScale = 1f; // unpause game
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
