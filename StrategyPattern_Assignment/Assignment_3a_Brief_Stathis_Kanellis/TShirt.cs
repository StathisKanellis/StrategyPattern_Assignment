using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3a_Brief_Stathis_Kanellis
{
    class TShirt
    {
        public readonly Color Color;
        public readonly Size Size;
        public readonly Fabric Fabric;

        public decimal Price { get; set; }

        public TShirt(Color color, Size size, Fabric fabric)
        {
            Color = color;
            Size = size;
            Fabric = fabric;
        }
    }

    enum Color
    {
        red,
        orange,
        yellow,
        green,
        blue,
        indigo,
        violet
    }
    enum Size
    {
        XS,
        S,
        M,
        L,
        XL,
        XXL,
        XXXL
    }
    enum Fabric
    {
        wool,
        cotton,
        polyester,
        rayon,
        linen,
        cashmere,
        silk
    }
}
