
using System;
using System.Numerics;
using FFTlib;
using ScottPlot;
using System.IO;

namespace Test9
{

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("====================================");
        Console.WriteLine("FFT / DSP Demonstration");
        Console.WriteLine("====================================");

        int nbechant = 256;
		
		Directory.CreateDirectory("output");

        // =========================================================
        // SIGNAL 1 : PURE SINUSOID
        // =========================================================

        Console.WriteLine("Generating sinusoidal signal...");

        decimal[] signal1 = SiTest.GenSin2piF(
            nbechant,
            1,
            50,
            1000
        );

        Complex[] Ts1 = DFT.DFTv2(signal1);

        decimal[] Module1 = DSP.Dspdeci(Ts1);

        double[] y1 = Array.ConvertAll(
            Module1,
            d => (double)d
        );

        int half1 = y1.Length / 2;

        double[] x1 = new double[half1];
        double[] y1half = new double[half1];

        for (int i = 0; i < half1; i++)
        {
            x1[i] = i;
            y1half[i] = y1[i];
        }

        var plt1 = new ScottPlot.Plot();

        plt1.Add.Scatter(x1, y1half);

        plt1.Title("DSP - Pure Sinusoidal Signal");

        plt1.XLabel("Frequency Bin");

        plt1.YLabel("Amplitude");

        plt1.SavePng("output/fft-sinus.png", 1200, 600);

        Console.WriteLine("PNG generated: fft-sinus.png");

        // =========================================================
        // SIGNAL 2 : GAUSSIAN / RANDOM SIGNAL
        // =========================================================

        Console.WriteLine("Generating random gaussian-like signal...");

        Random rnd = new Random();

        decimal[] signal2 = new decimal[nbechant];

        for (int i = 0; i < nbechant; i++)
        {
            // random centered noise
            double noise =
                (rnd.NextDouble() - 0.5) +
                (rnd.NextDouble() - 0.5) +
                (rnd.NextDouble() - 0.5);

            signal2[i] = (decimal)noise;
        }

        Complex[] Ts2 = DFT.DFTv2(signal2);

        decimal[] Module2 = DSP.Dspdeci(Ts2);

        double[] y2 = Array.ConvertAll(
            Module2,
            d => (double)d
        );

        int half2 = y2.Length / 2;

        double[] x2 = new double[half2];
        double[] y2half = new double[half2];

        for (int i = 0; i < half2; i++)
        {
            x2[i] = i;
            y2half[i] = y2[i];
        }

        var plt2 = new ScottPlot.Plot();

        plt2.Add.Scatter(x2, y2half);

        plt2.Title("DSP - Gaussian / Random Signal");

        plt2.XLabel("Frequency Bin");

        plt2.YLabel("Amplitude");

        plt2.SavePng("output/fft-gaussian.png", 1200, 600);

        Console.WriteLine("PNG generated: fft-gaussian.png");

        Console.WriteLine("====================================");
        Console.WriteLine("Processing complete.");
        Console.WriteLine("====================================");
    }
}



}