using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public static int damage = 3;
    public static int burstdamage = 1;
    public AudioClip sfx;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right*speed;
        Destroy(gameObject,3);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "musuh"||col.gameObject.tag == "tile")
        {
            AudioSource audio = gameObject.AddComponent<AudioSource>();
            audio.PlayOneShot(sfx);
            Destroy(gameObject,0.1f);
        }
    }
}
