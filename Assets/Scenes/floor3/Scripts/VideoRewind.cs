using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoRewind : MonoBehaviour
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

    public void OnPointerClick()
    {
        videoManager.RewindVideo();
    }

    public void OnMouseDown()
    {
        videoManager.RewindVideo();
    }
}
