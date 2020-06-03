using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3a_Brief_Stathis_Kanellis
{
    abstract class Variation
    {
        public abstract decimal Cost(TShirt tshirt);
    }

    class ColorVariation : Variation
    {
        private static Dictionary<Color, decimal> _colorCosts;

        static ColorVariation()
        {
            _colorCosts = new Dictionary<Color, decimal>()
            {
                  { Color.blue, +1m },
                  { Color.green, +0.5m },
                  { Color.indigo, +0.9m },
                  { Color.orange, +0.5m },
                  { Color.red, +1.1m },
                  { Color.violet, +1.5m },
                  { Color.yellow, +2m }
            };
        }

        public override decimal Cost(TShirt tshirt)
        {
            tshirt.Price += _colorCosts[tshirt.Color];
            return tshirt.Price;
        }
    }

    class SizeVariation : Variation
    {
        private static Dictionary<Size, decimal> _sizeCosts;

        static SizeVariation()
        {
            _sizeCosts = new Dictionary<Size, decimal>()
            {
                  { Size.XS, +1m },
                  { Size.S, +0.5m },
                  { Size.M, +0.9m },
                  { Size.L, +0.5m },
                  { Size.XL, +1.1m },
                  { Size.XXL, +1.5m },
                  { Size.XXXL, +2m }
            };
        }

        public override decimal Cost(TShirt tshirt)
        {
            tshirt.Price += _sizeCosts[tshirt.Size];
            return tshirt.Price;
        }
    }

    class FabricVariation : Variation
    {
        private static Dictionary<Fabric, decimal> _fabricVariations;

        static FabricVariation()
        {
            _fabricVariations = new Dictionary<Fabric, decimal>()
            {
                { Fabric.cashmere, +7m },
                { Fabric.cotton, +6m },
                { Fabric.linen, +4.5m },
                { Fabric.polyester, +3.9m },
                { Fabric.rayon, +4.1m },
                { Fabric.silk, +5.5m },
                { Fabric.wool, 2.3m }
            };
        }

        public override decimal Cost(TShirt tshirt)
        {
            tshirt.Price += _fabricVariations[tshirt.Fabric];
            return tshirt.Price;
        }
    }
}
