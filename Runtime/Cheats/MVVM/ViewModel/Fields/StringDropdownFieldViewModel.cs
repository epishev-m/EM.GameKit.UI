using System.Collections.Generic;
using EM.Foundation;

namespace EM.GameKit.UI
{

public class StringDropdownFieldViewModel : IFieldViewModel
{
	private readonly ObservableField<int> _index = new();

	private readonly StringDropdownCheatFieldModel _model;
	
	#region IFieldViewModel
	
	public void Initialize()
	{
		_model.OnChanged += OnChangeModel;
	}

	public void Release()
	{
		_model.OnChanged -= OnChangeModel;
	}

	public void UpdateAllRxProperties()
	{
		OnChangeModel();
	}

	#endregion

	#region StringDropdownFieldViewModel

	public StringDropdownFieldViewModel(StringDropdownCheatFieldModel model)
	{
		_model = model;
	}

	public IObservableField<int> Index => _index;

	public IEnumerable<string> Options => _model.Options;

	public void SetIndex(int index)
	{
		_index.SetValueWithoutNotify(index);
		_model.Index = index;
	}

	private void OnChangeModel()
	{
		_index.SetValue(_model.Index);
	}

	#endregion
}

}