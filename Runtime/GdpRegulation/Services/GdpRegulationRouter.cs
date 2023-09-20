using System.Threading;
using Cysharp.Threading.Tasks;
using EM.UI;

namespace EM.GameKit.UI
{

public sealed class GdpRegulationRouter
{
	private readonly IPanelSystem _panelSystem;

	#region GdpRegulationRouter

	public GdpRegulationRouter(IPanelSystem panelSystem)
	{
		_panelSystem = panelSystem;
	}

	public async UniTask OpenAsync(CancellationToken ct)
	{
		await _panelSystem.OpenAsync<GdpRegulationPanelView, GdpRegulationViewModel>(Modes.Modal, ct);
	}

	public async UniTask CloseAsync(CancellationToken ct)
	{
		await _panelSystem.CloseAsync<GdpRegulationPanelView>(ct);
	}

	#endregion
}

}