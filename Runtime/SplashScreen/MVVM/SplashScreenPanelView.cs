using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using EM.Foundation;
using EM.UI;
using UnityEngine;
using UnityEngine.UI;

namespace EM.GameKit.UI
{

[ViewAsset(nameof(SplashScreenPanelView), LifeTime.Local)]
public sealed class SplashScreenPanelView : PanelView<ISplashScreenViewModel>
{
	[SerializeField]
	private Button _skipButton;

	[SerializeField]
	private List<SplashView> _splashes;

	private SplashView _currentSplashView;

	#region View

	protected override void OnSettingViewModel()
	{
		base.OnSettingViewModel();

		this.Subscribe(ViewModel.CurrentSplashName, ChangeSplashAsync, CtsInstance);
		this.Subscribe(_skipButton, ViewModel.Skip, CtsInstance);
	}

	#endregion

	#region SplashScreenView

	private async UniTask ChangeSplashAsync(string splash,
		CancellationToken ct)
	{
		Hide();
		await ShowAsync(splash, ct);
	}

	private void Hide()
	{
		if (_currentSplashView != null)
		{
			_currentSplashView.Hide();
		}
	}

	private async UniTask ShowAsync(string splash,
		CancellationToken ct)
	{
		if (string.IsNullOrWhiteSpace(splash))
		{
			return;
		}

		if (TryGetView(splash, out var splashView))
		{
			_currentSplashView = splashView;

			if (_currentSplashView != null)
			{
				await _currentSplashView.ShowAsync(ct);
			}
		}
	}

	private bool TryGetView(string splashName,
		out SplashView splashView)
	{
		splashView = _splashes.Find(item => item.Name == splashName);

		if (splashView != null)
		{
			return true;
		}

		Debug.LogWarning($"Splash with name {splashName} not found");

		return false;
	}

	#endregion
}

}