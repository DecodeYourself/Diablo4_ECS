using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxisTest : MonoBehaviour
{
    [SerializeField] CharacterController cc;

    Vector3 gravity = new Vector3(0, -9.7f, 0);
    private void Start()
    {
        
    }
    void Update()
    {
        if(!cc.isGrounded)
        {
            cc.Move(gravity);
        }

    }
}
