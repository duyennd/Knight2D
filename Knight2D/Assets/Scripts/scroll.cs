using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class scroll : MonoBehaviour
{
    public Player player; // lay vi tri ng choi 
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
 
    void FixedUpdate()
    {
        MeshRenderer mr = GetComponent<MeshRenderer>();
        Material mat = mr.material;
        Vector2 offset = mat.mainTextureOffset;
        offset.x = player.transform.position.x ;
        mat.mainTextureOffset = offset * Time.fixedDeltaTime /0.42f;
    }
}