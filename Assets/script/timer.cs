using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    public static float timercountdown;
    public Text timerteks;

    void Start()
    {
        timercountdown = 120;
    }

    // Update is called once per frame
    void Update()
    {
        if(timercountdown>0)
        {
            timercountdown -= Time.deltaTime;
            int timeteks = (int)timercountdown;
            timerteks.text = timeteks.ToString();
        }
        else if(timercountdown<0)
        {
            FindObjectOfType<gamemanagerscrirpt>().gameover();
        }
        else if(timercountdown == 0)
        {
            timerteks.text = "Selamat!";
        }
    }
}
