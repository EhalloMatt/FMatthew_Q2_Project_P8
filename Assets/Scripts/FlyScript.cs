using System.Collections;
using UnityEngine;

public class FlyScript : MonoBehaviour
{
    [SerializeField] Sprite deadSprite;
    [SerializeField] GameObject player;
    Transform playerPos;
    Vector2 currentPos;
    [SerializeField] float distance;
    [SerializeField] float ememySpeed;
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        playerPos = player.GetComponent<Transform>();
        currentPos = GetComponent<Transform>().position;
        sr = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, playerPos.position) < distance)
        {
            transform.position = Vector2.MoveTowards
                (transform.position, playerPos.position, ememySpeed * Time.deltaTime);

        }
        else
        {
            if (Vector2.Distance(transform.position,
                currentPos) <= 0)
            {
                //do nothing
            }
            else
            {
                transform.position = Vector2.MoveTowards
                    (transform.position, currentPos, ememySpeed * Time.deltaTime);
            }
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        Vector2 normal = col.contacts[0].normal;
        if (normal.y <= -.5)
        {
            StartCoroutine(Die());
        }
        else
        {
            player.GetComponent<HealthScript>().Damage();
        }
    }

    IEnumerator Die()
    {
        sr.sprite = deadSprite;
        GetComponent<Animator>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        enabled = false;

        float alpha = 1f;
        while (alpha > 0)
        {
            yield return null;
            alpha -= Time.deltaTime;
            sr.color = new Color(1, 1, 1, alpha);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, distance);

    }
}
