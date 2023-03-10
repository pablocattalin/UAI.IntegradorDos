using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UAI.IntegradorDos.Logica;
using UAI.IntegradorDos.Modelos;
using UAI.IntegradorDos.ModeloVista;

namespace UAI.IntegradorDos
{
    public partial class Form1 : Form
    {
        private InversorLogica _inversorLogica;
        private AccionLogica _accionLogica;
        private ComisionLogica _comisionLogica;
        public Form1()
        {
            _comisionLogica = new ComisionLogica();
            _accionLogica = new AccionLogica(AccionBuscada_CambioCotizacion);
            _inversorLogica = new InversorLogica(_accionLogica, _comisionLogica);
            InitializeComponent();
        }

        public void AccionBuscada_CambioCotizacion(object sender, CambioCotizacionEventArgs e)
        {
            MessageBox.Show($"La cotizacion cambio. La nueva cotizacion es {e.CotizacionActual} $");
        }
        private void ActualizarDatagrid<T>(DataGridView dgv, List<T> list) {
            dgv.DataSource = null;
            dgv.DataSource = list.ToList();            
        }

        private void ActualizarTextbox(TextBox txtBox, decimal total)
        {
            txtBox.Text = total.ToString();
        }

        private void AltaInversor(out string dni, out string saldo, out string nombre, out string apellido)
        {
            dni = Interaction.InputBox("DNI ");
            if (!Information.IsNumeric(dni)) throw new ApplicationException("Debe ser numerico");
            saldo = Interaction.InputBox("SALDO: ");
            if (!Information.IsNumeric(saldo)) throw new ApplicationException("Debe ser numerico");
            apellido = Interaction.InputBox("APELLIDO: ");
            nombre = Interaction.InputBox("NOMBRE: ");
        }

        private void btnClick_AltaPremium(object sender, EventArgs e)
        {
            try
            {
                AltaInversor(out string dni, out string saldo, out string nombre, out string apellido);
                _inversorLogica.Agregar(new InversorPremium
                {
                    Dni = long.Parse(dni),
                    Saldo = long.Parse(saldo),
                    Apellido = apellido,
                    Nombre = nombre
                });
                ActualizarDatagrid(dgVInversor, _inversorLogica.DevolverTodos());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnClick_AltaComun(object sender, EventArgs e)
        {
            try
            {
                AltaInversor(out string dni, out string saldo, out string nombre, out string apellido);
                _inversorLogica.Agregar(new Inversor
                {
                    Dni = long.Parse(dni),
                    Saldo = long.Parse(saldo),
                    Apellido = apellido,
                    Nombre = nombre
                });
                ActualizarDatagrid(dgVInversor, _inversorLogica.DevolverTodos());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          
        }

        private void btnClick_AltaAccion(object sender, EventArgs e)
        {
            try
            {
                AltaAccion(out string codigo, out string cotizaconActual, out string denominacion, out string cantidadEmitida);
                _accionLogica.Agregar(new Accion
                {
                    CotizacionActual = decimal.Parse(cotizaconActual),
                    Codigo = codigo,
                    CantidadEmitida = double.Parse(cantidadEmitida),
                    Denominacion = denominacion,
                });
                ActualizarDatagrid(dgvAcciones, _accionLogica.DevolverTodos());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void AltaAccion(out string codigo, out string cotizaconActual, out string denominacion, out string cantidadEmitida)
        {
            codigo = Interaction.InputBox("Codigo: ");            
            cotizaconActual = Interaction.InputBox("Cotizacion: ");
            if (!Information.IsNumeric(cotizaconActual)) throw new ApplicationException("Debe ser numerico");
            denominacion = Interaction.InputBox("Denominacion: ");
            cantidadEmitida = Interaction.InputBox("Cantidad emitida: ");
            if (!Information.IsNumeric(cantidadEmitida)) throw new ApplicationException("Debe ser numerico");
        }

        private void btnClick_ModificarAccion(object sender, EventArgs e)
        {
            try
            {
                var accionElegida = (Accion)dgvAcciones.CurrentRow.DataBoundItem;
                if (accionElegida != null)
                {
                    AltaAccion(out string codigo, out string cotizaconActual, out string denominacion, out string cantidadEmitida);
                    accionElegida.CotizacionActual = long.Parse(cotizaconActual);
                    accionElegida.CantidadEmitida = long.Parse(cantidadEmitida);
                    accionElegida.Codigo = codigo;
                    accionElegida.Denominacion = denominacion;
                    _accionLogica.Actualizar(accionElegida);
                    ActualizarDatagrid(dgvAcciones, _accionLogica.DevolverTodos());
                    var inversorElegido = (Inversor)dgVInversor.CurrentRow.DataBoundItem;
                    if (inversorElegido != null)
                    {
                        List<Inversiones> inversiones = new List<Inversiones>();
                        _inversorLogica
                            .DevolverPorLegajo(inversorElegido)
                            .Inversiones
                            .ForEach(a => {
                                var inversion = new Inversiones
                                {

                                    Codigo = a.Accion.Codigo,
                                    Denominacion = a.Accion.Denominacion,
                                    CotizacionActual = a.Accion.CotizacionActual,
                                    Cantidad = a.Cantidad,
                                    InversionTotal = a.Accion.DevolverImporteOperacion(a.Cantidad),
                                };
                                foreach (var item in a.Accion)
                                {
                                    inversion.Codigo = item.ToString();
                                }
                                inversiones.Add(inversion);
                            });
                        ActualizarDatagrid(dgvInversiones, inversiones);                        
                    }
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

       

        private void btnClick_ModificarInversor(object sender, EventArgs e)
        {
            try
            {
                var inversorElegido = (Inversor)dgVInversor.CurrentRow.DataBoundItem;
                if (inversorElegido != null)
                {
                    AltaInversor(out string dni, out string saldo, out string nombre, out string apellido);
                    inversorElegido.Dni = long.Parse(dni);
                    inversorElegido.Saldo = long.Parse(saldo);
                    inversorElegido.Nombre = nombre;
                    inversorElegido.Apellido = apellido;
                    _inversorLogica.Actualizar(inversorElegido);
                    ActualizarDatagrid(dgVInversor, _inversorLogica.DevolverTodos());
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnClick_EliminarInversor(object sender, EventArgs e)
        {
            try
            {
                var inversorElegido = (Inversor)dgVInversor.CurrentRow.DataBoundItem;
                if (inversorElegido != null)
                {
                    _inversorLogica.Eliminar(inversorElegido);
                    ActualizarDatagrid(dgVInversor, _inversorLogica.DevolverTodos());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnClick_EliminarAccion(object sender, EventArgs e)
        {
            try
            {
                var accionElegida = (Accion)dgvAcciones.CurrentRow.DataBoundItem;
                if (accionElegida != null)
                {
                    _accionLogica.Eliminar(accionElegida);
                    ActualizarDatagrid(dgvAcciones, _accionLogica.DevolverTodos());
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void btnClick_Comprar(object sender, EventArgs e)
        {

            try
            {
                var accionElegida = (Accion)dgvAcciones.CurrentRow.DataBoundItem;
                var inversorElegido = (Inversor)dgVInversor.CurrentRow.DataBoundItem;
                if (accionElegida != null && inversorElegido != null)
                {
                    var cantidad = Interaction.InputBox("Acciones a comprar: ");
                    if (!Information.IsNumeric(cantidad)) throw new ApplicationException("Debe ser numerico");
                    accionElegida.CantidadEmitida = double.Parse(cantidad);
                    _inversorLogica.Comprar(inversorElegido, accionElegida);
                    List<Inversiones> inversiones = new List<Inversiones>();
                    _inversorLogica
                        .DevolverPorLegajo(inversorElegido)
                        .Inversiones
                        .ForEach(a => {
                            var inversion = new Inversiones
                            {

                                Codigo = a.Accion.Codigo,
                                Denominacion = a.Accion.Denominacion,
                                CotizacionActual = a.Accion.CotizacionActual,
                                Cantidad = a.Cantidad,
                                InversionTotal = a.Accion.DevolverImporteOperacion(a.Cantidad),
                            };
                            foreach (var item in a.Accion)
                            {
                                inversion.Codigo = item.ToString();  
                            }
                            inversiones.Add(inversion); 
                        });
                    ActualizarDatagrid(dgvInversiones, inversiones);
                    //ActualizarDatagrid(dgvInversiones, _inversorLogica
                    //    .DevolverPorLegajo(inversorElegido)
                    //    .Inversiones
                    //    .Select(a => new Inversiones
                    //    {
                    //        Codigo = a.Accion.Codigo,
                    //        Denominacion = a.Accion.Denominacion,                            
                    //        CotizacionActual = a.Accion.CotizacionActual,
                    //        Cantidad = a.Cantidad,
                    //        InversionTotal = a.Accion.DevolverImporteOperacion(a.Cantidad),
                    //    }).ToList());
                    ActualizarDatagrid(dgvAcciones, _accionLogica.DevolverTodos());
                    ActualizarDatagrid(dgVInversor, _inversorLogica.DevolverTodos());
                    ActualizarTextbox(txtBoxPremiumHasta20, _comisionLogica.Devolver().ComisionComunPremium);
                    ActualizarTextbox(txtBoxComisionTotal, _comisionLogica.Devolver().TotalComisiones);
                    ActualizarTextbox(txtBoxTotalClienteComun, _comisionLogica.Devolver().ComisionComun);
                    ActualizarTextbox(txtBoxPremiumSupera20, _comisionLogica.Devolver().ComisionPremium);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClick_Vender(object sender, EventArgs e)
        {
            try
            {
                var accionElegida = (Inversiones)dgvInversiones.CurrentRow.DataBoundItem;
                var inversorElegido = (Inversor)dgVInversor.CurrentRow.DataBoundItem;
                if (accionElegida != null && inversorElegido != null)
                {
                    var cantidad = Interaction.InputBox("Acciones a vender: ");
                    if (!Information.IsNumeric(cantidad)) throw new ApplicationException("Debe ser numerico");
                    accionElegida.Cantidad = double.Parse(cantidad);
                    _inversorLogica.Vender(inversorElegido, new Accion
                    {
                        CotizacionActual = accionElegida.CotizacionActual,
                        CantidadEmitida = accionElegida.Cantidad,
                        Codigo = _accionLogica.ConvertirCodigo(accionElegida.Codigo),
                    });
                    List<Inversiones> inversiones = new List<Inversiones>();
                    _inversorLogica
                        .DevolverPorLegajo(inversorElegido)
                        .Inversiones
                        .ForEach(a => {
                            var inversion = new Inversiones
                            {

                                Codigo = a.Accion.Codigo,
                                Denominacion = a.Accion.Denominacion,
                                CotizacionActual = a.Accion.CotizacionActual,
                                Cantidad = a.Cantidad,
                                InversionTotal = a.Accion.DevolverImporteOperacion(a.Cantidad),
                            };
                            foreach (var item in a.Accion)
                            {
                                inversion.Codigo = item.ToString();
                            }
                            inversiones.Add(inversion);
                        });
                    ActualizarDatagrid(dgvInversiones, inversiones);
                    ActualizarDatagrid(dgVInversor, _inversorLogica.DevolverTodos());
                    ActualizarTextbox(txtBoxPremiumHasta20, _comisionLogica.Devolver().ComisionComunPremium);
                    ActualizarTextbox(txtBoxComisionTotal, _comisionLogica.Devolver().TotalComisiones);
                    ActualizarTextbox(txtBoxTotalClienteComun, _comisionLogica.Devolver().ComisionComun);
                    ActualizarTextbox(txtBoxPremiumSupera20, _comisionLogica.Devolver().ComisionPremium);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClick_CargarFake(object sender, EventArgs e)
        {
            if (_accionLogica.DevolverTodos().Count == 0 && _inversorLogica.DevolverTodos().Count == 0)
            {
                List<string> codigos = new List<string>();
                for (int i = 1; i < 30; i++)
                {
                    Inversor inversor;
                    if (EsPrimo(i))
                        inversor = new InversorPremium();
                    else
                        inversor = new Inversor();                                            
                    inversor.Nombre = GenerarNombres();
                    inversor.Apellido = GenerarNombres();
                    inversor.Saldo = (decimal)GenerarImportes(i);
                    inversor.Legajo = i;
                    inversor.Dni = i;
                    _inversorLogica.Agregar(inversor);
                    string codigo = CodigoAdelanto();
                    while (codigos.Any(a => a == codigo))
                        codigo = CodigoAdelanto();
                    codigos.Add(codigo);
                    _accionLogica.Agregar(new Accion
                    {
                        Codigo = codigo,
                        CantidadEmitida = GenerarImportes(i),
                        CotizacionActual = (decimal)GenerarImportes(i),
                        Denominacion = GenerarNombres()
                    });
                }
                ActualizarDatagrid(dgvAcciones, _accionLogica.DevolverTodos());
                ActualizarDatagrid(dgVInversor, _inversorLogica.DevolverTodos());
            }
            else
            {
                MessageBox.Show("Ya hay datos cargados");
            }
        }

        private string CodigoAdelanto()
        {
            Random r = new Random();
            return GenerarNombres().Substring(0, 1).ToUpper()
                + GenerarNombres().Substring(0, 1).ToUpper() + GenerarNombres().Substring(0, 1).ToUpper() + GenerarNombres().Substring(0, 1).ToUpper()
                + "-" +  r.Next(0, 9).ToString() + r.Next(0, 9) + r.Next(0, 9) + r.Next(0, 9) + "-" + GenerarNombres().Substring(0, 1).ToUpper() + r.Next(0, 9) + GenerarNombres().Substring(0, 1).ToUpper() + r.Next(0, 9);
        }

        private bool EsPrimo(int numero)
        {
            for (int i = 2; i < numero; i++)
            {
                if ((numero % i) == 0)
                {
                    return false;
                }
            }
            return true;
        }

        private double GenerarImportes(int v)
        {
            Random r = new Random();
            return r.Next(100, 100000) * v;
        }

        private string GenerarNombres(int longitud = 0)
        {
            Random r = new Random();
            if (longitud == 0)
                longitud = r.Next(5, 8);
            string[] consonantes = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
            string[] vocales = { "a", "e", "i", "o", "u", "ae", "y" };
            string nombre = "";
            nombre += consonantes[r.Next(consonantes.Length)].ToUpper();
            nombre += vocales[r.Next(vocales.Length)];
            int b = 2;
            //Aseguro que el nombre tenga una longitud de entre 4 y 8 caracteres
            while (b < longitud)
            {
                nombre += consonantes[r.Next(consonantes.Length)];
                b++;
                nombre += vocales[r.Next(vocales.Length)];
                b++;
            }

            return nombre;
        }

        private void btnClick_SelectedInversor(object sender, DataGridViewCellEventArgs e)
        {
            var inversorSeleccionado = (Inversor)dgVInversor.CurrentRow.DataBoundItem;
            if (inversorSeleccionado != null)
            {
                var inversionesAlmacenadas = _inversorLogica.DevolverPorLegajo(inversorSeleccionado);
                if (inversionesAlmacenadas.Inversiones.Count > 0)
                {
                    List<Inversiones> inversiones = new List<Inversiones>();
                    _inversorLogica
                        .DevolverPorLegajo(inversorSeleccionado)
                        .Inversiones
                        .ForEach(a => {
                            var inversion = new Inversiones
                            {

                                Codigo = a.Accion.Codigo,
                                Denominacion = a.Accion.Denominacion,
                                CotizacionActual = a.Accion.CotizacionActual,
                                Cantidad = a.Cantidad,
                                InversionTotal = a.Accion.DevolverImporteOperacion(a.Cantidad),
                            };
                            foreach (var item in a.Accion)
                            {
                                inversion.Codigo = item.ToString();
                            }
                            inversiones.Add(inversion);
                        });
                    ActualizarDatagrid(dgvInversiones, inversiones);                    
                }
                else
                {
                    ActualizarDatagrid(dgvInversiones, inversionesAlmacenadas.Inversiones);
                }
            }
        }
    }
}
