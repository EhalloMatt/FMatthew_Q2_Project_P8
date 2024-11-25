using UnityEngine;

public class GunAimScript : MonoBehaviour
{
    public Transform gunTransform;

    private void Update()
    {
        // Ensure the camera reference is correct
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePosition - gunTransform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Apply rotation to the gun only
        gunTransform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
