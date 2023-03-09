using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class altınCikma : MonoBehaviour

{
    fizikMekanik kontrol=new fizikMekanik();
public int skor;
public Text skorText;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    void Start()
    {
        altinKonum();
    }

    void Update(){
        skorText.text=skor.ToString();
    }

    
   
    void OnTriggerEnter2D(Collider2D col){
        print(col.gameObject.tag);
        print(skor);
        skor++;


        if(col.gameObject.tag=="yilan"){
            altinKonum();
            
        }
       
    }
    void altinKonum(){
        transform.position=new Vector2(Random.Range(minX,maxX),Random.Range(minY,maxY));
    }
}
