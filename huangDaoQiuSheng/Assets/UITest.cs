using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class UITest : MonoBehaviour ,IPointerDownHandler{
    
	// Use this for initialization
	void Start () {
		
	}
    public void OnPointerDown(PointerEventData eventData)
    {
        print(1);
    }
	// Update is called once per frame
	void Update () {
		
	}
}
