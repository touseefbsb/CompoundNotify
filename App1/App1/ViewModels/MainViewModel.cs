using System.ComponentModel;

namespace App1.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _locationName;
        private string _subLocationName;
        private string _locationCompleteString;

        public MainViewModel() => PropertyChanged += MyClass_PropertyChanged;

        private void MyClass_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(LocationName) || e.PropertyName == nameof(SubLocationName))
            {
                RaisePropertyChanged(LocationCompleteString);
            }
        }

        public string LocationCompleteString
        {
            get
            {
                return $"{LocationName}/{SubLocationName}";
            }

            set
            {
                _locationCompleteString = value;
                RaisePropertyChanged(nameof(LocationCompleteString));
            }
        }
        public string LocationName
        {
            get => _locationName;
            set
            {
                if (_locationName != value)
                {
                    _locationName = value;
                    RaisePropertyChanged(nameof(LocationName));
                }
            }
        }

        public string SubLocationName
        {
            get => _subLocationName;
            set
            {
                if (_subLocationName != value)
                {
                    _subLocationName = value;
                    RaisePropertyChanged(nameof(SubLocationName));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void RaisePropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}
