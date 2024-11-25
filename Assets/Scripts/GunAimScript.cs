using UnityEngine;

public class GunAimScript : MonoBehaviour
{
    public Transform gun;

    void Update()
    {
        Aim();
    }

    void Aim()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        Vector2 direction = (mousePosition - gun.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        gun.rotation = Quaternion.Euler(0, 0, angle);
    }
}
