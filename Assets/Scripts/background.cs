using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour
{
    //배경 움직이는 속도
    private float moveSpeed = 3f;

    // Update is called once per frame
    void Update()
    {
        //배경 움직이는 코드
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        if (transform.position.x < -33) {
            transform.position += new Vector3(93f, 0, 0);
        }
        
    }
}

