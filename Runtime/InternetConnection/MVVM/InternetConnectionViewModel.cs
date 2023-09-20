using System.Threading;
using Cysharp.Threading.Tasks;

namespace EM.GameKit.UI
{

public sealed class InternetConnectionViewModel : IInternetConnectionViewModel
{
	private readonly InternetConnectionRouter _router;

	#region IInternetConnectionViewModel

	public void Restart()
	{
		_router.CloseAsync(new CancellationToken()).Forget();
	}

	#endregion

	#region InternetConnectionViewModel

	public InternetConnectionViewModel(InternetConnectionRouter router)
	{
		_router = router;
	}

	#endregion
}

}