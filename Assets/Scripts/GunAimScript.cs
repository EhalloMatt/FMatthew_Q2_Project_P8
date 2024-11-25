using UnityEngine;

public class GunAimScript : MonoBehaviour
{
    private Camera mainCamera;

    private void Start()
    {
        // Cache the Main Camera
        mainCamera = Camera.main;
        if (mainCamera == null)
        {
            Debug.LogError("Main Camera is not tagged or missing.");
        }
    }

    private void Update()
    {
        AimAtMouse();
    }

    private void AimAtMouse()
    {
        if (mainCamera == null) return;

        // Get mouse position in world space
        Vector3 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0; // Ensure the Z position is consistent (2D game)

        // Calculate direction to mouse
        Vector3 direction = mousePos - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Rotate gun to point at the mouse
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
