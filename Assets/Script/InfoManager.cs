using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoManager : MonoBehaviour
{
    public GameObject Panel;
    private bool Show = false;
    public void ShowAndHideInfo(){
        if(!Show){
            Panel.SetActive(true);
            Show = true;
        }
        else {
            Panel.SetActive(false);
            Show = false;
        }
    }
    
    public SoundManager soundManager1;

    public void OnClick(){
        soundManager1.PlayImageSound();
    }
}
