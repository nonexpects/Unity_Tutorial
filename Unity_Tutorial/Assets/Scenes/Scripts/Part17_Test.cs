using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part17_Test : MonoBehaviour
{
    //LayerMask -> 레이저를 쐈을 때 특정 레이어만 맞도록 설정해줄 수 있음
    //[SerializeField] private LayerMask layerMask;
    [SerializeField] private GameObject go_BulletPrefab;
    
    // 1초에 한개만 발사되게 설정
    private float createTime = 1f;
    private float currentCreateTime = 0;
    
    
    void Update()
    {
        //currentCreateTime += Time.deltaTime;
        //if(currentCreateTime >= createTime)
        //{
        //    //currentCreateTime = 0f;
        //    //
        //    //RaycastHit hitInfo;
        //    //if (Physics.Raycast(this.transform.position, this.transform.forward, out hitInfo, 10f, layerMask))
        //    //{
        //    //    // hitInfo에 충돌한 오브젝트의 정보가 담기므로 
        //    //    if (hitInfo.transform.tag == "Player")
        //    //    {
        //    //        // Instantiate -> Prefab을 생성시키는 명령어 / Quaternion 회전값 (방향설정) => 플레이어의 위치 - 자기자신의 위치
        //    //        Instantiate(go_BulletPrefab, transform.position, Quaternion.LookRotation(hitInfo.transform.position - transform.position));
        //    //    }
        //    //}
        //
        //}
        // 오버랩 시리즈 -> 특정 모양으로 영역을 생성하고 그 영역 안에 있는 모든 컬라이더를 담음 
        Collider[] col = Physics.OverlapSphere(transform.position, 5f); // 지름 10

        if(col.Length > 0) // 콜라이더가 1개 이상 있다
        {
            for (int i = 0; i < col.Length; i++)
            {
                // 임시변수 col의 i번째 위치를 담음
                Transform tf_Target = col[i].transform;

                if(tf_Target.tag == "Player")
                {
                    Quaternion rotation = Quaternion.LookRotation(tf_Target.position - this.transform.position);
                    //LookRotation에 타겟 위치좌표와 내 위치좌표 뺀 값을 보내면 피타고라스 정리에 의해 대각선값 계산해서
                    //그 대각선 값을 방향값으로 바꿈
                    transform.rotation = rotation;

                    currentCreateTime += Time.deltaTime;

                    if (currentCreateTime >= createTime)
                    {
                        //총알 컬라이더를 변수로 받음 (prefab을 생성시켜서 변수에다 넣는다)
                        GameObject _temp = Instantiate(go_BulletPrefab, transform.position, rotation);
                        // 콜라이더 1(총알)과 콜라이더 2 (플레이어)사이의 모든 충돌을 무시하게 만든다
                        Physics.IgnoreCollision(_temp.GetComponent<Collider>(), tf_Target.GetComponent<Collider>());
                        currentCreateTime = 0;
                    }
                }
            }
        }
    }
}
