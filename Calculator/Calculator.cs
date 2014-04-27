using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace Calculator
{
    class Calculator
    {
        private string input { set; get; } //Declare string input for menampung masukkan
        private ArrayList data = new ArrayList();
        public Calculator(string inp)  //declare Constructore
        {
            input = inp;
        }
        private bool validasi(string inp)
        {
            bool cekTrue = true;
            if (inp == "")  //Validasi
            {
                Console.WriteLine("Input False");
                cekTrue = false;
            }
            else  //Validasi
                foreach (char i in inp)
                {
                    if (Char.IsLetter(i))
                    {
                        Console.WriteLine("Input False");
                        cekTrue = false;
                        break;
                    }
                    else if (char.IsWhiteSpace(i))
                    {
                        Console.WriteLine("Input False");
                        cekTrue = false;
                        break;
                    }
                }
            return cekTrue;
        }

    }
}
