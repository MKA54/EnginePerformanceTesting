using EnginePerformanceTesting.Model.Engines;

namespace EnginePerformanceTesting.Stands
{
    public static class HeatingStand
    { 
        public static int TimeToOverheatInternalCombustion(InternalCombustionEngine engine, double TAir)
        {
            var TEngine = TAir;

            var workingHours = 0;
            var i = 0;

            while (i < engine.M.Length)
            {
                var a = FindAcceleration(engine.M[i], engine.I);
                TEngine += FindVh(engine.M[i], engine.V[i] + a, engine.Hm, engine.Hv) - FindVc(TAir, TEngine, engine.C);

                if (TEngine >= engine.TOverheat)
                {
                    return workingHours;
                }

                workingHours++;
                i++;
            }

            return 0;
        }

        private static double FindVh(double M, double V, double Hm, double Hv) => M * Hm + Math.Pow(V, 2) * Hv;
        private static double FindVc(double TAir, double TEngine, double C) => C * (TAir - TEngine);
        private static double FindAcceleration(double M, double I) => M / I;
    }
}