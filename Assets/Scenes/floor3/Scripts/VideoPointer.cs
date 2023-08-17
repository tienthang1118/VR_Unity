using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoPointer : MonoBehaviour
{
    public VideoManager videoManager;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    // public void OnPointerEnter()
    // {

    // }
    public void OnPointerClick()
    {
        videoManager.PauseVideo();
    }

    public void OnMouseDown()
    {
        videoManager.PauseVideo();
    }
}
