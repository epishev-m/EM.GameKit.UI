using Cysharp.Threading.Tasks;
using DG.Tweening;
using EM.Foundation;
using EM.UI;
using TMPro;
using UnityEngine;

namespace EM.GameKit.UI
{

[ViewAsset(nameof(HintTooltipPanelView), LifeTime.Local)]
public sealed class HintTooltipPanelView : PanelView<BaseHintTooltipViewModel>
{
	[Header(nameof(HintTooltipPanelView))]

	[SerializeField]
	private CanvasGroup _container;

	[SerializeField]
	private TextMeshProUGUI _text;

	[SerializeField]
	private float _offset;

	[SerializeField]
	private float _showDuration;

	[SerializeField]
	private float _hideDuration;

	[SerializeField]
	private float _duration;

	#region View

	protected override void OnInitialize()
	{
		base.OnInitialize();
		_text.text = ViewModel.Message;
		StartShowAnimation();
	}

	#endregion

	#region HintTooltipView

	private void StartShowAnimation()
	{
		_container.transform.localPosition = new Vector3(0f, 0f);
		_container.alpha = 0;

		DOTween.Sequence()
			.Append(_container.DOFade(1, _showDuration))
			.Append(_container.transform.DOLocalMove(new Vector3(0f, _offset), _hideDuration).SetDelay(_duration))
			.Join(_container.DOFade(0, _hideDuration))
			.OnComplete(ViewModel.Finish)
			.ToUniTask(cancellationToken: CtsInstance.Token)
			.Forget();
	}

	#endregion
}

}