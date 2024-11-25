using UnityEngine;

public class GunAimScript : MonoBehaviour
{
    public Transform firePoint; // Fire point of the gun (where bullets come out)
    private Transform gunTransform; // The gun transform to adjust
    private Vector2 aimDirection; // Direction the gun will aim at
    private Vector2 mousePosition; // The current mouse position in world space

    void Start()
    {
        // Get the gun's transform if it's not set
        gunTransform = transform;
    }

    void Update()
    {
        // Get the current mouse position in world space
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Calculate the direction from the gun to the mouse (no scaling or rotation applied)
        aimDirection = mousePosition - (Vector2)gunTransform.position;

        // Log the aim direction for debugging
        Debug.Log($"Aim Direction: {aimDirection}");
    }
}
