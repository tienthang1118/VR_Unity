using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public GameObject buttonPlayVideo;
    public GameObject buttonPauseVideo;
    public Text currentMinutes;
    public Text currentSeconds;
    public Text totalMinutes;
    public Text totalSeconds;
    public PlayHeadMover playHeadMover;

    // void Awake()
    // {
    //     videoPlayer = GetComponent<VideoPlayer>();
    // }
    // Start is called before the first frame update
    void Start()
    {
        //videoPlayer.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (videoPlayer.isPlaying)
        {
            SetCurrentTimeUi();
            playHeadMover.MovePlayHead(CaculatePlayedFraction());
        }
    }
    public void PauseVideo()
    {
        if (videoPlayer.isPlaying)
        {
            videoPlayer.Pause();
            buttonPlayVideo.SetActive(true);
            buttonPauseVideo.SetActive(false);
        }
        else
        {
            videoPlayer.Play();
            SetTotalTimeUi();
            buttonPauseVideo.SetActive(true);
            buttonPlayVideo.SetActive(false);
        }
    }

    void SetCurrentTimeUi()
    {
        string minutes = Mathf.Floor((int)videoPlayer.time / 60).ToString("00");
        string seconds = ((int)videoPlayer.time % 60).ToString("00");

        currentMinutes.text = minutes;
        currentSeconds.text = seconds;
    }
    void SetTotalTimeUi()
    {
        string minutes = Mathf.Floor((int)videoPlayer.clip.length / 60).ToString("00");
        string seconds = ((int)videoPlayer.clip.length % 60).ToString("00");

        totalMinutes.text = minutes;
        totalSeconds.text = seconds;
    }

    double CaculatePlayedFraction()
    {
        double fraction = (double)videoPlayer.frame / (double)videoPlayer.clip.frameCount;
        return fraction;
    }

    public void RewindVideo()
    {
        videoPlayer.time += 5;
    }

    public void TuaLaiVideo()
    {
        videoPlayer.time -= 5;
    }
}
