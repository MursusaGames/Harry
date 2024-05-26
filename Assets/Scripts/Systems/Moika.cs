using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moika : MonoBehaviour
{
    [SerializeField] private Animator anim;

    public void Go()
    {
        anim.SetBool("Sos", true);
    }
}
