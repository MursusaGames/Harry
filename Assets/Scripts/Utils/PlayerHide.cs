using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHide : MonoBehaviour
{
    [SerializeField] private Sosige sosige;

    public void HideHero()
    {
        sosige.StopVisual();
    }
}
