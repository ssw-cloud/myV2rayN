namespace v2rayN.Views;

public partial class CheckUpdateView
{
    public CheckUpdateView(bool coreOnlyMode = false)
    {
        InitializeComponent();

        ViewModel = new CheckUpdateViewModel(UpdateViewHandler, coreOnlyMode);

        this.WhenActivated(disposables =>
        {
            this.OneWayBind(ViewModel, vm => vm.CheckUpdateModels, v => v.lstCheckUpdates.ItemsSource).DisposeWith(disposables);

            this.Bind(ViewModel, vm => vm.EnableCheckPreReleaseUpdate, v => v.togEnableCheckPreReleaseUpdate.IsChecked).DisposeWith(disposables);
            this.BindCommand(ViewModel, vm => vm.CheckUpdateCmd, v => v.btnCheckUpdate).DisposeWith(disposables);
            this.OneWayBind(ViewModel, vm => vm.ActionText, v => v.btnCheckUpdate.Content).DisposeWith(disposables);
        });
    }

    private async Task<bool> UpdateViewHandler(EViewAction action, object? obj)
    {
        return await Task.FromResult(true);
    }
}
