using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
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

        private ICommand removeItemsCommand;
        public ICommand RemoveItemsCommand
        {
            get
            {
                if (removeItemsCommand == null)
                    removeItemsCommand = new RelayCommand(OnRemoveItems, CanRemoveItems);
                return removeItemsCommand;
            }
        }

        private void OnAddItems(object obj)
        {
            var itemsToAdd = new[]
            {
                new Item { Id = "1", Text = "Pieterjan", Description = "Pieterjan" },
                new Item { Id = "1", Text = "Pieterjan", Description = "Pieterjan" },
                new Item { Id = "1", Text = "Pieterjan", Description = "Pieterjan" },
                new Item { Id = "1", Text = "Pieterjan", Description = "Pieterjan" }
            };
            //items.AddRange(itemsToAdd);
            new Thread(new ParameterizedThreadStart((param) =>
            {
                Items.AddRange((Item[])param);
            })).Start(itemsToAdd);
        }

        private bool CanAddItems(object arg)
        {
            return true;
        }

        private void OnRemoveItems(object obj)
        {
            var items = Items.Take(4).ToList();
            Items.RemoveRange(items);
        }

        private bool CanRemoveItems(object arg)
        {
            return true;
        }
    }
}
