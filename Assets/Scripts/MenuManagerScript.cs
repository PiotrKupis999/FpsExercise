using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManagerScript : MonoBehaviour
{

    public void DestroyButton(GameObject button)
    {
        Destroy(button);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
