using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sosige : MonoBehaviour
{
    [SerializeField] private AudioSource step;
    [SerializeField] private GameObject knifeGO;
    [SerializeField] private GameObject visual;
    [SerializeField] private Image weapon;
    [SerializeField] private float ownSpeed;
    [SerializeField] private LevelController levelController;
    //[SerializeField] private GameObject gSosige;
    public float speed;
    //private bool go;
    private bool finish;
    private Vector2 pos;
    private Animator animator;
    private bool set;
    public bool attac;
    public bool attacBee;
    public bool attac2;
    public bool attac2Bee;
    private bool _sound;

    void OnEnable()
    {
        _sound = levelController.data.sound;    
        step.volume = PlayerPrefs.GetFloat(Constant.SOUND);
        animator = GetComponent<Animator>();
        ownSpeed = levelController.data.speed;
        speed = ownSpeed;
    }
    public void PlayStep()
    {
        if (_sound)
        {
            step.Play();
        }
    }
    public void HideVisual()
    {
        visual.SetActive(false);
        if (levelController.currentAnim.gameObject.activeInHierarchy)
        {
           // levelController.IsTime();
        }
    }
    public void GameOver()
    {
        levelController.GameOver();
    }
    private void KnifeGo()
    {
        //knifeGO.tag = levelController.data.currentTag;
        weapon.gameObject.SetActive(false);
        knifeGO.SetActive(true);
        knifeGO.GetComponent<Knife>().KnifeGo();
    }
    private void Knife2Go()
    {
        levelController.knife2.GetComponent<Knife>().KnifeGo();
    }
    public void UnJump()
    {
        animator.SetBool("Jump", false);
        speed = ownSpeed;
    }
    /*public void HideVer1()
    {
        if (attac)
        {
            foreach(var ver in ver1)
            {
                ver.SetActive(false);
            }
        } 
        else if (attac2)
        {
            foreach (var ver in ver2)
            {
                ver.SetActive(false);
            }
        }
    }*/
    public void Attac()
    {
        levelController.ResetAttacBtn();
        levelController.SetKnife(knifeGO);
        speed = 0;
        levelController.StopMonster();
        animator.SetBool("Jump", true);
        //Invoke(nameof(KnifeGo), 1.0f);
        //Invoke(nameof(UnJump), 2f);
    }
    public void Seet()
    {
        set = true;
        animator.SetBool("Seet", true);
        speed *= 5;
    }
    public void Up()
    {
        if(speed == 0)
        {
            return;
        }
        set = false;
        animator.SetBool("Seet", false);
        speed = ownSpeed;        
    }
    public void Fallen()
    {
        animator.SetBool("Fall", true);
    }
    public void Chost()
    {
        animator.SetBool("Chost", true);
    }
    public void Vampir()
    {
        animator.SetBool("Vampir", true);
    }
    private void ResetAttac()
    {
        attac = false;
        attac2 = false;
    }
    public void GetPause()
    {
        speed = 0;
        Flip();
       // if(levelController.bossFight)
        //Invoke(nameof(ResetAnim), 3f);
        Invoke(nameof(LetsPlay), 1f);
    }
    private void ResetAnim()
    {
        levelController.ResetAnim();
    }
    private void LetsPlay()
    {
        Flip();
        speed = ownSpeed;
    }
    private void Flip()
    {
        var trans = gameObject.transform.localScale;
        trans.x *= -1;
        gameObject.transform.localScale = trans;
    }
    private void IsFinish()
    {
        levelController.Win();
    }
    public void StopVisual()
    {
        animator.SetBool("Stop", true);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Finish"))
        {
            speed = 0;
            animator.SetBool("Finish", true);
            if (levelController.data.monsterDy)
            {
                Invoke(nameof(IsFinish), 2f);
            }
            else
            {
                levelController.DeathAnim();
            }
            
            
        }
        else if (collision.gameObject.CompareTag("Pech"))
        {
            speed = 0;
            levelController.MonsterStopAnim();
            animator.SetBool("Pech", true);
        }
        else if (collision.gameObject.CompareTag("Nog") && !set)
        {
            speed = 0;
            levelController.MonsterStopAnim();
            animator.SetBool("Nog", true);
        }
        else if (collision.gameObject.CompareTag("Nogg") && !set)
        {
            speed = 0;
            levelController.MonsterStopAnim();
            animator.SetBool("Nogg", true);
            Invoke(nameof(GameOver), 3f);
        }
        else if (collision.gameObject.CompareTag("Moika") )
        {
            animator.SetBool("Stop", true);
            speed = 0;
            levelController.MonsterStopAnim();
            collision.gameObject.GetComponent<Moika>().Go();
            Invoke(nameof(GameOver), 4f);
        }
        else if (collision.gameObject.CompareTag("Attac"))
        {
            attac = true;            
        }
        else if (collision.gameObject.CompareTag("Attac2"))
        {
            attac2 = true;
            //Invoke(nameof(ResetAttac), 1f);
        }
        else if (collision.gameObject.CompareTag("Wawa"))
        {
            animator.SetBool("Stop", true);
            speed = 0;
            levelController.MonsterStopAnim();
            collision.gameObject.GetComponent<Wawa>().Go();
            Invoke(nameof(GameOver), 4f);
        }
        else if (collision.gameObject.CompareTag("Sterv"))
        {
            collision.gameObject.GetComponent<Sterv>().GoAnim();            
        }
        else if (collision.gameObject.CompareTag("Blender"))
        {
            speed = 0;
            levelController.MonsterStopAnim();
            animator.SetBool("Blender", true);
        }
        if (collision.gameObject.CompareTag("Ring") && !set)
        {
            weapon.sprite = levelController.data.currentKnife;
            weapon.gameObject.SetActive(true);
            collision.gameObject.transform.parent.gameObject.SetActive(false);
            levelController.AttacTrue();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Attac"))
        {
            attac = false;           
        }
        else if (collision.gameObject.CompareTag("Attac2"))
        {
            attac2 = false;            
        }
    }
}
