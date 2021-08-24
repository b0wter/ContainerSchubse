using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerSchubse
{
    public enum Quadrants
    {
        UpperLeft,
        UpperRight,
        LowerLeft,
        LowerRight
    }

    public class MainViewModel : BaseViewModel
    {
        private RectangleViewModel upperLeftModel = new UpperLeftRectangleViewModel();
        private RectangleViewModel lowerLeftModel = new LowerLeftRectangleViewModel();
        private RectangleViewModel upperRightModel = new UpperRightRectangleViewModel();
        private RectangleViewModel lowerRightModel = new LowerRightRectangleViewModel();

        public RectangleViewModel UpperLeftModel
        {
            get
            {
                return upperLeftModel;
            }
            set
            {
                upperLeftModel = value;
                OnPropertyChanged();
            }
        }
        public RectangleViewModel LowerLeftModel
        {
            get
            {
                return lowerLeftModel;
            }
            set
            {
                lowerLeftModel = value;
                OnPropertyChanged();
            }
        }
        public RectangleViewModel UpperRightModel
        {
            get
            {
                return upperRightModel;
            }
            set
            {
                upperRightModel = value;
                OnPropertyChanged();
            }
        }
        public RectangleViewModel LowerRightModel
        {
            get
            {
                return lowerRightModel;
            }
            set
            {
                lowerRightModel = value;
                OnPropertyChanged();
            }
        }
    }
}
