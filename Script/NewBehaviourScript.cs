using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        Debug.Log("Awake");
    }

    void Start(){
        Debug.Log("Start");
    }

    // Update is called once per frame
    void Update()
    {
       Debug.Log("Update"); 
    }
}
