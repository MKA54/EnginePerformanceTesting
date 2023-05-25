namespace EnginePerformanceTesting.Model.Engines
{
    public class InternalCombustionEngine
    {
        private double _I;
        private double[] _M;
        private double[] _V;
        private double _Hm;
        private double _Hv;
        private double _C;
        private double _TOverheat;

        public InternalCombustionEngine(double I, double[] M, double[] V, double Hm, double Hv, double C, double TOverheat)
        {
            _I = I;
            _M = M;
            _V = V;

            if (M.Length == 0)
            {
                throw new ArgumentException("Array M is empty.");
            }

            if (V.Length == 0)
            {
                throw new ArgumentException("Array V is empty.");
            }

            if (M.Length != V.Length)
            {
                throw new ArgumentException("Arrays have different sizes: M - " + M.Length + ", V - " + V.Length + ".");
            }

            _Hm = Hm;
            _Hv = Hv;
            _C = C;
            _TOverheat = TOverheat;
        }

        public double I { get => _I; set => _I = value; }
        public double[] M { get => _M; set => _M = value; }
        public double[] V { get => _V; set => _V = value; }
        public double Hm { get => _Hm; set => _Hm = value; }
        public double Hv { get => _Hv; set => _Hv = value; }
        public double C { get => _C; set => _C = value; }
        public double TOverheat { get => _TOverheat; set => _TOverheat = value; }
    }
}