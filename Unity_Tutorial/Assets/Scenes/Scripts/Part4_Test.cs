using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part4_Test : MonoBehaviour
{
    private BoxCollider col;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<BoxCollider>();
    }

    //OnTriggerEnter-> isTrigger가 켜졌을 때 박스 콜라이더 안으로 
    //다른 컬라이더가 들어오면 발동됨 => 들어올 때 최초 1회 실행
    private void OnTriggerEnter(Collider other)
    {
        
    }
    //OnTriggerExit => 나갈 때 1회 실행 
    private void OnTriggerExit(Collider other)
    {
        other.transform.position = new Vector3(0, 2, 0);
    }
    //OnTriggerStay => 머물고 있으면 계속 실행됨
    private void OnTriggerStay(Collider other)
    {
        other.transform.position += new Vector3(0, 0, 0.1f);
    }

    //OnCollision~~~ => IsTrigger가 아니라 실제로 충돌이 일어났을 떄 발동
    private void OnCollisionEnter(Collision collision)
    {
        
    }
    private void OnCollisionExit(Collision collision)
    {

    }
    private void OnCollisionStay(Collision collision)
    {

    }


    // Update is called once per frame
    //void Update()
    //{
    //    if(Input.GetMouseButtonDown(0)) // 0 -> 좌버튼
    //    {
    //        //Debug.Log("cold.bounds" + col.bounds);
    //        ////extents -> 각 면에 대한 사이즈의 반을 나타냄. x축이 1이면 0.5 리턴
    //        //Debug.Log("col.bounds.extents" + col.bounds.extents);
    //        //Debug.Log("col.bounds.extents.x" + col.bounds.extents.x);
    //        ////extents랑 extents.x 빼고 전부 수정가능
    //
    //        //Debug.Log("col.size" + col.size);
    //        //Debug.Log("col.center" + col.center);
    //
    //        //col.size = new Vector3(3, 3, 3);
    //        //Raycast = > 보이지 않지만 레이저를 쏜다 (boolean을 반환)
    //        //3개의 파라미터 좌표 (레이저 좌표, 맞은 곳에 대한 정보, 사정거리)
    //        //메인 카메라에 Tag -> MainCamera로 변경 
    //        //ScreenPointToRay -> 특정 좌표에 레이저 쏘는거
    //        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //        //RaycastHit hitInfo;
    //        //if(col.Raycast(ray, out hitInfo, 1000))
    //        //{
    //        //    this.transform.position = hitInfo.point;
    //        //}
    //    }
    //}
}
