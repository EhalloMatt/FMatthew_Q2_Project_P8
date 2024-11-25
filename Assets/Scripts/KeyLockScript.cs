using UnityEngine;
using UnityEngine.Events;

public class KeyLockScript : MonoBehaviour
{
    [SerializeField] UnityEvent onUnlock;

    public void Unlock()
    {
        onUnlock.Invoke();
    }
}
