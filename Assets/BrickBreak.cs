using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BrickBreak : MonoBehaviour
{
    private SpriteRenderer sr;       // handles the block’s sprite
    public Sprite explodedBlock;     // drag the “exploded” sprite here in Inspector

    void Start()
    {
        // get the SpriteRenderer attached to this block
        sr = GetComponent<SpriteRenderer>();
    }

    // runs when something collides with this block
    void OnCollisionEnter2D(Collision2D other)
    {
        // check that it’s the Player AND that the collision came from below
        if (other.gameObject.tag == "Player" &&
            other.contacts[0].point.y < transform.position.y)
        {
            // change sprite to the exploded version
            sr.sprite = explodedBlock;

            // wait 0.2 seconds, then destroy the block
            Destroy(gameObject, 0.2f);
        }
    }
}

