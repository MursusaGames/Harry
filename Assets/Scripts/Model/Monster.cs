using System;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] private float distance = 200f;    
    [SerializeField] private Transform target;
    [SerializeField] private Transform parent;
    [SerializeField] private Transform parentOld;
    [SerializeField] private GoInSpeed goInSpeed;
    private bool isGoLeft;    
    private float randDist;
   // private bool increaseDist;
    public bool pause;
    private bool stop;
    
    void OnEnable()
    {
        isGoLeft = true;
        //randDist = UnityEngine.Random.Range(1, 5);
        //increaseDist = false;        
    }
    public void StopMonster()
    {
        gameObject.transform.SetParent(parent);
    }
    public void GetPause()
    {
        pause = true;        
    }
    public void GetStop()
    {
        goInSpeed.enabled = true;        
    }

    public void LetsPlay()
    {
        pause = false;        
    }
    void FixedUpdate()
    {
        if (pause) return;
        //CheckScale();
        if (isGoLeft)
        {
            var pos = target.transform.localPosition;           
            if (target.transform.localScale.x > 0)
            {
                pos.x -= distance;
                transform.localPosition = pos;                
            }
            //else
            //{
               // pos.x -= distance;
               // transform.localPosition = pos;
               // isGoLeft = false;
               // isGoRight = true;
               // Flip();
           // }            
        }
        
        randDist = 10*Time.fixedDeltaTime;
        distance -= randDist;

    }
    private void CheckScale()
    {
        var posT = transform.localPosition;
        var scaleT = transform.localScale;
        scaleT.x = Math.Abs(posT.y - 200f) / 1500f + 0.6f;
        if (isGoLeft)
        {
            scaleT.x *= -1;
        }


        scaleT.y = Math.Abs(scaleT.x);
        transform.localScale = scaleT;
    }
    private void Flip()
    {
        var trans = gameObject.transform.localScale;
        trans.x *= -1;
        gameObject.transform.localScale = trans;
        randDist = UnityEngine.Random.Range(3, 15);
    }
}
