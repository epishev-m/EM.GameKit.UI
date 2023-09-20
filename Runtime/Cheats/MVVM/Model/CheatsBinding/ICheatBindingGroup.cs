using System.Collections.Generic;

namespace EM.GameKit.UI
{

public interface ICheatBindingGroup
{
	IEnumerable<string> Groups { get; }

	ICheatBinding SetGroups(params string[] groups);
}

}