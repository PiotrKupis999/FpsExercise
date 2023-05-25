using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManagerScript : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void DestroyButton(GameObject button)
    {
        Destroy(button);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
