using Meteoro.Corte.Entities.Entities;
using Meteoro.Services.Corte.Data;
using Meteoro.Services.Corte.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Meteoro.ViewModels.ViewModel.Corte
{
    public class CategoriaVm : BaseViewModel.BaseViewModel, INotifyPropertyChanged
    {
        #region Members Variables
        private CategoriaSvc _categoriaSvc;
        #endregion

        #region Constructor
        public CategoriaVm()
        {
            _categoriaSvc = new CategoriaSvc();
            GetCategoriasCommand = new Command(async () => await Get(), () => !IsBusy);
        }
        #endregion

        #region PrivateMethods
        private async Task Get()
        {
            IsBusy = true;
            try
            {
                Categorias = (IList<TbCategoria>)await _categoriaSvc.Get();
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
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value;
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

        private IList<TbCategoria> categorias;

        public IList<TbCategoria> Categorias
        {
            get 
            {
                Task.Run(async () => 
                {
                    await Get();
                });
                return categorias; 
            }
            set { categorias = value;
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
        public ICommand GetCategoriasCommand { get; set; }
        #endregion
    }
}
