using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerSchubse
{
    public abstract class RectangleViewModel : BaseViewModel
    {

        /// <summary>
        /// Interne Berechnungsvariable um den Container an der richtigen Stelle im Canvas anzuzeigen.
        /// </summary>
        public double CenterOffsetX { get; }
        /// <summary>
        /// Interne Berechnungsvariable um den Container an der richtigen Stelle im Canvas anzuzeigen.
        /// </summary>
        public double CenterOffsetY { get; }

        /// <summary>
        /// Breite des Rechtecks (Container) in Pixeln.
        /// </summary>
        public double RectangleWidth => (Container.Width / 1000) * Constants.PixelsPerMeter;
        /// <summary>
        /// Höhre (=Länge) des Rechtecks (Container) in Pixeln.
        /// </summary>
        public double RectangleHeight => (Container.Length / 1000) * Constants.PixelsPerMeter;
        public double CircleRadius { get; } = 10;

        private double measuredOffsetX;
        /// <summary>
        /// Aus den Messdaten bestimmter X-Offset in Millimetern.
        /// </summary>
        public double MeasuredOffsetX
        {
            get { return measuredOffsetX; }
            set { measuredOffsetX = value; OnPropertyChanged(); OnPropertyChanged(nameof(TotalOffsetX)); }
        }

        private double measuredOffsetY;
        /// <summary>
        /// Aus den Messdaten bestimmter Y-Offset in Millimetern.
        /// </summary>
        public double MeasuredOffsetY
        {
            get { return measuredOffsetY; }
            set { measuredOffsetY = value; OnPropertyChanged(); OnPropertyChanged(nameof(TotalOffsetY)); }
        }

        /// <summary>
        /// Notwendige Verschiebung, damit das Rechteck nicht in der Mitte des Canvas sondern in der Ecke gezeichnet wird.
        /// </summary>
        public abstract double CanvasOffsetX { get; }
        /// <summary>
        /// Notwendige Verschiebung, damit das Rechteck nicht in der Mitte des Canvas sondern in der Ecke gezeichnet wird.
        /// </summary>
        public abstract double CanvasOffsetY { get; }

        public abstract double CircleX { get; }
        public abstract double CircleY { get; }

        /// <summary>
        /// Berechnete Größe um das Rechteck passend im Canvas zu verschieben.
        /// Hierfür wird der `CanvasOffset` mit dem `MeasuredOffset` zusammengerechnet.
        /// </summary>
        public double TotalOffsetX
        {
            get { return CanvasOffsetX + MeasuredOffsetX / 1000.0 * Constants.PixelsPerMeter; }
        }

        /// <summary>
        /// Berechnete Größe um das Rechteck passend im Canvas zu verschieben.
        /// Hierfür wird der `CanvasOffset` mit dem `MeasuredOffset` zusammengerechnet.
        /// </summary>
        public double TotalOffsetY
        {
            get { return CanvasOffsetY + MeasuredOffsetY; }
        }

        /// <summary>
        /// Container, dessen Maße verwendet werden sollen.
        /// </summary>
        public readonly Container Container;

        private double rotation = 0;
        /// <summary>
        /// Aktuelle Rotation des Containers.
        /// </summary>
        public double Rotation
        {
            get => this.rotation;
            set
            {
                this.rotation = value;
                this.OnPropertyChanged();
            }
        }

        public Quadrants Quadrant { get; }

        public RectangleViewModel(Quadrants quadrant, Container container)
        {
            this.Quadrant = quadrant;
            this.Container = container;
        }

        protected double InMeter(double pixels) => pixels / Constants.PixelsPerMeter;
        protected double InPixels(double meters) => meters * Constants.PixelsPerMeter;
    }

    public class UpperLeftRectangleViewModel : RectangleViewModel
    {
        public override double CanvasOffsetX => Constants.CanvasWidth - (RectangleWidth / 2);
        public override double CanvasOffsetY => Constants.CanvasHeight - (RectangleHeight / 2);

        public override double CircleX => CanvasOffsetX - (CircleRadius / 2);
        public override double CircleY => CanvasOffsetY - (CircleRadius / 2);


        public UpperLeftRectangleViewModel() : base(Quadrants.UpperLeft, Container.Current)
        {
            //
        }
    }

    public class UpperRightRectangleViewModel : RectangleViewModel
    {
        public override double CanvasOffsetX => RectangleWidth / -2;
        public override double CanvasOffsetY => Constants.CanvasHeight - (RectangleHeight / 2);

        public override double CircleX => CanvasOffsetX + (CircleRadius / 2);
        public override double CircleY => CanvasOffsetY - (CircleRadius / 2);

        public UpperRightRectangleViewModel() : base(Quadrants.UpperRight, Container.Current)
        {
            //
        }
    }

    public class LowerLeftRectangleViewModel : RectangleViewModel
    {
        public override double CanvasOffsetX => Constants.CanvasWidth - (RectangleWidth / 2);
        public override double CanvasOffsetY => RectangleHeight / -2;

        public override double CircleX => CanvasOffsetX - (CircleRadius / 2);
        public override double CircleY => CanvasOffsetY + (CircleRadius / 2);

        public LowerLeftRectangleViewModel() : base(Quadrants.LowerLeft, Container.Current)
        {
            //
        }
    }

    public class LowerRightRectangleViewModel : RectangleViewModel
    {
        public override double CanvasOffsetX => RectangleWidth / -2;
        public override double CanvasOffsetY => RectangleHeight / -2;

        public override double CircleX => CanvasOffsetX - (CircleRadius / 2);
        public override double CircleY => CanvasOffsetY + (CircleRadius / 2);

        public LowerRightRectangleViewModel() : base(Quadrants.LowerRight, Container.Current)
        {
            //
        }
    }
}
