namespace EM.GameKit.UI
{

public sealed class SplashScreenModel
{
	public bool IsFinished { get; private set; }

	public void Finish()
	{
		IsFinished = true;
	}
}

}