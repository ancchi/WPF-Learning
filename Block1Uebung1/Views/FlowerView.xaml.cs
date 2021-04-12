using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Block1Uebung1.Views {
    /// <summary>
    /// Interaction logic for FlowerView.xaml
    /// </summary>
    public partial class FlowerView : UserControl {
        public FlowerView() {
            InitializeComponent();
        }

        private void addFlowerButton_Click(object sender, RoutedEventArgs eventArgs) {

            BindingExpression binding = meineTextBox.GetBindingExpression(TextBox.TextProperty);
            binding.UpdateSource();
        }
    }
}
