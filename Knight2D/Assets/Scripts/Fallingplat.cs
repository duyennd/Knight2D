﻿using Microsoft.Win32;
using System.Security.Cryptography;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fallingplat : MonoBehaviour
{
    public Rigidbody2D r2;
    public float timedelay =2;
    // Start is called before the first frame update
    void Start()
    {
        r2= gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
// 2 collider va cham 
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.collider.CompareTag("Player")){
            StartCoroutine(fall());

        }
    }
//
    IEnumerator fall(){
        yield return new WaitForSeconds(timedelay);
        r2.bodyType = RigidbodyType2D.Dynamic;
        yield return 0;

    }
}
