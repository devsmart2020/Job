using Meteoro.Corte.Entities.Entities;
using Meteoro.Services.Services;
using Meteoro.ViewModels.BaseViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
namespace Meteoro.ViewModels.ViewModel.Corte
{
    public class AreaVm : BaseViewModel.BaseViewModel, INotifyPropertyChanged
    {
        #region Members Variables
        private AreaSvc _service;
        #endregion

        #region Constructor
        public AreaVm()
        {
            _service = new AreaSvc();
            ListarAreaCommand = new Command(ListarAreasExecute, CanExecuteMethod);
        }
        #endregion

        #region Private Methods
        private bool CanExecuteMethod(object parameter)
        {
            return true;
        }
        private async void ListarAreasExecute(object parameter)
        {
            await ListarAreas();
        }

        private protected async Task ListarAreas()
        {
            IsBusy = true;
            try
            {
                AreasList = (List<TbArea>)await _service.Get();
            }
            catch (Exception ex)
            {
                IsBusy = false;
                NotSaved = true;
                Msj = $"{ex}";
            }
        }
        #endregion

        #region Properties
        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set
            {
                nombre = value;
                NotifyPropertyChanged();
            }
        }

        private List<TbArea> areasList;

        public List<TbArea> AreasList
        {
            get { return areasList; }
            set { areasList = value;
                NotifyPropertyChanged();
            }
        }

        private bool isBusy;

        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                NotifyPropertyChanged();

            }
        }

        private bool isSaved;

        public bool IsSaved
        {
            get { return isSaved; }
            set
            {
                isSaved = value;
                NotifyPropertyChanged();

            }
        }
        private bool notSaved;

        public bool NotSaved
        {
            get { return notSaved; }
            set
            {
                notSaved = value;
                NotifyPropertyChanged();

            }
        }
        private string msj;
        public string Msj
        {
            get { return msj; }
            set
            {
                msj = value;
                NotifyPropertyChanged();
            }
        }
        #endregion

        #region Commands
        public ICommand ListarAreaCommand { get; set; }
        #endregion

        #region Public Methods
        public async Task<List<TbArea>> ListarAreasCmd()
        {
            await ListarAreas();
            return AreasList;
        }
        #endregion

    }
}
