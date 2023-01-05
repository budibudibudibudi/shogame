using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class playermovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.D))
        {
            transform.Translate(1,0,0,0);
        }
        if(Input.GetKeyDown(KeyCode.A))
        {
            transform.Translate(-1,0,0,0);
        }
    }

    public void pindahscene(int index)
    {
        SceneManager.LoadScene(index);
    }
}
