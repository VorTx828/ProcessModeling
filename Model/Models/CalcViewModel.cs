using Formulas;

namespace Model.Models
{
    public class CalcViewModel
    {
        public CalcViewModel(List<Par> Result, double C_gas, double C_material, double G, double d, double W, double av) {
            this.Result = Result;
            this.C_gas = C_gas;
            this.C_material = C_material;
            this.G = G;
            this.d= d;
            this.W = W;
            this.av = av;

        }
        public List<Par> Result { get; set; }
        public List<double> TempMat { get; set; } = [260, 200, 170, 150];
        public List<double> TempGas { get; set; } = [260, 200, 170, 150];

        public List<double> x { get; set; } = [260, 200, 170, 150];

        public List <double> DeltaT { get; set; }
        public double C_gas { get; set; }
        public double C_material { get; set; }
        public double G { get; set; }
        public double d { get; set; }
        public double W { get; set; }
        public double av { get; set; }
    }
}
