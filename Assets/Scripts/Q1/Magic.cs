using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic : IAttackPattern
{
    public float magicspeed = 10.0f;
    public void Attack(GameObject projectile, Vector3 origin, Vector3 target)
    {
        int numprojectiles = 10; // ����ü ���� 
        float checkangle = 360.0f / numprojectiles; // ����ü������ ����

        for (int i = 0; i < numprojectiles; i++) // ����ü ������ŭ 
        {
            float angle = checkangle * i; // ���� ��� 

            Vector3 dir = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad),0, Mathf.Sin(angle * Mathf.Deg2Rad));  // ������ ���� �������� ��������, y���� �ǵ帱 �ʿ� x 
            // ���� ���ָ� ���� ��ġ�ؾ��ϰ�, �ﰢ�Լ��� �̿������Ƿ� Radian���� ��ȯ (Deg2Rad)

            GameObject magicProjectile = GameObject.Instantiate(projectile, origin, Quaternion.identity); // ����ü origin ��ġ���� ����
            Rigidbody rb = magicProjectile.GetComponent<Rigidbody>();

            rb.velocity = dir * magicspeed; // �����ӵ���� ��������


        }

        
    }
}

//    - �� ������� ���ĳ����� ���� ����
