using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureManager : MonoBehaviour
{
    public GameObject Detail;
    public GameObject PlusButton;
    public GameObject DecreaseButton;
    public GameObject LeftButton;
    public GameObject RightButton;
    private bool Show = false;
    public void ShowAndHideManager(){
        if(!Show){
            Detail.SetActive(true);
            PlusButton.SetActive(false);
            DecreaseButton.SetActive(false);
            LeftButton.SetActive(false);
            RightButton.SetActive(false);
            Show = true;
        }
        else {
            Detail.SetActive(false);
            Show = false;
        }
    }
}
