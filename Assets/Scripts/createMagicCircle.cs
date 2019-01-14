using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createMagicCircle : MonoBehaviour
{
    public GameObject MagicCircleOrigin;

    // 生成する魔法陣
    GameObject magicCircle;

    Vector3 mousePos;
    Vector3 offSet;
    Vector3 clickPos;

    bool dragMode = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // 魔法陣を追加する
            AddMagicCircle();

            //ドラッグ処理を開始
            dragMode = true; 
        }

        // ドラッグ中の処理
        if (dragMode)
        {
            PanelDrag();
        }

        // 指を話したとき
        if (Input.GetMouseButtonUp(0))
        {
            // ドラッグ処理を終了
            dragMode = false;
        }

    }

    void AddMagicCircle()
    {
        magicCircle = Instantiate(MagicCircleOrigin, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        magicCircle.transform.position += transform.forward *= 2.0f;
        magicCircle.transform.Rotate(Vector3.right * 90);

        clickPos = Input.mousePosition; //ドラッグ開始位置を取得して、
        offSet = transform.position - clickPos; //UIの中心とドラッグ開始位置のズレを取得

        //Debug.Log(magicCircle.name, magicCircle);
    }

    void PanelDrag()
    {
        mousePos = Input.mousePosition; //ドラッグ中のカーソル位置

        // transform.position = mousePos + offSet; //UIをドラッグさせる

        // タップ位置（深さはカメラから一定距離）に魔法陣を出現させる
        magicCircle.transform.position = DesiredMagicCirclePlace();
    }

    // 現在のマウスの位置から、魔法陣を置くべき場所を算出する
    // 角度はどれくらいにするか調整が難しいので一旦蒲柳
    Vector3 DesiredMagicCirclePlace()
    {
        Vector3 touchScreenPosition = Input.mousePosition;

        // 10.0fに深い意味は無い。画面に表示したいので適当な値を入れてカメラから離そうとしているだけ.
        // 自キャラよりは奥に配置する必要がある
        touchScreenPosition.z = 20.0f;

        Camera gameCamera = Camera.main;
        Vector3 touchWorldPosition = gameCamera.ScreenToWorldPoint(touchScreenPosition);

        return touchWorldPosition;
    }
}
