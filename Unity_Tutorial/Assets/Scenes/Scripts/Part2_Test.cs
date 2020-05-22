using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part2_Test : MonoBehaviour
{
    Vector3 rotation;

    // Inspector 창에 띄우기 //
    // public으로 하면 되긴 하는데 보안범위가 너무 넓어짐
    // 고로 SerializedField 사용 
    [SerializeField]
    private GameObject go_camera;
    // 시작할 때 최초 1회 실행
    void Start()
    {
        rotation = this.transform.eulerAngles;
    }

    // 1초에 약 60회 실행됨 -> 매 프레임마다 입력이 필요할 때
    void Update()
    {
        if (Input.GetKey(KeyCode.W)) // bool
        {
            // 이동
            //1. 매 프레임 마다 1씩 증가시킴 -> 한번 누를 때 60번 증가
            //this.transform.position = this.transform.position + new Vector3(0, 0, 1);
            //2. 누를 때마다 1씩 증가시킴
            //this.transform.position = this.transform.position + new Vector3(0, 0, 1) * Time.deltaTime;
            //3. Translate 이용해서 이동
            //this.transform.Translate(new Vector3(0, 0, 1) * Time.deltaTime);
            // 
            // 로테이션
            //1. 유니티에서 보는 회전값(vector3) -> 내부적으로 돌아가는 것과 겉으로 보이는게 다름 
            // this.transform.eulerAngles를 쓰면 90도 넘으면 이상해짐
            //this.transform.eulerAngles = transform.eulerAngles + new Vector3(90, 0, 0) * Time.deltaTime;
            //2. 90도 넘었을 때 이상해지진 않지만 수치가 다름 겉으로 보이는 것과 내부값이 다르다
            // 이유 : 오일러 값이 쿼터니온으로 변환되기 떄문 -> 유니티는 회전을 쿼터니온으로 함.
            // 우리는 보기 편하기 오일러 앵글로 사용하고 유니티가 자체적으로 쿼터니온으로 알아서 바꿔줌
            // ==> 따라서 수치가 다르게 보인다
            //rotation = rotation + new Vector3(90, 0, 0) * Time.deltaTime;
            //this.transform.eulerAngles = rotation;
            //3. Rotate 이용 => 가장 편하다 / 권장
            //this.transform.Rotate(new Vector3(90, 0, 0) * Time.deltaTime);
            //Debug.Log(this.transform.eulerAngles);
            //4. Quaternion 이용 => 4원소이고 실수 이용 (유니티도 값을 직접 입력하지 말라고 한다)
            //this.transform.rotation = new Quaternion(0.3f, .4f, 0, 0);
            // ==> 오일러 메소드를 이용하면 된다.
            rotation += new Vector3(90, 0, 0) * Time.deltaTime;
            this.transform.rotation = Quaternion.Euler(rotation);
            // 왜 Rotate 안쓰고 쿼터니온으로 쓰는가?
            // 한 축을 90도로 고정하면 다른 축들이 이상해질 수 있다 < '짐벌락' 현상
            // 짐벌락은 오일러 현상에서만 존재함 -> 쿼터니온에선 그럴 일이 없다. 그래서 쿼터니온을 이용한다.
            // 짐벌락이 일어날것 같으면 쿼터니온 사용하면 됨.
            //
            // 트랜스폼
            // 1. 기본적인 local Scale
            //this.transform.localScale = this.transform.localScale + new Vector3(2, 2, 2) * Time.deltaTime;
            //this.transform.forward // ==> 정규화 벡터(방향만을 알려주는 녀석) new Vector3(0, 0, 1) 과 같은 기능을 한다 
            //moveSpeed * this.transform.Up * Time.deltaTime;
            //this.transform.LookAt(go_camera.transform.position); // 타겟을 바라보게 함 -> 타겟이 필요하고 특정 대상이 필요함.
            //RotateAround => 태양 공전이랑 비슷 (타겟, 축, 얼만큼 회전시킬거냐)
            transform.RotateAround(go_camera.transform.position, Vector3.up, 100 * Time.deltaTime);
        }
    }
}
