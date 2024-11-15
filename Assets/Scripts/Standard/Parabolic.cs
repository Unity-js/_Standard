using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Parabolic : MonoBehaviour, IAttackPattern
{
    public void Attack(GameObject projectile, Vector3 origin, Vector3 target)
    {
        projectile.transform.position = origin; // ���� ��ġ �� ȸ��

        Rigidbody rb = projectile.GetComponent<Rigidbody>(); // �߷�(��������) Rigidbody
        if (rb != null)
        {
            rb = projectile.GetComponent<Rigidbody>();
        } // null

        rb.useGravity = true;

        Vector3 velocity = CalculateVelocity(origin, target, 1.0f); // �ӵ� ���
        rb.velocity = velocity;
    }

    private Vector3 CalculateVelocity(Vector3 origin, Vector3 target, float flytime)
    {
        Vector3 dis = target - origin; // x, z �ӵ�
        Vector3 disXZ = dis;
        disXZ.y = 0;

        float horizontalDis = disXZ.magnitude;
        float verticalDis = dis.y;

        float velocityXZ = horizontalDis / flytime; // x, z �ӵ� = (�Ÿ� / �ð�)

        float velocityY = (verticalDis / flytime) + (0.5f * Mathf.Abs(Physics.gravity.y) * flytime); // y �ӵ� = �������� ������ġ , �Ÿ� / �ð� , �߷� ���

        Vector3 result = disXZ.normalized * velocityXZ; // ���� * �ӵ� > ���� ��ȯ
        result.y = velocityY;

        return result;
    }
}

//  - ������ �� ���� �������� �׸��� �����̴� ��ô�� 
// flytime ���� �������� ���� ������ �ɼ�����