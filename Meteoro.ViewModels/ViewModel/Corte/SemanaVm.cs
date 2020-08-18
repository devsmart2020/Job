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
    public class SemanaVm :BaseViewModel.BaseViewModel, INotifyPropertyChanged
    {
        #region Members Variables
        private readonly SemanaSvc _semanaSvc;
        private TbSemana _tbSemana;
        #endregion

        #region Constructor
        public SemanaVm()
        {
            _semanaSvc = new SemanaSvc();
            GetSemanaCommand = new Command(async () => await GetSemana());            
        }
        #endregion

        #region Private Methods
        private async Task GetSemana()
        {
            IsBusy = true;
            try
            {
                _tbSemana = new TbSemana()
                {
                    Semana = Semana,
                    Año = Año,
                    FechaIni = FechaIni,
                    FechaFin = FechaFin
                };
                TbSemana = await _semanaSvc.Get(_tbSemana);               
                Semana = TbSemana.Semana;
                Año = TbSemana.Año;
                FechaIni = TbSemana.FechaIni;
                FechaFin = TbSemana.FechaFin;
                IsBusy = false;
            }
            catch (Exception ex)
            {
                IsBusy = false;
                Msj = ex.ToString();
                await Application.Current.MainPage.DisplayAlert("Error", Msj, "Ok");
                Msj = WebService<TbSemana>.ExceptionMsj;               
                await Application.Current.MainPage.DisplayAlert("Error", Msj, "Ok");
            }
        }
        #endregion

        #region Properties
        private int semana;

        public int Semana
        {
            get { return semana; }
            set { semana = value;
                NotifyPropertyChanged();
            }
        }
        private int año;

        public int Año
        {
            get { return año; }
            set { año = value;
                NotifyPropertyChanged();
            }
        }
        private DateTime fechaIni;

        public DateTime FechaIni
        {
            get { return fechaIni; }
            set { fechaIni = value;
                NotifyPropertyChanged();
            }
        }
        private DateTime fechaFin;

        public DateTime FechaFin
        {
            get { return fechaFin; }
            set { fechaFin = value;
                NotifyPropertyChanged();
            }
        }

        private TbSemana tbsemana;

        public TbSemana TbSemana
        {
            get
            {
                Task.Run(async () =>
                {
                    await GetSemana();
                });
                return tbsemana;
            }
            set { tbsemana = value;
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
        public ICommand GetSemanaCommand { get; set; }

        public async Task GetSemanaCmd()
        {
            await GetSemana();
        }
        #endregion
    }
}
