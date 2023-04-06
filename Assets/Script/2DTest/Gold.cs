using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gold : MonoBehaviour
{
    public GameObject m_gameManager;
    public GameObject m_Player;

    // Start is called before the first frame update
    void Start()
    {
        m_gameManager=GameObject.Find("GameManager");
        m_Player=GameObject.Find("Player");
        Destroy(gameObject, 10);        
    }

    // Update is called once per frame
    void Update()
    {

    }

    //處理碰撞事件(被玩家碰到後發生的事)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //玩家血量+10，血條往前補滿
            m_Player.GetComponent<PlayerMove>().LifeAmount += 10;
            m_gameManager.GetComponent<GameManager>().m_HPBar.fillAmount += 0.1f;
            
            //金幣消失
            Destroy(gameObject);
        }
    }
}
