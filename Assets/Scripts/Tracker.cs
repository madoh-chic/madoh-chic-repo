using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// このスクリプトをアタッチされたオブジェクトは target を追尾するようになります。
public class Tracker : MonoBehaviour
{
    // 追尾対象
    public GameObject target;

    // 追尾対象との距離
    public float interDistance;

    Vector3 interDistanceVector;

    // Start is called before the first frame update
    void Start()
    {
        // 前方向(front) の逆側（つまり後ろ側）に interDistance だけ動いた位置
        interDistanceVector = new Vector3(-interDistance, -interDistance, -interDistance);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.transform.position + Vector3.Scale(target.transform.forward, interDistanceVector);
    }
}
