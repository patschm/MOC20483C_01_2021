using System;
using System.Windows.Forms;

namespace EventDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Form f1 = new Form();
            f1.Text = "Hallo";

            Button btn = new Button();
            btn.Text = "Click me";
            btn.Location = new System.Drawing.Point(50, 50);
            f1.Controls.Add(btn);

            btn.Click += KlikMij;

            f1.ShowDialog();
            Console.ReadLine();
        }

        private static void KlikMij(object sender, EventArgs e)
        {
            Button snd = sender as Button;
            snd.Parent.BackColor = System.Drawing.Color.Red;
            //Console.WriteLine("Hallo");
        }
    }
}
