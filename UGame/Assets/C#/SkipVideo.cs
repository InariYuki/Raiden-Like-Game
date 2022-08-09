using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class SkipVideo : MonoBehaviour
{
    VideoPlayer video_player;
    bool skipable = false;
    private void Awake()
    {
        video_player = GetComponent<VideoPlayer>();
    }
    private void Start()
    {
        StartCoroutine(WaitForSkip());
    }
    private void FixedUpdate()
    {
        if (!video_player.isPlaying && skipable)
        {
            SceneManager.LoadScene("Game");
        }
    }
    IEnumerator WaitForSkip()
    {
        yield return new WaitForSeconds(1f);
        skipable = true;
    }
}
