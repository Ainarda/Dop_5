using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lastic : MonoBehaviour
{
    [SerializeField] private Erasing _lastic;

    private bool isMoving = false;
    private Vector3 targetPosition;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.z = 0f;

            _lastic.transform.position = targetPosition;
            _lastic.gameObject.SetActive(true);
        }

        if (Input.GetMouseButtonUp(0))
        {
            _lastic.TryCleanMask();
            _lastic.gameObject.SetActive(false);
        }
    }
}
