using System;
using EM.Foundation;

namespace EM.GameKit.UI
{

public sealed class Cheats : IDisposable
{
#if UNITY_EDITOR
	public static CheatsModel CheatsModel { get; set; }
#endif

	private readonly ICheatFactory _cheatFactory;

	private readonly ICheatBinder _cheatBinder;

	#region IDisposable

	public void Dispose()
	{
#if UNITY_EDITOR
		CheatsModel = null;
#endif
	}

	#endregion

	#region Cheats

	public Cheats(ICheatFactory cheatFactory,
#if UNITY_EDITOR
		CheatsModel cheatsModel,
#endif
		ICheatBinder cheatBinder)
	{
		_cheatFactory = cheatFactory;
		_cheatBinder = cheatBinder;

#if UNITY_EDITOR
		Requires.Null(CheatsModel, nameof(CheatsModel));

		CheatsModel = cheatsModel;
#endif
	}

	public Cheats Add<T>(LifeTime lifeTime)
		where T : class, ICheat
	{
		var result = _cheatFactory.Get<T>();

		if (result.Failure)
		{
			return this;
		}

		result.Data.Registration(_cheatBinder, lifeTime);

		return this;
	}

	#endregion
}

}