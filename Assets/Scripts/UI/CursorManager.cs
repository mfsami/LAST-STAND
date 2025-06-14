using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
        Cursor.visible = false; // Hide the system cursor
    }

    void Update()
    {
        Vector3 mouseWorld = cam.ScreenToWorldPoint(Input.mousePosition);
        mouseWorld.z = 0f; // Ensure it's flat on the game plane
        transform.position = mouseWorld;
    }
}
