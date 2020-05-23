using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part16_Test : MonoBehaviour
{
    private AudioSource theAudio;

    [SerializeField] private AudioClip[] clip;

    // Start is called before the first frame update
    void Start()
    {
        theAudio = GetComponent<AudioSource>();
    }

    public void PlaySE()
    {
        //int형이라 0~3까지만 포함됨
        int _temp = Random.Range(0, 4);

        theAudio.clip = clip[_temp];
        theAudio.Play();
    }
}
