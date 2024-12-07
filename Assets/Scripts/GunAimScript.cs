using UnityEngine;

public class GunAimScript : MonoBehaviour
{
    private Camera mainCamera;

    void Start()
    {
        // Reference the main camera
        mainCamera = Camera.main;
    }

    void Update()
    {
        // Get the mouse position on the screen
        Vector3 mouseScreenPosition = Input.mousePosition;

        // Convert the screen position of the mouse to a ray in world space
        Ray ray = mainCamera.ScreenPointToRay(mouseScreenPosition);

        // Define a plane at the gun's position (in world space) facing the camera
        Plane plane = new Plane(Vector3.forward, transform.position);

        // Find the point where the ray intersects the plane
        if (plane.Raycast(ray, out float distance))
        {
            Vector3 mouseWorldPosition = ray.GetPoint(distance);

            // Calculate the direction from the gun to the mouse position
            Vector3 direction = mouseWorldPosition - transform.position;

            // Keep the rotation in 2D
            direction.z = 0;

            // Calculate the angle and rotate the gun
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);

        }
    }
}
