using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part3_Test : MonoBehaviour
{
    private Rigidbody myRigid;
    private Vector3 rotation;

    void Start()
    {
        //이 스크립트가 붙여져있는 게임 오브젝트의 RigidBody를 불러옴 
        myRigid = GetComponent<Rigidbody>();
        rotation = this.transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            // 현재 움직이고 있는 속도 (Z축 방향으로 1로 나감)
            // 저항이 0이면 계속 Z축 방향으로 나아간다
            //myRigid.velocity = Vector3.forward; // == new Vector3(0, 0, 1); 
            // myRigid.angularVelocity = Vector3.right;
            //myRigid.mass = 2f;  // 질량
            //myRigid.drag = 2f;  // 저항
            //myRigid.angularDrag = 2f;  // 회전에 대한 저항
            //myRigid.maxAngularVelocity = 100; // 회전이 최대 속도 변경 -> 기본값은 7
            //myRigid.angularVelocity = Vector3.right * 100;

            // 메소드
            //myRigid.MovePosition(transform.forward * Time.deltaTime); // 일정 방향으로 이동시킴
            //rotation += new Vector3(90, 0, 0) * Time.deltaTime;
            //myRigid.MoveRotation(Quaternion.Euler(rotation));
            //MovePosition , MoveRotation -> 관성과 질량의 영향을 받지 않고 강제로 이동시킴
            //관성과 질량의 영향을 받으려면 AddForce로
            //myRigid.AddForce(Vector3.forward);
            //AddTorque = > W키 누를 때 계속 회전하다가 떼면 그 관성이 남아있음
            //myRigid.AddTorque(Vector3.up);
            //AddExplosionForce = > 폭발 구현할 때 유용함 (3가지만 넘겨도 됨)
            // (폭발력 세기, 폭발 위치(우측에서 터지면 왼쪽으로), 폭발 반경)
            // IsKinematic 누르면 적용 안됨
            myRigid.AddExplosionForce(10, this.transform.right, 10);
            //Add 시리즈는 물리효과와 관련 있다
            //Move 시리즈는 물리효과를 무시한다
        }
    }
}
