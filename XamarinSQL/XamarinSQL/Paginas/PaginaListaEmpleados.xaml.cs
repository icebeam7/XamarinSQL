using System;
using Xamarin.Forms;
using XamarinSQL.Clases;

namespace XamarinSQL.Paginas
{
	public partial class PaginaListaEmpleados : ContentPage
	{
		public PaginaListaEmpleados ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            lsvEmpleados.ItemsSource = BaseDatos.ObtenerEmpleados();
        }

        private void lsvEmpleados_Selected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
                NavegarEmpleado(e.SelectedItem as Empleados);
        }

        void btnNuevo_Click(object sender, EventArgs a)
        {
            NavegarEmpleado(new Empleados());
        }

        void NavegarEmpleado(Empleados empleado)
        {
            PaginaEmpleado pagina = new PaginaEmpleado();
            pagina.Empleado = empleado;
            Navigation.PushAsync(pagina);
        }
    }
}