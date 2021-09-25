using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
 
    public float speed = 50f, maxspeed = 3, jumpPow = 220f, maxjump =4;
    public bool grounded = true, faceright = true, doublejump = false;
    //mau hp
    public int ourHealth;
    public int maxhealth = 5;

    public Rigidbody2D r2;
    public Animator anim;
    public gamemaster gm;

    public SoundManager sound;

    public GameObject gameover;

    // Use this for initialization
    void Start () {
        r2 = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        gm = GameObject.FindGameObjectWithTag("gamemaster").GetComponent<gamemaster>();
        sound = GameObject.FindGameObjectWithTag("sound").GetComponent<SoundManager>();
        ourHealth = maxhealth;

        
        }
    
    // Update is called once per frame
    void Update () {
        anim.SetBool("Grounded", grounded);
        anim.SetFloat("Speed", Mathf.Abs(r2.velocity.x));
 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded)
            {
                grounded = false;
                doublejump = true;
                r2.AddForce(Vector2.up * jumpPow);
 
            }
 
            else
            {
                if (doublejump)
                {
                    doublejump = false;
                    // co dinh nguoi choi
                    r2.velocity = new Vector2(r2.velocity.x, 0);
                    r2.AddForce(Vector2.up * jumpPow * 0.7f);
 
                }
            }
 
        }
    }
 //lien quan den vat ly, duocj goi moi 0.2s
    void FixedUpdate()
    {
        // di chuyen
        float h = Input.GetAxis("Horizontal");
        r2.AddForce((Vector2.right) * speed * h);
 //gioi han toc do
        if (r2.velocity.x > maxspeed)
            r2.velocity = new Vector2(maxspeed, r2.velocity.y);
        if (r2.velocity.x < -maxspeed)
            r2.velocity = new Vector2(-maxspeed, r2.velocity.y);

        // gioi han buoc nhay
        if (r2.velocity.y > maxjump)
            r2.velocity = new Vector2(r2.velocity.x, maxjump);
        if (r2.velocity.y < -maxjump)
            r2.velocity = new Vector2(r2.velocity.x, -maxjump);

    // h>0 -. huong phai va nguoi choi huong trai -> flip    
        if (h>0 && !faceright)
        {
            Flip();
        }
 
        if (h < 0 && faceright)
        {
            Flip();
        }
 // tao ma sat gia
        if (grounded)
        {
            r2.velocity = new Vector2(r2.velocity.x * 0.7f, r2.velocity.y);
        }

        // het mau
        if (ourHealth <= 0)
        {
            Death();
        }
    }
 
    public void Flip()
    {
        faceright = !faceright;
        Vector3 Scale;
        Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;
    }

      public void Death()
    {  
        Time.timeScale =0 ;
        gameover.SetActive(true);
        
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
// luu gia tri highscore 
        if (PlayerPrefs.GetInt("highscore") < gm.points)
            PlayerPrefs.SetInt("highscore", gm.points);

    }

    public void Damage(int damage){
        ourHealth -=damage;

        //gameObject.GetComponent<Animation>().Play("redflash");
    }
//day lui
//luc day, huong day lui
//luc anh huong van toc nguoi choi
    public void Knockback(float Knockpow,Vector2 Knockdir){
         r2.velocity = new Vector2(0, 0);
        r2.AddForce(new Vector2(Knockdir.x * -100, Knockdir.y * Knockpow));
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Coins"))
        {
            sound.Playsound("coins");
            Destroy(col.gameObject);
            gm.points += 1;
        }

        if (col.CompareTag("shoe"))
        {
            Destroy(col.gameObject);
            maxspeed = 6f;
            speed = 100f;
            StartCoroutine(timecount(5));
        }
 
        if (col.CompareTag("heart"))
        {
            Destroy(col.gameObject);
            ourHealth = 5;
        }
    }
// tgian dem ngc ngoai vong lap
    IEnumerator timecount (float time)
    {
        yield return new WaitForSeconds(time);
        maxspeed = 3f;
        speed = 50f;
        yield return 0;
    }

}