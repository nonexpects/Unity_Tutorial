using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part9_Test : MonoBehaviour
{
    private Animator anim;
    private Rigidbody rigid;
    private BoxCollider col;

    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private LayerMask layerMask;

    private bool isMove;
    private bool isJump;
    private bool isFall;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
        col = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {

        TryWalk();
        TryJump();
        
    }

    private void TryJump()
    {
       
        if (isJump)
        {
            //속도가 점프하면 +지만 떨어질 땐 -가됨
            if(rigid.velocity.y <= -0.01f && !isFall)
            {
                isFall = true;
                anim.SetTrigger("Fall");
            }
            //땅에 닿은건 Raycast로 감지
            //레이저에 맞은 객체의 정보 저장시킴
            RaycastHit hitInfo;
            // 모든 콜라이더와 충돌할 경우 true가 됨
            //-up이면 밑으로 레이저 쏘는거
            // 얼마만큼의 레이저를 쏠지 거리는 BoxCollider를 사용. extents는 박스콜라이더 사이즈의 반사이즈 (중심)
            // 특정 레이어만 충돌하도록 layerMask 추가. (여기선 바닥)
            if (Physics.Raycast(transform.position, -transform.up, out hitInfo, col.bounds.extents.y + 0.1f, layerMask))
            {
                anim.SetTrigger("Land");
                isJump = false;
                isFall = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space) && !isJump) //Jump 안할 때만 점프시키자
        {
            isJump = true;
            //rigid.velocity = new Vector3(0, jumpForce, 0);
            rigid.AddForce(Vector3.up * jumpForce);
            anim.SetTrigger("Jump");
        }
    }

    private void TryWalk()
    {
        // Horizontal -> A나 D키 / 방향키 왼쪽, 오른쪽 (오른쪽 1, 왼쪽은 -1, 아무것도 안누르면 0)
        float _dirX = Input.GetAxisRaw("Horizontal");
        // Vertical -> W나 S키 / 방향키 위, 아래 (위 1, 아래 -1, 아무것도 안누르면 0)
        float _dirZ = Input.GetAxisRaw("Vertical");

        //Project Setting -> Input에 Horizontal / Vertical이 있고 키가 정의되어 있음

        Vector3 direction = new Vector3(_dirX, 0, _dirZ);
        isMove = false;

        if (direction != Vector3.zero) // 키를 누르면 발동
        {
            //normalized -> 방향만 나타내게 됨. => 키룰 두 개 같이 눌러 1 + 1 으로 2가 되어도 1로 처리함
            //대각선 움직임도 수평 수직 움직임과 똑같이 만들기 위해서 사용
            // 하지 않으면 대각선 속도만 유독 빨라진다.
            this.transform.Translate(direction.normalized * moveSpeed * Time.deltaTime);
            isMove = true;
        }

        anim.SetBool("Move", isMove);
        anim.SetFloat("DirX", direction.x);
        anim.SetFloat("DirZ", direction.z);
    }
}
