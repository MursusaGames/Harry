using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UniRx;
using UniRx.Extensions;


public class LevelController : MonoBehaviour
{
    [SerializeField] private List<GameObject> levels;
    [SerializeField] private GameObject attacBtn;
    [SerializeField] private AudioSource run;
    [SerializeField] private GameObject laser;
    [SerializeField] private GameObject laser2;
    [SerializeField] private Animator laserAnim;
    [SerializeField] private Sprite magikWandMor;
    [SerializeField] private GameObject scat;
    [SerializeField] private GameObject firePartikl;
    [SerializeField] private GameObject fireworkPartikl;
    [SerializeField] private List<GameObject> magicAnimals;
    [SerializeField] private GameObject magicPartikl;
    [SerializeField] private Sprite star;
    [SerializeField] private GameObject magicWand;
    [SerializeField] private GameObject magicWand2;
    [SerializeField] private GameObject rocet;
    [SerializeField] private GameObject nuclear;
    [SerializeField] private List<GameObject> socks;    
    [SerializeField] private GameObject waterPartikl;
    [SerializeField] private GameObject yellowPartikl;
    [SerializeField] private Sprite water;
    [SerializeField] private GameObject acid;
    [SerializeField] private GameObject bulletParticles;
    [SerializeField] private GameObject pistol;
    [SerializeField] private GameObject pistol2;
    [SerializeField] private GameObject waterPistol;
    [SerializeField] private GameObject waterPistol2;
    [SerializeField] private Sprite bullet;
    [SerializeField] private Sprite silverBullet;
    [SerializeField] private GameObject carrot;
    [SerializeField] private GameObject stone;
    [SerializeField] private GameObject tomat;
    [SerializeField] private GameObject poop;
    [SerializeField] private GameObject egg;
    [SerializeField] private GameObject bomb;
    [SerializeField] private GameObject gas;
    [SerializeField] private List<GameObject> cactuses;
    [SerializeField] private List<GameObject> arrows;
    [SerializeField] private List<GameObject> spears;    
    [SerializeField] private GameObject blessed;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource boomSource;
    [SerializeField] private List<AudioClip> clips;
    //[SerializeField] private TimeController timeController;
    public int timeToEnd;
    [SerializeField] private GameObject knifePrefab;
    [SerializeField] private GameObject winWindow;
    [SerializeField] private GameObject loseWindow;
    [SerializeField] private GameObject gameWindow;
    [SerializeField] private GameObject bonusWindow;
    [SerializeField] private Transform knifeParent;
    [SerializeField] private Transform knife2Parent;
    [SerializeField] private Transform knifePos;
    [SerializeField] private Transform knife2Pos;
    [SerializeField] private Image levelIcons;
    [SerializeField] private List<Image> tryIcons;
    public List<StageInfo> stages;
    [SerializeField] private TextMeshProUGUI stageNumber;
    [SerializeField] private TMP_Text score;
    public MatchData data;
    [SerializeField] public string thisStageName;
    public Monster monster;
    [SerializeField] private Image monsterLeft;
    [SerializeField] private Image monsterRight;
    [SerializeField] public int thisSceneNumber;
    [SerializeField] private GameObject greenLine;
    [SerializeField] private GameObject yellowLine;
    [SerializeField] private GameObject ballGO;
    [SerializeField] private UserData userData;
    [SerializeField] private List<GameObject> bossAnim;
    [SerializeField] private List<GameObject> monsterAnim;
    [SerializeField] private List<GameObject> deathAnim;
    [SerializeField] private GameObject finishWindow;
    [SerializeField] private Sosige player;
    public Animator currentAnim;
    public int currentStage;
    public int currentLevel;
    private int tryCount;
    public bool bossFight;
    public bool bossFirstFight;
    private bool lastStage;
    public int ballPower;
    public bool win;
    public GameObject knife1;
    public GameObject knife2;
    private float filAmount;
    public bool kitchen;
    public bool sea;
    public bool desert;
    public bool bugwards;
    public bool hell;

    private void Start()
    {
        userData.apple.SubscribeToText(score);
    }
    void OnEnable()
    {
        if (kitchen)
        {
            currentLevel = data.kitchenLevel;
        }
        else if(sea)
        {
            currentLevel = data.seaLevel;
        }
        else if (desert)
        {
            currentLevel = data.desertLevel;
        }
        else if (bugwards)
        {
            currentLevel = data.bugwardsLevel;
        }
        else if (hell)
        {
            currentLevel = data.hellLevel;
        }
        levels[currentLevel].SetActive(true);
        ballPower = 2;
        switch (thisStageName)
        {
            case "Game":
                stageNumber.text = "Раунд " + data.gameStage.ToString();
                currentStage = data.gameStage;
                if (currentStage > 4)
                {
                    lastStage = true;
                }
                break;
            case "WildOcean":
                stageNumber.text = "Раунд " + data.oceanStage.ToString();
                currentStage = data.oceanStage;
                if (currentStage > 4)
                {
                    lastStage = true;
                }
                break;
            case "WildFerm":
                stageNumber.text = "Раунд " + data.fermStage.ToString();
                currentStage = data.fermStage;
                if(currentStage > 5)
                {
                    lastStage = true;
                }
                break;
            case "WildForest":
                stageNumber.text = "Раунд "+ data.forestStage.ToString();
                currentStage = data.forestStage;
                if (currentStage > 5)
                {
                    lastStage = true;
                }
                break;
            case "Hell":
                stageNumber.text = "Раунд "+data.hellStage.ToString();
                currentStage = data.hellStage;
                if (currentStage > 4)
                {
                    lastStage = true;
                }
                break;
            case "Technopolis":
                stageNumber.text = "Раунд "+data.technoStage.ToString();
                currentStage = data.technoStage;
                if (currentStage > 4)
                {
                    lastStage = true;
                }
                break;
        }
        if (lastStage)
        {
            ShowFinishWindow();
            return;
        }
        
        if (currentLevel == 2)
        {
            currentAnim = bossAnim[stages[currentStage].id].GetComponent<Animator>();
            bossAnim[stages[currentStage].id].SetActive(true);
            bossFight = true;
           // greenLine.SetActive(true);
        }
        else
        {
            currentAnim = monsterAnim[stages[currentStage].id].GetComponent<Animator>();
            monsterAnim[stages[currentStage].id].SetActive(true);
        }
        monster.gameObject.tag = stages[currentStage].monsterTag;
        data.monsterDy = false;
        //timeController.SetTime();
        monsterLeft.sprite = stages[currentStage].monsterHalf1;
        monsterRight.sprite = stages[currentStage].monsterHalf2;
        data.currentMonster = stages[currentStage].bossSprite;
        tryCount = stages[currentStage].tryCount;
        filAmount = 0.33f *currentLevel;
        levelIcons.fillAmount = filAmount;       
        
    }
    #region Weapons

    public void IsChucha()
    {
        SetPause();
        currentAnim.SetBool("Chucha", true);
    }
    public void AttacTrue()
    {
        data.attac = true;
        attacBtn.SetActive(true);
    }
    public void IsPoop()
    {

        PlaySound(6);
        SetPause();
        poop.SetActive(true);        
    }
    public void IsEgg()
    {
        //PlaySound(7);
        SetPause();
        egg.SetActive(true);
    }
    public void IsRocet(int id = 0)
    {
        SetPause();
        if (id == 0)
        {
            currentAnim.gameObject.SetActive(false);
        }        
        rocet.SetActive(true);
    }
    public void IsNuclear()
    {
        SetPause();
        currentAnim.gameObject.SetActive(false);
        rocet.SetActive(true);
        nuclear.SetActive(true);
    }
    public void IsForest()
    {
        PlaySound(2);
        SetPause();
        bomb.SetActive(true);        
    }
    public void IsBomb()
    {
        SetPause();
       
        currentAnim.SetBool("Bomb", true);
    }
    public void IsSprut()
    {
        SetPause();
        currentAnim.SetBool("Sprut", true);
    }
    public void IsScatAttac(int id = 0)
    {
        SetPause();
        if (id == 1)
        {
            currentAnim.gameObject.SetActive(false);
        }
        scat.SetActive(true);
    }
    public void StoneDy()
    {
        SetPause();
        currentAnim.SetBool("Dy", true);
    }
    public void IsMor()
    {
        //PlaySound(2);
        SetPause();
        currentAnim.SetBool("Attac", true);
    }
    public void VampirDy()
    {
        SetPause();
        currentAnim.SetBool("Dy", true);
    }
    public void IsPeel()
    {
        //PlaySound(2);
        SetPause();
        currentAnim.SetBool("Peel", true);
    }
    public void IsGas()
    {
        //PlaySound(2);
        SetPause();
        //bomb.SetActive(true);
        currentAnim.SetBool("Gas", true);
        //bossAnim[stages[currentStage].id].GetComponent<Animator>().SetBool("Gas", true);
    }
    public void IsPepperGas()
    {
        //PlaySound(2);
        SetPause();
        //bomb.SetActive(true);
        currentAnim.SetBool("PepperGas", true);
        //bossAnim[stages[currentStage].id].GetComponent<Animator>().SetBool("Gas", true);
    }
    public void IsCarrot()
    {
        carrot.SetActive(true );
        Invoke(nameof(ResetCarrotGO), 1f);
    }
    public void ShowSock()
    {
        socks[currentStage].SetActive(true);
    }
    public void IsCactus()
    {
        SetPause();
        cactuses[currentStage].SetActive(true);
        currentAnim.SetBool("Cactus", true);
        Invoke(nameof(ResetCactus), 1f);
    }
    public void DronDy()
    {
        SetPause();        
        currentAnim.SetBool("Dy", true);        
    }
    private void ResetCactus()
    {
        cactuses[currentStage].SetActive(false);
    }
    public void IsBall()
    {
        ballPower--;
        if(ballPower <= 0)
        {
            SetPause();
            currentAnim.SetBool("Stone", true);            
        }
    }
    public void IsPapir()
    {
        PlaySound(1);
        SetPause();
        //cactuses[currentStage].SetActive(true);
        currentAnim.SetBool("Papir", true);
        //bossAnim[stages[currentStage].id].GetComponent<Animator>().SetBool("Cactus", true);
    }    
    private void ResetCarrotGO()
    {
        carrot.SetActive(false);
    }
    public void IsTomate()
    {
        PlaySound(5);
        SetPause();
        tomat.SetActive(true);
        Invoke(nameof(ResetTomatGO), 1f);
    }
    public void JustTomate()
    {
        SetPause();
        tomat.SetActive(true);
        Invoke(nameof(ResetTomatGO), 1f);
    }
    private void ResetTomatGO()
    {
        tomat.SetActive(false);
    }
    public void MonsterStop()
    {
        monster.GetPause();
    }
    public void IsStone()
    {
        currentAnim.SetBool("Stone", true);
        //bossAnim[stages[currentStage].id].GetComponent<Animator>().SetBool("Stone", true);
        PlaySound(7);
        SetPause();        
        //monsterAnim[stages[currentStage].id].GetComponent<Animator>().SetBool("Stone", true);
        //bossAnim[stages[currentStage].id].GetComponent<Animator>().SetBool("Stone", true);
        stone.SetActive(true);
    }
    public void IsBullet()
    {
        tomat.SetActive(true);
        Debug.Log("IsBullet");
        player.GetPause();
        monster.GetPause();
        currentAnim.SetBool("Bullet", true);
        Invoke(nameof(ResetTomatGO), 1f);
    }
    public void IsWord()
    {
        //timeController.GetPause();
        player.GetPause();
        monster.GetPause();
        currentAnim.SetBool("Word", true);
    }
    public void IsArrow(int id)
    {
        Debug.Log("IsArrow");
        if (id == 2)
        {
            tomat.SetActive(true);
           // timeController.GetPause();
            player.GetPause();
            monster.GetPause();
            currentAnim.SetBool("Poison", true);
            return;
        }
        tomat.SetActive(true);
        arrows[currentStage].SetActive(true);
        //timeController.GetPause();
        player.GetPause();
        monster.GetPause();
        if(id == 0)
        {
            currentAnim.SetBool("Bullet", true);
        }
        else
        {
            currentAnim.SetBool("Poison", true);
        }
               
    }
    public void IsSpear()
    {
        tomat.SetActive(true);
        spears[currentStage].SetActive(true);
        //timeController.GetPause();
        player.GetPause();
        monster.GetPause();
        currentAnim.SetBool("Stone", true);
    }
    public void IsMolot()
    {
        tomat.SetActive(true);
        currentAnim.SetBool("Molot", true);
        player.GetPause();
        monster.GetPause();        
    }
    public void IsAcid()
    {
        Debug.Log("IsAcid");
        acid.SetActive(true);
       // timeController.GetPause();
        player.GetPause();
        monster.GetPause();
        currentAnim.SetBool("Acid", true);
    }
    public void IsWater()
    {
        waterPartikl.SetActive(true);
        SetPause();   
    }
    public void IsMagic()
    {
        magicPartikl.SetActive(true);
        SetPause();
        currentAnim.gameObject.SetActive(false);
        int rand = Random.Range(0, magicAnimals.Count);
        magicAnimals[rand].SetActive(true);
    }
    public void IsGlue()
    {
        yellowPartikl.SetActive(true);
        SetPause();
        currentAnim.SetBool("Glue", true);
    }
    public void IsScat()
    {
        SetPause();
        currentAnim.SetBool("Scat", true);
    }
    public void IsMolotov()
    {
        SetPause();
        currentAnim.SetBool("Molotov", true);
    }
    public void IsFirework(int id =0 )
    {
        fireworkPartikl.SetActive(true);
        SetPause();
        if (id == 1)
        {
            IsChes();
        }
        else
        {
            currentAnim.SetBool("Firework", true);
        }            
    }
    public void IsSilverBullet()
    {
        tomat.SetActive(true);
        //timeController.GetPause();
        player.GetPause();
        monster.GetPause();
        currentAnim.SetBool("Bullet", true);        
        Invoke(nameof(ResetTomatGO), 1f);
    }
    public void IsStoneOut()
    {
        PlaySound(5);
        SetPause();
        stone.SetActive(true);
        Invoke(nameof(ResetStoneGO), 1f);
    }    
    private void ResetStoneGO()
    {
        stone.SetActive(false);
    }
    public void IsChes()
    {
        SetPause();
        PlaySound(5);
    }
    #endregion

    #region Utilits
    public void SetPause()
    {
        //timeController.GetPause();
        player.GetPause();
        monster.GetPause();
        monsterAnim[stages[currentStage].id].GetComponent<Animator>().SetBool("Stop", true);
    }
    public void StopMonster()
    {
        monster.GetPause();
    }
    public void MonsterStopAnim()
    {
        currentAnim.SetBool("Stop", true);
        MonsterStop();
    }
    private void ShowFinishWindow()
    {
        finishWindow.SetActive(true);
    }
    public void ResetAnim()
    {
        Invoke(nameof(ResetMonster), 4f);
        monsterAnim[stages[currentStage].id].SetActive(false);
        bossAnim[stages[currentStage].id].SetActive(false);
    }
    private void ResetMonster()
    {
        monster.gameObject.SetActive(false);
    }
    public void PlaySound(int id)
    {
        if (data.sound)
        {
            audioSource.volume = PlayerPrefs.GetFloat(Constant.SOUND);
            audioSource.clip = clips[id];
            audioSource.Play();
        }        
    }
    public void ResetAttacBtn()
    {
        attacBtn.SetActive(false);
    }
    public void GetKnifeInfo(Transform parent, Transform pos, bool first)
    {
        if(first)
        {
            knifePos = pos;
            knifeParent = parent;
        }
        else
        {
            knife2Pos = pos;
            knife2Parent = parent;
            knife1 = Instantiate(knifePrefab, knifePos.position, Quaternion.identity, knifeParent);
            knife1.GetComponent<Image>().sprite = data.currentKnife;
            knife1.tag = data.currentTag;
            knife2 = Instantiate(knifePrefab, knife2Pos.position, Quaternion.identity, knife2Parent);
            knife2.GetComponent<Image>().sprite = data.currentKnife;
            knife2.tag = data.currentTag;
        }

    }
    public void SetKnife(GameObject knife)
    {
       // knife = Instantiate(knifePrefab, knifePos.position, Quaternion.identity, knifeParent);
        knife.GetComponent<Image>().sprite = data.currentKnife;
        knife.tag = data.currentTag;
        //knife2 = Instantiate(knifePrefab, knife2Pos.position, Quaternion.identity, knife2Parent);
        //knife2.GetComponent<Image>().sprite = data.currentKnife;
        //knife2.tag = data.currentTag;
        if (data.currentTag == "Knife")
        {
            knife.GetComponent<Knife>()._knife = true;
            //knife2.GetComponent<Knife>()._knife = true;
        }
        else if(data.currentTag == "superKnife"|| data.currentTag == "Chucha" || data.currentTag == "Vampir")
        {
            knife.GetComponent<Knife>()._superKnife = true;
            //knife2.GetComponent<Knife>()._superKnife = true;
        }
        else if (data.currentTag == "Tomate")
        {
            knife.GetComponent<Knife>()._tomate = true;
            //knife2.GetComponent<Knife>()._tomate = true;
        }
        else if (data.currentTag == "Bes")
        {
            knife.GetComponent<Knife>()._bes = true;
            //knife2.GetComponent<Knife>()._bes = true;
        }
        else if (data.currentTag == "Carrot")
        {
            knife.GetComponent<Knife>()._carrot = true;
            //knife2.GetComponent<Knife>()._carrot = true;
        }
        else if (data.currentTag == "Dron")
        {
            knife.GetComponent<Knife>()._bomb = true;
            //knife2.GetComponent<Knife>()._bomb = true;
        }
        else if (data.currentTag == "stone" || data.currentTag == "Stone")
        {
            knife.GetComponent<Knife>()._stone = true;
            //knife2.GetComponent<Knife>()._stone = true;
        }
        else if (data.currentTag == "poop")
        {
            knife.GetComponent<Knife>()._poop = true;
           // knife2.GetComponent<Knife>()._poop = true;
        }
        else if (data.currentTag == "Tykw")
        {
            knife.GetComponent<Knife>().SetTykw();
            //knife2.GetComponent<Knife>().SetTykw();
        }
        else if (data.currentTag == "Shark")
        {
            knife.GetComponent<Knife>()._shark = true;
            //knife2.GetComponent<Knife>()._shark = true;
        }
        else if (data.currentTag == "Meduza")
        {
            knife.GetComponent<Knife>()._meduza = true;
           // knife2.GetComponent<Knife>()._meduza = true;
        }
        else if (data.currentTag == "bullet")
        {
            bulletParticles.SetActive(false);
            knife.GetComponent<Knife>()._bullet = true;
            pistol.SetActive(true);
            knife.GetComponent<Image>().sprite = bullet;
            //bulletParticles.SetActive(false);
            //knife2.GetComponent<Knife>()._bullet = true;
            //pistol2.SetActive(true);
            //knife2.GetComponent<Image>().sprite = bullet;
        }
        else if (data.currentTag == "silverBullet")
        {
            bulletParticles.SetActive(false);
            knife.GetComponent<Knife>()._silverBullet = true;
            pistol.SetActive(true);
            knife.GetComponent<Image>().sprite = silverBullet;
            //bulletParticles.SetActive(false);
            //knife2.GetComponent<Knife>()._silverBullet = true;
           // pistol2.SetActive(true);
           // knife2.GetComponent<Image>().sprite = silverBullet;
        }
        else if (data.currentTag == "egg")
        {
            knife.GetComponent<Knife>()._egg = true;
           // knife2.GetComponent<Knife>()._egg = true;
        }
        else if (data.currentTag == "bomb")
        {
            knife.GetComponent<Knife>()._bomb = true;
            //knife2.GetComponent<Knife>()._bomb = true;
        }
        else if (data.currentTag == "churiken")
        {
            knife.GetComponent<Knife>()._churik = true;
            //knife2.GetComponent<Knife>()._churik = true;
        }
        else if (data.currentTag == "gas")
        {
            knife.GetComponent<Knife>()._gas = true;
            //knife2.GetComponent<Knife>()._gas = true;
        }
        else if (data.currentTag == "blessedSword")
        {
            knife.GetComponent<Knife>()._blessedSword = true;
            blessed.SetActive(true);
           // knife2.GetComponent<Knife>()._blessedSword = true;
           // blessed.SetActive(true);
        }
        else if (data.currentTag == "Cactus")
        {
            knife.GetComponent<Knife>()._cactus = true;
            //knife2.GetComponent<Knife>()._cactus = true;
        }
        else if (data.currentTag == "stone")
        {
            knife.GetComponent<Knife>()._stone = true;
            //knife2.GetComponent<Knife>()._stone = true;
        }
        else if (data.currentTag == "Papir")
        {
            knife.GetComponent<Knife>()._papir = true;
           // knife2.GetComponent<Knife>()._papir = true;
        }
        else if (data.currentTag == "lightsaber")
        {
            knife.GetComponent<Knife>()._lightsaber = true;
           // knife2.GetComponent<Knife>()._lightsaber = true;
        }
        else if (data.currentTag == "Ball")
        {
            knife.GetComponent<Knife>().SetBall();
            //knife2.GetComponent<Knife>().SetBall();
            ballGO.SetActive(true);
        }
        else if (data.currentTag == "Arrow")
        {
            knife.GetComponent<Knife>()._arrow = true;
            //knife2.GetComponent<Knife>()._arrow = true;
        }
        else if (data.currentTag == "Spear")
        {
            knife.GetComponent<Knife>()._spear = true;
            //knife2.GetComponent<Knife>()._spear = true;
        }
        else if (data.currentTag == "PoisonArrow")
        {
            knife.GetComponent<Knife>()._pArrow = true;
           // knife2.GetComponent<Knife>()._pArrow = true;
        }
        else if (data.currentTag == "Molot")
        {
            knife.GetComponent<Knife>()._molot = true;
            //knife2.GetComponent<Knife>()._molot = true;
        }
        else if (data.currentTag == "Acid")
        {
            knife.GetComponent<Knife>()._acid = true;
           // knife2.GetComponent<Knife>()._acid = true;
        }
        else if (data.currentTag == "WaterGun")
        {
            knife.GetComponent<Knife>()._waterGun = true;
            waterPistol.SetActive(true);
            knife.GetComponent<Image>().sprite = water;
            knife.gameObject.transform.localScale = Vector3.zero;
           // knife2.GetComponent<Knife>()._waterGun = true;
           // waterPistol2.SetActive(true);
           // knife2.GetComponent<Image>().sprite = water;
           // knife2.gameObject.transform.localScale = Vector3.zero;
        }
        else if (data.currentTag == "Glue")
        {
            knife.GetComponent<Knife>()._glue = true;
            //knife2.GetComponent<Knife>()._glue = true;
        }
        else if (data.currentTag == "Molotov")
        {
            knife.GetComponent<Knife>()._molotov = true;
           // knife2.GetComponent<Knife>()._molotov = true;
        }
        else if (data.currentTag == "PepperGas")
        {
            knife.GetComponent<Knife>()._pepperGas = true;
           // knife2.GetComponent<Knife>()._pepperGas = true;
        }
        else if (data.currentTag == "SmellySock")
        {
            knife.GetComponent<Knife>()._smellySock = true;
            //knife2.GetComponent<Knife>()._smellySock = true;
        }
        else if (data.currentTag == "rocet" || data.currentTag == "Helik")
        {
            knife.GetComponent<Knife>()._rocet = true;
           // knife2.GetComponent<Knife>()._rocet = true;
        }
        else if (data.currentTag == "BananaPeel")
        {
            knife.GetComponent<Knife>()._peel = true;
           // knife2.GetComponent<Knife>()._peel = true;
        }
        else if (data.currentTag == "MagicWand"|| data.currentTag == "Mor")
        {
            knife.GetComponent<Knife>()._magic = true;
            magicWand.SetActive(true);
            //knife2.GetComponent<Knife>()._magic = true;
            //magicWand2.SetActive(true);
            if (data.currentTag == "Mor")
            {
                magicWand.GetComponent<Image>().sprite = magikWandMor;
                //magicWand2.GetComponent<Image>().sprite = magikWandMor;
            }            
            knife.GetComponent<Image>().sprite = star;
            knife.gameObject.transform.localScale = Vector3.zero;
            //knife2.GetComponent<Image>().sprite = star;
           // knife2.gameObject.transform.localScale = Vector3.zero;
        }
        else if (data.currentTag == "Word")
        {
            knife.GetComponent<Knife>()._word = true;
            //knife2.GetComponent<Knife>()._word = true;
        }
        else if (data.currentTag == "Firework")
        {
            knife.GetComponent<Knife>()._firework = true;
            //knife2.GetComponent<Knife>()._firework = true;
        }
        else if (data.currentTag == "nuclear")
        {
            knife.GetComponent<Knife>()._nuclear = true;
           // knife2.GetComponent<Knife>()._nuclear = true;
        }
        else if (data.currentTag == "Ches")
        {
            knife.GetComponent<Knife>()._ches = true;
            //knife2.GetComponent<Knife>()._ches = true;
        }
        else if (data.currentTag == "Water")
        {
            knife.GetComponent<Knife>()._water = true;
            //knife2.GetComponent<Knife>()._water = true;
        }
        else if (data.currentTag == "Forest")
        {
            knife.GetComponent<Knife>()._forest= true;
           // knife2.GetComponent<Knife>()._forest = true;
        }
        else if (data.currentTag == "Air")
        {
            knife.GetComponent<Knife>().SetAir();
            //knife2.GetComponent<Knife>().SetAir();
        }
        else if (data.currentTag == "Godzy")
        {
            knife.GetComponent<Knife>()._godzy = true;
            //knife2.GetComponent<Knife>()._godzy = true;
        }
        else if (data.currentTag == "Light")
        {
            knife.GetComponent<Knife>().SetLight();
            //knife2.GetComponent<Knife>().SetLight();
        }
        else if (data.currentTag =="Fire" || data.currentTag == "Demon")
        {
            knife.GetComponent<Knife>().SetFire();
           // knife2.GetComponent<Knife>().SetFire();
        }
        else if (data.currentTag == "Meduza"|| data.currentTag == "Nag")
        {
            knife.GetComponent<Knife>()._meduza = true;
           // knife2.GetComponent<Knife>()._meduza = true;
        }
        else if (data.currentTag == "Scat")
        {
            knife.GetComponent<Knife>()._scat = true;
           // knife2.GetComponent<Knife>()._scat = true;
        }
        else if (data.currentTag == "Sprut")
        {
            knife.GetComponent<Knife>()._sprut = true;
           // knife2.GetComponent<Knife>()._sprut = true;
        }
        else if (data.currentTag == "Mandragora")
        {
            knife.GetComponent<Knife>()._mandra = true;
           // knife2.GetComponent<Knife>()._mandra = true;
        }
        else if (data.currentTag == "Vasilisk")
        {
            knife.GetComponent<Knife>()._vasya = true;
            //knife2.GetComponent<Knife>()._vasya = true;
        }
        else if (data.currentTag == "Host")
        {
            knife.GetComponent<Knife>()._chost = true;
            //knife2.GetComponent<Knife>()._chost = true;
        }
        else if (data.currentTag == "Death")
        {
            knife.GetComponent<Knife>()._death = true;
           // knife2.GetComponent<Knife>()._death = true;
        }
        else if (data.currentTag == "Ufo")
        {
            knife.GetComponent<Knife>()._ufo = true;
           // knife2.GetComponent<Knife>()._ufo = true;
        }
        else if (data.currentTag == "Tank")
        {
            knife.GetComponent<Knife>()._tank = true;
           // knife2.GetComponent<Knife>()._tank = true;
        }
        else if (data.currentTag == "Iron")
        {
            knife.GetComponent<Knife>()._iron = true;
            laser.SetActive(true);
            knife.GetComponent<Image>().enabled = false;
            knife.gameObject.transform.localScale = Vector3.zero;
           // knife2.GetComponent<Knife>()._iron = true;
          //  laser2.SetActive(true);
           // knife2.GetComponent<Image>().enabled = false;
           // knife2.gameObject.transform.localScale = Vector3.zero;
        }
    }
    public void ResetBlessedPartikl()
    {
        blessed.SetActive(false);
    }
    public void StartLaser()
    {
        laserAnim.SetBool("Laser", true);
        Invoke(nameof(StopLaser), 1f);
    }
    public void StopLaser()
    {
        laserAnim.SetBool("Laser", false);
    }
    public void Bullet()
    {
        bulletParticles.SetActive(true);
    }
    public void WaterElement()
    {
        waterPartikl.SetActive(true);        
    }
    public void AcidWater()
    {
        waterPartikl.SetActive(true);
        SetPause();
        currentAnim.SetBool("Acid", true);
    }
    public void FireElement(int id = 0)
    {
        firePartikl.SetActive(true);        
        if (id == 1)
        {
            waterPartikl.SetActive(true);
            SetPause();
            currentAnim.SetBool("FireDy", true);
            ResetGreenLine();
        }
    }
    public void AirElement()
    {
        SetPause();
        currentAnim.SetBool("Attac", true);
    }
    public void AirDy()
    {
        SetPause();
        ResetGreenLine();
        currentAnim.SetBool("Dy", true);
    }
    public void IsAir()
    {
        SetPause();
        currentAnim.SetBool("Air", true);
    }
    public void IsChostAttac()
    {
        SetPause();
        currentAnim.SetBool("Chost", true);
    }
    public void Light()
    {
        SetPause();
        currentAnim.SetBool("Attac", true);
    }
    public void IsChost()
    {
        SetPause();
        currentAnim.SetBool("Attac", true);
    }
    public void LightDy()
    {
        SetPause();
        currentAnim.SetBool("Dy", true);
    }
    public void Dark()
    {

    }
    public void IsTime()
    {
        //audioSource.clip = clips[4];
        //audioSource.Play();
        tryCount = 1;
        Fall();
    }
    public void PlayBoom()
    {
        boomSource.Play();
    }
    public void ResetYellowLine()
    {
        yellowLine.SetActive(false);
    }
    public void ResetGreenLine()
    {
        greenLine.SetActive(false);
    }
    public void Fall()
    {
        
        bomb.SetActive(false);
        gas.SetActive(false);
        rocet.SetActive(false);
        ballPower = 2;
        waterPartikl.SetActive(false);
        firePartikl.SetActive(false);
        fireworkPartikl.SetActive(false);
        acid.SetActive(false);
        ballGO.SetActive(false);
        poop.SetActive(false);
        egg.SetActive(false);
        //arrows[currentStage].SetActive(true);
        //player.LetsPlay();
        monster.LetsPlay();
        //timeController.LetsPlay();
        currentAnim.SetBool("Stop", false);              
        if (bossFirstFight)
        {
            greenLine.SetActive(false);
            yellowLine.SetActive(true);
        }
        if (tryCount > 0)
        {
            tryCount--;
        }        
        tryIcons[tryCount].color = Color.gray;
        if (tryCount == 0)
        {
            GameOver();
            return;
        }
        //SetKnife();
    }
    public void StopRunSound()
    {
        run.Stop();
    }
    public void GameOver()
    {
        
        //player.gameObject.SetActive(false);
        //monster.gameObject.SetActive(false);
        //deathAnim[currentStage].SetActive(true);
        Invoke(nameof(OpenLooseWindow), 1f);
    }
    public void DeathAnim()
    {
        StopRunSound();
        monster.gameObject.SetActive(false);
        deathAnim[currentStage].SetActive(true);
        //tryCount = 1;
        Invoke(nameof(IsTime), 2f);
    }
    private void OpenLooseWindow()
    {
        loseWindow.SetActive(true);
        gameWindow.SetActive(false);
    }
    public void Win()
    {
        StopRunSound();
        ballPower = 2;
        if (bossFight)
        {
            bonusWindow.SetActive(true);
            switch (thisStageName)
            {
                case "Game":
                    data.gameStage++;
                    PlayerPrefs.SetInt(Constant.GAMESTAGE, data.gameStage);
                    data.bugwardsLevel = 0;
                    PlayerPrefs.SetInt(Constant.bugwardsLEVEL, data.bugwardsLevel);
                    break;
                case "WildOcean":
                    data.oceanStage++;
                    PlayerPrefs.SetInt(Constant.OCEANSTAGE, data.oceanStage);
                    data.seaLevel = 0;
                    PlayerPrefs.SetInt(Constant.seaLEVEL, data.seaLevel);
                    break;
                case "WildFerm":
                    data.fermStage++;
                    PlayerPrefs.SetInt(Constant.FERMSTAGE, data.fermStage);
                    data.kitchenLevel=0;
                    PlayerPrefs.SetInt(Constant.kitchenLEVEL, data.kitchenLevel);
                    break;
                case "WildForest":
                    data.forestStage++;
                    PlayerPrefs.SetInt(Constant.FORESTSTAGE, data.forestStage);
                    data.desertLevel = 0;
                    PlayerPrefs.SetInt(Constant.desertLEVEL, data.desertLevel);
                    break;
                case "Hell":
                    data.hellStage++;
                    PlayerPrefs.SetInt(Constant.HELLSTAGE, data.hellStage);
                    data.hellLevel = 0;
                    PlayerPrefs.SetInt(Constant.hellLEVEL, data.hellLevel);
                    break;
                case "Technopolis":
                    data.technoStage++;
                    PlayerPrefs.SetInt(Constant.TECHNOSTAGE, data.technoStage);
                    break;
            }
            return;
        }
        winWindow.SetActive(true);

    }
    public void NextLevel()
    {
        if (kitchen)
        {
            data.kitchenLevel++;
            if (data.kitchenLevel >= 3)
            {
                data.kitchenLevel = 0;
            }
            PlayerPrefs.SetInt(Constant.kitchenLEVEL, data.kitchenLevel);
        }
        else if (sea)
        {
            data.seaLevel++;
            if (data.seaLevel >= 3)
            {
                data.seaLevel = 0;                
            }
            PlayerPrefs.SetInt(Constant.seaLEVEL, data.seaLevel);           
           
        }
        else if (desert)
        {
            data.desertLevel++;
            if (data.desertLevel >= 3)
            {
                data.desertLevel = 0;
            }
            PlayerPrefs.SetInt(Constant.desertLEVEL, data.desertLevel);
        }
        else if (bugwards)
        {
            data.bugwardsLevel++;
            if (data.bugwardsLevel >= 3)
            {
                data.bugwardsLevel = 0;
            }
            PlayerPrefs.SetInt(Constant.bugwardsLEVEL, data.bugwardsLevel);
        }
        else if (hell)
        {
            data.hellLevel++;
            if (data.hellLevel >= 3)
            {
                data.hellLevel = 0;
            }
            PlayerPrefs.SetInt(Constant.hellLEVEL, data.hellLevel);
        }
        else
        {
            data.level++;
        }        
        SceneManager.LoadScene(thisSceneNumber);
    }

    public void Reload()
    {
        SceneManager.LoadScene(0);
    }

    #endregion
}
