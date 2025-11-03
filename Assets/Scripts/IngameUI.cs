using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Unity.VisualScripting;

//IngameUI

public class IngameUI : MonoBehaviour
{
    public GameObject Status; //채력 스탯 가지고 있는 오브젝트
    public IngameUI HpBar; // 체력바 UI

    private void Start()
    {
        Status.GetComponent<Status>().nowHp = Status.GetComponent<Status>().maxHp;
        // 초기화 작업
    }

}

