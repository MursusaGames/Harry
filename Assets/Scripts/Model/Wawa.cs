using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wawa : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private GameObject sosigBody;
    void OnEnable()
    {
        anim = GetComponent<Animator>();
    }

    public void Go()
    {
        sosigBody.SetActive(true);
        Invoke(nameof(ResetGAnim), 1f);
    }
    private void ResetGAnim()
    {
        anim.SetBool("Stop", true);
    }
}
