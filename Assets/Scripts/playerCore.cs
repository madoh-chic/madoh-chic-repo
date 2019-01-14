using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 自キャラの状態を表現するための Enum
enum MovingState
{
    normal, // 通常移動時
    turn, // 魔法陣を蹴ってターンする状態
    damaged // ダメージを受けたときのノックバックなどの状態
}

public class playerCore : MonoBehaviour
{
    // 自キャラの中にコアとなる小さい球体を用意して、それを動かす。このスクリプトもそのコアにアタッチする。

    // 移動速度
    public float speed;

    private MovingState movingState = MovingState.normal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (movingState)
        {
            // 通常状態
            case MovingState.normal:
                // 前向きに一定速度で進む
                transform.position += transform.forward * speed;
                break;
        }
    }
}
