using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;

namespace WpfApp2
{
    public class MainVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }


        private MintPlayer.ObservableCollection.ObservableCollection<Item> items = new MintPlayer.ObservableCollection.ObservableCollection<Item>();
        public MintPlayer.ObservableCollection.ObservableCollection<Item> Items
        {
            get { return items; }
            set
            {
                items = value;
                OnPropertyChanged();
            }
        }

        private ICommand addItemsCommand;
        public ICommand AddItemsCommand
        {
            get
            {
                if (addItemsCommand == null)
                    addItemsCommand = new RelayCommand(OnAddItems, CanAddItems);
                return addItemsCommand;
            }
        }

        private void OnAddItems(object obj)
        {
            Items.AddRange(new[]
            {
                new Item { Id = "1", Text = "Pieterjan", Description = "Pieterjan" },
                new Item { Id = "1", Text = "Pieterjan", Description = "Pieterjan" },
                new Item { Id = "1", Text = "Pieterjan", Description = "Pieterjan" },
                new Item { Id = "1", Text = "Pieterjan", Description = "Pieterjan" }
            });
        }

        private bool CanAddItems(object arg)
        {
            return true;
        }
    }
}
