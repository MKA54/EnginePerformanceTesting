using EnginePerformanceTesting.Model.Engines;
using EnginePerformanceTesting.Stands;

var I = 10.0;
var M = new[] { 20.0, 75.0, 100.0, 105.0, 75.0, 0.0 };
var V = new[] { 0.0, 75.0, 150.0, 200.0, 250.0, 300.0 };
var Hm = 0.01;
var Hv = 0.0001;
var C = 0.1;
var TOverheat = 110.0;

var engine = new InternalCombustionEngine(I, M, V, Hm, Hv, C, TOverheat);

Console.WriteLine("Тест нагрева двигателя внутреннего сгорания:");
Console.Write("Введите температуру окружающего воздуха: ");
var ambientTemperature = Convert.ToInt32(Console.ReadLine()); // T(окружающего воздуха)
var time = HeatingStand.TimeToOverheatInternalCombustion(engine, ambientTemperature);

if (time > 0)
{
    Console.WriteLine("Время работы двигателя до перегрева: " + time + " сек.");
}
else
{
    Console.WriteLine("Двигатель не перегревается.");
}

var maxPowerAndCrankshaftSpeed = MaximumPowerStand.MaxPowerAndCrankshaftSpeedInternalCombustion(engine);

Console.WriteLine();
Console.WriteLine("Тест максимальной мощности двигателя внутреннего сгорания:");
foreach (var parameter in maxPowerAndCrankshaftSpeed)
{
    Console.WriteLine($"parameter: {parameter.Key}  value: {parameter.Value}");
}