using UnityEngine;

public class KeyScript : MonoBehaviour
{
    [SerializeField] KeyLockScript keyLock;

    void OnTriggerEnter2D(Collider2D col)
    {
        var player = col.GetComponent
            <PlayerScript>();
        if (player != null)
        {
            transform.SetParent(player.transform);
            transform.localPosition
                = Vector3.up;


        }
        var KeyLocked = col.GetComponent<KeyLockScript>();
        if (keyLock != null && KeyLocked == keyLock)
        {
            keyLock.Unlock();
            Destroy(gameObject);
        }
    }
}
