using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            decimal a = txtA.Value;
            decimal b = txtB.Value;

            //decimal result = LongAdd(a, b);
            //UpdateLabel(result);
            //var ctx = SynchronizationContext.Current;
            //var ctx = WindowsFormsSynchronizationContext.Current;

            //Task.Run(() => LongAdd(a, b))
            //    .ContinueWith(pt => {
            //        ctx.Post(UpdateLabel, pt.Result);
            //        //UpdateLabel(pt.Result);
            //    });

            decimal result = await LongAddAsync(a, b);//.ConfigureAwait(false);
            UpdateLabel(result);
        }

        private void UpdateLabel(object result)
        {
            lblAnswer.Text = result.ToString();
        }

        private decimal LongAdd(decimal a, decimal b)
        {
            Task.Delay(10000).Wait();
            return a + b;
        }
        private Task<decimal> LongAddAsync(decimal a, decimal b)
        {
            return Task.Run(() => LongAdd(a, b));
        }
    }
}
