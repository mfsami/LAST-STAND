using UnityEngine;

public class CursorUI : MonoBehaviour
{
    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        Cursor.visible = false;
    }

    void Update()
    {
        Vector2 pos = Input.mousePosition;
        rectTransform.position = pos;
    }
}
