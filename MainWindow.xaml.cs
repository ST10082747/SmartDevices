using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SmartDevices
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CustomDictionary<string, SmartDevice> deviceDictionary;

        public MainWindow()
        {
            InitializeComponent();
            deviceDictionary = new CustomDictionary<string, SmartDevice>();
            UpdateDeviceList();
        }

        private void AddDevice_Click(object sender, RoutedEventArgs e)
        {
            string name = DeviceNameTextBox.Text;
            string status = DeviceStatusTextBox.Text;

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(status))
            {
                MessageBox.Show("Please enter both a device name and status.");
                return;
            }

            try
            {
                SmartDevice device = new SmartDevice(name, status);
                deviceDictionary.Add(name, device);
                UpdateDeviceList();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateDevice_Click(object sender, RoutedEventArgs e)
        {
            string name = DeviceNameTextBox.Text;
            string status = DeviceStatusTextBox.Text;

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(status))
            {
                MessageBox.Show("Please enter both a device name and status.");
                return;
            }

            try
            {
                SmartDevice device = new SmartDevice(name, status);
                deviceDictionary.Update(name, device);
                UpdateDeviceList();
            }
            catch (KeyNotFoundException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RemoveDevice_Click(object sender, RoutedEventArgs e)
        {
            string name = DeviceNameTextBox.Text;

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Please enter a device name.");
                return;
            }

            try
            {
                deviceDictionary.Remove(name);
                UpdateDeviceList();
            }
            catch (KeyNotFoundException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateDeviceList()
        {
            DeviceListBox.Items.Clear();
            foreach (var kvp in deviceDictionary.GetAllItems())
            {
                DeviceListBox.Items.Add(kvp.Value.ToString());
            }
        }
    }
}