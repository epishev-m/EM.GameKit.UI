using EM.Foundation;
using EM.UI;

namespace EM.GameKit.UI
{

public interface ISplashScreenViewModel : IViewModel
{
	IObservableFieldAsync<string> CurrentSplashName
	{
		get;
	}

	void Skip();
}

}