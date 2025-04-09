
using System.Collections.ObjectModel;

namespace UnoAndroidListViewScrollExample.Presentation;

public partial class MainViewModel : ObservableObject
{
    private INavigator _navigator;

    [ObservableProperty]
    private string? name;

    [ObservableProperty]
    private string? _itemCount;

    [ObservableProperty]
    private string? _currentItemCount = "0";

    [ObservableProperty]
    private ObservableCollection<string> _items = [];

    public MainViewModel(
        IStringLocalizer localizer,
        IOptions<AppConfig> appInfo,
        INavigator navigator)
    {
        _navigator = navigator;
        Title = "Main";
        Title += $" - {localizer["ApplicationName"]}";
        Title += $" - {appInfo?.Value?.Environment}";
        UpdateItemsCommand = new RelayCommand(UpdateItems);
    }

    public string? Title { get; }

    public ICommand UpdateItemsCommand { get; }

    private void UpdateItems()
    {
        Items.Clear();
        if (int.TryParse(ItemCount, out int count))
        {
            for (int i = 0; i < count; i++)
            {
                Items.Add($"Item {i}");
            }
        }
        CurrentItemCount = ItemCount;
        ItemCount = string.Empty;
    }
}
