using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyscript : MonoBehaviour
{
    int health = 30;

    public GameObject explosion;
    public GameObject amunisi;
    public Transform bompoint;
    
    void Update()
    {
        if(health <= 0)
        {
            skorscript.skor += 1;
            Instantiate(explosion,bompoint.position,bompoint.rotation);
            Instantiate(amunisi,bompoint.position,bompoint.rotation);
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "peluru")
        {
            health -= bullet.damage;
        }
        if(col.gameObject.tag == "burstpeluru")
        {
            health -= bullet.burstdamage;
        }
    }
}
