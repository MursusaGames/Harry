using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GoInSpeed : MonoBehaviour
{
    [SerializeField] private Sosige sosige;
    public bool rocks;
    public bool forest;
    public bool forest1;
    public bool houses;
    public bool green;
    public bool earth;
    public bool go;
    public float speed;
    private float koeff;
    private Vector2 pos;
    void Start()
    {
        if (earth || green)
        {
            koeff = 1f;
        }
        else if (houses)
        {
            koeff = 0.8f;
        }
        else if (forest)
        {
            koeff = 0.5f;
        }
        else if (forest1)
        {
            koeff = 0.3f;
        }
        else
        {
            koeff = 0.1f;
        }

        go = true;
    }

    void FixedUpdate()
    {
        if (go )
        {
            speed = sosige.speed*koeff;
            pos = gameObject.transform.localPosition;
            pos.x -= speed * Time.fixedDeltaTime;
            transform.localPosition = pos;
        }
    }
}
