using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerSchubse
{
    public abstract class Container
    {
        /// <summary>
        /// Außenmaße (Breite) des Containers in Millimetern.
        /// </summary>
        public abstract int Width { get; }

        /// <summary>
        /// Außenmaße (Länge) des Containers in Millimetern.
        /// </summary>
        public abstract int Length { get; }

        public static Container Current => Container40Feet.Instance;
    }

    public class Container40Feet : Container
    {
        public override int Width => 12192;

        public override int Length => 2438;

        private Container40Feet()
        {
            //
        }

        public static Container40Feet Instance = new Container40Feet();
    }

    public class Container20Feet : Container
    {
        public override int Width => 6058;
        public override int Length => 2438;

        private Container20Feet()
        {
            //
        }

        public static Container20Feet Instance => new Container20Feet();
    }
}
