using System;

using Xamarin.Forms;
using XamarinSQL.Clases;

namespace XamarinSQL.Paginas
{
	public partial class PaginaEmpleado : ContentPage
	{
        public Empleados Empleado;

        public PaginaEmpleado ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            BindingContext = this.Empleado;
        }

        void btnGuardar_Click(object sender, EventArgs a)
        {
            if (Empleado.ID == 0)
                BaseDatos.AgregarEmpleado(Empleado);
            else
                BaseDatos.ModificarEmpleado(Empleado);

            Navigation.PopAsync();
        }

        void btnEliminar_Click(object sender, EventArgs a)
        {
            if (Empleado.ID != 0)
            {
                BaseDatos.EliminarEmpleado(Empleado);
                Navigation.PopAsync();
            }
        }
    }
}
