﻿using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace DLToolkit.PageFactory
{
	/// <summary>
	/// IPageFactory navigation.
	/// </summary>
	public interface IPageFactoryNavigation
	{
		/// <summary>
		/// Gets the page from cache. Creates a new page instances if not exists.
		/// </summary>
		/// <returns>The page from cache.</returns>
		/// <param name="resetViewModel">If set to <c>true</c> resets view model.</param>
		/// <typeparam name="TViewModel">View model type.</typeparam>
		IBasePage<INotifyPropertyChanged> GetPageFromCache<TViewModel>(bool resetViewModel = false) where TViewModel : class, INotifyPropertyChanged;

		/// <summary>
		/// Gets the page from cache. Creates a new page instances if not exists.
		/// </summary>
		/// <returns>The page from cache.</returns>
		/// <param name="viewModelType">View model type.</param>
		/// <param name="resetViewModel">If set to <c>true</c> resets view model.</param>
		IBasePage<INotifyPropertyChanged> GetPageFromCache(Type viewModelType, bool resetViewModel = false);

		/// <summary>
		/// Gets the page as new instance.
		/// </summary>
		/// <returns>The page as new instance.</returns>
		/// <param name="saveOrReplaceInCache">If set to <c>true</c> saves or replaces page in cache.</param>
		/// <typeparam name="TViewModel">View model type.</typeparam>
		IBasePage<INotifyPropertyChanged> GetPageAsNewInstance<TViewModel>(bool saveOrReplaceInCache = false) where TViewModel : class, INotifyPropertyChanged;

		/// <summary>
		/// Gets the page as new instance.
		/// </summary>
		/// <returns>The page as new instance.</returns>
		/// <param name="viewModelType">View model type.</param>
		/// <param name="saveOrReplaceInCache">If set to <c>true</c> saves or replaces page in cache.</param>
		IBasePage<INotifyPropertyChanged> GetPageAsNewInstance(Type viewModelType, bool saveOrReplaceInCache = false);

		/// <summary>
		/// Gets the page by view model.
		/// </summary>
		/// <returns>The page by view model.</returns>
		/// <param name="viewModelInstance">View model instance.</param>
		/// <typeparam name="TViewModel">View model type.</typeparam>
		IBasePage<INotifyPropertyChanged> GetPageByViewModel<TViewModel>(TViewModel viewModelInstance) where TViewModel : class, INotifyPropertyChanged;

		/// <summary>
		/// Replaces the cached page view model.
		/// </summary>
		/// <returns><c>true</c>, if cached page view model was replaced, <c>false</c> otherwise (eg. if page type doesn't exist in cache).</returns>
		/// <param name="newViewModel">New view model.</param>
		/// <typeparam name="TViewModel">View model type.</typeparam>
		bool ReplaceCachedPageViewModel<TViewModel>(TViewModel newViewModel) where TViewModel : class, INotifyPropertyChanged;

		/// <summary>
		/// Resets the cached page view model.
		/// </summary>
		/// <returns><c>true</c>, if cached page view model was reset, <c>false</c> otherwise (eg. if page type doesn't exist in cache).</returns>
		/// <typeparam name="TViewModel">View model type.</typeparam>
		bool ResetCachedPageViewModel<TViewModel>() where TViewModel : class, INotifyPropertyChanged;

		/// <summary>
		/// Removes the page from cache.
		/// </summary>
		/// <returns><c>true</c>, if page was removed from cache, <c>false</c> otherwise (eg. if page type doesn't exist in cache).</returns>
		/// <param name="viewModelType">View model type.</param>
		bool RemovePageFromCache(Type viewModelType);

		/// <summary>
		/// Removes the page from cache.
		/// </summary>
		/// <returns><c>true</c>, if page was removed from cache, <c>false</c> otherwise (eg. if page type doesn't exist in cache).</returns>
		/// <typeparam name="TViewModel">View model type.</typeparam>
		bool RemovePageFromCache<TViewModel>() where TViewModel : class, INotifyPropertyChanged;

		/// <summary>
		/// Clears the cache.
		/// </summary>
		void ClearCache();

		/// <summary>
		/// Pushes the page into navigation stack.
		/// </summary>
		/// <returns><c>true</c>, if page was pushed, push was not interrupted, <c>false</c> otherwise (eg. PageFactoryPushing returned <c>false</c>)</returns>
		/// <param name="page">Page to push.</param>
		/// <param name="animated">If set to <c>true</c> animation enabled.</param>
		Task<bool> PushPageAsync(IBasePage<INotifyPropertyChanged> page, bool animated = true);

		/// <summary>
		/// Pushes the page as modal.
		/// </summary>
		/// <returns><c>true</c>, if page was pushed, push was not interrupted, <c>false</c> otherwise (eg. PageFactoryPushing returned <c>false</c>)</returns>
		/// <param name="page">Page to push.</param>
		/// <param name="animated">If set to <c>true</c> animation enabled.</param>
		Task<bool> PushModalPageAsync(IBasePage<INotifyPropertyChanged> page, bool animated = true);

		/// <summary>
		/// Pushes the cached page into navigation stack. Creates a new page instances if not exists.
		/// </summary>
		/// <returns><c>true</c>, if page was pushed, push was not interrupted, <c>false</c> otherwise (eg. PageFactoryPushing returned <c>false</c>)</returns>
		/// <param name="resetViewModel">If set to <c>true</c> resets page view model.</param>
		/// <param name="animated">If set to <c>true</c> animation enabled.</param>
		/// <typeparam name="TViewModel">View model type.</typeparam>
		Task<bool> PushPageFromCacheAsync<TViewModel>(bool resetViewModel = false, bool animated = true) where TViewModel : class, INotifyPropertyChanged;

		/// <summary>
		/// Pushes the cached page into navigation stack and replaces view model. Creates a new page instances if not exists.
		/// </summary>
		/// <returns><c>true</c>, if page was pushed, push was not interrupted, <c>false</c> otherwise (eg. PageFactoryPushing returned <c>false</c>)</returns>
		/// <param name="replaceViewModel">View model to replace existing one.</param>
		/// <param name="animated">If set to <c>true</c> animation enabled.</param>
		/// <typeparam name="TViewModel">View model type.</typeparam>
		Task<bool> PushPageFromCacheAsync<TViewModel>(TViewModel replaceViewModel, bool animated = true) where TViewModel : class, INotifyPropertyChanged;

		/// <summary>
		/// Pushes the cached page as modal. Creates a new page instances if not exists.
		/// </summary>
		/// <returns><c>true</c>, if page was pushed, push was not interrupted, <c>false</c> otherwise (eg. PageFactoryPushing returned <c>false</c>)</returns>
		/// <param name="resetViewModel">If set to <c>true</c> resets view model.</param>
		/// <param name="animated">If set to <c>true</c> animation enabled.</param>
		/// <typeparam name="TViewModel">View model type.</typeparam>
		Task<bool> PushModalPageFromCacheAsync<TViewModel>(bool resetViewModel = false, bool animated = true) where TViewModel : class, INotifyPropertyChanged;

		/// <summary>
		/// Pushes the cached page as modal. Creates a new page instances if not exists.
		/// </summary>
		/// <returns><c>true</c>, if page was pushed, push was not interrupted, <c>false</c> otherwise (eg. PageFactoryPushing returned <c>false</c>)</returns>
		/// <param name="replaceViewModel">Replaces view model.</param>
		/// <param name="animated">If set to <c>true</c> animation enabled.</param>
		/// <typeparam name="TViewModel">View model type.</typeparam>
		Task<bool> PushModalPageFromCacheAsync<TViewModel>(TViewModel replaceViewModel, bool animated = true) where TViewModel : class, INotifyPropertyChanged;

		/// <summary>
		/// Pushes a new page instance into navigation stack and replaces view model.
		/// </summary>
		/// <returns><c>true</c>, if page was pushed, push was not interrupted, <c>false</c> otherwise (eg. PageFactoryPushing returned <c>false</c>)</returns>
		/// <param name="replaceViewModel">View model to replace existing one.</param>
		/// <param name="saveOrReplaceInCache">If set to <c>true</c> will save page to cache or replace existing one in cache.</param>
		/// <param name="animated">If set to <c>true</c> animation enabled.</param>
		/// <typeparam name="TViewModel">View model type.</typeparam>
		Task<bool> PushPageAsNewAsync<TViewModel>(TViewModel replaceViewModel, bool saveOrReplaceInCache = false, bool animated = true) where TViewModel : class, INotifyPropertyChanged;

		/// <summary>
		/// Pushes a new page instance into navigation stack.
		/// </summary>
		/// <returns><c>true</c>, if page was pushed, push was not interrupted, <c>false</c> otherwise (eg. PageFactoryPushing returned <c>false</c>)</returns>
		/// <param name="saveOrReplaceInCache">If set to <c>true</c> will save page to cache or replace existing one in cache.</param>
		/// <param name="animated">If set to <c>true</c> animation enabled.</param>
		/// <typeparam name="TViewModel">View model type.</typeparam>
		Task<bool> PushPageAsNewAsync<TViewModel>(bool saveOrReplaceInCache = false, bool animated = true) where TViewModel : class, INotifyPropertyChanged;

		/// <summary>
		/// Pushes a new page instance as modal.
		/// </summary>
		/// <returns><c>true</c>, if page was pushed, push was not interrupted, <c>false</c> otherwise (eg. PageFactoryPushing returned <c>false</c>)</returns>
		/// <param name="replaceViewModel">View model to replace existing one.</param>
		/// <param name="saveOrReplaceInCache">If set to <c>true</c> will save page to cache or replace existing one in cache.</param>
		/// <param name="animated">If set to <c>true</c> animation enabled.</param>
		/// <typeparam name="TViewModel">View model type.</typeparam>
		Task<bool> PushModalPageAsNewAsync<TViewModel>(TViewModel replaceViewModel, bool saveOrReplaceInCache = false, bool animated = true) where TViewModel : class, INotifyPropertyChanged;

		/// <summary>
		/// Pushes a new page instance as modal.
		/// </summary>
		/// <returns><c>true</c>, if page was pushed, push was not interrupted, <c>false</c> otherwise (eg. PageFactoryPushing returned <c>false</c>)</returns>
		/// <param name="saveOrReplaceInCache">If set to <c>true</c> will save page to cache or replace existing one in cache.</param>
		/// <param name="animated">If set to <c>true</c> animation enabled.</param>
		/// <typeparam name="TViewModel">View model type.</typeparam>
		Task<bool> PushModalPageAsNewAsync<TViewModel>(bool saveOrReplaceInCache = false, bool animated = true) where TViewModel : class, INotifyPropertyChanged;

		/// <summary>
		/// Inserts the page before another page into navigation stack.
		/// </summary>
		/// <returns><c>true</c>, if page was insert was not interrupted, <c>false</c> otherwise (eg. PageFactoryInserting returned <c>false</c>)</returns>
		/// <param name="page">Page to insert</param>
		/// <param name="before">Before page</param>
		bool InsertPageBefore(IBasePage<INotifyPropertyChanged> page, IBasePage<INotifyPropertyChanged> before);

		/// <summary>
		/// Inserts the cached page before another page into navigation stack. Creates a new page instances if not exists.
		/// </summary>
		/// <returns><c>true</c>, if page insert was not interrupted, <c>false</c> otherwise (eg. PageFactoryInserting returned <c>false</c>)</returns>
		/// <param name="resetViewModel">If set to <c>true</c> resets the view model.</param>
		/// <typeparam name="TViewModel">Type of page to insert.</typeparam>
		/// <typeparam name="TBeforeViewModel">Type of before page.</typeparam>
		bool InsertPageBeforeFromCache<TViewModel, TBeforeViewModel>(bool resetViewModel = false) where TViewModel : class, INotifyPropertyChanged where TBeforeViewModel : class, INotifyPropertyChanged;

		/// <summary>
		/// Inserts the cached page before another page into navigation stack and replaces the view model. Creates a new page instances if not exists.
		/// </summary>
		/// <returns><c>true</c>, if page insert was not interrupted, <c>false</c> otherwise (eg. PageFactoryInserting returned <c>false</c>)</returns>
		/// <param name="replaceViewModel">View model to replace existing one.</param>
		/// <typeparam name="TViewModel">Type of page to insert.</typeparam>
		/// <typeparam name="TBeforeViewModel">Type of before page.</typeparam>
		bool InsertPageBeforeFromCache<TViewModel, TBeforeViewModel>(TViewModel replaceViewModel) where TViewModel : class, INotifyPropertyChanged where TBeforeViewModel : class, INotifyPropertyChanged;

		/// <summary>
		/// Inserts the page before another page into navigation stack as new instance.
		/// </summary>
		/// <returns><c>true</c>, if page insert was not interrupted, <c>false</c> otherwise (eg. PageFactoryInserting returned <c>false</c>)</returns>
		/// <param name="saveOrReplaceInCache">If set to <c>true</c> will save page to cache or replace existing one in cache.</param>
		/// <typeparam name="TViewModel">Type of page to insert.</typeparam>
		/// <typeparam name="TBeforeViewModel">Type of before page.</typeparam>
		bool InsertPageBeforeAsNew<TViewModel, TBeforeViewModel>(bool saveOrReplaceInCache = false) where TViewModel : class, INotifyPropertyChanged where TBeforeViewModel : class, INotifyPropertyChanged;

		/// <summary>
		/// Inserts the page before another page into navigation stack as new instance and replaces view model.
		/// </summary>
		/// <returns><c>true</c>, if page insert was not interrupted, <c>false</c> otherwise (eg. PageFactoryInserting returned <c>false</c>)</returns>
		/// <param name="replaceViewModel">View model to replace existing one.</param>
		/// <param name="saveOrReplaceInCache">If set to <c>true</c> will save page to cache or replace existing one in cache.</param>
		/// <typeparam name="TViewModel">Type of page to insert.</typeparam>
		/// <typeparam name="TBeforeViewModel">Type of before page.</typeparam>
		bool InsertPageBeforeAsNew<TViewModel, TBeforeViewModel>(TViewModel replaceViewModel, bool saveOrReplaceInCache = false) where TViewModel : class, INotifyPropertyChanged where TBeforeViewModel : class, INotifyPropertyChanged;

		/// <summary>
		/// Pops the page from navigation stack.
		/// </summary>
		/// <returns><c>true</c>, if page was pop was not interrupted, <c>false</c> otherwise (eg. PageFactoryPopping returned <c>false</c>)</returns>
		/// <param name="resetViewModel">If set to <c>true</c> resets the view model.</param>
		/// <param name="animated">If set to <c>true</c> animation enabled.</param>
		Task<bool> PopPageAsync(bool resetViewModel = false, bool animated = true);

		/// <summary>
		/// Pops the modal page.
		/// </summary>
		/// <returns><c>true</c>, if page pop was not interrupted, <c>false</c> otherwise (eg. PageFactoryPopping returned <c>false</c>)</returns>
		/// <param name="resetViewModel">If set to <c>true</c> resets the view model.</param>
		/// <param name="animated">If set to <c>true</c> animation enabled.</param>
		Task<bool> PopModalPageAsync(bool resetViewModel = false, bool animated = true);

		/// <summary>
		/// Removes the page from navigation stack.
		/// </summary>
		/// <returns><c>true</c>, if page remove was not interrupted, <c>false</c> otherwise (eg. PageFactoryRemoving returned <c>false</c>)</returns>
		/// <param name="pageToRemove">Page to remove.</param>
		bool RemovePage(IBasePage<INotifyPropertyChanged> pageToRemove);

		/// <summary>
		/// Removes the cached page from navigation stack.
		/// </summary>
		/// <returns><c>true</c>, if page remove was not interrupted, <c>false</c> otherwise (eg. PageFactoryRemoving returned <c>false</c>)</returns>
		/// <param name="removeFromCache">If set to <c>true</c> removes the page from cache.</param>
		/// <param name="resetViewModel">If set to <c>true</c> resets the view model.</param>
		/// <typeparam name="TViewModel">Cached view model type.</typeparam>
		bool RemoveCachedPage<TViewModel>(bool removeFromCache = false, bool resetViewModel = false) where TViewModel : class, INotifyPropertyChanged;

		/// <summary>
		/// Pops the pages to root.
		/// </summary>
		/// <param name="clearCache">If set to <c>true</c> clears cache.</param>
		/// <param name="animated">If set to <c>true</c> animation enabled.</param>
		Task PopPagesToRootAsync(bool clearCache = false, bool animated = true);

		/// <summary>
		/// Sets the new root and resets.
		/// </summary>
		/// <typeparam name="TViewModel">New root view model type.</typeparam>
		void SetNewRootAndReset<TViewModel>() where TViewModel : class, INotifyPropertyChanged;
	}
}
