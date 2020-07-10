using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Login : MonoBehaviour {
    AsyncOperation aync;
    public Slider loading;
    public InputField name;
    public Text load;
    private float value=0;
    private float i;
    public GameObject BG;
    public GameObject Slider;
	void Start () {

        
	}
	
	// Update is called once per frame
	
    public void OnbuttonClick()
    {
        BG.SetActive(false);
        Slider.SetActive(true);
        string str1 = name.text;
        PlayerPrefs.SetString("myName",str1);
        //StartCoroutine(Loading());
        StartCoroutine("Loading");
    }
    void Update () {
        
		 
	}
    IEnumerator Loading() {
        for (i = 0; i <= 100;i++ )
        {
            load.text = "正在加载..." + i + "%";
            loading.value = i / 100.0f;
            yield return new WaitForSeconds(0.01f);
            if (loading.value == 1)
            {
                aync = SceneManager.LoadSceneAsync(1);
                
            } 
                
           
       //aync.allowSceneActivation = false;
        //    yield return aync;
        }
       
        }
}
