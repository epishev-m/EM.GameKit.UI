using EM.Foundation;

namespace EM.GameKit.UI
{

public interface ICheatFactory
{
	Result<ICheat> Get<TCheat>()
		where TCheat : class, ICheat;
}

}