using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Parabolic : MonoBehaviour, IAttackPattern
{
    public void Attack(GameObject projectile, Vector3 origin, Vector3 target)
    {
        projectile.transform.position = origin; // 시작 위치 및 회전

        Rigidbody rb = projectile.GetComponent<Rigidbody>(); // 중력(포물선용) Rigidbody
        if (rb != null)
        {
            rb = projectile.GetComponent<Rigidbody>();
        } // null

        rb.useGravity = true;

        Vector3 velocity = CalculateVelocity(origin, target, 1.0f); // 속도 계산
        rb.velocity = velocity;
    }

    private Vector3 CalculateVelocity(Vector3 origin, Vector3 target, float flytime)
    {
        Vector3 dis = target - origin; // x, z 속도
        Vector3 disXZ = dis;
        disXZ.y = 0;

        float horizontalDis = disXZ.magnitude;
        float verticalDis = dis.y;

        float velocityXZ = horizontalDis / flytime; // x, z 속도 = (거리 / 시간)

        float velocityY = (verticalDis / flytime) + (0.5f * Mathf.Abs(Physics.gravity.y) * flytime); // y 속도 = 포물선의 고점위치 , 거리 / 시간 , 중력 계산

        Vector3 result = disXZ.normalized * velocityXZ; // 방향 * 속도 > 벡터 변환
        result.y = velocityY;

        return result;
    }
}

//  - 던졌을 때 위로 포물선을 그리며 움직이는 투척물 
// flytime 으로 포물선의 높이 조정이 될수있음