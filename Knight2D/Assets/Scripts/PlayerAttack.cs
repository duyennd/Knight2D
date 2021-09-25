using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class PlayerAttack : MonoBehaviour {
    public float attackdelay = 0.3f;
    public bool attacking = false;
 
    public Animator anim;
 
    public Collider2D trigger;

    public SoundManager sound;

 // xhay trc start, luon chay 
    private void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        trigger.enabled = false;
         sound = GameObject.FindGameObjectWithTag("sound").GetComponent<SoundManager>();
    }
 
    
    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Z) && !attacking)
        {
            attacking = true;
            trigger.enabled = true;
            attackdelay = 0.3f;
            sound.Playsound("sword");
        }
 
        if (attacking)
        {
            if (attackdelay > 0)
            {// giam theo tgian thuc
                attackdelay -= Time.deltaTime;
 
            }
            else
            {
                attacking = false;
                trigger.enabled = false;
            }
        }
 
        anim.SetBool("Attacking", attacking);
    }
}