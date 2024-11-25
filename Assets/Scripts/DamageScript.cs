using UnityEngine;

public class DamageScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            var player = col.GetComponent<HealthScript>();
            player.Damage();
        }
    }
}
