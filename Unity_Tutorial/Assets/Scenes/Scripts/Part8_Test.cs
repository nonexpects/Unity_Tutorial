using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part8_Test : MonoBehaviour
{
    private Animation anim;
    private AnimationClip clip;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            // 큐브1이 끊기고 바로 재생
            //anim.Play("Cube_2");
            //// 큐브1이 끝나고 재생됨
            //anim.PlayQueued("Cube_2");
            // 같이 재생됨
            //anim.Blend("Cube_2");
            // 큐브1 실행한게 자연스레 사라지고 큐브2가 실행됨 
            //anim.CrossFade("Cube_2");
            //// IsPlaying->Cube2가 실행중이면 true를 반환
            //if(anim.IsPlaying("Cube_2"))
            //{
            //    anim.Play("Cube_2");
            //}
            // 진행중인 애니메이션 전부 멈춤
            //anim.Stop();
            //anim.wrapMode = WrapMode.PingPong;
            //anim.clip = clip;
            anim.animatePhysics = false;
        }
    }
}
