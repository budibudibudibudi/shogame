using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainmenuscript : MonoBehaviour
{
    public GameObject [] surepanel;
    public AudioClip klik;
    AudioSource audio;
    int indexpanduan = 0;
    

    void Start()
    {
        audio = gameObject.AddComponent<AudioSource>();
        Time.timeScale = 1;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            audio.PlayOneShot(klik);
        }
    }
    public void startgame()
    {
        SceneManager.LoadScene("game1");
    }

    public void othermenu(int index)
    {
        surepanel[index].SetActive(true);
    }

    public void pilihanexit(bool isbenar)
    {
        if(isbenar)
        {
            Application.Quit();
        }
        else
        {
            closepanel();
        }
    }

    public void closepanel()
    {
        foreach(GameObject p in surepanel)
        {
            p.SetActive(false);
        }
    }
}
