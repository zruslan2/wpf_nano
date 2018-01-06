using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Diagnostics;



namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }
        
        Stopwatch sw = new Stopwatch();
        string path = @"E:\mas.txt";
        int[] mas = new int[10000];
        double[] vrem = new double[5];
        long sum=0;
        private void button_Click(object sender, RoutedEventArgs e)
        {
            using (StreamReader sr = File.OpenText(path))
            {
                sw.Start();
                String Line;
                while ((Line = sr.ReadLine()) != null)
                {
                    textBox.Text += Line+"\n";                    
                }
                sr.Close();
                sw.Stop();
                vrem[0] = sw.ElapsedMilliseconds;
                label.Content = "Файл открылся за " + sw.ElapsedMilliseconds + " миллисекунд";
            }

        }
       
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            using (StreamReader sr = File.OpenText(path))
            {
                sw.Restart();
                string Line;
                int j = 0;
                while ((Line = sr.ReadLine()) != null)
                {
                    mas[j] = Convert.ToInt32(Line);
                    j++;
                }
                //for (int i = 0; i < 10000; i++)
                //{
                //    textBox1.Text += mas[i] + "\n";
                //}
                sr.Close();
                sw.Stop();
                double ticks = sw.ElapsedTicks;
                double nanoseconds = (ticks / Stopwatch.Frequency) * 1000000000;
                vrem[1] = Convert.ToUInt32(nanoseconds);
                label1.Content = "Массив загрузился за " + Convert.ToUInt32(nanoseconds) + " нансекунд";
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            sw.Restart();
            for (int i = 0; i < 10000; i++)
            {
                sum += mas[i];
            }
            textBox1.Text = Convert.ToString(sum);
            sw.Stop();
            double ticks = sw.ElapsedTicks;
            double nanoseconds = (ticks / Stopwatch.Frequency) * 1000000000;
            vrem[2] = Convert.ToUInt32(nanoseconds);
            label2.Content = "Cумма всех чисел массива посчиталась за " + Convert.ToUInt32(nanoseconds) + " наносекунд";
            label3.Content = "Итого затраченное время " + sum_vr();
            
        }
        private double sum_vr()
        {
            double sum = 0;
            for(int i=0;i<=5;i++)
            {
                sum += vrem[i];
            }
            return sum;
        }

    }
}
