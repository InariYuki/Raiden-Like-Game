using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlButton : MonoBehaviour
{
    public void ChangeGameScene(string scene_name)
    {
        SceneManager.LoadScene(scene_name);
    }
}
