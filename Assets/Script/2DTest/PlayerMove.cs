using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    /*Move*/
    private Rigidbody2D Player_Rig; //建立一個2D剛體變數Player_Rig
    public float MoveSpeed=5.0f; //建立一個浮點數MoveSpeed(移動速度)

    /*Move_Animation*/
    private Animator Player_Anim; //建立一個動畫控制器Player_Anim

    public GameManager m_gameManager; //建立放gamemanager的變數

    public int LifeAmount=100; //玩家血量上限
    public int Score = 0; //分數

    /*SE*/
    private AudioSource audioSource;
    public AudioClip damage;
    public AudioClip getscore;


    // Start is called before the first frame update(只會在遊戲開始時執行一次)
    void Start()
    {
        //Debug.Log("恭喜你，成功建立了第一個腳本:D"+Time.deltaTime);
        Player_Rig = GetComponent<Rigidbody2D>();
        Player_Anim = GetComponent<Animator>();
    }

    // Update is called once per frame(在遊戲運行時會以每個影格為單位一直執行=>類似無限迴圈)
    void Update()
    {
        float speedpx = Mathf.Abs(Player_Rig.velocity.x); //取得角色速度(Abs-取絕對值，保證數值是正數))
        Player_Anim.speed = speedpx / 2;

        //Time.deltatime如同緩衝，可以讓移動速度變得平均
        /*transform.position = transform.position 
            + new Vector3(1, 0, 0)
            *Time.deltaTime;*/
        if (Input.GetKey(KeyCode.D))
        {
            Player_Rig.velocity = new Vector3(MoveSpeed, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Player_Rig.velocity = new Vector3(-MoveSpeed, 0, 0);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            Player_Rig.velocity = new Vector3(0, MoveSpeed
                , 0);
        }

        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A)||Input.GetKeyUp(KeyCode.Space))
        {
            Player_Rig.velocity = new Vector3(0, 0, 0);
        }

        //假如血量超出上限(吃一堆金幣)，則修正血量回歸為設定的上限
        if (LifeAmount > 100)
            LifeAmount = 100;

    }

    //處理碰撞事件(碰到怪物/金幣)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            //扣10滴血，血條減少
            LifeAmount -= 10;
            m_gameManager.m_HPBar.fillAmount -= 0.1f;
            audioSource.PlayOneShot(damage);

            //假如血量歸零，則玩家死亡(角色消失)
            if (LifeAmount == 0)
            {
                Destroy(gameObject);
            }
        }
        else if (collision.gameObject.tag == "Gold")
        {
            Score += 10;
            m_gameManager.m_Score.text = "分數：" + Score.ToString();
            audioSource.PlayOneShot(getscore);
        }
    }
}
