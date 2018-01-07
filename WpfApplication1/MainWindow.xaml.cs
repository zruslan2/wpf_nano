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
        long proizv = 1;
        int[] masp = new int[10000];
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
                double ticks = sw.ElapsedTicks;
                double nanoseconds = (ticks / Stopwatch.Frequency) * 1000000000;
                vrem[0] = Convert.ToUInt64(nanoseconds);
                label.Content = "Файл открылся за " + Convert.ToUInt64(nanoseconds) + " миллисекунд";
                double sum1 = 0;
                for (int i = 0; i < 5; i++)
                {
                    sum1 += vrem[i];
                }
                label3.Content = "Итого затраченное время " + sum1 + " нансекунд";
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
                vrem[1] = Convert.ToUInt64(nanoseconds);
                label1.Content = "Массив загрузился за " + Convert.ToUInt64(nanoseconds) + " нансекунд";
                double sum1 = 0;
                for (int i = 0; i < 5; i++)
                {
                    sum1 += vrem[i];
                }
                label3.Content = "Итого затраченное время " + sum1 + " нансекунд";
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
            vrem[2] = Convert.ToUInt64(nanoseconds);
            label2.Content = "Cумма всех чисел массива посчиталась за " + Convert.ToUInt64(nanoseconds) + " наносекунд";
            double sum1 = 0;
            for (int i = 0; i < 5; i++)
            {
                sum1 += vrem[i];
            }
            label3.Content = "Итого затраченное время " + sum1 + " нансекунд";
            
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            sw.Restart();
            for (int i = 0; i < 10000; i++)
            {
                masp[i] = mas[i] * 3;
            }
            textBox1.Text = Convert.ToString(proizv);
            sw.Stop();
            double ticks = sw.ElapsedTicks;
            double nanoseconds = (ticks / Stopwatch.Frequency) * 1000000000;
            vrem[3] = Convert.ToUInt64(nanoseconds);
            label4.Content = "Произведение всех чисел массива посчиталась за " + Convert.ToUInt64(nanoseconds) + " наносекунд";
            double sum1 = 0;
            for (int i = 0; i < 5; i++)
            {
                sum1 += vrem[i];
            }
            label3.Content = "Итого затраченное время " + sum1 + " нансекунд";
        }
    }
}
