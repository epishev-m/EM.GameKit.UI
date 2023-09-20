using System.Collections.Generic;
using System.Linq;
using System.Threading;
using EM.Foundation;
using EM.UI;
using UnityEngine;
using UnityEngine.UI;

namespace EM.GameKit.UI
{

public sealed class GroupModuleViewContainer : MonoBehaviour
{
	[SerializeField]
	private RectTransform _rectTransform;

	[SerializeField]
	private Transform _container;

	[SerializeField]
	private Button _enableAllButton;

	[SerializeField]
	private Button _disableAllButton;

	[SerializeField]
	private SearchView _searchView;

	[SerializeField]
	private GroupModuleView _groupModuleViewPrefab;

	private readonly List<GroupModuleView> _groupViews = new();

	private CancellationTokenSource _ctxInstance;

	private GroupModuleViewPool _groupModuleViewPool;

	private ICheatsViewModel _viewModel;

	#region MonoBehaviour

	private void Awake()
	{
		var factory = new GroupModuleViewFactory(_container, _groupModuleViewPrefab);
		_groupModuleViewPool = new GroupModuleViewPool(factory);
	}

	#endregion

	#region GroupModuleViewContainer

	public void Initialize(ICheatsViewModel viewModel)
	{
		Requires.NotNullParam(viewModel, nameof(viewModel));

		_viewModel = viewModel;
		_ctxInstance = new CancellationTokenSource();

		this.Subscribe(_enableAllButton, _viewModel.EnableAllGroups, _ctxInstance);
		this.Subscribe(_disableAllButton, _viewModel.DisableAllGroups, _ctxInstance);

		_searchView.Initialize(_viewModel);
		CreateButtons();
	}

	public void Release()
	{
		ReleaseGroupButtonViews();
		_searchView.Release();
		_ctxInstance.Cancel();
		_viewModel = null;
	}

	public void Show(float width)
	{
		_rectTransform.sizeDelta = new Vector2(width, 0f);
		_rectTransform.gameObject.SetActive(true);
	}

	public void Hide()
	{
		_rectTransform.gameObject.SetActive(false);
	}

	public void SetVisibleGroups(IEnumerable<string> groups)
	{
		foreach (var view in _groupViews)
		{
			view.gameObject.SetActive(false);
		}

		foreach (var group in groups)
		{
			var view = _groupViews.FirstOrDefault(v => v.Name == group);

			if (view != null)
			{
				view.gameObject.SetActive(true);
			}
		}
	}

	public void SetEnableGroups(IEnumerable<string> groups)
	{
		foreach (var view in _groupViews)
		{
			view.Disable();
		}

		foreach (var group in groups)
		{
			var view = _groupViews.FirstOrDefault(v => v.Name == group);

			if (view != null)
			{
				view.Enable();
			}
		}
	}

	private void CreateButtons()
	{
		foreach (var group in _viewModel.Groups)
		{
			var result = _groupModuleViewPool.GetObject();

			if (result.Failure)
			{
				continue;
			}

			var cheatView = result.Data;
			cheatView.Initialize(group, _viewModel);
			_groupViews.Add(cheatView);
		}
	}

	private void ReleaseGroupButtonViews()
	{
		foreach (var groupView in _groupViews)
		{
			groupView.Release();
			_groupModuleViewPool.PutObject(groupView);
		}

		_groupViews.Clear();
	}

	#endregion
}

}