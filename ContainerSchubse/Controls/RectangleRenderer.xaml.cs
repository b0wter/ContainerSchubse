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
        private static readonly byte EvenColorByte = 240;
        private static readonly Color EvenColor = Color.FromRgb(EvenColorByte, EvenColorByte, EvenColorByte);
        private static readonly byte OddColorByte = 220;
        private static readonly Color OddColor = Color.FromRgb(OddColorByte, OddColorByte, OddColorByte);
        
        public static readonly DependencyProperty AddOffsetAtTopProperty = DependencyProperty.Register(
            nameof(AddOffsetAtTop), typeof(bool), typeof(RectangleRenderer));
        public bool AddOffsetAtTop
        {
            get { return (bool)GetValue(AddOffsetAtTopProperty); }
            set { SetValue(AddOffsetAtTopProperty, value); }
        }

        public RectangleRenderer()
        {
            InitializeComponent();
            // Dieser Hack ist notwendig, weil die Eigenschaften aus dem XAML erst gesetzt werden
            // nachdem die Klasse instantiiert wird.
            // Normalerweise umgeht man das Problem mit INotifyPropertyChanged, aber hier soll ja nur
            // einmalig etwas angepasst werden.
            LayoutUpdated += RectangleRenderer_LayoutUpdated;
        }

        private void RectangleRenderer_LayoutUpdated(object sender, EventArgs e)
        {
            LayoutUpdated -= RectangleRenderer_LayoutUpdated;
            AddChessPattern();
        }

        private void AddChessPattern()
        {
            var columnCount = Math.Ceiling(Constants.CanvasWidth / Constants.PixelsPerMeter);
            for (int i = 0; i < columnCount; i++)
                ChessGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(Constants.PixelsPerMeter) });

            var rowCount = Math.Ceiling(Constants.CanvasHeight / Constants.PixelsPerMeter);
            var gridYOffset = Math.Abs(Constants.CanvasHeight - ((rowCount - 1) * Constants.PixelsPerMeter));
            if(AddOffsetAtTop)
                ChessGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(gridYOffset) });
            for (int i = 0; i < rowCount; i++)
                ChessGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(Constants.PixelsPerMeter) });

            for (int i = 0; i < columnCount; i++)
                for (int j = 0; j < rowCount; j++)
                    ChessGrid.Children.Add(CreateBorder(j, i));
        }


        private Border CreateBorder(int row, int col)
        {
            var border = new Border();
            var color = (row + col) % 2 == 0 ? EvenColor : OddColor;
            border.SetValue(Grid.RowProperty, row);
            border.SetValue(Grid.ColumnProperty, col);
            border.Background = new SolidColorBrush(color);
            return border;
        }
    }
}
