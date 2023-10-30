using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
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

using System.IO;
using System.Windows.Shapes;

namespace Semen
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
 
            // Замените на ваш действительный MAC-адрес.
            private string licenseFilePath = "license.txt";
            public MainWindow()
        {
            InitializeComponent();
            string currentMacAddress = GetMacAddress();
            MacAddressText.Text = "Действующий MAC-адрес: " + currentMacAddress;
        }

        private void ActivateLicenseButton_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists(licenseFilePath))
            {
                string savedMacAddress = File.ReadAllText(licenseFilePath);
                if (savedMacAddress == GetMacAddress())
                {
                    MessageBox.Show("Лицензия действительна. Вы можете использовать продукт.");
                }
                else
                {
                    MessageBox.Show("Вы используете нелегальную копию продукта.");
                }
            }
            else
            {
                string currentMacAddress = GetMacAddress();
                File.WriteAllText(licenseFilePath, currentMacAddress);
                MessageBox.Show("Продукт активирован. MAC-адрес сохранен.");
            }
            if (File.Exists(licenseFilePath))
            {
                string savedMacAddress = File.ReadAllText(licenseFilePath);
                if (savedMacAddress == GetMacAddress())
                {
                    MessageBox.Show("Ключи совпадают");
                }
                else
                {
                    MessageBox.Show("Вы используете нелегальную копию продукта.");
                }
            }
            else
            {
                MessageBox.Show("Нет активированной лицензии. Пожалуйста, свяжитесь с администратором.");
            }
        }

        private string GetMacAddress()
        {
            NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
            string macAddress = "N/A";

            foreach (NetworkInterface networkInterface in networkInterfaces)
            {
                if (networkInterface.OperationalStatus == OperationalStatus.Up)
                {
                    macAddress = networkInterface.GetPhysicalAddress().ToString();
                    break;
                }
            }

            return macAddress;
        }
    }
}
