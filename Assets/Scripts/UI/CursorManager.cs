using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public float pixelsPerUnit = 16f; // Match this with your Pixel Perfect Camera

    void Start()
    {
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;

        // Snap to pixel grid
        Vector3 snappedPos = new Vector3(
            Mathf.Round(mousePos.x * pixelsPerUnit) / pixelsPerUnit,
            Mathf.Round(mousePos.y * pixelsPerUnit) / pixelsPerUnit,
            0f
        );

        transform.position = snappedPos;
    }
}
