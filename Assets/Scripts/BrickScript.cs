using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickScript : MonoBehaviour
{
    ParticleSystem bricks;
    public bool solidBrick = false;
    public bool canUse = true;
    public Sprite usedSprite;
    [SerializeField] List<AudioClip> boxSounds;

    // Start is called before the first frame update
    void Start()
    {
        bricks = GetComponentInChildren
            <ParticleSystem>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.GetComponent
            <PlayerScript>() == null)
        {
            return;
        }
        if (col.contacts[0].normal.y > 0.5f)
        {
            Break();
        }
    }

    void Break()
    {
        if (solidBrick == false && canUse == true)
        {
            bricks.Play();
            GetComponent<Collider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
            AudioClip clip = boxSounds[0];
            GetComponent<AudioSource>().PlayOneShot(clip);

        }
        else if(solidBrick == true && canUse == true) 
        {
            bricks.Play(true);
            canUse = false;
            GetComponent<SpriteRenderer>().sprite = usedSprite;
            AudioClip clip = boxSounds[0];
            GetComponent<AudioSource>().PlayOneShot(clip);
        }
        else 
        {
            AudioClip clip = boxSounds[1];
            GetComponent<AudioSource>().PlayOneShot(clip);
        }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
