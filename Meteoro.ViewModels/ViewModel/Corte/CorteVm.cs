using Meteoro.Corte.Entities.Entities;
using Meteoro.Services.Corte.Data;
using Meteoro.Services.Corte.Services;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Meteoro.ViewModels.ViewModel.Corte
{
    public class CorteVm : BaseViewModel.BaseViewModel, INotifyPropertyChanged
    {
        #region Members Variables
        private readonly CorteSvc _corteSvc;
        private readonly AseguradorEmpleadoSvc _aseguradorEmpleadoSvc;  
        private TbAseguradorEmpleado _aseguradorEmpleado;  
        private TbCorte _corte;
        private SemanaVm _semanaVm;
        #endregion

        #region Constructor
        public CorteVm()
        {
            _corteSvc = new CorteSvc(); 
            CrearCorteCommand = new Command(async () => await CrearCorte(), () => !IsBusy);
            ObtenerIdRevisionCommand = new Command(async () => await ObtenerIdRevision(), () => !IsBusy);
            _semanaVm = new SemanaVm();
            
        }
        #endregion

        #region Private Methods
        private async Task CrearCorte()
        {
            IsBusy = true;
            try
            {
                _corte = new TbCorte()
                {
                    Fecha = Fecha,
                    Año = Año,
                    Semana = Semana,
                    Empleado = Colaborador,
                    Asegurador = Asegurador,
                    Categoria = Categoria,
                    Deshoje = Deshoje,
                    DañoMecanico = DañoMecanico,
                    NumTallo = NumTallo,
                    Ftallo = FTallo,
                    Cauchos = Cauchos,
                    Longitud = Longitud,
                    Base = BaseC,
                    Alineado = Alineado,
                    Follaje = Follaje,
                    Fitosanidad = Fitosanidad,
                    Presentacion = Presentacion,
                    Apertura = Apertura,
                    Ramall = Ramall,
                    Mezcla = Mezcla,
                    Sync = Sync
                };
                if (_corte != null)
                {
                    if (IsSaved = await _corteSvc.Post(_corte))
                    {
                        IsBusy = false;
                        Msj = ResourceVm.MsjDatosGuardados;
                        Limpiar();
                    }
                    else
                    {
                        IsBusy = false;
                        NotSaved = true;
                        Msj = WebService<TbCorte>.ExceptionMsj;
                    }
                }
                else
                {
                    IsBusy = false;
                    NotSaved = true;
                    Msj = ResourceVm.MsjErrorEntidadVacia;
                }
            }
            catch (Exception ex)
            {
                IsBusy = false;
                IsError = true;
                Msj = $"{ex}";
            }
        }
        private async Task ObtenerIdRevision()
        {
            IsBusy = true;
            try
            {
                _aseguradorEmpleado = new TbAseguradorEmpleado()
                {
                    Asegurador = Asegurador,
                    Empleado = Colaborador,
                    Fecha = DateTime.Today,
                    Revisiones = Revision,
                    Sync = false
                };
                if (!string.IsNullOrEmpty(_aseguradorEmpleado.Empleado))
                {
                    AseguradorEmpleado = await _aseguradorEmpleadoSvc.ObtenerIdRevision(_aseguradorEmpleado);
                    IsBusy = false;
                }
                else
                {
                    IsBusy = false;
                    NotSaved = true;
                    Msj = WebService<TbCorte>.ExceptionMsj;
                }
            }
            catch (Exception ex)
            {
                IsBusy = false;
                IsError = true;
                Msj = $"{ex}";
            }
        }
        private async Task AtualizarRevision()
        {
            IsBusy = true;
            try
            {
                AseguradorEmpleado.Revisiones = Revision - 1;
                if (await _aseguradorEmpleadoSvc.ActualizarRevision(AseguradorEmpleado))
                {
                    await Task.Delay(200);
                    await Application.Current.MainPage.DisplayAlert("Éxito", "revisión actualizada", "Ok");
                }
            }
            catch (Exception ex)
            {
                IsBusy = false;
                IsError = true;
                Msj = $"{ex}";
            }
        }
        private void Limpiar()
        {
            Colaborador = string.Empty;
            Asegurador = string.Empty;
            Categoria = default;
            Deshoje = default;
            DañoMecanico = default;
            NumTallo = default;
            FTallo = default;
            Cauchos = default;
            Longitud = default;
            BaseC = default;
            Alineado = default;
            Follaje = default;
            Fitosanidad = default;
            Presentacion = default;
            Apertura = default;
            Ramall = default;
            Mezcla = default;
            Sync = default;
        }
        #endregion

        #region Properties

        private int id;

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                NotifyPropertyChanged();
            }
        }
        private DateTime fecha;

        public DateTime Fecha
        {
            get
            {
                fecha = DateTime.Today;
                return fecha;
            }
            set
            {
                fecha = value;
                NotifyPropertyChanged();
            }
        }
        private int año;

        public int Año
        {
            get { return año; }
            set
            {
                año = value;
                NotifyPropertyChanged();
            }
        }
        private int semana;

        public int Semana
        {
            get
            {
                semana = _semanaVm.Semana;
                return semana;
            }
            set
            {
                semana = value;
                NotifyPropertyChanged();
            }
        }
        private string colaborador;

        public string Colaborador
        {
            get
            {

                return colaborador;
            }
            set
            {
                colaborador = value;
                NotifyPropertyChanged();
            }
        }
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
        private int categoria;

        public int Categoria
        {
            get { return categoria; }
            set
            {
                categoria = value;
                NotifyPropertyChanged();
            }
        }
        private bool deshoje;

        public bool Deshoje
        {
            get { return deshoje; }
            set
            {
                deshoje = value;
                NotifyPropertyChanged();
            }
        }
        private bool dañoMecanico;

        public bool DañoMecanico
        {
            get { return dañoMecanico; }
            set
            {
                dañoMecanico = value;
                NotifyPropertyChanged();
            }
        }
        private bool numTallo;

        public bool NumTallo
        {
            get { return numTallo; }
            set
            {
                numTallo = value;
                NotifyPropertyChanged();
            }
        }
        private bool fTallo;

        public bool FTallo
        {
            get { return fTallo; }
            set
            {
                fTallo = value;
                NotifyPropertyChanged();
            }
        }
        private bool cauchos;

        public bool Cauchos
        {
            get { return cauchos; }
            set
            {
                cauchos = value;
                NotifyPropertyChanged();
            }
        }
        private bool longitud;

        public bool Longitud
        {
            get { return longitud; }
            set
            {
                longitud = value;
                NotifyPropertyChanged();
            }
        }
        private bool baseC;

        public bool BaseC
        {
            get { return baseC; }
            set
            {
                baseC = value;
                NotifyPropertyChanged();
            }
        }
        private bool alineado;

        public bool Alineado
        {
            get { return alineado; }
            set
            {
                alineado = value;
                NotifyPropertyChanged();
            }
        }
        private bool follaje;

        public bool Follaje
        {
            get { return follaje; }
            set
            {
                follaje = value;
                NotifyPropertyChanged();
            }
        }
        private bool fitosanidad;

        public bool Fitosanidad
        {
            get { return fitosanidad; }
            set
            {
                fitosanidad = value;
                NotifyPropertyChanged();
            }
        }
        private bool presentacion;

        public bool Presentacion
        {
            get { return presentacion; }
            set
            {
                presentacion = value;
                NotifyPropertyChanged();
            }
        }
        private bool apertura;

        public bool Apertura
        {
            get { return apertura; }
            set
            {
                apertura = value;
                NotifyPropertyChanged();
            }
        }
        private bool ramall;

        public bool Ramall
        {
            get { return ramall; }
            set
            {
                ramall = value;
                NotifyPropertyChanged();
            }
        }
        private bool mezcla;

        public bool Mezcla
        {
            get { return mezcla; }
            set
            {
                mezcla = value;
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
        private bool isEror;

        public bool IsError
        {
            get { return isEror; }
            set
            {
                isEror = value;
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

        private int revision;

        public int Revision
        {
            get { return revision; }
            set
            {
                revision = value;
                NotifyPropertyChanged();
            }
        }

        public TbAseguradorEmpleado AseguradorEmpleado { get; set; }
        #endregion

        #region Commands
        public ICommand CrearCorteCommand { get; set; }
        public ICommand ObtenerIdRevisionCommand { get; set; }

        #endregion
    }
}
