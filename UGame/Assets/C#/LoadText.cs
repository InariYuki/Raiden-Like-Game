using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadText : MonoBehaviour
{
    public int id;
    string save_lang_id = "lang";
    private void FixedUpdate()
    {
        switch (PlayerPrefs.GetInt(save_lang_id))
        {
            case 0:
                GetComponent<Text>().text = FindObjectOfType<ReadText>().cht_sliced[id];
                break;
            case 1:
                GetComponent<Text>().text = FindObjectOfType<ReadText>().eng_sliced[id];
                break;
        }
    }
}
