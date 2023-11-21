using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WallFinishCreatorOptions
{
    public partial class WallFinishCreatorOptionsWPF : Window
    {
        WallFinishCreatorOptionsSettings WallFinishCreatorOptionsSettingsParam = null;
        public WallFinishCreatorOptionsWPF()
        {
            InitializeComponent();
            WallFinishCreatorOptionsSettingsParam = WallFinishCreatorOptionsSettings.GetSettings();
            if (WallFinishCreatorOptionsSettingsParam.FloorCreationOptionValue != null)
            {
                if (WallFinishCreatorOptionsSettingsParam.FloorCreationOptionValue == "rbt_ByCurrentFile")
                {
                    (groupBox_FloorCreationOption.Content as System.Windows.Controls.Grid)
                    .Children.OfType<RadioButton>()
                    .FirstOrDefault(rb => rb.Name == "rbt_ByCurrentFile").IsChecked = true;
                }
                else
                {
                    (groupBox_FloorCreationOption.Content as System.Windows.Controls.Grid)
                        .Children.OfType<RadioButton>()
                        .FirstOrDefault(rb => rb.Name == "rbt_ByLinkedFile").IsChecked = true;
                }
            }
        }
        private void btn_Ok_Click(object sender, RoutedEventArgs e)
        {
            SaveSettings();
            DialogResult = true;
            Close();
        }
        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
        private void WallFinishCreatorOptionsWPF_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter || e.Key == Key.Space)
            {
                SaveSettings();
                DialogResult = true;
                Close();
            }

            else if (e.Key == Key.Escape)
            {
                DialogResult = false;
                Close();
            }
        }
        private void SaveSettings()
        {
            WallFinishCreatorOptionsSettingsParam.FloorCreationOptionValue = (groupBox_FloorCreationOption.Content as System.Windows.Controls.Grid)
                .Children.OfType<RadioButton>()
                .FirstOrDefault(rb => rb.IsChecked.Value == true)
                .Name;
            WallFinishCreatorOptionsSettingsParam.SaveSettings();
        }
    }
}
