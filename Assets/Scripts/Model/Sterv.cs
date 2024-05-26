using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sterv : MonoBehaviour
{
    [SerializeField] private Animator anim;

    public void GoAnim()
    {
        anim.SetBool("Go", true);
    }
}
