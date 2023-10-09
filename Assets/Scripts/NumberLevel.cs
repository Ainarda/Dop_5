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
    public void ChangeLevel()
    {
        NumberLevels++;
        SaveNumberLevel();
    }
    private void LoadNumberLevel()
    {
        if ((bool)(YandexData.Load("NumberLevel", 1)))
        {
            NumberLevels = (int)(YandexData.Load("NumberLevel", 1));
        }
        
        
        if (NumberLevels == 24)
        {
            NumberLevels = 29;
        }
        if(NumberLevels == 44)
        {
            NumberLevels = 49;
        }
        _numberLevel.text = NumberLevels.ToString();
    }

    private void SaveNumberLevel()
    {
        YandexData.Save("NumberLevel", NumberLevels);
    }
}
