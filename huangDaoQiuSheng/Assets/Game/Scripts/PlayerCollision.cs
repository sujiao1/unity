using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {

	// Use this for initialization


    public void OnTriggerEnter(Collider other)
    {
       // print("OnTriggterEnter");
        if (other.tag=="door" && GameMgr.GameCount==4){
            other.transform.parent.GetComponent<Animator>().SetBool("open",true);
            
        }
        else if(other.tag=="door"&&GameMgr.GameCount<4){
            GameMgr.m_instance.UIGame().bottomImg.SetActive(true);
            GameMgr.m_instance.UIGame().bottomText.text = "你当前能量只有"+(GameMgr.GameCount)+"个，你需要四个能量才能开门";
        }
        if (other.tag == "power")
        {
            print("OnTriggterEnter");
        
            GameMgr.m_instance.PickUp();
            GameMgr.GameCount++;

            Destroy(other.gameObject);    
        }
        if (other.tag == "game1"){
            GameMgr.m_instance.UIGame().StartButton.gameObject.SetActive(true);//出现开始游戏按钮
           
            Cursor.visible = true;
            GameMgr.gamestart = false; 
           // Cursor.visible = true;
        }
        if (other.tag=="huoChai"){
            GameMgr.m_instance.UIGame().bottomImg.gameObject.SetActive(true);
            GameMgr.m_instance.UIGame().bottomText.text = "你可以去点燃火堆";
            GameMgr.huoChai = true;
        }
        if(other.tag=="huoDui"&& GameMgr.huoChai==true){
            GameMgr.huoDui = true;
            GameMgr.m_instance.UIGame().bottomImg.gameObject.SetActive(true);
            GameMgr.m_instance.UIGame().bottomText.text = "恭喜你，你可以离开了";
        }
        else if (other.tag == "huoDui" && GameMgr.huoChai == false)
        {
            GameMgr.m_instance.UIGame().bottomImg.gameObject.SetActive(true);
            GameMgr.m_instance.UIGame().bottomText.text = "你应该去寻找点火工具";
        }
       
    } 
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "game1")
        {
           GameMgr.m_instance.UIGame().StartButton.gameObject.SetActive(false);//游戏按钮消失
           GameMgr.m_instance.UIGame().bottomText.transform.parent.gameObject.SetActive(false);
           GameMgr.gamestart = false;
            Cursor.visible = false;
        }
        if (other.tag == "door")
        {
            GameMgr.m_instance.UIGame().bottomImg.SetActive(false);
            other.transform.parent.GetComponent<Animator>().SetBool("open", false);

        }
        if (other.tag == "huoChai")
        {
            GameMgr.m_instance.UIGame().bottomImg.gameObject.SetActive(false);
            GameMgr.m_instance.UIGame().bottomText.text = "";
        }
        if(other.tag=="huoDui"&&GameMgr.huoChai==true){
            GameMgr.m_instance.UIGame().bottomImg.gameObject.SetActive(false);
            GameMgr.m_instance.UIGame().bottomText.text = "你可以离开了";
        }
        if (other.tag == "huoDui" && GameMgr.huoChai == false)
        {
            GameMgr.m_instance.UIGame().bottomImg.gameObject.SetActive(false);
            GameMgr.m_instance.UIGame().bottomText.text = "";
        }
    }
   
}

   
