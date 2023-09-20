using EM.Foundation;

namespace EM.GameKit.UI
{

public interface ICheatBindingLifeTime
{
	LifeTime LifeTime { get; }

	ICheatBindingGroup InGlobal();

	ICheatBindingGroup InLocal();

	ICheatBindingGroup SetLifeTime(LifeTime lifeTime);
}

}