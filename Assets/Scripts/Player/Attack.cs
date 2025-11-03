using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    Animator animator;
    UnitMgr unitMgr;

    void Start()
    {
        unitMgr = GetComponent<UnitMgr>(); // UnitMgr 컴포넌트 가져오기
        animator = unitMgr.animator; 
    }

    void Update()
    {
        if (unitMgr.died) return; // 유닛이 죽었으면 공격하지 않음

        if (Input.GetKey(KeyCode.A) &&
            !animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            animator.SetTrigger("attack");
            //SFXManager.Instance.PlaySound(SFXManager.Instance.playerAttack); // 공격 사운드 재생
        }
    }
}
