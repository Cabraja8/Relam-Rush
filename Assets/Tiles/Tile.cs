using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{ 
    [SerializeField] Tower TowerPrefab;
    [SerializeField] bool isPlaceable;

    GridManager gridManager;
    PathFinder pathFinder;
    Vector2Int coordinates = new Vector2Int();

    void Awake() {
      gridManager = FindObjectOfType <GridManager>();
      pathFinder = FindObjectOfType <PathFinder>();
    }

    public bool IsPlaceable {
      get {
        return isPlaceable;
      }
    }
    Vector3 pos;
    public float minX = 0.0f;
    public float maxX = 70.0f;
    public float minZ = 0.0f;
    public float maxZ = 70.0f;

     void Start() {

    for (int i = 0; i < 10; i++) {

    float x = UnityEngine.Random.Range(minX, maxX);
    float y = 2.5f;
    float z = UnityEngine.Random.Range(minZ, maxZ);

        x = Mathf.Round(x / 10f) * 10f;
        z = Mathf.Round(z / 10f) * 10f;

        pos= new Vector3(x, y, z);
        if(gridManager != null) {
          coordinates = gridManager.GetCoordinatesFromPosition(pos); 

          if(!IsPlaceable){
            gridManager.BlockNode(coordinates);
          }
        }
       SpawnTowers();
            
        }
    }
    




     
    public void SpawnTowers(){

            if(gridManager.GetNode(coordinates).isWalkable && !pathFinder.WillBlockpath(coordinates)){
             bool isSuccessful = TowerPrefab.CreateTower(TowerPrefab,pos); 
       
             if(isSuccessful){
               gridManager.BlockNode(coordinates);
               pathFinder.NotifyReceiver();
             }
           }
    }
      
      
          

   
   
}
