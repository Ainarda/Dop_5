using System.Collections;
using UnityEngine;

public class Hint : MonoBehaviour
{
    [SerializeField] private AdButton _adButton;
    public GameObject targetObject;
    public float delay = 0.5f;

    private void OnEnable()
    {
        if(_adButton != null)
        {
            _adButton.RewardClosed += StartHint;
        }
        

        if (Player.IsAvailbleHint)
        {
            StartHint();
        }
    }

    private void OnDisable()
    {
        if (_adButton != null)
        {
            _adButton.RewardClosed -= StartHint;
        }
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