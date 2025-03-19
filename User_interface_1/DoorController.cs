using System.Collections;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Transform doorTransform; // Assign the door GameObject in Inspector
    public float openAngle = 90f; // Angle to open the door
    public float openSpeed = 2f; // Speed of door opening
    public KeyCode interactKey = KeyCode.E;
    public float interactionDistance = 3f;
    
    private Quaternion closedRotation;
    private Quaternion openRotation;
    private bool isOpen = false;
    private bool isMoving = false;

    void Start()
    {
        closedRotation = doorTransform.rotation;
        openRotation = Quaternion.Euler(doorTransform.eulerAngles + new Vector3(0, openAngle, 0));
    }

    void Update()
    {
        if (Input.GetKeyDown(interactKey) && !isMoving)
        {
            if (IsPlayerClose())
                StartCoroutine(ToggleDoor());
        }
    }

    IEnumerator ToggleDoor()
    {
        isMoving = true;
        Quaternion targetRotation = isOpen ? closedRotation : openRotation;
        float elapsedTime = 0f;

        while (elapsedTime < 1f)
        {
            doorTransform.rotation = Quaternion.Slerp(doorTransform.rotation, targetRotation, elapsedTime * openSpeed);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        doorTransform.rotation = targetRotation;
        isOpen = !isOpen;
        isMoving = false;
    }

    bool IsPlayerClose()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            return Vector3.Distance(player.transform.position, doorTransform.position) <= interactionDistance;
        }
        return false;
    }
}
