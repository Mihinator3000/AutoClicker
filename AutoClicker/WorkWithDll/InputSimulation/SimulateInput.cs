﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AutoClicker.WorkWithDll.InputSimulation
{
    public class SimulateInput
    {
        [DllImport("user32.dll")]
        private static extern void SendInput(
            uint nInputs,
            [MarshalAs(UnmanagedType.LPArray), In] Input[] pInputs,
            int cbSize);

        public static void SimpleMouseEvent(MouseMessages mouseMessage)
        {
            var input = new Input
            {
                type = 0
            };
            input.U.mi.DwFlags = mouseMessage;
            SendInput(1, new[] { input }, Input.Size);
        }


        private const uint WheelValue = 60;
        public static void MouseEvent(MouseMessages mouseMessage)
        {
            if (MouseActions.ClicksDictionary.ContainsKey(mouseMessage))
            {
                MouseActions.MouseClick(mouseMessage);
                return;
            }

            var input = new Input
            {
                type = 0
            };

            switch (mouseMessage)
            {
                case MouseMessages.WheelDown:
                    input.U.mi.DwFlags = MouseMessages.Wheel;
                    unchecked
                    {
                        input.U.mi.MouseData = (uint)(-WheelValue);
                    }
                    break;

                case MouseMessages.WheelUp:
                    input.U.mi.DwFlags = MouseMessages.Wheel;
                    input.U.mi.MouseData = WheelValue;
                    break;

                default:
                    input.U.mi.DwFlags = mouseMessage;
                    break;
            }

            SendInput(1, new [] {input}, Input.Size);
        }

        private static KeyEventF GetEvent(bool keyDown)
        {
            return keyDown ? KeyEventF.KeyDown : KeyEventF.KeyUp;
        }

        public static void KeyboardEvent(Key key)
        {
            KeyboardEvent(key, true);
            KeyboardEvent(key, false);
        }
        public static void KeyboardEvent(Key key, bool keyDown)
        {
            var input = new Input
            {
                type = 1
            };      
            input.U.ki.wVk = (short) KeyInterop.VirtualKeyFromKey(key);
            input.U.ki.dwFlags = GetEvent(keyDown);

            SendInput(1, new [] { input }, Input.Size);
        }

        public static void KeyboardEvent(char c)
        {
            KeyboardEvent(c, true);
            KeyboardEvent(c, false);
        }
        public static void KeyboardEvent(char c, bool keyDown)
        {
            var input = new Input
            {
                type = 1
            };
            input.U.ki.wScan = (short)c;
            input.U.ki.dwFlags = KeyEventF.Unicode | GetEvent(keyDown);

            SendInput(1, new [] { input }, Input.Size);
        }
    /*    public static void SendInputWithAPI(Key k)
        {
            Input[] Inputs = new Input[1];
            Input Input = new Input();

            Input.type = 1; // 1 = Keyboard Input
            Input.U.ki.wVk = (short)KeyInterop.VirtualKeyFromKey(k);
            //Input.U.ki.wScan = KeyInterop.VirtualKeyFromKey(k);
            Input.U.ki.dwFlags = KeyEventF.Unicode;
            Inputs[0] = Input;


            SendInput(1, Inputs, Input.Size);
        }

        public static void SendInputWithAPI(char c)
        {
            Input[] Inputs = new Input[1];
            Input Input = new Input();

            *//*Input.type = 0;
            Input.U.mi.dwFlags = MOUSEEVENTF.LEFTDOWN;*//*
            Input.U.ki.wScan = (short)c;
            Input.type = 1; // 1 = Keyboard Input
            Input.U.ki.dwFlags = KeyEventF.Unicode;
            //Input.U.ki.wVk = (short)KeyInterop.VirtualKeyFromKey(k);
            //Input.U.ki.wScan = KeyInterop.VirtualKeyFromKey(k);
            //Input.U.ki.dwFlags = KEYEVENTF.UNICODE;
            Inputs[0] = Input;


            SendInput(1, Inputs, Input.Size);
        }
*/
       /* public static void SendInputWithAPI(MouseMessages s)
        {
            Input[] Inputs = new Input[1];
            Input Input = new Input();
            unchecked
            {
                Input.type = 0;
                Input.U.mi.DwFlags = s;
                Input.U.mi.MouseData = (uint)(-120);
                Inputs[0] = Input;
            }


            SendInput(1, Inputs, Input.Size);
        }*/
    }
}