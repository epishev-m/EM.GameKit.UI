using System.Globalization;
using EM.UI;
using TMPro;
using UnityEngine;

namespace EM.GameKit.UI
{

public sealed class Vector3CheatFieldView : CheatFieldView<Vector3FieldViewModel>
{
	[SerializeField]
	private TextMeshProUGUI _label;

	[SerializeField]
	private TMP_InputField _inputFieldX;

	[SerializeField]
	private TMP_InputField _inputFieldY;

	[SerializeField]
	private TMP_InputField _inputFieldZ;

	#region CheatFieldView

	protected override void OnInitialize()
	{
		this.Subscribe(ViewModel.X, UpdateValueX, CtsInstance);
		this.Subscribe(ViewModel.Y, UpdateValueY, CtsInstance);
		this.Subscribe(ViewModel.Z, UpdateValueZ, CtsInstance);
		this.Subscribe(ViewModel.Label, UpdateLabel, CtsInstance);
		this.Subscribe(_inputFieldX, SetValueX, CtsInstance);
		this.Subscribe(_inputFieldY, SetValueY, CtsInstance);
		this.Subscribe(_inputFieldZ, SetValueZ, CtsInstance);
	}

	#endregion

	#region Vector2FieldView

	private void UpdateValueX(float value)
	{
		_inputFieldX.SetTextWithoutNotify(value.ToString(CultureInfo.CurrentUICulture));
	}

	private void UpdateValueY(float value)
	{
		_inputFieldY.SetTextWithoutNotify(value.ToString(CultureInfo.CurrentUICulture));
	}

	private void UpdateValueZ(float value)
	{
		_inputFieldZ.SetTextWithoutNotify(value.ToString(CultureInfo.CurrentUICulture));
	}

	private void UpdateLabel(string value)
	{
		_label.text = value;
	}

	private void SetValueX(string value)
	{
		if (float.TryParse(value, out var floatValue))
		{
			ViewModel.SetX(floatValue);
		}
	}

	private void SetValueY(string value)
	{
		if (float.TryParse(value, out var floatValue))
		{
			ViewModel.SetY(floatValue);
		}
	}

	private void SetValueZ(string value)
	{
		if (float.TryParse(value, out var floatValue))
		{
			ViewModel.SetZ(floatValue);
		}
	}

	#endregion
}

}