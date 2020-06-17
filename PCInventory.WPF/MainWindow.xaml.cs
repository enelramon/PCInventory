using BLL;
using Entidades;
using System;
using System.ComponentModel;
using System.Management;
using System.Windows;

namespace PCInventory.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Equipos Equipo = new Equipos();

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = Equipo;
        }


        private void Limpiar()
        {
            this.Equipo = new Equipos();
            this.DataContext = Equipo;
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

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;

            paso = EquiposBLL.Guardar(Equipo);

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Transaccione exitosa!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Transaccion Fallida", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
