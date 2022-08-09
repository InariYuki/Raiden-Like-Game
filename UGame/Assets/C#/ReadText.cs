using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ReadText : MonoBehaviour
{
    string cht_path;
    string eng_path;
    public string cht_unsliced;
    public string eng_unsliced;
    public string[] cht_sliced;
    public string[] eng_sliced;
    public enum platform
    {
        PC,
        Mobile
    }
    public platform current_platform;
    WWW ch_reader;
    WWW en_reader;
    private void Awake()
    {
        cht_path = Application.streamingAssetsPath + "/CH.txt";
        eng_path = Application.streamingAssetsPath + "/EN.txt";
        switch (current_platform)
        {
            case platform.PC:
                cht_unsliced = File.ReadAllText(cht_path);
                eng_unsliced = File.ReadAllText(eng_path);
                cht_sliced = cht_unsliced.Split('\n');
                eng_sliced = eng_unsliced.Split('\n');
                break;
            case platform.Mobile:
                ch_reader = new WWW(cht_path);
                en_reader = new WWW(eng_path);
                cht_sliced = ch_reader.text.Split('\n');
                eng_sliced = en_reader.text.Split('\n');
                break;
        }
    }
}
