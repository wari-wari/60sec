using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kick : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f;

    private float minX = -20;

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        if(transform.position.x < minX) {
            Destroy(gameObject);
        }
    }
   // private void OnTriggerEnter2D(Collider2D other){   //istrigger 체크 되었을때 사용
//
   // }
//
     //private void private void OnCollisionEnter2D(Collision2D other) { //istrigger 체크 안되어있을때 사용
    //
   // }
    



}
