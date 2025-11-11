using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBreak : MonoBehaviour
{
    // Start is called before the first frame update
    private SpriteRenderer sr;       // used to change the sprite
    public Sprite explodedBlock;     // the sprite to change into

    void Start()
    {
        // get the SpriteRenderer component
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
