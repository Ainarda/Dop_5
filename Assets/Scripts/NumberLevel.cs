using KiYandexSDK;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class NumberLevel : MonoBehaviour
{
    public static int NumberLevels=0;

    [SerializeField] private TMP_Text _numberLevel;
    private void Start()
    {
        LoadNumberLevel();
        SaveNumberLevel();
    }
    private void LoadNumberLevel()
    {
        if ((bool)(YandexData.Load("NumberLevel", 0)))
        {
            print("1");
            NumberLevels = (int)(YandexData.Load("NumberLevel", 0));
        }
        //else
        //{
        //    NumberLevels++;
        //}
        NumberLevels++;
        if (NumberLevels == 24)
        {
            NumberLevels = 29;
        }
        _numberLevel.text = NumberLevels.ToString();
    }

    private void SaveNumberLevel()
    {
        YandexData.Save("NumberLevel", NumberLevels);
    }
}
