using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public Player player;

    public Movingplat mov;

    public Vector3 movep;

    public Flyingplat move;

    // Start is called before the first frame update
    void Start()
    {
      player = gameObject.GetComponentInParent<Player>();  
      mov = GameObject.FindGameObjectWithTag("Movingplat").GetComponent<Movingplat>();
      move = GameObject.FindGameObjectWithTag("flyingplat").GetComponent<Flyingplat>();
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
            movep.x += mov.speed* 1.15f;
            player.transform.position = movep;
        }
         if (collision.isTrigger == false && collision.CompareTag("flyingplat"))
        {
            movep = player.transform.position;
            movep.y += move.speed* 1.0f;
            player.transform.position = movep;
        }
    }
 
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.isTrigger == false || collision.CompareTag("water"))
            player.grounded = false;
    }
}
