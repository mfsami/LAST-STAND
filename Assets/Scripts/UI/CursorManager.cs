using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    

    void Start()
    {
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        transform.position = Input.mousePosition;
    }
}
