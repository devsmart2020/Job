using Meteoro.Corte.Entities.Entities;
using Meteoro.Corte.Entities.Helpers;
using Meteoro.Services.Corte.Data;
using Meteoro.Services.Corte.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Meteoro.ViewModels.ViewModel.Corte
{
    public class AseguradorEmpleadoVm : BaseViewModel.BaseViewModel, INotifyPropertyChanged
    {
        #region Members Variables
        private readonly AseguradorEmpleadoSvc _service;
        private readonly CorteVm _corteVm;
        #endregion

        #region Constructor
        public AseguradorEmpleadoVm()
        {
            _service = new AseguradorEmpleadoSvc();
            _corteVm = new CorteVm();
            AsignarCosechadoresCommand = new BaseViewModel.Command(AsignarCosechadoresExecute, CanExecuteMethod);
            ListarCosechadoresAsignadosCommand = new BaseViewModel.Command(ListarCosechadoresAsignadosExecute, CanExecuteMethod);
            Task.Run(() =>
            {
                ListarCosechadoresAsignadosCommand.Execute(null);
            });

        }
        #endregion

        #region Private Methods
        private bool CanExecuteMethod(object parameter)
        {
            return true;
        }
        private async void AsignarCosechadoresExecute(object parameter)
        {
            await AsignarCosechadores();
        }
        private async void ListarCosechadoresAsignadosExecute(object parameter)
        {
            await ListarCosechadoresAsignados();
        }
        private async Task AsignarCosechadores()
        {
            IsBusy = true;            
            try
            {
                Revisiones = 3;
                if (Revisiones > 0)
                {
                    if (SetRevisiones = await _service.AsignarCosechadores(Revisiones))
                    {                        
                        await ListarCosechadoresAsignados();
                        await Task.Delay(500);
                        Msj = "Revisiones asignadas con éxito";
                        IsAsigned = true;
                        IsBusy = false;
                    }
                    else
                    {
                        IsBusy = false;
                        IsError = true;
                        Msj = WebService<TbAseguradorEmpleado>.ExceptionMsj;
                    }
                }
                else
                {
                    Msj = "Por favor asigne el número de revisiones";
                    IsBusy = false;                 
                    IsError = true;
                }
            }
            catch (Exception ex)
            {
                IsBusy = false;
                IsError = true;
                Msj = $"{ex}";
            }
        }
        private async Task ListarCosechadoresAsignados()
        {
            IsBusy = true;
            try
            {
                Tblaseguradorempleados = await _service.ListarCosechadoresAsignados(Tblaseguradorempleados);               
                if (Tblaseguradorempleados.Any())
                {
                    NumCosechadores = Tblaseguradorempleados.Where(x => x.Area.Equals(5)).Count();
                    NumAseguradores = Tblaseguradorempleados.GroupBy(x => x.Asegurador).Count();                    
                }
                IsBusy = false;
            }
            catch (Exception ex)
            {
                IsBusy = false;
                IsError = true;
                Msj = $"{ex}";
            }
        }
        private async void HandleSelected()
        {
            try
            {
                Empleado = SelectedEmpleadoAseg.GetType().GetProperty("Colaborador").GetValue(SelectedEmpleadoAseg, null).ToString();//Obtener Propiedades del objeto    
                Revisiones = Convert.ToInt32(SelectedEmpleadoAseg.GetType().GetProperty("Revisiones").GetValue(SelectedEmpleadoAseg, null));
                _corteVm.Revision = Revisiones;
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.ToString(), "Ok");
            }
        }

        #endregion

        #region Properties
        private string asegurador;

        public string Asegurador
        {
            get { return asegurador; }
            set
            {
                asegurador = value;
                NotifyPropertyChanged();
            }
        }
        private string empleado;

        public string Empleado
        {
            get { return empleado; }
            set
            {
                empleado = value;
                NotifyPropertyChanged();
            }
        }

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
        private DateTime fecha;

        public DateTime Fecha
        {
            get { return fecha; }
            set
            {
                fecha = value;
                NotifyPropertyChanged();
            }
        }
        private int revisiones;

        public int Revisiones
        {
            get { return revisiones; }
            set
            {
                revisiones = value;
                NotifyPropertyChanged();
            }
        }
        private bool sync;

        public bool Sync
        {
            get { return sync; }
            set
            {
                sync = value;
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

        private bool isAsigned;

        public bool IsAsigned
        {
            get { return isAsigned; }
            set
            {
                isAsigned = value;
                NotifyPropertyChanged();
            }
        }

        private bool isRefreshing;

        public bool IsRefreshing
        {
            get
            {
                Task.Run(async () =>
                {
                    await ListarCosechadoresAsignados();
                });
                return isRefreshing; 
            }
            set
            {
                isRefreshing = value;
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
        private bool isError;

        public bool IsError
        {
            get { return isError; }
            set
            {
                isError = value;
                NotifyPropertyChanged();
            }
        }
        private int numCosechadores;

        public int NumCosechadores
        {
            get { return numCosechadores; }
            set
            {
                numCosechadores = value;
                NotifyPropertyChanged();
            }
        }
        private int numAseguradores;

        public int NumAseguradores
        {
            get
            {
                return numAseguradores;
            }
            set
            {
                numAseguradores = value;
                NotifyPropertyChanged();
            }
        }

        private IEnumerable<AseguradorEmpleadoListado> tblaseguradorempleados;
        public IEnumerable<AseguradorEmpleadoListado> Tblaseguradorempleados
        {
            get
            {
                return tblaseguradorempleados;
            }
            set
            {
                tblaseguradorempleados = value;
                NotifyPropertyChanged();
            }
        }

        private bool setRevisiones;

        public bool SetRevisiones
        {
            get { return setRevisiones; }
            set
            {
                setRevisiones = value;
                NotifyPropertyChanged();
            }
        }

        private object selectedEmpleadoAseg;
        public object SelectedEmpleadoAseg
        {
            get { return selectedEmpleadoAseg; }
            set
            {
                if (selectedEmpleadoAseg != value)
                {
                    selectedEmpleadoAseg = value;
                    HandleSelected();
                    NotifyPropertyChanged();
                }
            }
        }
        #endregion

        #region Commands
        public ICommand AsignarCosechadoresCommand { get; set; }
        public ICommand ListarCosechadoresAsignadosCommand { get; set; }
        #endregion
    }
}
