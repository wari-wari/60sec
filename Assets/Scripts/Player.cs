using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private float jumpForce; // 점프 힘

    private bool isGrounded; // 지면에 닿았는지 여부 체크

    private Rigidbody2D rb;

    private float life = 3f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {         
                         //키보드 방향키 받기
        float horizontalInput = Input.GetAxisRaw("Horizontal");
                                //키보드 방향키 받기
        float verticalInput = Input.GetAxisRaw("Vertical");
        // Vector3(x좌표,y좌표,z좌표)
        Vector3 moveTo = new Vector3(horizontalInput, verticalInput, 0f);

        transform.position += moveTo * moveSpeed * Time.deltaTime;

        // 점프 처리
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
        }


        //가로방향으로 움직이기
        // Vector3 moveTo  = new Vector3(moveSpeed * Time.deltaTime, 0, 0);
        // if(Input.GetKey(KeyCode.LeftArrow)) {
        //     transform.position -= moveTo;
        // } else if(Input.GetKey(KeyCode.RightArrow)){
        //     transform.position += moveTo;
        // }
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Enermy"){
            Debug.Log("Game Over!!");
            Destroy(gameObject);
        }
        if(other.gameObject.tag == "Kick"){
            life = life - 1;
            if(life <= 0){
                Debug.Log("Game Over!!");
                Destroy(gameObject);
            }else {
                Debug.Log("남은 목숨" + life);
            }
        }
    }

     private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

}
