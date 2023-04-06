using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject MonsterPrefab; //設置放怪物Prefab的變數MonsterPrefab
    public GameObject GoldPrefab;

    public float MonsterSpawnSpan = 5.0f; //預設時間長度(怪物生成時間點)
    public float GoldSpawnSpan = 5.0f; //預設時間長度(金幣生成時間點)

    float MonsterDelta = 0; //現在已經累積的時間
    float GoldDelta = 0; //現在已經累積的時間

    public Image m_HPBar;
    public Text m_Score;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float px = Random.Range(-9.0f, 10.0f); //設置金幣隨機生成的X值範圍(-8至8之間)

        MonsterDelta += Time.deltaTime; // 不斷累積時間
        // 如果累積時間大於預設的時間長度(到達生成時間)，就依據Prefab產生遊戲物件
        if (MonsterDelta > MonsterSpawnSpan)
        {
            MonsterDelta = 0; // 將累積時間歸零
            Instantiate(MonsterPrefab, new Vector3(6, 1.5f, 0), Quaternion.identity);// 產生遊戲物件
        }

        GoldDelta += Time.deltaTime; // 不斷累積時間
        // 如果累積時間大於預設的時間長度(到達生成時間)，就依據Prefab產生遊戲物件
        if (GoldDelta > GoldSpawnSpan)
        {
            GoldDelta = 0; // 將累積時間歸零
            Instantiate(GoldPrefab, new Vector3(px, 6, 0), Quaternion.identity);// 產生遊戲物件
        }


    }
}
