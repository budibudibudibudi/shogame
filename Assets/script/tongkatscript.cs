using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tongkatscript : MonoBehaviour
{
    void OntriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "peluru")
        {
            Destroy(gameObject);
            skorscript.skor += 1;
        }
    }
}
