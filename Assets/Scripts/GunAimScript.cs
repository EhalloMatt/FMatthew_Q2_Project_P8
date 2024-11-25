using UnityEngine;

public class GunAimScript : MonoBehaviour
{
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (mainCamera == null)
        {
            Debug.LogWarning("Main camera not found!");
            return;
        }

        // Convert mouse position to world point
        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0f; // Ignore Z-axis

        // Calculate the angle towards the mouse position
        Vector3 direction = mouseWorldPosition - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Apply rotation
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        Debug.Log($"Mouse Position: {mouseWorldPosition}, Gun Angle: {angle}");
    }
}
