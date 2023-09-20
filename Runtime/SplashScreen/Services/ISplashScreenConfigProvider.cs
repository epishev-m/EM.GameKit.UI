using System.Collections.Generic;

namespace EM.GameKit.UI
{

public interface ISplashScreenConfigProvider
{
	bool IsUsed
	{
		get;
	}

	Queue<string> GetSplashNameQueue();

	bool CheckSkipByName(string name);
}

}