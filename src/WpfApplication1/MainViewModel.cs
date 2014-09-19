using System;

namespace WpfApplication1
{
    public class MainViewModel : ViewModelBase
    {
        public DelegateCommand<object> GoCommand { get; private set; }

        private string _address;
        public string Address
        {
            get { return _address; }
            set
            {
                if (OnPropertyChanged(ref _address, value))
                    EditableAddress = value;
            }
        }

        private string _editAddress;
        public string EditableAddress
        {
            get { return _editAddress; }
            set
            {
                if (OnPropertyChanged(ref _editAddress, value))
                    GoCommand.OnCanExecuteChanged();
            }
        }

        public MainViewModel()
        {
            GoCommand = new DelegateCommand<object>(
               _ => Address = EditableAddress,
               _ =>
               {
                   Uri uri;
                   var goodUri = Uri.TryCreate(EditableAddress, UriKind.Absolute, out uri);
                   return goodUri;
               });

            Address = "about:credits";
        }
    }
}