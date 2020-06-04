using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PCInventory.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Equipos equipos = new Equipos();
        public MainWindow()
        {
            InitializeComponent();
        }



        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;


            if (equipos.EquipoId == 0)
            {
                paso = EquiposBLL.Guardar(equipos);
            }
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede modificar");
                    return;
                }
                else
                {
                    paso = EquiposBLL.Modificar(equipos);
                }
            }

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado");
            }
            else
            {
                MessageBox.Show("No se pudo guardar");
            }

        }

        private void Propiedades()
        {
            ManagementObjectSearcher SO = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_OperatingSystem");//me busca las caracteristica del sistema operativo
            ManagementObjectSearcher pc = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_UserAccount");//Busca La caracteristica del Usuario de la maquina
            ManagementObjectSearcher ram = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_PhysicalMemory");//Busca la especificaciones de la memoria fisica de la ram, vram, cache.
            ManagementObjectSearcher CPU = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Processor");//Busca la Caracteristicas del procesador
            ManagementObjectSearcher HDD = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_LogicalDisk where drivetype = 3");//Busca la Caracteristicas del HDD

            foreach (ManagementObject item in SO.Get())
            {
                SistemaOperativoTextBox.Text = item.GetPropertyValue("Caption").ToString();
                SerialTextBox.Text = item.GetPropertyValue("SerialNumber").ToString();
            }

            foreach (ManagementObject item in pc.Get())
            {
                NombresTextBox.Text = item.GetPropertyValue("Caption").ToString();
            }

            long MemSize = 0;
            long MinSize;

            foreach (ManagementObject Item in ram.Get())
            {
                MinSize = Convert.ToInt64(Item["Capacity"]);
                MemSize += MinSize;
            }
            MemSize = (MemSize / 1024) / 1024;
            MemoriaTextBox.Text = MemSize.ToString();


            foreach (ManagementObject item in CPU.Get())
            {
                ProcesadorTextBox.Text = item.GetPropertyValue("Name").ToString();

            }

            foreach (ManagementObject item in HDD.Get())
            {
                long HDDMax = Int64.Parse(item["Size"].ToString());
                double Gigabayte = ((HDDMax / 1024) / 1024) / 1024;
                DiscoTextBox.Text = Gigabayte.ToString();
            }
        }

        private void Analizar_Click(object sender, RoutedEventArgs e)
        {
            Propiedades();
        }

        private void Limpiar()
        {
            equipos = new Equipos();
            reCargar();
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            Equipos anterir = EquiposBLL.Buscar(equipos.EquipoId);

            return (anterir != null);
        }

        private void reCargar()
        {
            this.DataContext = null;
            this.DataContext = equipos;
        }

    }
}
