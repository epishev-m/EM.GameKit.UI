using System.Globalization;
using EM.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace EM.GameKit.UI
{

public sealed class SliderCheatFieldView : CheatFieldView<SliderFieldViewModel>
{
	[SerializeField]
	private TextMeshProUGUI _label;

	[SerializeField]
	private TMP_InputField _inputField;

	[SerializeField]
	private Slider _slider;

	#region CheatFieldView

	protected override void OnInitialize()
	{
		this.Subscribe(ViewModel.Value, UpdateValue, CtsInstance);
		this.Subscribe(_inputField, SetValue, CtsInstance);
		this.Subscribe(_slider, SetValue, CtsInstance);

		_label.text = ViewModel.Label;
		_slider.minValue = ViewModel.MinLimit;
		_slider.maxValue = ViewModel.MaxLimit;
	}

	#endregion

	#region FloatCheatFieldView

	private void UpdateValue(float value)
	{
		_inputField.SetTextWithoutNotify(value.ToString(CultureInfo.CurrentUICulture));
		_slider.SetValueWithoutNotify(value);
	}

	private void SetValue(string value)
	{
		if (!float.TryParse(value, out var floatValue))
		{
			return;
		}

		ViewModel.SetValue(floatValue);
		_slider.value = floatValue;
	}

	private void SetValue(float value)
	{
		ViewModel.SetValue(value);
		_inputField.text = value.ToString(CultureInfo.CurrentUICulture);
	}

	#endregion
}

}