﻿using EM.UI;
using UnityEngine;

namespace EM.GameKit.UI
{

public abstract class BaseIconTooltipViewModel : ViewModel<IIconTooltipData>
{
	public abstract IconTooltipLayouts Layouts { get; }

	public abstract ISpriteAtlas Icon { get; }

	public abstract string Title { get; }

	public abstract string Description { get; }

	public abstract Vector3 Position { get; }

	public abstract Vector2 Size { get; }
}

}