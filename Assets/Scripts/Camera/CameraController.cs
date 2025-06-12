using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float displacementMultiplier = 0.15f;
    private float zPosition = -10;

    private void Update()
    {
        // Exit early if player is destroyed
        if (playerTransform == null)
            return; 

        // Calculate mouse position in world coordinates then calculate displacement depending on difference between mouse and player position
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 cameraDisplacement = (mousePosition - playerTransform.position) * displacementMultiplier;

        // Determine final camera position and assign it
        Vector3 finalCameraPosition = playerTransform.position + cameraDisplacement;
        finalCameraPosition.z = zPosition;
        transform.position = finalCameraPosition;
    }
}