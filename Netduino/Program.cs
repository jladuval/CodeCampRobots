using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

namespace Netduino
{
    public class Program
    {
        static OutputPort interuptLed = new OutputPort(Pins.ONBOARD_LED, false);
        
        public static void Main()
        {
            InterruptPort button = new InterruptPort(Pins.ONBOARD_BTN,
            false,
            Port.ResistorMode.Disabled,
            Port.InterruptMode.InterruptEdgeLow);
            button.OnInterrupt += new NativeEventHandler(button_OnInterrupt);

            InterruptPort hr = new InterruptPort(Pins.GPIO_PIN_D2,
                false,
                Port.ResistorMode.Disabled,
                Port.InterruptMode.InterruptEdgeLow);
            hr.OnInterrupt += new NativeEventHandler(hr_OnInterrupt);



            Thread.Sleep(Timeout.Infinite);
            //var led = new OutputPort(Pins.ONBOARD_LED, false);
            //var rotatary = new AnalogInput(AnalogChannels.ANALOG_PIN_A0);

            //while (true)
            //{
            //    led.Write(!led.Read());
                
            //    Thread.Sleep((int) rotatary.ReadRaw());
            //}


        }

        static void hr_OnInterrupt(uint data1, uint data2, DateTime time)
        {
            interuptLed.Write(true);
            Thread.Sleep(300);
            interuptLed.Write(false);
        }

        static void button_OnInterrupt(uint data1, uint data2, DateTime time)
        {
            interuptLed.Write(!interuptLed.Read());
        }
    }
}