using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pech : MonoBehaviour
{
    [SerializeField] private GameObject fire;

    public void FireOn()
    {
        fire.SetActive(true);
    }
    public void FireOff()
    {
        fire.SetActive(false);
    }
}
