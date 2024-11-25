using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    [Header("Life")]
    public int Health = 3;
    public int numOfHearts;
    [SerializeField] Image[] hearts;
    [SerializeField] Sprite fullHeart;
    [SerializeField] Sprite emptyHeart;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        HealthSystem();
    }

    private void HealthSystem()
    {
        if (Health > numOfHearts)
        {
            Health = numOfHearts;
        }
        for (int i = hearts.Length - 1; i >= 0; i--)
        {
            if (i < Health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }


    }

    public void Damage()
    {
        Health--;
        if (Health <= 0)
        {
            Debug.Log("You Lose");
        }
    }

    public void AddHealth()
    {
        Health++;
    }

    public void AddContainer()
    {
        Health++;
        if (numOfHearts <= hearts.Length)
        {
            numOfHearts += 1;
        }
    }
}
