using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Part25_Test : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField] private RectTransform rect_Background;
    [SerializeField] private RectTransform rect_Joystick;

    private float radius;

    [SerializeField] private GameObject go_Player;
    [SerializeField] private float moveSpeed;

    private bool isTouch = false;
    private Vector3 movePosition;

    // Start is called before the first frame update
    void Start()
    {
        radius = rect_Background.rect.width * 0.5f; // 반지름
    }

    // Update is called once per frame
    void Update()
    {
        if (isTouch)
            go_Player.transform.position += movePosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 value = eventData.position - (Vector2)rect_Background.position; // rect는 UI 포지션이 x, y, z라서 vector3
        // 조이스틱을 마우스좌표와 백그라운드 좌표에서 뺀 만큼 이동시킨다

        // 좌표 이동 제한(너무 멀리 나가면 안되므로)
        value = Vector2.ClampMagnitude(value, radius); // value를 radius만큼 가둬둔다 
        // ex) 만약 value가 1이고 radius가 4면 제한이 (-3 ~ 5)로 제한됨 = (1-4, 1+4)


        // 조이스틱은 부모 객체의 좌표를 기준으로 좌표를 계산하므로 
        rect_Joystick.localPosition = value;

        float distance = Vector2.Distance(rect_Background.position, rect_Joystick.position) / radius; // 조이스틱이 백그라운드에서 멀어지면 멀어질수록 Distance가 커짐
        // radius = 60 / 최대한 먼 경우가 반지름 밖에 없으니까 최대 1 나올 것임 (1*speed니까 최대스피드가 나옴)
        value = value.normalized; // 속도값은 빠지고 방향값만 남음 -> value값을 speed로 이용해주면 된다.
        // (50, 0, 30) -> (0.5, 0.3)

        movePosition = new Vector3(value.x * moveSpeed * distance * Time.deltaTime, 0f, value.y * moveSpeed * distance * Time.deltaTime);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isTouch = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isTouch = false;
        rect_Joystick.localPosition = Vector3.zero; // 원 위치로 돌림 
        // 이전 클릭값이 기억되어서 클릭만해도 움직이므로 초기화 필요
        movePosition = Vector3.zero;
    }

}
