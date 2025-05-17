using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        LAMouse();
    }

    private void LAMouse()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        // Flip gun sprite if mouse is to the left of gun (less) 

        Vector3 scale = transform.localScale;

        if (mousePos.x < transform.position.x)
        {
            scale.y = -Mathf.Abs(scale.y);
        }
        else
        {
            scale.y = Mathf.Abs(scale.y);
        }

        transform.localScale = scale;
        

    }

   
}
