using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playermovscript : MonoBehaviour
{
    AudioSource audio;

    public CharacterController2D cc2d;
    public Animator anim;
    public AudioClip [] sfx;
    public Text peluruteks;

    public float run_speed = 40f;
    public int pelurusekarang;
    public int maxpeluru = 10;
    public int stokpeluru = 10;
    public int maxstok = 200;

    int rammo;
    float jumpatt;
    float horiz = 0f;
    bool jump = false;
    float cooldown = 1f;
    bool isreload = false;
    bool canshoot = true;
    int health = 3;
    float delay = 0.3f;
    float clickTime = 0.0f;
    bool canreload = true;

    public GameObject peluru;
    public GameObject burstpeluru;
    public Animator animreload;
    public GameObject reloadteks;


    public Transform firepoint;
    // Update is called once per frame

    void Start()
    {
        audio = gameObject.AddComponent<AudioSource>();
        pelurusekarang = maxpeluru;
        peluruteks.text = pelurusekarang+"/"+stokpeluru;
    }
    void Update()
    {
        horiz = Input.GetAxisRaw("Horizontal")*run_speed;

        anim.SetFloat("speed",Mathf.Abs(horiz));

        if(Input.GetKeyDown(KeyCode.W)||Input.GetButtonDown("Jump"))
        {
            jump = true;
            anim.SetBool("lompat",true);
        }
        
        if(Input.GetKeyDown(KeyCode.N))
        {
            launch(-1);
        }
        if(pelurusekarang<maxpeluru)
        {
            if(Input.GetKeyDown(KeyCode.R)&&!isreload)
            {
                StartCoroutine(reload(pelurusekarang));
            }
        }

        
        if(Input.GetMouseButtonDown(0)){
            clickTime = Time.time;
        }
        if(Input.GetMouseButtonUp(0)){
            if(Time.time - clickTime <= delay){
            launch(-1);
            }
        }
        if(Input.GetMouseButton(0)){
            if(Time.time - clickTime > delay){
            StartCoroutine(FireBurst(-1));
            }
        }

        if(pelurusekarang == 0)
        {
            canshoot = false;
        }

        if(stokpeluru == 0)
        {
            canreload = false;
        }else{
            canreload = true;
        }

    }

    void FixedUpdate()
    {
        cc2d.Move(horiz*Time.fixedDeltaTime,false,jump);
        jump = false;

    }

    public void onlanding()
    {
        anim.SetBool("lompat",false);
        audio.PlayOneShot(sfx[1]);
    }

    void launch(int amount)
    {
        if(canshoot)
        {      
            if(amount < 0)
            {
                Instantiate(peluru,firepoint.position,firepoint.rotation);
                audio.PlayOneShot(sfx[0]);
                pelurusekarang = Mathf.Clamp(pelurusekarang+amount,0,maxpeluru);
                peluruteks.text = pelurusekarang+"/"+stokpeluru;
            }
        }
        else
        {
            reloadteks.SetActive(true);
            if(animreload.GetCurrentAnimatorStateInfo(0).IsName("RELOAD TEKS 2"))
            {
                animreload.SetTrigger("play");
            }
        }
    }

    public void amunisi(int amount)
    {
        if(amount>0)
        {
            stokpeluru = Mathf.Clamp(stokpeluru+amount,0,maxstok);
            peluruteks.text = pelurusekarang+"/"+stokpeluru;
        }
            
    }

    IEnumerator reload(int amount)
    {
        audio.PlayOneShot(sfx[2]);
        isreload = true;
        canshoot = false;
        if(canreload)
        {
            yield return new WaitForSeconds(cooldown);
            maxpeluru = maxpeluru-amount;
            if(stokpeluru<maxpeluru)
            {
                pelurusekarang+=stokpeluru;
                stokpeluru = 0;
                maxpeluru = 10;
            }
            else{
                stokpeluru = Mathf.Clamp(stokpeluru-maxpeluru,0,maxstok);
                pelurusekarang = pelurusekarang+maxpeluru;
                maxpeluru = 10;
            }
            peluruteks.text = pelurusekarang+"/"+stokpeluru;
            canshoot = true;
            isreload = false;
        }
        else
        {
            Debug.Log("bug");
            canshoot = true;
            isreload = false;
        }
    }
	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag == "musuh"&&FindObjectOfType<CharacterController2D>().m_FacingRight)
		{
            if(health <= 1)
            {
                FindObjectOfType<gamemanagerscrirpt>().gameover();
            }
            audio.PlayOneShot(sfx[3]);
            FindObjectOfType<CharacterController2D>().GetComponent<Rigidbody2D>().AddForce(new Vector2(-1000,0));
            health--;
		}
		if(col.gameObject.tag == "musuh"&&!FindObjectOfType<CharacterController2D>().m_FacingRight)
		{
            if(health <= 1)
            {
                FindObjectOfType<gamemanagerscrirpt>().gameover();
            }
            audio.PlayOneShot(sfx[3]);
            FindObjectOfType<CharacterController2D>().GetComponent<Rigidbody2D>().AddForce(new Vector2(1000,0));
            health--;
		}

        if(col.gameObject.tag == "api")
        {
            if(health <= 1)
            {
                FindObjectOfType<gamemanagerscrirpt>().gameover();
            }
            audio.PlayOneShot(sfx[3]);
            FindObjectOfType<CharacterController2D>().GetComponent<Rigidbody2D>().AddForce(new Vector2(0,1000));
            health--;
        }
	}
    public IEnumerator FireBurst(int amount)
    {
     // rate of fire in weapons is in rounds per minute (RPM), therefore we should calculate how much time passes before firing a new round in the same burst.
        if(canshoot)
        {
            for (int i = 0; i < 1; i++)
            {
                Instantiate(burstpeluru,firepoint.position,firepoint.rotation);
                audio.PlayOneShot(sfx[0]);
                pelurusekarang = Mathf.Clamp(pelurusekarang+amount,0,maxpeluru);
                peluruteks.text = pelurusekarang+"/"+stokpeluru;
                yield return new WaitForSeconds(10); // wait till the next round
            }
        }
        else
        {
            reloadteks.SetActive(true);
            if(animreload.GetCurrentAnimatorStateInfo(0).IsName("RELOAD TEKS 2"))
            {
                animreload.SetTrigger("play");
            }
        }
    }
}
