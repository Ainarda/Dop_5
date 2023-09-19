using System;
using KiYandexSDK;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScratchDemoUI : MonoBehaviour
{
	public ScratchCardManager CardManager;
	public Texture[] Brushes;
	public Toggle[] BrushToggles;
	public Toggle ProgressToggle;
	public Text ProgressText;
	public Dropdown ScratchModeDropdown;
	public Slider BrushScaleSlider;
	public Text BrushScaleText;
	public EraseProgress EraseProgress;

    [SerializeField] private GameObject _lastic;
    private Vector3 targetPosition;

    private string ToggleKey = "Toggle";
	private string BrushKey = "Brush";
	private string ScaleKey = "Scale";

    private bool _isFinishLevel;

    public  Action OnCompleteLevel;


    void Start()
	{
		Application.targetFrameRate = 60;
		ProgressToggle.isOn = PlayerPrefs.GetInt(ToggleKey, 0) == 0;
		EraseProgress.OnProgress += OnEraseProgress;
		BrushScaleSlider.onValueChanged.AddListener(OnSlider);
		ScratchModeDropdown.onValueChanged.AddListener(OnDropdown);
		BrushScaleSlider.value = PlayerPrefs.GetFloat(ScaleKey, 1f);
		foreach (var brushToggle in BrushToggles)
		{
			brushToggle.onValueChanged.AddListener(OnChange);
		}
		BrushToggles[PlayerPrefs.GetInt(BrushKey)].isOn = true;
	}

	public Texture2D tex;
	void Update()
	{
		if (Input.GetMouseButton(0))
		{
			ShowLastick();

        }
		if (Input.GetMouseButtonUp(0)) 
		{
			Restart();
		}
	}

	private void ShowLastick()
	{
        targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPosition.z = 0f;

        _lastic.transform.position = targetPosition;
        _lastic.gameObject.SetActive(true);
    }
	private void OnDropdown(int id)
	{
		var mode = (ScratchCard.ScratchMode)id;
		CardManager.Card.Mode = mode;
	}
	
	private void OnSlider(float val)
	{
		CardManager.Card.BrushScale = Vector2.one * val;
		BrushScaleText.text = Math.Round(val, 2).ToString();
		YandexData.Save(ScaleKey, val);
	}

	private void OnChange(bool val)
	{
		for (var i = 0; i < BrushToggles.Length; i++)
		{
			if (BrushToggles[i].isOn)
			{
				CardManager.SetEraseTexture(Brushes[i]);
				YandexData.Save(BrushKey, i);
				break;
			}
		}
	}

	private void OnEraseProgress(float progress)
	{
		float value = Mathf.Round(progress * 100f);

		if (value >90)
		{
            _isFinishLevel=true;

			OnCompleteLevel?.Invoke();
		}
	}
	
	public void OnCheck(bool check)
	{
		EraseProgress.enabled = ProgressToggle.isOn;
		YandexData.Save(ToggleKey, ProgressToggle.isOn ? 0 : 1);
	}

	public void Restart()
	{
        _lastic.gameObject.SetActive(false);

		if (_isFinishLevel==false)
		{
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }
	}
}