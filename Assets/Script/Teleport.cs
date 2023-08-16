using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    private int floor;
    public void IsTriggerPressed(){
        if(gameObject.tag == "Floor1"){
            floor = 0;
        }
        else if(gameObject.tag == "Floor2"){
            floor = 1;
        }
        else if(gameObject.tag == "Floor3"){
            floor = 2;
        }
        SceneManager.LoadScene(floor);
    }
}
