using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            var player = col.GetComponent<HealthScript>();
            if (gameObject.tag == "AddHealth")
            {
                player.AddHealth();
            }
            else if (gameObject.tag == "AddContainer")
            {
                player.AddContainer();
            }
            GetComponent<Collider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
