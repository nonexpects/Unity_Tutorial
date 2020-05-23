using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part10_Test : MonoBehaviour
{
    ParticleSystem ps;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // play on awake 체크 안되어있으면 우리가 플레이를 해줘야함
        ps.Play();
        //입자가 숫자만큼 뿜어져나옴(Burst)
        ps.Emit(300);
    }
}
