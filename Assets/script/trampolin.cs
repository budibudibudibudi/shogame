using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trampolin : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            FindObjectOfType<CharacterController2D>().GetComponent<Rigidbody2D>().AddForce(new Vector2(0,1500));
        }
    }
}
