using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    bool inputRight = false;
    bool inputLeft = false;
    //이동 방향 어느쪽인지

    UnitMgr unitMgr;
    Animator animator;
    Rigidbody2D rigid2D;
    Status status;
    //각종 컴포넌트 선언
    void Start()
    {
        unitMgr = GetComponent<UnitMgr>();
        animator = unitMgr.animator;
        rigid2D = unitMgr.rigid2D;
        status = unitMgr.status;
        //각종 컴포넌트 받아오기
    }

    void Update()
    {
        if (unitMgr.died) return;
        //죽었으면 움직이지 않음

        /*-----애니매이션을 부드럽게 하면서 이동-----*/
        if (Input.GetKey(KeyCode.RightArrow))
        {
            inputRight = true;
            transform.localScale = new Vector3(-1, 1, 1);
            animator.SetBool("moving", true);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            inputLeft = true;
            transform.localScale = new Vector3(1, 1, 1);
            animator.SetBool("moving", true);
        }
        else animator.SetBool("moving", false);
    }

    private void FixedUpdate()
    {
        if (unitMgr.died) return;

        if (inputRight)
        {
            inputRight = false;
            //transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            //rigid2D.MovePosition(rigid2D.position + Vector2.right * moveSpeed * Time.deltaTime);
            //rigid2DlinearVelocity = new Vector2(moveSpeed, rigid2DlinearVelocity.y);
            rigid2D.AddForce(Vector2.right * status.moveSpeed);
        }
        if (inputLeft)
        {
            inputLeft = false;
            //transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            //rigid2D.MovePosition(rigid2D.position + Vector2.left * moveSpeed * Time.deltaTime);
            //rigid2DlinearVelocity = new Vector2(-moveSpeed, rigid2DlinearVelocity.y);
            rigid2D.AddForce(Vector2.left * status.moveSpeed);
        }
        if (rigid2D.linearVelocity.x >= 1.5f) rigid2D.linearVelocity = new Vector2(1.5f, rigid2D.linearVelocity.y);
        //최대 속도 제한
        else if (rigid2D.linearVelocity.x <= -1.5f) rigid2D.linearVelocity = new Vector2(-1.5f, rigid2D.linearVelocity.y);
        //반대방향 최대 속도 제한
    }

    
}
