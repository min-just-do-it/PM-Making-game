///////////////
// 점프:space키 할당
// TODO:공격 A
// PM_TODO:하강 X
// PM_TODO:AttackSkill1,2,3() qwe
// PM_TODO:막기 D or Ctrl
// PM_TODO:매달리기 Shift키

// PM_TODO:공중점프
////////////////

using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [Header("키입력")]
    public KeyCode attackKey = KeyCode.A;
    public KeyCode fallKey = KeyCode.X;
    public KeyCode skill1Key = KeyCode.Q;
    public KeyCode skill2Key = KeyCode.W;
    public KeyCode skill3Key = KeyCode.E;
    public KeyCode guardKey = KeyCode.D;
    public KeyCode jumpKey = KeyCode.Space;

    [Header("키입력체크")]
    public bool attack;
    public bool fall;
    public bool skill1;
    public bool skill2;
    public bool skill3;
    public bool guard;
    public bool jump;   // 점프 입력

    void Update()
    {
        attack = Input.GetKeyDown(attackKey);
        fall = Input.GetKeyDown(fallKey); 
        skill1 = Input.GetKeyDown(skill1Key);        
        skill2 = Input.GetKeyDown(skill2Key);        
        skill3 = Input.GetKeyDown(skill3Key);
        guard = Input.GetKey(guardKey);

        // jumpPressed
        jump = Input.GetKeyDown(jumpKey);
    }
}