using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using MM.ServerMonitoring.Consumer.Wpf.Interface;
using MM.ServerMonitoring.Consumer.Wpf.Interface.View;
using MM.ServerMonitoring.Consumer.Wpf.Shell.Views.Infrastructure.Crud.Commands;
using MM.ServerMonitoring.Consumer.Wpf.Shell.Views.Infrastructure.Crud.Events;
using MM.ServerMonitoring.Provider.WebApi.Dto.Model.Interfaces;
using Prism.Events;
using Prism.Mvvm;

namespace MM.ServerMonitoring.Consumer.Wpf.Shell.Views.Infrastructure.Crud.ViewModel;

public abstract class CrudViewModelBase<TDelete, TInsert, TUpdate, TLoad>
    : BindableBase, IViewModel
    where TDelete : IHasId
    where TInsert : IHasId
    where TUpdate : IHasId
    where TLoad : IHasId
{
    protected readonly DeleteFailedEvent<TDelete> deleteFailed;
    protected readonly DeleteSucceedEvent<TDelete> deleteSucceed;
    protected readonly IDispatcher dispatcher;
    protected readonly EditPageIsHiddenEvent<TUpdate> editPageIsHidden;
    protected readonly EditPageIsShowingEvent<TUpdate> editPageIsShowing;
    protected readonly FilterSuccessEventTDto<TLoad> filterSuccess;
    protected readonly HideEditPageEvent<TUpdate> hideEditPage;
    protected readonly HideInsertPageEvent<TInsert> hideInsertPage;

    protected readonly InsertFailedEvent<TInsert> insertFailed;
    protected readonly InsertPageIsHiddenEvent<TInsert> insertPageIsHidden;
    protected readonly InsertPageIsShowingEvent<TInsert> insertPageIsShowing;
    protected readonly InsertSucceedEvent<TInsert> insertSucceed;
    protected readonly DataLoadedFailedEvent<TLoad> loadFailed;
    protected readonly SingleDataLoadedFailedEvent<TLoad> loadSingleFailed;
    protected readonly SingleDataLoadedSucceedEvent<TLoad> loadSingleSucceed;
    protected readonly DataLoadedSucceedEvent<TLoad> loadSucceed;
    protected readonly SelectedItemChanged<TLoad> selectedItemChanged;

    protected readonly ShowEditPageEvent<TUpdate> showEditPage;
    protected readonly ShowInsertPageEvent<TInsert> showInsertPage;

    protected readonly UpdateFailedEvent<TUpdate> updateFailed;
    protected readonly UpdateSucceedEvent<TUpdate> updateSucceed;
    protected IView displayPage;
    protected GridLength editWidth;

    protected ObservableCollection<TLoad> items;
    protected TLoad selectedItem;
    protected ICommand toggleEditPageCommand;
    protected ICommand toggleInsertPageCommand;

    protected CrudViewModelBase()
    {
        if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
        {
        }
        else
        {
            throw new Exception("only design time");
        }
    }

    protected CrudViewModelBase(
        IEventAggregator eventAggregator,
        IDispatcher dispatcher,
        CrudCommandFactoryBase commandFactory)
    {
        _ = eventAggregator ?? throw new ArgumentNullException(nameof(eventAggregator));
        _ = dispatcher ?? throw new ArgumentNullException(nameof(dispatcher));
        _ = commandFactory ?? throw new ArgumentNullException(nameof(commandFactory));

        this.dispatcher = dispatcher;

        this.deleteFailed = eventAggregator.GetEvent<DeleteFailedEvent<TDelete>>();
        this.deleteSucceed = eventAggregator.GetEvent<DeleteSucceedEvent<TDelete>>();
        this.insertFailed = eventAggregator.GetEvent<InsertFailedEvent<TInsert>>();
        this.insertSucceed = eventAggregator.GetEvent<InsertSucceedEvent<TInsert>>();
        this.updateFailed = eventAggregator.GetEvent<UpdateFailedEvent<TUpdate>>();
        this.updateSucceed = eventAggregator.GetEvent<UpdateSucceedEvent<TUpdate>>();

        this.loadFailed = eventAggregator.GetEvent<DataLoadedFailedEvent<TLoad>>();
        this.loadSucceed = eventAggregator.GetEvent<DataLoadedSucceedEvent<TLoad>>();

        this.loadSingleFailed = eventAggregator.GetEvent<SingleDataLoadedFailedEvent<TLoad>>();
        this.loadSingleSucceed = eventAggregator.GetEvent<SingleDataLoadedSucceedEvent<TLoad>>();

        this.showInsertPage = eventAggregator.GetEvent<ShowInsertPageEvent<TInsert>>();
        this.hideInsertPage = eventAggregator.GetEvent<HideInsertPageEvent<TInsert>>();

        this.showEditPage = eventAggregator.GetEvent<ShowEditPageEvent<TUpdate>>();
        this.hideEditPage = eventAggregator.GetEvent<HideEditPageEvent<TUpdate>>();

        this.insertPageIsShowing = eventAggregator.GetEvent<InsertPageIsShowingEvent<TInsert>>();
        this.editPageIsShowing = eventAggregator.GetEvent<EditPageIsShowingEvent<TUpdate>>();

        this.insertPageIsHidden = eventAggregator.GetEvent<InsertPageIsHiddenEvent<TInsert>>();
        this.editPageIsHidden = eventAggregator.GetEvent<EditPageIsHiddenEvent<TUpdate>>();

        this.filterSuccess = eventAggregator.GetEvent<FilterSuccessEventTDto<TLoad>>();
        this.selectedItemChanged = eventAggregator.GetEvent<SelectedItemChanged<TLoad>>();

        //todo durchgehende verwendung von view/page create/insert/neu etc
        this.WireEvents();

        LoadCommand = commandFactory.LoadCommand;
        LoadSingleCommand = commandFactory.LoadSingleCommand;
        DeleteCommand = commandFactory.DeleteCommand;


        ShowInsertPageCommand = commandFactory.ShowInsertPageCommand;
        HideInsertPageCommand = commandFactory.HideInsertPageCommand;
        ToggleInsertPageCommand = ShowInsertPageCommand;

        ShowEditPageCommand = commandFactory.ShowEditPageCommand;
        HideEditPageCommand = commandFactory.HideEditPageCommand;
        ToggleEditPageCommand = ShowEditPageCommand;

        FilterCommand = commandFactory.FilterCommand;
    }

    public ObservableCollection<TLoad> Items
    {
        get => this.items;
        set => this.SetProperty(ref this.items, value);
    }

    public ICommand ToggleInsertPageCommand
    {
        get => this.toggleInsertPageCommand;
        set => this.SetProperty(ref this.toggleInsertPageCommand, value);
    }

    public ICommand ToggleEditPageCommand
    {
        get => this.toggleEditPageCommand;
        set => this.SetProperty(ref this.toggleEditPageCommand, value);
    }

    public ICommand LoadCommand { get; }
    public ICommand LoadSingleCommand { get; }
    public ICommand DeleteCommand { get; }
    public ICommand ShowInsertPageCommand { get; }
    public ICommand ShowEditPageCommand { get; }
    public ICommand HideInsertPageCommand { get; }
    public ICommand HideEditPageCommand { get; }
    public ICommand FilterCommand { get; }

    public TLoad SelectedItem
    {
        get => this.selectedItem;
        set
        {
            this.SetProperty(ref this.selectedItem, value);
            this.selectedItemChanged.Publish(value);
        }
    }

    public IView DisplayPage
    {
        get => this.displayPage;
        set => this.SetProperty(ref this.displayPage, value);
    }

    public GridLength EditWidth
    {
        get => this.editWidth;
        set => this.SetProperty(ref this.editWidth, value);
    }

    public virtual void ViewReady()
    {
        //Task.Run(() => LoadCommand.Execute(null));
    }

    private void WireEvents()
    {
        this.deleteFailed.Subscribe(this.DeleteFailed);
        this.deleteSucceed.Subscribe(this.DeleteSucceed);

        this.insertFailed.Subscribe(this.InsertFailed);
        this.insertSucceed.Subscribe(this.InsertSucceed);

        this.updateFailed.Subscribe(this.UpdateFailed);
        this.updateSucceed.Subscribe(this.UpdateSucceed);

        this.loadFailed.Subscribe(this.DataLoadFailed);
        this.loadSucceed.Subscribe(this.DataLoadSucceed);

        this.loadSingleFailed.Subscribe(this.DataSingleLoadFailed);
        this.loadSingleSucceed.Subscribe(this.DataSingleLoadSucceed);


        this.showInsertPage.Subscribe(this.ShowInsertPage);
        this.hideInsertPage.Subscribe(this.HideInsertPage);

        this.showEditPage.Subscribe(this.ShowEditPage);
        this.hideEditPage.Subscribe(this.HideEditPage);

        this.filterSuccess.Subscribe(this.FilterSuccess);
    }

    private void FilterSuccess(IEnumerable<TLoad> obj)
    {
        SelectedItem = default;
        Items = new ObservableCollection<TLoad>(obj);
    }

    protected virtual void DataSingleLoadSucceed(TLoad obj)
    {
        this.dispatcher.Invoke(() =>
        {
            if (this.items.Any(item => item.Id == obj.Id))
            {
                var updated = this.items.First(item => item.Id == obj.Id);
                this.items[this.items.IndexOf(updated)] = obj;
                return;
            }

            this.items.Add(obj);
        });
    }

    protected virtual void DataSingleLoadFailed()
    {
        //todo show generic sorry page
    }

    protected virtual void ShowEditPage(IEditView<TUpdate> view)
    {
        EditWidth = new GridLength(50, GridUnitType.Star);
        DisplayPage = view;
        ToggleEditPageCommand = HideEditPageCommand;
        this.editPageIsShowing.Publish();
    }

    protected virtual void ShowInsertPage(IInsertView<TInsert> view)
    {
        EditWidth = new GridLength(50, GridUnitType.Star);
        DisplayPage = view;
        ToggleInsertPageCommand = HideInsertPageCommand;
        this.insertPageIsShowing.Publish();
    }

    protected virtual void HideEditPage()
    {
        EditWidth = new GridLength(0);
        ToggleEditPageCommand = ShowEditPageCommand;
        this.editPageIsHidden.Publish();
    }

    protected virtual void HideInsertPage()
    {
        EditWidth = new GridLength(0);
        ToggleInsertPageCommand = ShowInsertPageCommand;
        this.insertPageIsHidden.Publish();
    }

    protected virtual void DataLoadSucceed(IEnumerable<TLoad> obj)
    {
        Items = new ObservableCollection<TLoad>(obj);
    }

    protected virtual void DataLoadFailed()
    {
        //disable all edit controls?
        //todo show generic sorry page
    }

    protected virtual void UpdateSucceed(TUpdate obj)
    {
        LoadSingleCommand.Execute(obj.Id);
    }

    protected virtual void UpdateFailed(TUpdate obj)
    {
        //todo show generic sorry page
    }

    protected virtual void InsertSucceed(TInsert obj)
    {
        LoadSingleCommand.Execute(obj.Id);
    }

    protected virtual void InsertFailed(TInsert obj)
    {
        //todo show generic sorry page
    }

    protected virtual void DeleteSucceed(TDelete deleted)
    {
        this.dispatcher.Invoke(() => { this.items.Remove(this.items.First(item => item.Id == deleted.Id)); });
    }

    protected virtual void DeleteFailed(TDelete obj)
    {
        //todo show generic sorry page
    }
}