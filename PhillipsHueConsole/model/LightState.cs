using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test.model;

namespace PhillipsHueConsole.model {
    public class LightState {
        public HueComponent Component { get; set; }

        public bool On { get; set; }        
        public int Bri { get; set; }        // Brightness  
        public int Hue { get; set; }        
        public int Sat { get; set; }        // Saturation
        public string Effect { get; set; }  
        public double[] XY { get; set; }

        public override string ToString() {
            return $"On: {On}\nBri: {Bri}\nHue: {Hue}\nSat: {Sat}\nEffect: {Effect}\nXY: [{XY[0]}, {XY[1]}]";
        }
    }

}
