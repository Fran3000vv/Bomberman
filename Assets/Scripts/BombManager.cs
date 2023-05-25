using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BombManager : MonoBehaviour
{
    Dictionary<CoordXY,Coroutine> bombas=new Dictionary<CoordXY,Coroutine>(); 
    public void AddCoroutine(IEnumerator coroutine){
        StartCoroutine(coroutine);
    }
}

struct CoordXY{
    public int xPosition{get;set;}
    public int yPosition{get;set;}
}