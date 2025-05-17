using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float displacementMultiplier = 0.3f;
    [SerializeField] private float pixelsPerUnit = 16f;

    private float zPosition = -10f;

    

    private void LateUpdate()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 cameraDisplacement = (mousePosition - playerTransform.position) * displacementMultiplier;

        Vector3 finalCameraPosition = playerTransform.position + cameraDisplacement;
        finalCameraPosition.z = zPosition;


        finalCameraPosition.x = Mathf.Round(finalCameraPosition.x * pixelsPerUnit) / pixelsPerUnit;
        finalCameraPosition.y = Mathf.Round(finalCameraPosition.y * pixelsPerUnit) / pixelsPerUnit;


        transform.position = finalCameraPosition;
    }
}

