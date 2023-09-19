using System.Collections;
using UnityEngine;

public class Hint : MonoBehaviour
{
    [SerializeField] private AdButton _adButton;
    public GameObject targetObject;
    public float delay = 0.5f;

    private void OnEnable()
    {
        _adButton.RewardClosed += StartHint;
    }

    private void OnDisable()
    {
        _adButton.RewardClosed -= StartHint;
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