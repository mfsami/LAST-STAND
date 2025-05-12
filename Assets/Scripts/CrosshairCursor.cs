using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairCursor : MonoBehaviour
{
    public float pixelsPerUnit = 256f;
    void Awake()
    {
        
        Cursor.visible = false;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 mouseCursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseCursorPos.z = 0;

        float snap = 1f / pixelsPerUnit;
        mouseCursorPos.x = Mathf.Round(mouseCursorPos.x / snap) * snap;
        mouseCursorPos.y = Mathf.Round(mouseCursorPos.y / snap) * snap;

        transform.position = mouseCursorPos;
    }
}
