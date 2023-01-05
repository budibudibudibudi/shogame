using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class objectivescript : MonoBehaviour
{
    public static int killteks;
    public Text objectiftext;
    // Update is called once per frame
    void Update()
    {
        objectiftext.text = GameObject.FindGameObjectsWithTag("musuh").Length.ToString();
    }
}
