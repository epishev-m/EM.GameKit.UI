﻿using System.Threading;
using Cysharp.Threading.Tasks;
using EM.UI;

namespace EM.GameKit.UI
{

public class InternetConnectionRouter
{
	private readonly IPanelSystem _panelSystem;

	private bool _isOpened;

	#region InternetConnectionRouter

	public InternetConnectionRouter(IPanelSystem panelSystem)
	{
		_panelSystem = panelSystem;
	}

	public async UniTask OpenAsync(CancellationToken ct)
	{
		await _panelSystem.OpenAsync<InternetConnectionPanelView, InternetConnectionViewModel>(Modes.Modal, ct);
		_isOpened = true;
	}

	public async UniTask CloseAsync(CancellationToken ct)
	{
		await _panelSystem.CloseAsync<InternetConnectionPanelView>(ct);
		_isOpened = false;
	}

	public async UniTask WaiteForCloseAsync(CancellationToken ct)
	{
		await UniTask.WaitUntil(() => !_isOpened, cancellationToken: ct);
	}

	#endregion
}

}