using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour
{
    public static GameMgr m_instance;//单例

    public static int GameCount = 0;
    public static int GameSorce = 0;
    public static bool gamestart = false;
    public bool over;
    public static bool huoChai=false;
    public static bool huoDui = false;
    public Transform firePosition;
    public GameObject zidan;
    public GameObject lizi;
    void Awake()
    {
        m_instance = this;
    }
    public talk UIGame()
    {

        return m_instance.GetComponent<talk>();
    }

    public void PickUp()
    {
        if (GameCount > 3)
        {
            GameCount = 3;
        }
        GetComponent<talk>().PickUp(GameCount);
    }
    void Update()
    {
        if (gamestart)
        {
            shoot();
        }
        if (over)
        {
            
            Cursor.visible = true;
            pickUpPowerCell();
        }
        if(huoDui && huoChai){
            lizi.SetActive(true);
        }

    }
    public void StartGame()
    {
        GameMgr.m_instance.UIGame().StartButton.gameObject.SetActive(false);
        GameMgr.m_instance.UIGame().bottomText.transform.parent.gameObject.SetActive(true);
        GameMgr.m_instance.UIGame().bottomText.text = "点击鼠标左键发射物体";
        Cursor.visible = false;
        gamestart = true;
    }
    void shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject go = Instantiate(zidan, firePosition.position, Quaternion.identity) as GameObject;
            Rigidbody rd = go.AddComponent<Rigidbody>();
            rd.velocity = firePosition.forward * 90;
            Destroy(go, 5);
        }
    }
    void pickUpPowerCell()
    {

        if (Input.GetMouseButtonDown(0))//射线的使用
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                if (hitInfo.transform.gameObject.tag == "power")
                {
                    Destroy(hitInfo.collider.gameObject);
                    GameMgr.m_instance.PickUp();
                    GameCount++;
                    print("GameCount:"+GameCount);
                    
                }
            }

        }
    }




}
