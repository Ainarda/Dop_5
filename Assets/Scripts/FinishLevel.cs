using System.Collections;
using System.Collections.Generic;
using KimicuUtility;
using KiYandexSDK;
using UnityEngine;
using UnityEngine.UI;

public class FinishLevel : MonoBehaviour
{
    [SerializeField] private ScratchDemoUI _scratchDemo;
    [SerializeField] private Button _nextLevel;
    [SerializeField] private GameObject _adContainer;
    [SerializeField] private GameObject _checkMark;
    [SerializeField] private Animator _animator;

    private KiCoroutine _routine = new KiCoroutine();

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
        _adContainer.gameObject.SetActive(false);
        _checkMark.SetActive(true);
        _routine.StartRoutine(KiCoroutine.Delay(1.5f, () => _nextLevel.gameObject.SetActive(true)), true);
        _animator.SetTrigger("OnLevelWon");
    }
}