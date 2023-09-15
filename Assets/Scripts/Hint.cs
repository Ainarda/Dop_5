using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Hint : MonoBehaviour
{
    [SerializeField] private HintButton _hintButton;

    public GameObject targetObject;
    public float delay = 0.5f;


    private void OnEnable()
    {
        _hintButton.OnWatchedAd += StartHint;
    }

    private void OnDisable()
    {
        _hintButton.OnWatchedAd -= StartHint;
    }

    public void StartHint()
    {
        StartCoroutine(TransparentCoroutine());
    }

    private IEnumerator TransparentCoroutine()
    {
        for (int i = 0; i < 3; i++)
        {
            targetObject.SetActive(false);

            yield return new WaitForSeconds(delay);

            targetObject.SetActive(true);

            yield return new WaitForSeconds(delay);
        }
    }
}
