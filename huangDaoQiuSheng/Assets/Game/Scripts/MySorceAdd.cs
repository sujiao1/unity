using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySorceAdd : MonoBehaviour {
    
	// Use this for initialization
	public void OnCollisionEnter(Collision zidan){
        print("1");
        if(zidan.collider.tag=="target"){
            GameMgr.GameSorce++;
            if(GameMgr.GameSorce>5){
                GameMgr.m_instance.over = true;
            }
        }           
    }			
}
