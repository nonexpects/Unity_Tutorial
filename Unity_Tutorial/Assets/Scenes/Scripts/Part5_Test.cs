using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part5_Test : MonoBehaviour
{
    [SerializeField]
    private Material red_Mat;
    [SerializeField]
    private Material green_Mat;

    private MeshRenderer mesh;
    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            mesh.material = green_Mat;
        }
        else
        {
            mesh.material = red_Mat;
        }
    }
}
