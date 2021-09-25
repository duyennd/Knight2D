using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class TurretAI : MonoBehaviour {
 
    public int curHealth = 100;
 
    public float distance;// kc ng choi va tru
    public float wakerange;// kc tru thuc giac

    public float shootinterval;// chu ky vien dan
    public float bulletspeed = 5;
    public float bullettimer;
 
    public bool awake = false;
    public bool lookingRight = true;
 
    public GameObject bullet;
    public Transform target;// lay vi tri target-ng choi
    public Animator anim;
    public Transform shootpointL, shootpointR;// lay vi tri 2 diem ban

    public SoundManager sound;
 
    private void Awake()
    {
        anim = GetComponent<Animator>();
       
    }
    // Use this for initialization
    void Start () {
          sound = GameObject.FindGameObjectWithTag("sound").GetComponent<SoundManager>();  
    }
    
    // Update is called once per frame
    void Update () {
        anim.SetBool("Awake", awake);
        anim.SetBool("LookRight", lookingRight);
 
        RangeCheck();
 // ktra trang thai
        if (target.transform.position.x > transform.position.x)
        {
            lookingRight = true;
        }
 
        if (target.transform.position.x < transform.position.x)
        {
            lookingRight = false;
        }
 
        if (curHealth < 0)
        {
            sound.Playsound("destroy");
            Destroy(gameObject);
        }
    }
 
 // kiem tra khoang cach
    void RangeCheck()
    {
        distance = Vector2.Distance(transform.position, target.transform.position);
 
        if (distance < wakerange)
            awake = true;
 
        if (distance > wakerange)
            awake = false;
    }
 // tan cong
    public void Attack(bool attackright)// bien kiem tra ban ben phai/trai
    {
        bullettimer += Time.deltaTime;
 
        if (bullettimer >= shootinterval)
        {
            Vector2 direction = target.transform.position - transform.position;
            direction.Normalize();
 
            if (attackright)
            {
                GameObject bulletclone;
                bulletclone = Instantiate(bullet, shootpointR.transform.position, shootpointR.transform.rotation) as GameObject;
                bulletclone.GetComponent<Rigidbody2D>().velocity = direction * bulletspeed;
 
                bullettimer = 0;
            }
 
            if (!attackright)
            {
                GameObject bulletclone;
                bulletclone = Instantiate(bullet, shootpointL.transform.position, shootpointL.transform.rotation) as GameObject;
                bulletclone.GetComponent<Rigidbody2D>().velocity = direction * bulletspeed;
 
                bullettimer = 0;
            }
        }
    }
 
    public void Damage(int dmg)
    {
        curHealth -= dmg;
        //gameObject.GetComponent<Animation>().Play("redflash");
    }
}