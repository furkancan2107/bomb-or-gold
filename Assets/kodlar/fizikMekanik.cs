
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fizikMekanik : MonoBehaviour
{
   public GameObject kuyrukBomba;
   Vector3 konum;
   
   List<GameObject> kuyruklar= new List<GameObject>();
   Vector2 basEski;
    float zaman;
   public float maxZaman;
   GameObject newKuyruk;
    public float hiz;
    void Start()
    {
      zaman=0;
      basEski=gameObject.transform.position;
      print(basEski);
     // kuyruklar.Add(gameObject);
      kuyruklar.Add(kuyrukBomba);
      
      for(int i=1;i<2;i++){
         kuyrukOlustur();
         kuyruklar[i].transform.position=new Vector2(gameObject.transform.position.x-1,gameObject.transform.position.y);

      }  
    }
    void BombaBirak(){
      /*for(int i=1;i<kuyruklar.Count;i++){
         Destroy(kuyruklar[i].gameObject,1f);
      }*/
      kuyruklar.Clear();
      newKuyruk=Instantiate(kuyrukBomba);
      newKuyruk.transform.position=basEski; 
    }
void FixedUpdate(){
   
   karekterHareket();
       if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)|| Input.GetKey(KeyCode.DownArrow))
      {
         bombaTakip();
         }
        
    }
    void Update(){
      zaman+=Time.deltaTime;
   print(zaman);
    if(zaman>maxZaman){
         Destroy(newKuyruk);
         zaman=0;
      }
    }
void karekterHareket(){
      if(Input.GetKey(KeyCode.W ) || Input.GetKey(KeyCode.UpArrow)){
       transform.Translate(Vector2.up*Time.deltaTime*hiz);
       basEski=new Vector2(transform.position.x,transform.position.y-1);
      // print(basEski);
     }
      if(Input.GetKey(KeyCode.S) ||  Input.GetKey(KeyCode.DownArrow)){
        transform.Translate(Vector2.down*Time.deltaTime*hiz);
      //  print(basEski);

basEski=new Vector2(transform.position.x,transform.position.y+1);     }
      if(Input.GetKey(KeyCode.A) ||  Input.GetKey(KeyCode.LeftArrow)){
        transform.Translate(Vector2.left*Time.deltaTime*hiz);
        basEski=new Vector2(transform.position.x+1,transform.position.y);
       // print(basEski);
         
     } if(Input.GetKey(KeyCode.D) ||  Input.GetKey(KeyCode.RightArrow)){
        transform.Translate(Vector2.right*Time.deltaTime*hiz);
           basEski=new Vector2(transform.position.x-1,transform.position.y);
           //print(basEski);  
     }
}
void OnTriggerEnter2D(Collider2D duvar){ 
 if(duvar.gameObject.tag=="duvar" || duvar.gameObject.tag=="dusman"){
    print("Game Over");
    Time.timeScale=0;
 }
 if(duvar.gameObject.tag=="altin"){
   BombaBirak();
   if(hiz<16.2f){
      hiz+=0.15f;
   }
 }
}

public void kuyrukOlustur(){
   GameObject yeniKuyruk=Instantiate(kuyrukBomba);
   yeniKuyruk.transform.position=basEski;
   kuyruklar.Add(yeniKuyruk);

}
void bombaTakip(){
   for(int i=kuyruklar.Count-1;i>0;i--){
      //kuyruklar[i].transform.position=new Vector2(kuyruklar[i-1].transform.position.x,kuyruklar[i-1].transform.position.y);
      kuyruklar[i].transform.position=basEski;
      /*print("bas pozisyon " + transform.position);
      print("kuyruk pozisyon: " + basEski);*/
   }
}
}
