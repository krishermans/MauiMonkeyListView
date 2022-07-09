using MauiMonkeyListView.Model;
using MauiMonkeyListView.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MauiMonkeyListView.ViewModel
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Monkey> _monkeys;
        private MonkeyService _monkeyService;

        public MainPageViewModel()
        {
            _monkeys = new ObservableCollection<Monkey>();
            _monkeyService = new MonkeyService();
        }

        public ObservableCollection<Monkey> Monkeys
        {
            get
            {
                return _monkeys;
            }
            set
            {
                _monkeys = value;
                RaisePropertyChanged(nameof(Monkeys));
            }
        }

        public async void OnAppearing()
        {
            var monkeyList = await _monkeyService.GetMonkeys();
            Monkeys = new ObservableCollection<Monkey>(monkeyList);
        }

        private void RaisePropertyChanged(string propertyname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
