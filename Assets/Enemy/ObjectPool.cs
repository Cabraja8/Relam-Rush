using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{   
   [SerializeField] GameObject Enemies;
   [SerializeField] [Range(0,50)]  int poolsize = 5;
   [SerializeField] [Range(0.1f,30f)] float spawnTimer= 1f;

   GameObject[] pool;

    void Awake() {
       
       PopulatePool();
   }

     void PopulatePool(){
        
        pool = new GameObject[poolsize];

        for(int i=0;i < pool.Length;i++){
          pool[i] =  Instantiate(Enemies,transform);
          pool[i].SetActive(false);
        }

    }


    
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy(){
        while(true){

            EnableObjectInPool();
        yield return new WaitForSeconds(spawnTimer);
        }
    }

    void EnableObjectInPool()
    {   
          

        for(int i=0;i < pool.Length;i++){
         
         if(pool[i].activeInHierarchy == false){
            pool[i].SetActive(true); 
            return;
         }
         
       
    }
}
}
