using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skorscript : MonoBehaviour
{
    public static int skor;
    public Text scoreteks;
    
    void Start()
    {
        skor = 0;
        scoreteks.text = skor.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        scoreteks.text = skor.ToString();
    }
}
