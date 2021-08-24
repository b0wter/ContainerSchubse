using System;
using System.Collections.Generic;
using System.Linq;
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

namespace ContainerSchubse
{
    /// <summary>
    /// Interaction logic for RectangleRenderer.xaml
    /// </summary>
    public partial class RectangleRenderer : UserControl
    {
        private Random random = new Random();

        public RectangleRenderer()
        {
            InitializeComponent();
            AddChessPattern();
        }

        private void AddChessPattern()
        {
            var grid = (Grid)this.FindName("chessGrid");

            var columnCount = Math.Ceiling(Constants.CanvasWidth / Constants.PixelsPerMeter);
            for (int i = 0; i < columnCount; i++)
                grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(Constants.PixelsPerMeter) });

            var rowCount = Math.Ceiling(Constants.CanvasHeight / Constants.PixelsPerMeter);
            for (int i = 0; i < rowCount; i++)
                grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(Constants.PixelsPerMeter) });

            for (int i = 0; i < columnCount; i++)
                for (int j = 0; j < rowCount; j++)
                    grid.Children.Add(CreateBorder(j, i));
        }

        private Border CreateBorder(int row, int col)
        {
            var border = new Border();
            border.SetValue(Grid.RowProperty, row);
            border.SetValue(Grid.ColumnProperty, col);
            var color = (byte)random.Next(160, 255);
            border.Background = new SolidColorBrush(Color.FromRgb(color, color, color));
            //border.Background = new SolidColorBrush(Color.FromRgb((byte)random.Next(0, 255), (byte)random.Next(0, 255), (byte)random.Next(0, 255)));
            return border;
        }
    }
}
