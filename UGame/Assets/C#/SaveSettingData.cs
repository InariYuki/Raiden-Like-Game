using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class SaveSettingData : MonoBehaviour
{
    string path;
    FileStream file;
    public Dropdown lang_dropdown;
    public Dropdown res_dropdown;
    public enum platform
    {
        PC,
        mobile
    }
    public platform current_platform;
    public string[] datas;
    WWW reader_mobile;
    string reader_PC;
    private void Awake()
    {
        path = Application.persistentDataPath + "/Save.txt";
        print(path);
        if (File.Exists(path))
        {
            LoadData();
        }
        else
        {
            file = new FileStream(path , FileMode.Create);
            file.Close();
        }
    }
    public void SaveData()
    {
        file = new FileStream(path, FileMode.Open);
        StreamWriter sw = new StreamWriter(file);
        sw.WriteLine(res_dropdown.value + "@" + lang_dropdown.value);
        sw.Close();
    }
    void LoadData()
    {
        switch (current_platform)
        {
            case platform.PC:
                reader_PC = File.ReadAllText(path);
                datas = reader_PC.Split('@');
                res_dropdown.value = int.Parse(datas[0]);
                lang_dropdown.value = int.Parse(datas[1]);
                break;
            case platform.mobile:
                reader_mobile = new WWW(path);
                datas = reader_mobile.text.Split('@');
                res_dropdown.value = int.Parse(datas[0]);
                lang_dropdown.value = int.Parse(datas[1]);
                break;
        }
    }
}
