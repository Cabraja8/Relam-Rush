using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{       
    [SerializeField] float buildDelay = 1f;
    void Start(){
        StartCoroutine(Build());
    }

    IEnumerator Build() {
        foreach(Transform child in transform){
            child.gameObject.SetActive(true);
            yield return new WaitForSeconds(buildDelay);
            foreach( Transform grandchild in child){
                grandchild.gameObject.SetActive(true);
            }
        }

    }
    [SerializeField] int cost = 100;


    public bool CreateTower(Tower tower,Vector3 pos){ 

        Bank bank = FindObjectOfType<Bank>();
      
        Debug.Log(pos + "pos");
        if (bank == null){
            return false;
        }

        if(bank.CurrentBalance >= cost){
        Instantiate(tower.gameObject,pos,Quaternion.identity);
        bank.Withdraw(cost);
        return true;
        }
        return false;
    }
}
