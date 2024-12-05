using UnityEngine;

public class ZDistanceLogger : MonoBehaviour
{
    public Transform cameraTransform;

    void Start()
    {
        if (cameraTransform == null)
        {
            Debug.LogError("Camera Transform is not assigned!");
            return;
        }

        float zDistance = Mathf.Abs(transform.position.z - cameraTransform.position.z);
        Debug.Log($"{gameObject.name} Z Distance from Camera: {zDistance}");
    }
}
