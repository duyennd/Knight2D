using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class GroundCheck1 : MonoBehaviour
{
  
    public Player player;
    public Movingplat mov;
 
    public Vector3 movep;
 
    // Use this for initialization
    void Start()
    {
        mov = GameObject.FindGameObjectWithTag("Movingplat").GetComponent<Movingplat>();
        player = gameObject.GetComponentInParent<Player>();
    }
 
 
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger == false)
            player.grounded = true;
    }
 
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.isTrigger == false || collision.CompareTag("water"))
            player.grounded = true;
        if (collision.isTrigger == false && collision.CompareTag("Movingplat"))
        {
            movep = player.transform.position;
            movep.x += mov.speed* 1.3f;
            player.transform.position = movep;
        }
            
    }
 
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.isTrigger == false || collision.CompareTag("water"))
            player.grounded = false;
    }
}