using UnityEngine;

public class EnemyChaseState : State
{
    public override void Enter()
    {
        Debug.Log("� ����� � ��������� �������������");
    }

    public override void Exit()
    {
        Debug.Log("� ����� �� ��������� �������������");
    }

    public override void Update()
    {
        Debug.Log("� � ��������� �������������");
    }
}