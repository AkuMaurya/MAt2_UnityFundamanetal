using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiController : MonoBehaviour
{
    public Transform player;
    float speed = 5.0f;
    float visAngle = 6.0f;

    public GameObject lastHit;
    public GameObject Detector;
    public Vector3 collision = Vector3.zero;
    public List<GameObject> positions = new List<GameObject>();

    // Vector3 bottomR = new Vector3(58,12,461);
    // Vector3 bottomL = new Vector3(467,12,461);
    // Vector3 UpperL = new Vector3(467,12,44);
    // Vector3 UpperR = new Vector3(58,12,52);
    int count = 0;

    
    void Start(){

    }

    void Update(){
        Vector3 direction = player.position - this.transform.position;        //player position w.r.t.Light
        float angle = Vector3.Angle(direction, this.transform.forward);         // angle between light n player 
                                                                                
        RayCasts();
        AiScript(angle,direction);

        if(lastHit == Detector){
            Debug.Log("Caught");
            this.enabled = false;
            this.transform.Translate(0,0,Time.deltaTime * speed);
        }   
    }

    void RayCasts(){
        var ray = new Ray(this.transform.position, this.transform.forward);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, 1000)){
            lastHit = hit.transform.gameObject;                                 //store name of object raycast Hitting
            collision = hit.point;
        }
    }

    void AiScript( float angle, Vector3 direction){
        if(angle < visAngle){                  //if angle between LiGHT n player is minimum look at player and gameOver
            this.transform.rotation =   Quaternion.Slerp(this.transform.rotation,
                                        Quaternion.LookRotation(direction),
                                        Time.deltaTime );                              
        }
        else{                               // AI script for light to search for player 
                Vector3 _angle =  positions[count].transform.position - this.transform.position;
                this.transform.rotation =   Quaternion.Slerp(this.transform.rotation,
                                            Quaternion.LookRotation(_angle),
                                            Time.deltaTime );
                if(lastHit == positions[count]){ 
                    count += 1;
                    count = count % positions.Count;
                    count = Random.Range(0,8);
                }
        }
    }

    



    // Vector3 RandomAngle(){
    //     Vector3 Right = new Vector3(55,
    //     4,Random.Range(bottomR.z,UpperR.z));
    //     Vector3 Left = new Vector3(460,4
    //     ,Random.Range(bottomL.z,UpperL.z));
    //     Vector3 FinalAngle = new Vector3(Random.Range(Right.x,Left.x),
    //     4,Random.Range(Right.z,Left.z));
    //     return FinalAngle;}

    void OnDraw(){
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(collision,5.0f);
    }
}
