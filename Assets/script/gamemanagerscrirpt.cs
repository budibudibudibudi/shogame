using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gamemanagerscrirpt : MonoBehaviour
{
    bool ispaused = false;
    private AudioSource [] all;
    public AudioSource bgm;
    public GameObject pausepanel;
    public GameObject [] panel;

    // Start is called before the first frame update
    void Start()
    {
        all = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!ispaused)
            {
                Time.timeScale = 0;
                foreach(AudioSource a in all)
                {
                    a.Pause();
                }
                ispaused = true;
                FindObjectOfType<playermovscript>().enabled = false;
                pausepanel.SetActive(true);
            }
            else
            {
                ispaused = false;
                pausepanel.SetActive(false);
                Time.timeScale = 1;
                foreach(AudioSource a in all)
                {
                    a.UnPause();
                }
                FindObjectOfType<playermovscript>().enabled = true;
            }
        }
        if (GameObject.FindGameObjectsWithTag("musuh").Length == 0)
        {
            win();
        }
    }

    public void resume()
    {
        ispaused = false;
        pausepanel.SetActive(false);
        Time.timeScale = 1;
        foreach(AudioSource a in all)
        {
            a.UnPause();
        }
        FindObjectOfType<playermovscript>().enabled = true;
    }

    public void quitgame()
    {
        SceneManager.LoadScene("mainmenu");
    }

    void win()
    {
        bgm.Stop();
        FindObjectOfType<playermovscript>().enabled = false;
        panel[0].SetActive(true);
        Time.timeScale = 0;
    }

    public void gameover()
    {
        bgm.Stop();
        Destroy(GameObject.FindGameObjectWithTag("Player"));
        panel[1].SetActive(true);
        Time.timeScale = 0;
    }

    public void restartgame()
    {
        SceneManager.LoadScene("game1");
    }
}
