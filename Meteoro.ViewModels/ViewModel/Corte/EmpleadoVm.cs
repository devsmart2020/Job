using Meteoro.Corte.Entities.Entities;
using Meteoro.Corte.Entities.Helpers;
using Meteoro.Services.Corte.Data;
using Meteoro.Services.Corte.Services;
using Meteoro.ViewModels.BaseViewModel;
using Meteoro.ViewModels.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Meteoro.ViewModels.ViewModel.Corte
{
    public class EmpleadoVm : BaseViewModel.BaseViewModel, INotifyPropertyChanged
    {
        #region Members Variables
        private EmpleadoSvc _service;
        private TbEmpleado _tblempleado;
        private AreaVm _areaVm;
        private SemanaVm _semanaVm;
        #endregion

        #region Constructor
        public EmpleadoVm()
        {
            _service = new EmpleadoSvc();
            _areaVm = new AreaVm();
            _semanaVm = new SemanaVm();
            LoginCommand = new BaseViewModel.Command(LoginExecute, CanExecuteMethod);          
            LoginAppCommand = new BaseViewModel.Command(LoginAppExecute, CanExecuteMethod);
            CrearEmpleadoCommand = new BaseViewModel.Command(CrearEmpleadoExecute, CanExecuteMethod);
            LimpiarCommand = new BaseViewModel.Command(LimpiarExecute, CanExecuteMethod);
            ActualizarEmpleadoCommand = new BaseViewModel.Command(ActualizarEmpleadoexecute, CanExecuteMethod);
            ListarEmpleadoCommand = new BaseViewModel.Command(ListarEmpleadoExecute, CanExecuteMethod);
            Task.Run(async () =>
            {
                AreasList = await _areaVm.ListarAreasCmd();
            });

            Task.Run(async () =>
            {
              
                await ListarEmpleado();
            });           
        }

        #endregion

        #region Private Methods
        private bool CanExecuteMethod(object parameter)
        {
            return true;
        }
        private async void LoginExecute(object parameter)
        {
            await Login();
        }
        private async void LoginAppExecute(object parameter)
        {
            await LoginApp();
        }
        private async void CrearEmpleadoExecute(object parameter)
        {
            await CrearEmpleado();
        }
        private void LimpiarExecute(object parameter)
        {
            Limpiar();
        }
        private async void ActualizarEmpleadoexecute(object parameter)
        {
            await ActualizarEmpleado();
        }
        private async void ListarEmpleadoExecute(object parameter)
        {
            await ListarEmpleado();
        }
        public void BuscarEmpleado(string text)
        {            
            if (!string.IsNullOrEmpty(text))
            {
                EmpleadosEntity = EmpleadosList
                    .Where(x => x.Nombre.Contains(text) || x.Documento.Contains(text) || x.Codigo.Contains(text))
                    .FirstOrDefault();
            }
            else
            {
                LimpiarCommand.Execute(null);
            }
        }

        private protected async Task Login()
        {
            IsBusy = true;
            try
            {
              
                _tblempleado = new TbEmpleado()
                {
                    Codigo = Codigo,
                    Pass = Pass,                    
                };

                if (_tblempleado != null)
                {
                    UserLogued = await _service.Login(_tblempleado);
                    if (UserLogued.Nombre != null)
                    {
                        IsBusy = false;
                        IsLogued = true;
                        UsuarioConectado.Codigo = UserLogued.Codigo;
                        UsuarioConectado.DocId = UserLogued.DocId;
                        UsuarioConectado.Nombre = UserLogued.Nombre;
                        UsuarioConectado.Periodo = UserLogued.Periodo;
                        UsuarioConectado.Area = UserLogued.Area;                       
                        Msj = $"Bienvenido /a {UsuarioConectado.Nombre}";
                    }
                    else
                    {
                        IsBusy = false;
                        IsLogued = false;
                        NotIsLogued = true;
                        Msj = ResourceVm.MsjErrorLogin;

                    }
                }
                else
                {
                    IsBusy = false;
                    NotIsLogued = true;
                    Msj = ResourceVm.MsjErrorEntidadVacia;
                }

            }
            catch (Exception ex)
            {
                IsBusy = false;
                NotIsLogued = true;
                Msj = ex.Message.ToString();
            }
        }
        private protected async Task LoginApp()
        {
            IsBusy = true;
            try
            {
                _tblempleado = new TbEmpleado()
                {
                    Codigo = Codigo,
                    Pass = PassApp
                };

                if (_tblempleado != null)
                {
                    UserLogued = await _service.Login(_tblempleado);
                    if (UserLogued.Nombre != null)
                    {                        
                        UsuarioConectado.Codigo = UserLogued.Codigo;
                        UsuarioConectado.DocId = UserLogued.DocId;
                        UsuarioConectado.Nombre = UserLogued.Nombre;
                        UsuarioConectado.Periodo = UserLogued.Periodo;
                        UsuarioConectado.Area = UserLogued.Area;
                        Msj = $"Bienvenido /a {UsuarioConectado.Nombre}";
                        await _semanaVm.GetSemanaCmd();
                        IsLogued = true;                          
                        IsBusy = false;
                    }
                    else
                    {
                        IsBusy = false;
                        IsLogued = false;
                        NotIsLogued = true;
                        Msj = ResourceVm.MsjErrorLogin;
                    }
                }
                else
                {
                    IsBusy = false;
                    NotIsLogued = true;
                    Msj = ResourceVm.MsjErrorEntidadVacia;
                }

            }
            catch (Exception ex)
            {
                IsBusy = false;
                NotIsLogued = true;
                Msj = ex.Message.ToString();
            }
        }

        private protected async Task CrearEmpleado()
        {
            IsBusy = true;
            try
            {
                _tblempleado = new TbEmpleado()
                {
                    Codigo = Codigo,
                    DocId = DocId,
                    Nombre = Nombre,
                    Pass = Pass,
                    Estado = Estado,
                    Periodo = Periodo,
                    Area = Area,
                    Empresa = "JS"
                };
                if (string.IsNullOrEmpty(_tblempleado.Codigo) || string.IsNullOrEmpty(_tblempleado.DocId) || string.IsNullOrEmpty(_tblempleado.Nombre))
                {

                    IsBusy = false;
                    NotSaved = true;
                    Msj = ResourceVm.MsjErrorEntidadVacia;
                }
                else
                {
                    if (IsSaved = await _service.Post(_tblempleado))
                    {
                        await ListarEmpleado();
                        IsBusy = false;
                        Msj = ResourceVm.MsjDatosGuardados;                       
                        Limpiar();
                    }
                    else
                    {
                        IsBusy = false;
                        NotSaved = true;
                        Msj = WebService<TbEmpleado>.ExceptionMsj;
                    }
                }
            }
            catch (Exception ex)
            {
                IsBusy = false;
                NotSaved = true;
                Msj = $"{ex}";
            }
        }
        private protected async Task ListarEmpleado()
        {
            IsBusy = true;
            try
            {
                EmpleadosList = await _service.Get();
                IsBusy = false;
                if (!EmpleadosList.Any())
                {
                    Msj = "No hay datos para mostrar";
                }
            }
            catch (Exception ex)
            {
                IsBusy = false;
                NotSaved = true;
                Msj = $"{ex}";
            }
        }      
        private protected async Task ObtenerDatosEmpleado()
        {
            IsBusy = true;
            try
            {
                if (EmpleadosEntity != null)
                {
                    TbEmpleado empleado = new TbEmpleado()
                    {
                        Codigo = EmpleadosEntity.Codigo,
                        DocId = EmpleadosEntity.Documento,
                    };
                    if (!string.IsNullOrEmpty(empleado.Codigo) || !string.IsNullOrEmpty(empleado.DocId))
                    {
                        Tblempleado = await _service.GetById(empleado);
                        Codigo = Tblempleado.Codigo;
                        DocId = Tblempleado.DocId;
                        Nombre = Tblempleado.Nombre;
                        Pass = Tblempleado.Pass;
                        Estado = Tblempleado.Estado;
                        Periodo = Tblempleado.Periodo;
                        Area = Area;
                        Empresa = Tblempleado.Empresa;
                        CodigoIsEnabled = false;
                        IsBusy = false;
                    }
                    else
                    {
                        CodigoIsEnabled = true;
                        IsBusy = false;
                        NotSaved = true;
                        Msj = "No se pueden enlazar los datos (Binding Vm)";
                    }
                }



            }
            catch (Exception ex)
            {
                IsBusy = false;
                NotSaved = true;
                Msj = $"{ex}";
            }
        }
        private protected async Task ActualizarEmpleado()
        {
            IsBusy = true;
            try
            {
                _tblempleado = new TbEmpleado()
                {
                    Codigo = Codigo,
                    DocId = DocId,
                    Nombre = Nombre,
                    Pass = Pass,
                    Estado = Estado,
                    Periodo = Periodo,
                    Area = Area,
                    Empresa = "JS"
                };
                if (string.IsNullOrEmpty(_tblempleado.Codigo) || string.IsNullOrEmpty(_tblempleado.DocId) || string.IsNullOrEmpty(_tblempleado.Nombre))
                {
                    IsBusy = false;
                    NotSaved = true;                    
                    Msj = ResourceVm.MsjErrorEntidadVacia;
                }
                else
                {
                    if (IsSaved = await _service.Put(_tblempleado))
                    {
                        await ListarEmpleado();
                        IsBusy = false;
                        IsUpdated = true;
                        Msj = ResourceVm.MsjDatosActualizados;
                        Limpiar();
                    }
                    else
                    {
                        IsBusy = false;
                        NotSaved = true;
                        Msj = WebService<TbEmpleado>.ExceptionMsj;
                    }
                }

            }
            catch (Exception ex)
            {
                IsBusy = false;
                NotSaved = true;
                Msj = $"{ex}";
            }
        }
        private void Limpiar()
        {
            Codigo = string.Empty;
            DocId = string.Empty;
            Nombre = string.Empty;
            Pass = string.Empty;
            Estado = false;
            Periodo = false;
            Area = default;
            SecurePassword = null;
            CodigoIsEnabled = true;
        }
        #endregion

        #region Properties
        private string codigo;

        public string Codigo
        {
            get
            {

                return codigo;
            }
            set
            {
                codigo = value;
                NotifyPropertyChanged();
            }
        }
        private string docId;

        public string DocId
        {
            get { return docId; }
            set
            {
                docId = value;
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
        private string pass;

        public string Pass
        {
            private get
            {
                return pass;
            }
            set
            {
                pass = value;
                NotifyPropertyChanged();

            }
        }

        private string passApp;

        public string PassApp
        {
            get { return passApp; }
            set { passApp = value;
                NotifyPropertyChanged();
            }
        }

        private bool estado;

        public bool Estado
        {
            get { return estado; }
            set
            {
                estado = value;
                NotifyPropertyChanged();

            }
        }
        private bool periodo;

        public bool Periodo
        {
            get { return periodo; }
            set
            {
                periodo = value;
                NotifyPropertyChanged();
            }
        }
        private int area;

        public int Area
        {
            get { return area; }
            set
            {
                area = value;
                NotifyPropertyChanged();

            }
        }
        private string empresa;


        public string Empresa
        {
            get { return empresa; }
            set
            {
                empresa = value;
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
        private TbEmpleado userLogued;

        public TbEmpleado UserLogued
        {
            get { return userLogued; }
            set
            {
                userLogued = value;
                NotifyPropertyChanged();
            }
        }
        private bool isLogued;

        public bool IsLogued
        {
            get { return isLogued; }
            set
            {
                isLogued = value;
                NotifyPropertyChanged();
            }
        }
        private bool notIsLogued;

        public bool NotIsLogued
        {
            get { return notIsLogued; }
            set
            {
                notIsLogued = value;
                NotifyPropertyChanged();
            }
        }
        private string buscar;

        public string Buscar
        {
            get 
            {                            
                return buscar; 
            }
            set
            {                
                buscar = value;
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

        private bool isUpdated;
        public bool IsUpdated
        {
            get 
            { 
                return isUpdated; 
            }
            set 
            {
                if (isUpdated != value)
                {
                    ListarEmpleado().ConfigureAwait(true);
                }
                isUpdated = value;
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
        private IEnumerable<EmpleadosListado> empleadosList;

        public IEnumerable<EmpleadosListado> EmpleadosList
        {
            get
            {            
                return empleadosList;
            }
            set
            {                
                empleadosList = value;
                NotifyPropertyChanged();
            }
        }

        private EmpleadosListado empleadosEntity;

        public EmpleadosListado EmpleadosEntity
        {
            get
            { return empleadosEntity; }
            set
            {
                Task.Run(async () =>
                {
                    await ObtenerDatosEmpleado();
                });
                empleadosEntity = value;                
                NotifyPropertyChanged();

            }
        }

        private TbEmpleado tblempleado;

        public TbEmpleado Tblempleado
        {
            get { return tblempleado; }
            set { tblempleado = value;
              
               

                NotifyPropertyChanged();
            }
        }
        private List<TbArea> areasList;

        public List<TbArea> AreasList
        {
            get
            {
                return areasList;
            }
            set
            {
                areasList = value;
                NotifyPropertyChanged();
            }
        }

        private bool codigoIsEnabled = true;

        public bool CodigoIsEnabled
        {
            get { return codigoIsEnabled; }
            set { codigoIsEnabled = value;
                NotifyPropertyChanged();

            }
        }

        private SecureString securePassword;
        public SecureString SecurePassword
        {
            get
            {
                return securePassword;
            }
            set
            {
                Pass = SecurityHelper.ToPlainString(SecurePassword);
                securePassword = value;
                NotifyPropertyChanged();
            }
        }


        #endregion

        #region Commands
        public ICommand LoginCommand { get; set; }     
        public ICommand LoginAppCommand { get; set; }
        public ICommand CrearEmpleadoCommand { get; set; }
        public ICommand ListarEmpleadoCommand { get; set; }
        public ICommand LimpiarCommand { get; set; }
        public ICommand ActualizarEmpleadoCommand { get; set; }
        #endregion


      


    }
}
