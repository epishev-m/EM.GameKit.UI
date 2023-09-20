using EM.UI;
using TMPro;
using UnityEngine;

namespace EM.GameKit.UI
{

public sealed class InfoCheatFieldView : CheatFieldView<InfoFieldViewModel>
{
	[SerializeField]
	private TextMeshProUGUI _infoText;

	#region CheatFieldView

	protected override void OnInitialize()
	{
		this.Subscribe(ViewModel.Info, UpdateInfo, CtsInstance);
	}

	#endregion

	#region InfoCheatFieldView

	private void UpdateInfo(string info)
	{
		_infoText.text = info;
	}

	#endregion
}

}