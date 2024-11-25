using UnityEngine;

public class GunAimScript : MonoBehaviour
{
    void Update()
    {
        // Screen space mouse position
        Vector3 mouseScreenPos = Input.mousePosition;
        Debug.Log($"Mouse Position (Screen): {mouseScreenPos}");

        // Convert to world space
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(new Vector3(mouseScreenPos.x, mouseScreenPos.y, transform.position.z));

        // Ensure Z alignment
        mouseWorldPos.z = transform.position.z;

        // Calculate direction to mouse
        Vector3 direction = mouseWorldPos - transform.position;

        // Calculate rotation angle
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Apply rotation to the gun
        transform.rotation = Quaternion.Euler(0, 0, angle);

        // Debugging outputs
        Debug.Log($"Mouse Position (World): {mouseWorldPos}, Gun Position: {transform.position}, Direction: {direction}, Gun Angle: {angle}");
    }
}
