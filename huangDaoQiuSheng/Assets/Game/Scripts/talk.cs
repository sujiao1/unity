using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;


public class talk : MonoBehaviour
{
    public Text bottomText;
    public Text name;
    public GameObject left;
    public GameObject right;
    public GameObject bottomImg;
    public Image img;
    public Sprite[] sprites;
    public Button StartButton;
    public GameObject ExitBG;
    public Button Exit;


    string str = "昨 夜 ，老 夫 夜 观 天 象 ， 发 现 你 被 困 于 此 岛 ，只 要 你 收 集 齐 我 所 需 要 的 能 量 体 ， 我 就 帮 你 离 开 。";
    string[] ss;
    string strMid = "昨夜，老夫夜观天象，发现你被困于此岛，只要你收集齐我所需要的能量体，我就帮你离开。";



    // Use this for initialization
    void Start()
    {
        // img.SetActive=(false);
        //left.SetActive(true);
        //ExitBG.SetActive(false);
        string str1=PlayerPrefs.GetString("myName");
        name.text = str1;
        ss = str.Split(' ');
       
        StartCoroutine(readInfo());  //开启协程
    }
    IEnumerator readInfo()//对话
    {
        for (int i = 0; i < ss.Length; i++)
        {
            bottomText.text += ss[i];
            if (B())
            {
                bottomText.text = strMid;
                break;
            }
            yield return new WaitForSeconds(0.1f);//0.1f之后按下中键实现跳转
            //yield return new WaitUntil(isdown);
        }

        yield return new WaitForSeconds(0.05f);
        yield return new WaitUntil(isdown);//检测isdown（）方法是否实现才跳转。。。。。。Wait Until
        bottomText.text = "我：你是谁？";
        right.SetActive(true);
        left.SetActive(false);
        yield return new WaitForSeconds(0.05f);
        yield return new WaitUntil(isdown);
        bottomText.text = "不用管我是谁，照我说的做你就能离开！";
        right.SetActive(false);
        left.SetActive(true);

        yield return new WaitForSeconds(0.05f);
        yield return new WaitUntil(isdown);

        GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>().enabled = true;//找到第一视角并不可以移动
        bottomImg.SetActive(false);  //隐藏对话框
        Cursor.visible = false;//鼠标隐藏

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
        }
    }
    bool B()
    {
        return isdown();
    }
    bool isdown()  //鼠标左键的检测，进入下一个对话
    {
        return Input.GetMouseButtonDown(0);
        //Input.GetKey(KeyCode.A);键盘上的按键
    }
    public void PickUp(int index)//更换电池数量的图片
    {
        print(index);
        img.sprite = sprites[index];
    }
    void OnGUI()//Resources的应用
    {
        if (GameMgr.startgame)
        {
            Texture img = Resources.Load<Texture>("Crosshair");//Crosshair的路径
            GUI.DrawTexture(new Rect(Screen.width / 2, Screen.height / 2, img.width, img.height), img);
        }
    }
    public void exit()
    {
        ExitBG.SetActive(true);

    }
    public void queDing()
    {

        Application.Quit();

    }
    public void quXiao()
    {
        ExitBG.SetActive(false);
    }
}
