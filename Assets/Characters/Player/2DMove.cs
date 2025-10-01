using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Move : MonoBehaviour
{
    private float movespeed = 5.0f; //이속
    private Vector3 moveDirection = Vector3.zero; //이동 방향
    private void Update()
    {
        float x = Input.GetAxis("Horizontal"); //수평 입력
        // 왼쪽은 -1, 오른쪽은 1
        moveDirection = new Vector3(x, 0, 0); //이동 방향 설정
        transform.position += moveDirection * movespeed * Time.deltaTime;
        //이동위치 = 현재위치 + (이동방향 * 이동속도) * 시간
        
        //점프
        //내려가기(메이플 웅크리기)
        //행동의 애니메이션
    }
}