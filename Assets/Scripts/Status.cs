using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Status : MonoBehaviour
{
    public UnitCode unitCode { get; } // 유닛 코드를 부여하고 정보 받기
    public string statusName { get; set; }
    public int maxHp { get; set; }
    public int nowHp { get; set; }
    public int atkDmg { get; set; }
    public float atkSpeed { get; set; }
    public float moveSpeed { get; set; }
    public float atkRange { get; set; }
    public float fieldOfVision { get; set; }// 시야 범위

    public Status()
    {
    }
    //기본 생성자

    public Status(UnitCode unitCode, string name, int maxHp, int atkDmg, float atkSpeed, float moveSpeed, float atkRange, float fieldOfVision)
    {
        this.unitCode = unitCode;
        this.name = name;
        this.maxHp = maxHp;
        nowHp = maxHp;
        this.atkDmg = atkDmg;
        this.atkSpeed = atkSpeed;
        this.moveSpeed = moveSpeed;
        this.atkRange = atkRange;
        this.fieldOfVision = fieldOfVision;
    }
    //매개변수 넣어서 데이터도 저장하는 status 생성자 = C의 구조체 느낌

    public Status SetUnitStatus(UnitCode unitCode)
    {
        Status status = null;

        switch (unitCode)
        {
            case UnitCode.swordman: // 플레이어 나중에 문제생기면 바꾸기
                status = new Status(unitCode, "Player", 50, 10, 1f, 8f, 0, 0);
                break;
            case UnitCode.enemy1:
                status = new Status(unitCode, "Enemy1", 100, 12, 1.5f, 2f, 1.5f, 7f);
                break;
        }
        return status;
    }
}
