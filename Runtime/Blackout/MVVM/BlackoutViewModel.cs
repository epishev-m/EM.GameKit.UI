﻿using Cysharp.Threading.Tasks;
using EM.UI;

namespace EM.GameKit.UI
{

public sealed class BlackoutViewModel : IBlackoutViewModel
{
	private readonly IScreenSystem _screenSystem;

	#region IBlackoutViewModel

	public void Click()
	{
		_screenSystem.BackAsync(default).Forget();
	}

	#endregion

	#region BlackoutViewModel

	public BlackoutViewModel(IScreenSystem screenSystem)
	{
		_screenSystem = screenSystem;
	}

	#endregion
}

}