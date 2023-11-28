using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    private bool isCursorLocked = false;

    private void Start()
    {
        // Ensure the cursor is initially visible and unlocked
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        isCursorLocked = false;
    }

    private void Update()
    {
        // Check if you want to toggle cursor lock state (for example, pressing the "Escape" key)
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleCursorLockState();
        }

        // Check if you want to keep the cursor visible and unlocked during gameplay
        // For example, you might use a key press or some other condition
        if (Input.GetMouseButtonDown(0)) // Assuming left mouse button click
        {
            if (!isCursorLocked)
            {
                // If the cursor is not locked, lock it
                Cursor.lockState = CursorLockMode.Locked;
                isCursorLocked = true;
            }
        }
    }

    private void ToggleCursorLockState()
    {
        // Toggle between locked and unlocked
        Cursor.lockState = isCursorLocked ? CursorLockMode.None : CursorLockMode.Locked;
        // Toggle visibility accordingly
        Cursor.visible = !isCursorLocked;
        isCursorLocked = !isCursorLocked;
    }
}

