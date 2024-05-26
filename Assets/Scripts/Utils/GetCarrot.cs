using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCarrot : MonoBehaviour
{
    [SerializeField] private AudioSource krik;
    [SerializeField] private Sosige sosige;

    public void Fallen()
    {
        sosige.Fallen();
    }
    public void Chostn()
    {
        krik.Play();
        sosige.Chost();
    }
    public void Vampir()
    {
        krik.Play();
        sosige.Vampir();
    }
}
