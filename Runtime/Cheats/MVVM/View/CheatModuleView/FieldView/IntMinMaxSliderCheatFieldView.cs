using System.Globalization;
using EM.UI;
using TMPro;
using UnityEngine;

namespace EM.GameKit.UI
{

public sealed class IntMinMaxSliderCheatFieldView : CheatFieldView<IntMinMaxSliderFieldViewModel>
{
	[SerializeField]
	private TextMeshProUGUI _label;

	[SerializeField]
	private TMP_InputField _minInputField;

	[SerializeField]
	private TMP_InputField _maxInputField;

	[SerializeField]
	private MinMaxSlider _minMaxSlider;

	#region IntMinMaxSliderCheatFieldView

	protected override void OnInitialize()
	{
		this.Subscribe(ViewModel.MinValue, UpdateMinValue, CtsInstance);
		this.Subscribe(ViewModel.MaxValue, UpdateMaxValue, CtsInstance);
		this.Subscribe(_minInputField, SetMinValue, CtsInstance);
		this.Subscribe(_maxInputField, SetMaxValue, CtsInstance);
		this.Subscribe(_minMaxSlider.OnMinValueChanged, SetMinValue, CtsInstance);
		this.Subscribe(_minMaxSlider.OnMaxValueChanged, SetMaxValue, CtsInstance);

		_label.text = ViewModel.Label;
		_minMaxSlider.MinLimit = ViewModel.MinLimit;
		_minMaxSlider.MaxLimit = ViewModel.MaxLimit;
		_minMaxSlider.MinDistance = ViewModel.MinDistance;
	}

	private void UpdateMinValue(int value)
	{
		_minInputField.SetTextWithoutNotify(value.ToString(CultureInfo.CurrentUICulture));
		_minMaxSlider.SetMinValueWithoutNotify(value);
	}
	
	private void UpdateMaxValue(int value)
	{
		_maxInputField.SetTextWithoutNotify(value.ToString(CultureInfo.CurrentUICulture));
		_minMaxSlider.SetMaxValueWithoutNotify(value);
	}
	
	private void SetMinValue(string value)
	{
		if (!int.TryParse(value, out var intValue))
		{
			return;
		}

		_minMaxSlider.SetMinValueWithoutNotify(intValue);
		_minMaxSlider.MinValue = intValue;
	}
	
	private void SetMaxValue(string value)
	{
		if (!int.TryParse(value, out var intValue))
		{
			return;
		}

		_minMaxSlider.SetMaxValueWithoutNotify(intValue);
		_minMaxSlider.MaxValue = intValue;
	}

	private void SetMinValue(float value)
	{
		var intValue = (int) value;
		ViewModel.SetMinValue(intValue);
		_minInputField.SetTextWithoutNotify(intValue.ToString(CultureInfo.CurrentUICulture));
	}

	private void SetMaxValue(float value)
	{
		var intValue = (int) value;
		ViewModel.SetMaxValue(intValue);
		_maxInputField.SetTextWithoutNotify(intValue.ToString(CultureInfo.CurrentUICulture));
	}

	#endregion
}

}