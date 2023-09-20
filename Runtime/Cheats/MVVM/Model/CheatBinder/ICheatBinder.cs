using System.Collections.Generic;
using EM.Foundation;

namespace EM.GameKit.UI
{

public interface ICheatBinder
{
	IEnumerable<string> GetNames();

	IEnumerable<string> GetGroupsByName(string name);

	IEnumerable<ICheatFieldModel> GetItemsByName(string name);

	ICheatBindingLifeTime Bind(string name);

	void Unbind(string name);

	void Unbind(LifeTime lifeTime);

	void UnbindAll();
}

}