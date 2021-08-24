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
        protected const double pixelsPerMeter = 1;

        protected double canvasWidth = 468;
        protected double canvasHeight = 297;

        public double CenterOffsetX { get; }
        public double CenterOffsetY { get; }
        public double RectangleWidth { get; } = 480;
        public double RectangleHeight { get; } = 94;
        public double CircleRadius { get; } = 10;

        private double measuredOffsetX;
        public double MeasuredOffsetX
        {
            get { return measuredOffsetX; }
            set { measuredOffsetX = value; OnPropertyChanged(); OnPropertyChanged(nameof(TotalOffsetX)); }
        }

        private double measuredOffsetY;
        public double MeasuredOffsetY
        {
            get { return measuredOffsetY; }
            set { measuredOffsetY = value; OnPropertyChanged(); OnPropertyChanged(nameof(TotalOffsetY)); }
        }

        public abstract double CanvasOffsetX { get; }
        public abstract double CanvasOffsetY { get; }

        public abstract double CircleX { get; }
        public abstract double CircleY { get; }

        public double TotalOffsetX
        {
            get { return CanvasOffsetX + MeasuredOffsetX; }
        }

        public double TotalOffsetY
        {
            get { return CanvasOffsetY + MeasuredOffsetY; }
        }

            
        private double rotation = 0;
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

        public RectangleViewModel(Quadrants quadrant)
        {
            this.Quadrant = quadrant;
        }

        protected double InMeter(double pixels) => pixels / pixelsPerMeter;
        protected double InPixels(double meters) => meters * pixelsPerMeter;
    }

    public class UpperLeftRectangleViewModel : RectangleViewModel
    {
        public override double CanvasOffsetX => canvasWidth - (RectangleWidth / 2);
        public override double CanvasOffsetY => canvasHeight - (RectangleHeight / 2);

        public override double CircleX => CanvasOffsetX - (CircleRadius / 2);
        public override double CircleY => CanvasOffsetY - (CircleRadius / 2);


        public UpperLeftRectangleViewModel() : base(Quadrants.UpperLeft)
        {
            //
        }
    }

    public class UpperRightRectangleViewModel : RectangleViewModel
    {
        public override double CanvasOffsetX => RectangleWidth / -2;
        public override double CanvasOffsetY => canvasHeight - (RectangleHeight / 2);

        public override double CircleX => CanvasOffsetX + (CircleRadius / 2);
        public override double CircleY => CanvasOffsetY - (CircleRadius / 2);

        public UpperRightRectangleViewModel() : base(Quadrants.UpperRight)
        {
            //
        }
    }

    public class LowerLeftRectangleViewModel : RectangleViewModel
    {
        public override double CanvasOffsetX => canvasWidth - (RectangleWidth / 2);
        public override double CanvasOffsetY => RectangleHeight / -2;

        public override double CircleX => CanvasOffsetX - (CircleRadius / 2);
        public override double CircleY => CanvasOffsetY + (CircleRadius / 2);

        public LowerLeftRectangleViewModel() : base(Quadrants.LowerLeft)
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

        public LowerRightRectangleViewModel() : base(Quadrants.LowerRight)
        {
            //
        }
    }
}
