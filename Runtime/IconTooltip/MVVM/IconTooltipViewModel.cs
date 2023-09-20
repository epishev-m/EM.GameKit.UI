using UnityEngine;

namespace EM.GameKit.UI
{

public sealed class IconTooltipViewModel : BaseIconTooltipViewModel
{
	public override IconTooltipLayouts Layouts => Data.Layout;

	public override ISpriteAtlas Icon => Data.Icon;

	public override string Title => Data.Title;

	public override string Description => Data.Description;

	public override Vector3 Position => Data.Position;

	public override Vector2 Size => Data.Size;
}

}