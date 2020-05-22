using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part6_Test : MonoBehaviour
{
    //[SerializeField]
    //private GameObject go_Target;
    //
    //[SerializeField]
    //private float speed;
    //
    //private Vector3 difValue;

    private Camera theCam;

    // Start is called before the first frame update
    void Start()
    {
        //difValue = transform.position - go_Target.transform.position;
        //difValue = new Vector3(Mathf.Abs(difValue.x), Mathf.Abs(difValue.y), Mathf.Abs(difValue.z));
        //theCam.fieldOfView = 50; //카메라 시점 설정 가능
        //theCam.clearFlags; // DepthOnly나 Skybos로 바꿀 수 있음
    }

    // Update is called once per frame
    void Update()
    {
        //Lerp -> 보간해줌 좌표 a, b와 비율 t (t = 0.5면 1/2비율로 보간한다는 뜻)
        //그냥 go_Target.transform.position 하면 상대 타겟에 카메라가 파고들게 됨 일정거리 (difValue)를 더해주어야 한다.
        //this.transform.position = Vector3.Lerp(this.transform.position, go_Target.transform.position + difValue, speed);
    }
}
