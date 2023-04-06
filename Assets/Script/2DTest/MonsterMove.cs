using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    private Rigidbody2D Monster_Rig;

    // Start is called before the first frame update
    void Start()
    {
        Monster_Rig = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 10);
    }

    // Update is called once per frame
    void Update()
    {
        Monster_Rig.velocity = new Vector3(-5, 0, 0);
    }
}
