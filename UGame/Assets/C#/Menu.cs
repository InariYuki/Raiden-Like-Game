using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.IO;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject BGM;
    [SerializeField] Dropdown resolution_dropdown;
    [SerializeField] Dropdown language_dropdown;
    [SerializeField] InputField[] input_fields = new InputField[4];
    string save_lang_id = "lang";
    string[] file_paths;
    private void Awake()
    {
        file_paths = Directory.GetFiles(Application.streamingAssetsPath, "*.png");
#if UNITY_STANDALONE_WIN
        resolution_dropdown.interactable = true;
#endif
#if UNITY_ANDROID || UNITY_IOS
        resolution_dropdown.interactable = false;
#endif
        if(input_fields[0].text == "" || input_fields[1].text == "" || input_fields[2].text == "" || input_fields[3].text == "")
        {
            input_fields[0].text = "w";
            input_fields[1].text = "s";
            input_fields[2].text = "a";
            input_fields[3].text = "d";
            for(int i = 0; i < input_fields.Length; i++)
            {
                StaticVars.keyboard_ctl[i] = input_fields[i].text;
            }
        }
    }
    private void Start()
    {
        if(GameObject.FindGameObjectsWithTag("BGM").Length == 0)
        {
            Instantiate(BGM);
        }
    }
    public void change_scene()
    {
        SceneManager.LoadScene("Level");
    }
    public void close_app()
    {
        Application.Quit();
    }
    [SerializeField] Sprite sound_on_image , sound_off_image;
    [SerializeField] Image sound_image;
    public void StopFX()
    {
        AudioListener.pause = !AudioListener.pause;
        if (!AudioListener.pause)
        {
            sound_image.sprite = ParseImage(1);
        }
        else
        {
            sound_image.sprite = ParseImage(0);
        }
    }
    Sprite ParseImage(int id)
    {
        Texture2D image = new Texture2D(0 , 0);
        image.LoadImage(File.ReadAllBytes(file_paths[id]));
        return Sprite.Create(image , new Rect(0 , 0 , image.width , image.height) , new Vector2(0.5f , 0.5f));
    }
    [SerializeField] Slider volumn_slider;
    [SerializeField] AudioMixer audio_mixer;
    public void ChangeVolume()
    {
        audio_mixer.SetFloat("BGM" , volumn_slider.value);
    }
    public void SetResolution()
    {
        switch (resolution_dropdown.value)
        {
            case 0:
                Screen.SetResolution(1080 , 1920 , false);
                break;
            case 1:
                Screen.SetResolution(720, 1280, false);
                break;
            case 2:
                Screen.SetResolution(480, 800, false);
                break;
        }
    }
    public void LanguageChanged()
    {
        PlayerPrefs.SetInt(save_lang_id , language_dropdown.value);
    }
    public void SetInput(int input_id)
    {
        StaticVars.keyboard_ctl[input_id] = input_fields[input_id].text;
    }
}
