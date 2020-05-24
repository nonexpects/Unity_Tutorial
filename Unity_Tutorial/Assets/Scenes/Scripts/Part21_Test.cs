using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Part21_Test : MonoBehaviour
{
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] col = Physics.OverlapSphere(transform.position, 10f);

        if(col.Length > 0)
        {
            for (int i = 0; i < col.Length; i++)
            {
                //플레이어의 좌표 담음
                Transform tf_Target = col[i].transform;

                if(tf_Target.name == "Player")
                {
                    // 경로계산 Path -> 좌표 값을 담고있음
                    NavMeshPath path = new NavMeshPath();
                    // CalculatePath 자기자신에서 목적지까지 거리 환산해서 path에 집어넣음
                    agent.CalculatePath(tf_Target.position, path);

                    // corners = > 적과 플레이어의 거리에 꺾어지는 코너값을 기억함 
                    // 단점 : 자기자신의 위치, 타겟의 위치까지 기억하지는 않음.
                    Vector3[] wayPoints = new Vector3[path.corners.Length + 2]; // 자기자신과 타겟의 목적지까지 담아야해서 +2
                    wayPoints[0] = transform.position; // 처음엔 자기자신 위치
                    wayPoints[wayPoints.Length - 1] = tf_Target.position; // 마지막 인덱스는 타겟의 위치

                    float _distance = 0f;
                    for (int p = 0; p < path.corners.Length; p++)
                    {
                        wayPoints[p + 1] = path.corners[p]; // p(=0)은 자기자신의 값이므로 
                        _distance += Vector3.Distance(wayPoints[p], wayPoints[p + 1]);
                        
                    }

                    if(_distance <= 10f)
                    {
                        // 에너미의 스피어 반경 안에 들어오면 목적지를 타겟의 좌표로 설정
                        agent.SetDestination(tf_Target.position);
                    }
                }
            }
        }
    }
}
