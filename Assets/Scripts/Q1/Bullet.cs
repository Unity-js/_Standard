using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : IAttackPattern
{
    public float bulletspeed = 10.0f;
    public void Attack(GameObject projectile, Vector3 origin, Vector3 target)
    {
        GameObject bullet = GameObject.Instantiate(projectile, origin, Quaternion.identity); // ����ü�� origin ��ġ���� ����

        Rigidbody rb = bullet.GetComponent<Rigidbody>(); // Rigidbody ������Ʈ�� �������̵�

        Vector3 dir = (target - origin).normalized; // target ��ġ�� ����3 ��� > ����ȭ

        rb.velocity = dir * bulletspeed; // ������ �ӵ��� �����̵�
    }
}

// �������� �����ϴ� �Ѿ�