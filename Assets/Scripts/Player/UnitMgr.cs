using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//충돌여부와 상태 판정 스크립트
public class UnitMgr : MonoBehaviour
{
    public Animator animator;
    [HideInInspector]
    public Rigidbody2D rigid2D;
    [HideInInspector]
    public bool died = false;
    [HideInInspector]
    public Collider2D col2D;
    [HideInInspector]
    public bool attacked = false;
    // 공격이 적중했는지 여부(한 공격당 1회만 데미지 주기 위해)

    public Status status;
    // 스테이터스

    public UnitCode unitCode;
    // 유닛 코드 (유닛 구분용)

    void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        col2D = GetComponent<Collider2D>();

        // 스테이터스 설정
        status = new Status();
        status = status.SetUnitStatus(unitCode);
        SetAttackSpeed(status.atkSpeed);
        StartCoroutine(CheckDied());
    }

    IEnumerator CheckDied()
    {
        while (true)
        {
            // 땅 밑으로 떨어졌다면
            if (transform.position.y < -8)
            {
                if (unitCode.Equals(UnitCode.swordman))
                    SceneManager.LoadScene("Main"); // Scene 재시작
                else Destroy(gameObject);
            }

            // 체력이 0이하일 때
            if (status.nowHp <= 0)
            {
                died = true;
                animator.SetTrigger("die");
                Destroy(rigid2D);
                Destroy(col2D);
                yield return new WaitForSeconds(2); // 2초 기다리기
                if (unitCode.Equals(UnitCode.swordman))
                    SceneManager.LoadScene("Main"); // Scene 재시작
                else Destroy(gameObject);
            }
            yield return new WaitForEndOfFrame(); // 매 프레임의 마지막 마다 실행
        }
    }

    /*적이 플레이어한테 공격당하면서 무기에 닿으면 ->> 데미지 주고 공격 적중 여부 초기화*/
    void OnTriggerEnter2D(Collider2D col)
    {
        if (tag.Equals("Enemy")) // 적이 플레이어한테 공격당했을 때
        {
            if (col.CompareTag("Weapon")) // 무기에 닿았을 때
            {
                UnitMgr _unitMgr = col.GetComponentInParent<UnitMgr>(); // 무기가 지닌 스탯 가져오기
                if (_unitMgr.attacked)
                {
                    status.nowHp -= _unitMgr.status.atkDmg; // 데미지 주기
                    _unitMgr.attacked = false; // 공격 적중 여부 초기화
                }
            }
        }
        /*플레이어가 적한테 공격당하면서 무기에 닿으면 ->> 데미지 주고 공격 적중 여부 초기화*/
        else if (tag.Equals("Player"))
        {
            if (col.CompareTag("Weapon"))
            {
                UnitMgr _unitMgr = col.GetComponentInParent<UnitMgr>(); // 무기가 지닌 스탯 가져오기
                if (_unitMgr.attacked)
                {
                    status.nowHp -= _unitMgr.status.atkDmg; // 데미지 주기
                    _unitMgr.attacked = false; // 공격 적중 여부 초기화
                }
            }
        }
    }
    //TODO: status 스크립트랑 겹쳐서 코드 어디다 둬야할지 생각해봐야
    /*속도, 공격속도 설정 및 반환*/
    #region properties
    
    public void SetAttackSpeed(float speed)
    {
        animator.SetFloat("attackSpeed", speed);
        status.atkSpeed = speed;
    }

    public float GetAttackSpeed()
    {
        return status.atkSpeed;
    }

    public void SetMoveSpeed(float speed)
    {
        status.moveSpeed = speed;
    }
    public float GetMoveSpeed()
    {
        return status.moveSpeed;
    }

    void AttackTrue()
    {
        attacked = true;
    }
    void AttackFalse()
    {
        attacked = false;
    }

    #endregion

}
