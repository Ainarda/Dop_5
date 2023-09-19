using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishLevel : MonoBehaviour
{
    [SerializeField] private ScratchDemoUI _scratchDemo;
    [SerializeField] private Button _nextLevel;
    [SerializeField] private Button _hint;
    [SerializeField] private SpriteRenderer _checkMark;
    
    private void OnEnable()
    {
        _scratchDemo.OnCompleteLevel += CompleteLevel;   
    }

    private void OnDisable()
    {
        _scratchDemo.OnCompleteLevel -= CompleteLevel;
    }

    private void CompleteLevel()
    {
        _hint.gameObject.SetActive(false);
        _checkMark.gameObject.SetActive(true);
        _nextLevel.gameObject.SetActive(true);
        
        //AdvertS.PlayAd();
    }
}
