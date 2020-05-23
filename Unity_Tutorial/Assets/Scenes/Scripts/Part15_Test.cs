using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 우리가 만든 커스텀 클래스는 System.Serializable을 따로 선언해줘야 
// inspector 창에 뜬다.

[System.Serializable]
public class Dialogue
{
    [TextArea]
    public string dialogue;
    public Sprite cg;
}

public class Part15_Test : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sprite_StandingCG;
    [SerializeField] private SpriteRenderer sprite_DialogueBox;
    [SerializeField] private Text txt_Dialogue;

    private bool isDialogue = false;
    private int count = 0;

    //대사가 여러줄있고 다음 문장으로 계속 교체되므로 배열
    [SerializeField] private Dialogue[] dialogue;

    public void ShowDialog()
    {
        OnOff(true);
        count = 0;
        NextDialogue();
    }

    private void OnOff(bool _flag)
    {
        // SetActive -> 이름 옆에 활성화 비활성화 버튼
        sprite_DialogueBox.gameObject.SetActive(_flag);
        sprite_StandingCG.gameObject.SetActive(_flag);
        txt_Dialogue.gameObject.SetActive(_flag);
        isDialogue = _flag;
    }

    private void NextDialogue()
    {
        txt_Dialogue.text = dialogue[count].dialogue;
        sprite_StandingCG.sprite = dialogue[count].cg;
        count++;
    }

    // Update is called once per frame
    void Update()
    {
        if(isDialogue)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if(count < dialogue.Length)
                {
                    NextDialogue();
                }
                else
                {
                    OnOff(false);
                }
            }
        }
    }
}
