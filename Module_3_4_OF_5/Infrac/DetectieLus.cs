using IEEE;
using System;
using System.Collections.Generic;

namespace Infrac
{
    public delegate void DetectorAction();

    public class DetectieLus
    {
        private List<IDetectable> devices = new List<IDetectable>();
        private List<Action> deviceDels = new List<Action>();

        public void Connect(Action device)
        {
            deviceDels.Add(device);
        }
        public void Connect(IDetectable device)
        {
            devices.Add(device);
        }

        public void Detect()
        {
            Console.WriteLine("Detectielus ziet iets");
            foreach (var del in deviceDels)
            {
                try
                {
                    del();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            foreach (IDetectable device in devices)
            {
                device.OnDetect();
            }
        }
    }
}
