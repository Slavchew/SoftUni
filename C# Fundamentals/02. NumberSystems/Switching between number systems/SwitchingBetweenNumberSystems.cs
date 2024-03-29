﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Switching_between_number_systems
{
/* Задача 1.
   - Преобразувайте 1234 (10) в двоична и шестнадесетична бройна системи. 
   - Преобразувайте 1100101 (2) в десетична и шестнадесетична бройна системи. 
   - Преобразувайте ABC (16) в десетично и двоична бройна системи.
*/
    class SwitchingBetweenNumberSystems
    {
        // Конвертор от десетично в двоично
        static string dec2bin(int number)
        {
            string binary = string.Empty;
            while (number > 0)
            {
                int reminder = number % 2;
                number /= 2;
                binary += reminder;
            }
            // Обръщане
            char[] reverse = binary.ToCharArray();
            Array.Reverse(reverse);
            return new string(reverse);
        }

        // Конвертор от десетично в шестнадесетично
        static string dec2hex(int number)
        {
            string hex = string.Empty;
            while (number > 0)
            {
                int reminder = number % 16;
                number /= 16;
                if (reminder > 9) hex += (char)(reminder + 55);
                else hex += reminder.ToString();
            }
            // Обръщане
            char[] reverse = hex.ToCharArray();
            Array.Reverse(reverse);
            return new string(reverse);
        }

        // Конвертиране от двоично в десетично
        static int bin2dec(string bin)
        {
            int result = 0, pow = 0;
            for (int i = bin.Length - 1; i >= 0; i--)
            {
                var A = int.Parse(bin[i].ToString());
                result += (int)(A * Math.Pow(2, pow));
                pow++;
            }
            return result;
        }

        // Конвертиране от двоично в шестнадесетично
        static string bin2hex(string bin)
        {
            string hex = String.Empty;
            // Цепим двоичното число на по четири бита            
            while (bin.Length >= 4)
            {
                string sub = bin.Substring(bin.Length - 4, 4);
                switch (sub)
                {
                    case "0000": hex += "0"; break;
                    case "0001": hex += "1"; break;
                    case "0010": hex += "2"; break;
                    case "0011": hex += "3"; break;
                    case "0100": hex += "4"; break;
                    case "0101": hex += "5"; break;
                    case "0110": hex += "6"; break;
                    case "0111": hex += "7"; break;
                    case "1000": hex += "8"; break;
                    case "1001": hex += "9"; break;
                    case "1010": hex += "A"; break;
                    case "1011": hex += "B"; break;
                    case "1100": hex += "C"; break;
                    case "1101": hex += "D"; break;
                    case "1110": hex += "E"; break;
                    case "1111": hex += "F"; break;
                }
                bin = bin.Substring(0, bin.Length - 4);
            }
            // На остатък след цепенето добавяме нужния брой нули отпред
            switch (bin.Length)
            {
                case 0: bin = "0000"; break;
                case 1: bin = "000" + bin; break;
                case 2: bin = "00" + bin; break;
                case 3: bin = "0" + bin; break;
            }
            switch (bin)
            {
                case "0000": hex += "0"; break;
                case "0001": hex += "1"; break;
                case "0010": hex += "2"; break;
                case "0011": hex += "3"; break;
                case "0100": hex += "4"; break;
                case "0101": hex += "5"; break;
                case "0110": hex += "6"; break;
                case "0111": hex += "7"; break;
                case "1000": hex += "8"; break;
                case "1001": hex += "9"; break;
                case "1010": hex += "A"; break;
                case "1011": hex += "B"; break;
                case "1100": hex += "C"; break;
                case "1101": hex += "D"; break;
                case "1110": hex += "E"; break;
                case "1111": hex += "F"; break;
            }
            // Обръщане
            char[] reverse = hex.ToCharArray();
            Array.Reverse(reverse);
            return new string(reverse);
        }

        // Конвертор от шестнадесетично в двоично
        static string hex2bin(string hex)
        {
            string bin = String.Empty;
            for (int i = 0; i < hex.Length; i++)
                switch (hex[i])
                {
                    case '0': bin += "0000"; break;
                    case '1': bin += "0001"; break;
                    case '2': bin += "0010"; break;
                    case '3': bin += "0011"; break;
                    case '4': bin += "0100"; break;
                    case '5': bin += "0101"; break;
                    case '6': bin += "0110"; break;
                    case '7': bin += "0111"; break;
                    case '8': bin += "1000"; break;
                    case '9': bin += "1001"; break;
                    case 'A': bin += "1010"; break;
                    case 'B': bin += "1011"; break;
                    case 'C': bin += "1100"; break;
                    case 'D': bin += "1101"; break;
                    case 'E': bin += "1110"; break;
                    case 'F': bin += "1111"; break;
                }
            return bin;
        }

        // Конвертор от шестнадесетично в десетично 
        static int hex2dec(string hex)
        {
            string bin = hex2bin(hex);
            return bin2dec(bin);
        }


        static void Main(string[] args)
        {

            // (10) -> (2), (10) -> (16)
            Console.WriteLine("{0} (10) = {1} (2)", 1234, dec2bin(1234));
            Console.WriteLine("{0} (10) = {1} (16)", 1234, dec2hex(1234));

            // (2) -> (10), (2) -> (16)
            Console.WriteLine("{0} (2) = {1} (10)", "1100101", bin2dec("1100101"));
            Console.WriteLine("{0} (2) = {1} (16)", "1100101", bin2hex("1100101"));

            // (16) -> (10), (16) -> (2)
            Console.WriteLine("{0} (16) = {1} (10)", "ABC", hex2dec("ABC"));
            Console.WriteLine("{0} (16) = {1} (2)", "ABC", hex2bin("ABC"));
        }
    }
}
