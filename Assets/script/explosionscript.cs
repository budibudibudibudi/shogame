using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosionscript : MonoBehaviour
{
    public AudioClip sfx;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource audio = gameObject.AddComponent<AudioSource>();
        audio.PlayOneShot(sfx);
        Destroy(gameObject,1);
    }
}
