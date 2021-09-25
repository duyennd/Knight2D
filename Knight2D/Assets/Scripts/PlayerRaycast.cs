using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class PlayerRaycast : MonoBehaviour {
 
    public float shootdelay = 0, damage = 20;
    public LayerMask Whattohit;// xd vat chieu toi
    public Transform firepoint;
 
    // Use this for initialization
    void Start () {
        firepoint = transform.Find("shootpoint");
    }
    
    // Update is called once per frame
    void Update () {
        shootdelay += Time.deltaTime;
        
        if (shootdelay >= 0.5f)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))// nhan phim chuot trai
            {
                shootdelay = 0;
                shot();
            }
        }
    }
 
    void shot()
    {  // vi tri con tro chuot
        Vector2 mousePos = new Vector2
             (Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
             Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        // diem raycast bat dau
        Vector2 firepointpos = new Vector2(firepoint.position.x, firepoint.position.y);
        // duong raycast ( diem khoi nguon, huong,khoang cách(chieu dai duong raycast),layer)
        RaycastHit2D hit = Physics2D.Raycast
            (firepointpos, (mousePos - firepointpos),10,Whattohit);
        Debug.DrawLine(firepointpos, (mousePos - firepointpos) * 100,Color.cyan);
 
        if (hit.collider != null)
        {
            Debug.DrawLine(firepointpos, hit.point, Color.red);
            Debug.Log("We hit " + hit.collider.name);
            hit.collider.SendMessageUpwards("Damage", damage);
        }
 
    }
}