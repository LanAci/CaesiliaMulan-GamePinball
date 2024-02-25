using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleControl : MonoBehaviour
{
    //taro smua variable sebelom start biar rapih (jadi kek daftar isi sebelom unity start)
    private HingeJoint hinge;

    public KeyCode input;

    private float targetPressed;
    private float targetRelease;

    private void Start()

    {
        //buat ngambil spring dari component Hinge Joint
        hinge = GetComponent<HingeJoint>();

        targetPressed = hinge.limits.max;
        targetRelease = hinge.limits.min;
    }

    private void Update()
    {
        ReadInput();
    }
    
    private void ReadInput()
    {
        //spring nya udah ada di start jadi tiap ganti frame gausa ngambil lagi
        JointSpring jointSpring = hinge.spring;

        //rubah value spring pas input dipencet/gadipencet
        if (Input.GetKey(input))
        {
            jointSpring.targetPosition = targetPressed;
            Debug.Log("Wai gerak!");
        }
        else
        {
            jointSpring.targetPosition = targetRelease;
        }

        //ngubah spring di Hinge Joint pake value yang udh diubah
        hinge.spring = jointSpring;
    }


}
