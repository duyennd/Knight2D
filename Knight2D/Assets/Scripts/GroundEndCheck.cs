using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEndCheck : MonoBehaviour
{
     public Player player;

    public Flyingplat move;
 
    public Vector3 movep;

    // Start is called before the first frame update
    void Start()
    {
      player = gameObject.GetComponentInParent<Player>();  
      move = GameObject.FindGameObjectWithTag("flyingplat").GetComponent<Flyingplat>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void  FixedUpdate()
    {
        
    }
     void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger == false)
            player.grounded = true;
    }
 
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.isTrigger == false || collision.CompareTag("water") || collision.CompareTag("groundend"))
            player.grounded = true;
         if (collision.isTrigger == false && collision.CompareTag("flyingplat"))
        {
            movep = player.transform.position;
            movep.y += move.speed* 1.3f;
            player.transform.position = movep;
        }
    }
 
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.isTrigger == false || collision.CompareTag("water"))
            player.grounded = false;
    }
}
