using EM.UI;

namespace EM.GameKit.UI
{

public abstract class BaseHintTooltipViewModel : ViewModel<IHintTooltipData>
{
	public abstract string Message { get; }

	public abstract void Finish();
}

}