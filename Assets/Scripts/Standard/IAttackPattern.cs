using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface IAttackPattern

    {
        void Attack(GameObject projectile, Vector3 origin, Vector3 target); // ����ü , ��������, ��ǥ��ġ
    }

// ���������� Ȱ���Ͽ� �پ��� ���Ÿ� ���� ���� ������ ��������.