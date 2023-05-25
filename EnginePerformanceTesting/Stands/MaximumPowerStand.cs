using EnginePerformanceTesting.Model.Engines;

namespace EnginePerformanceTesting.Stands
{
    public static class MaximumPowerStand
    {
        public static Dictionary<string, double> MaxPowerAndCrankshaftSpeedInternalCombustion(InternalCombustionEngine engine)
        {
            var result = new Dictionary<string, double>();

            var maxPower = 0.0;
            var crankshaftSpeed = 0.0;
            var currentM = 0.0;
            var previousM = 0.0;

            var i = 0;

            while (i < engine.M.Length)
            {
                currentM = engine.M[i];

                if (currentM < previousM)
                {
                    break;
                }

                var currentPower = FindEnginePower(currentM, engine.V[i]);

                if (currentPower > maxPower)
                {
                    maxPower = currentPower;
                    crankshaftSpeed = engine.V[i];
                }


                previousM = currentM;
                i++;
            }

            result.Add("MaxPower", maxPower);
            result.Add("CrankshaftSpeed", crankshaftSpeed);

            return result;
        }

        private static double FindEnginePower(double M, double V) => M * V / 1000;
    }
}