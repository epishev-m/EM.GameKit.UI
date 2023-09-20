using EM.Foundation;
using EM.UI;
using UnityEngine;
using UnityEngine.UI;

namespace EM.GameKit.UI
{

[ViewAsset(nameof(BlackoutPanelView), LifeTime.Local)]
public sealed class BlackoutPanelView : PanelView<IBlackoutViewModel>
{
	[Header(nameof(BlackoutPanelView))]

	[SerializeField]
	private Button _button;

	#region PanelView

	protected override void OnSettingViewModel()
	{
		base.OnSettingViewModel();
		this.Subscribe(_button, ViewModel.Click, CtsInstance);
	}

	#endregion
}

}