using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; // 클릭과 관련된 인터페이스를 상속받을 수 있음

// 클릭&드래그 인터페이스는 Canvas 안에 있는 UI요소에만 적용됨
//IEndDragHandler - > 마우스 클릭을 떼면 호출됨 (무조건적임)
//IDropHandler - > 마우스 클릭을 떼면 호출됨 (마우스 뗐을 때 그 객체에서 마우스가 벗어나지 않을 때 호출됨)
//Drop 이용하면 아이템 드래그 할 때 엉뚱한 데에다가 마우스를 놓으면 그냥 제자리로 돌아가게끔 할 수 있음(Drag만 호출되므로)
public class Part23_Test : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    public void OnBeginDrag(PointerEventData eventData)
    {
        //오류가 뜰 때 시스템 메시지 출력해주는 명령어
        //throw new System.NotImplementedException();

        Debug.Log("Begin Drag");
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Drag");
        // 스크립트가 붙여져 있는 객체에 eventData의 좌표값을 대입 
        // eventData는 현재 커서의 위치 
        transform.position = eventData.position;
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Drop");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("End Drag");
    }
}
