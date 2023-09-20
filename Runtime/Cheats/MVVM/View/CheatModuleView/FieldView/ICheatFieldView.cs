using System;
using UnityEngine;

namespace EM.GameKit.UI
{

public interface ICheatFieldView
{
	void Initialize(IFieldViewModel viewModel);

	void Release();

	Type GetViewModelType();

	void SetVisible(bool value);

	void SetParent(Transform parent);
}

}