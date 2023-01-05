using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class amunisiscript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            int rand = Random.Range(10,20);
            FindObjectOfType<playermovscript>().amunisi(10);
            Destroy(gameObject);
        }
    }
}
