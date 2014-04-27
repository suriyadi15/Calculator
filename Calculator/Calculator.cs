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
        public void convert(string inp, ArrayList arr)
        {
            if (validasi(input)) //cek validasi TRUE atau False
            {
                string tmp="";  //untuk tempat sementara bilangan
                if (inp[0] != '(')
                    tmp += inp[0];
                else
                    arr.Add(inp[0]);
                for (int i = 1; i < inp.Length; i++) //for dari inp[1] bukan inp[0]
                {
                    if(inp[i]=='^'||inp[i]=='*'||inp[i]=='/'||inp[i]=='+'||inp[i]=='('||inp[i]==')')
                    {
                        arr.Add(Convert.ToDouble(tmp));
                        tmp = "";
                        arr.Add(inp[i]);
                    }
                    else if(inp[i]=='-')
                    {
                        if(inp[i-1]=='^'||inp[i-1]=='*'||inp[i-1]=='/'||inp[i-1]=='+')
                            tmp+=inp[i];
                        else
                            arr.Add(inp[i]);
                    }
                    else
                        tmp+=inp[i];
                }
                if (tmp != "")
                    arr.Add(Convert.ToDouble(tmp));
            }
            else
                Console.WriteLine("Error!!!...");
        }

    }
}
