﻿using Meteoro.Entities.Entities;
using Meteoro.Entities.Helpers;
using Meteoro.Services.Data;
using Meteoro.Services.Services;
using Meteoro.ViewModels.BaseViewModel;
using Meteoro.ViewModels.Helpers;
using System;
using System.ComponentModel;
using System.Security;
using System.Threading.Tasks;
using System.Windows.Input;


namespace Meteoro.ViewModels.ViewModel
{
    public class EmpleadoVm : BaseViewModel.BaseViewModel, INotifyPropertyChanged
    {
        #region Members Variables
        private  EmpleadoSvc _service;
        private Tblempleado _tblempleado;
        #endregion

        #region Constructor
        public EmpleadoVm()
        {
            _service = new EmpleadoSvc();
            LoginCommand = new Command(LoginExecute, CanExecuteMethod);
            CrearEmpleadoCommand = new Command(CrearEmpleadoExecute, CanExecuteMethod);
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
        private async void CrearEmpleadoExecute(object parameter)
        {
            await CrearEmpleado();
        }

        private protected async Task Login()
        {
            IsBusy = true;            
            try
            {
                _tblempleado = new Tblempleado()
                {
                    Codigo = Codigo,
                    Pass = Pass
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
                        Msj = $"Error de usuario y/o contraseña, por favor verifique";

                    }
                }
                else
                {
                    IsBusy = false;
                    NotIsLogued = true;
                    Msj = "Error, entidad vacía, por favor contacte a soporte";                
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
                _tblempleado = new Tblempleado()
                {
                    Codigo = Codigo,
                    DocId = DocId,
                    Nombre = Nombre,
                    Pass = "12345",
                    Estado = Estado,
                    Periodo = Periodo,
                    Area = 1,
                    Empresa = "JS"
                };
                if(_tblempleado != null)
                {
                    if (IsSaved = await _service.Post(_tblempleado))
                    {
                        IsBusy = false;
                        Msj = $"Colaborador /a registrado con éxito";
                    }
                    else
                    {
                        IsBusy = false;            
                        NotSaved = true;
                        Msj = WebService<Tblempleado>.ExceptionMsj;
                    }
                }
                else
                {
                    IsBusy = false;
                    NotSaved = true;
                    Msj = $"Entidad vacía, por favor verifique o contácte a soporte";
                }             
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
        private string codigo;

        public string Codigo
        {
            get 
            {                
                return codigo;
            }
            set { codigo = value;
                NotifyPropertyChanged();
            }
        }
        private string docId;

        public string DocId
        {
            get { return docId; }
            set { docId = value; 
                NotifyPropertyChanged();

            }
        }
        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value;
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
            set { pass = value;
                NotifyPropertyChanged();

            }
        }
        private bool estado;

        public bool Estado
        {
            get { return estado; }
            set { estado = value;
                NotifyPropertyChanged();

            }
        }
        private bool periodo;

        public bool Periodo
        {
            get { return periodo; }
            set { periodo = value;
                NotifyPropertyChanged();
            }
        }
        private int area;

        public int Area
        {
            get { return area; }
            set { area = value; 
                NotifyPropertyChanged();

            }
        }
        private string empresa;


        public string Empresa
        {
            get { return empresa; }
            set { empresa = value;
                NotifyPropertyChanged();

            }
        }
        private bool isSaved;

        public bool IsSaved
        {
            get { return isSaved; }
            set { isSaved = value; 
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
        private Tblempleado userLogued;

        public Tblempleado UserLogued
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
            set { isLogued = value;
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
            get { return buscar; }
            set { buscar = value;
                NotifyPropertyChanged();
            }
        }


        private bool isBusy;

        public bool IsBusy
        {
            get { return isBusy; }
            set { isBusy = value;
                NotifyPropertyChanged();

            }
        }

        private string msj;
        public string Msj
        {
            get { return msj; }
            set { msj = value;
                NotifyPropertyChanged();
            }
        }


        #endregion

        #region Commands
        public ICommand LoginCommand { get; set; }
        public ICommand CrearEmpleadoCommand { get; set; }
        #endregion


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


    }
}
