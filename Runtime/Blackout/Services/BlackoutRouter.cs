﻿using System.Threading;
using Cysharp.Threading.Tasks;
using EM.UI;

namespace EM.GameKit.UI
{

public sealed class BlackoutRouter
{
	private readonly IPanelSystem _panelSystem;

	#region BlackoutRouter

	public BlackoutRouter(IPanelSystem panelSystem)
	{
		_panelSystem = panelSystem;
	}

	public async UniTask OpenAsync(CancellationToken ct)
	{
		await _panelSystem.OpenAsync<BlackoutPanelView, BlackoutViewModel>(Modes.Modal, ct);
	}

	public async UniTask CloseAsync(CancellationToken ct)
	{
		await _panelSystem.CloseAsync<BlackoutPanelView>(ct);
	}

	#endregion
}

}