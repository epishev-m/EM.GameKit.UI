using Cysharp.Threading.Tasks;

namespace EM.GameKit.UI
{

public sealed class HintTooltipViewModel : BaseHintTooltipViewModel
{
	private readonly HintTooltipRouter _router;

	#region BaseHintTooltipViewModel

	public override string Message => Data.Message;

	public override void Finish()
	{
		_router.CloseAsync(default).Forget();
	}

	#endregion

	#region HintTooltipViewModel

	public HintTooltipViewModel(HintTooltipRouter router)
	{
		_router = router;
	}

	#endregion
}

}