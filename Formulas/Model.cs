using System;

namespace Formulas
{
    public class Par
    {
        public Par(double Y, double y, double tm, double tg, double delta_t)
        {
            this.Y = Y;
            this.y = y;
            this.tm = tm;
            this.tg = tg;
            this.delta_t = delta_t;
        }
        double Y;
        double y;
        double tg;
        double tm;
        double delta_t;
    }
    public class Model
    {
        public double h;
        public double T_material;
        public double T_gas;
        public double C_gas;
        public double C_material;
        public double G;
        public double d;
        public double w;
        public int av;
        public double yo;
        public Model(double h = 5, double T_material = 10, double T_gas = 650, double C_gas = 1.35, double C_material = 1.49, double G = 1.68, double d = 2.2, double w = 0.74, int av = 2440)
        {
            this.h = h;
            this.T_material = T_material;
            this.T_gas = T_gas;
            this.C_gas = C_gas;
            this.C_material = C_material;
            this.G = G;
            this.d = d;
            this.w = w;
            this.av = av;

            yo = Height(h);

        }
        public double M()
        {
            double r = d / 2;
            return C_material * G / (w * Math.Pow(r, 2));
        }
        public double Height(double y)
        {
            return av * h / (w * C_gas);
        }
        public double RelHeight1(double y)
        {
            return 1 - Math.Exp((M() - 1) * Height(y) / M());
        }
        public double RelHeight2(double y)
        {
            return 1 - M() * Math.Exp((M() - 1) * Height(y) / M());
        }
        public double nu(double y)
        {
            return (1 - RelHeight1(y)) / (1 - M() * Math.Exp((M() - 1) * yo / M()));
        }
        public double omega(double y)
        {
            return (1 - RelHeight2(y)) / (1 - M() * Math.Exp((M() - 1) * yo / M()));
        }
        public double t(double y)
        {
            return T_material + (T_gas - T_material) * nu(y);
        }
        public double T(double y)
        {
            return T_material + (T_gas - T_material) * omega(y);
        }
        public double delta_T(double y)
        {
            return T(y) - t(y);
        }
    }
}
//int h = 5;
//int T_material = 10;
//int T_gas = 650
//double C_gas = 1.35;
//double C_material = 1.49;
//double G = 1.68;
//double d = 2.2
//double w = 0.74;
//double av = 2440
