using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{
    public Transform playerTransform;
    public float pixelsPerUnit = 16f; // Same as Pixel Perfect Camera

    private void LateUpdate()
    {
        if (playerTransform == null) return;

        Vector3 targetPosition = playerTransform.position;
        targetPosition.z = transform.position.z;

        // Snap to pixel grid
        Vector3 snappedPosition = new Vector3(
            Mathf.Round(targetPosition.x * pixelsPerUnit) / pixelsPerUnit,
            Mathf.Round(targetPosition.y * pixelsPerUnit) / pixelsPerUnit,
            targetPosition.z
        );

        transform.position = snappedPosition;
    }
}
