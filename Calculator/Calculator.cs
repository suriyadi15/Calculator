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
        private string inp { set; get; } //Declare string input for menampung masukkan
        private ArrayList arr;
        public Calculator(string inp,ArrayList arr)  //declare Constructore
        {
            this.inp = inp;
            this.arr = arr;
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
        public void convert()
        {
            if (validasi(inp)) //cek validasi TRUE atau False
            {
                string tmp = "";  //untuk tempat sementara bilangan
                if (inp[0] != '(')
                    tmp += inp[0];
                else
                    arr.Add(inp[0]);
                for (int i = 1; i < inp.Length; i++) //for dari inp[1] bukan inp[0]
                {
                    if (inp[i] == '^' || inp[i] == '*' || inp[i] == '/' || inp[i] == '+' || inp[i] == '(' || inp[i] == ')')
                    {
                        if(tmp!="")
                            arr.Add(Convert.ToDouble(tmp));
                        tmp = "";
                        arr.Add(inp[i]);
                    }
                    else if (inp[i] == '-')
                    {
                        if (inp[i - 1] == '^' || inp[i - 1] == '*' || inp[i - 1] == '/' || inp[i - 1] == '+')
                            tmp += inp[i];
                        else
                            arr.Add(inp[i]);
                    }
                    else
                        tmp += inp[i];
                }
                if (tmp != "")
                    arr.Add(Convert.ToDouble(tmp));
            }
            else
                Console.WriteLine("Error!!!...");
        }
        private double hitung(double op1, double op2, char op) //Fungsi Perhitungan ^,*,/,+,-
        {
            if (op == '^')
            {
                double tmp=op1;
                for (int i = 2; i <= op2;i++)
                    tmp *= op1;
                return tmp;
            }
            else if(op=='*')
                return op1*op2;
            else if(op=='/')
                return op1/op2;
            else if(op=='+')
                return op1+op2;
            else
                return op1-op2;
        }
        private int prioritas(int start, int end) //Mengambil posisi Prioritas operator 
        {
            if (arr.IndexOf('^', start, end - start) != -1)
                return arr.IndexOf('^', start, end - start);
            else if(arr.IndexOf('*', start, end - start) != -1)
                return arr.IndexOf('*', start, end - start);
            else if (arr.IndexOf('/', start, end - start) != -1)
                return arr.IndexOf('/', start, end - start);
            else if (arr.IndexOf('+', start, end - start) != -1)
                return arr.IndexOf('+', start, end - start);
            else
                return arr.IndexOf('-', start, end - start);
        }
        public void tampil()
        {
            for (int i = 0; i < arr.Count; i++)
                Console.Write("{0}", arr[i]);
            Console.WriteLine();
        }
        private void cekKali()  //Untuk mengecek input * mis 2(2-2), akan diubah menjadi 2*(2-2)
        {
            int tmp = arr.IndexOf('(');
            while (tmp != -1)
            {
                if ((char)arr[tmp - 1] != '(' && (char)arr[tmp - 1] != '^' && (char)arr[tmp - 1] != '*' && (char)arr[tmp - 1] != '/' && (char)arr[tmp - 1] != '+' && (char)arr[tmp - 1] != '-')
                {
                    arr.Insert(tmp, '*');
                    tmp++;
                }
                tmp = arr.IndexOf('(', tmp + 1);
            }
            tmp = arr.LastIndexOf(')', arr.Count - 2);
            while (tmp != -1)
            {
                if ((char)arr[tmp +1] != ')' && (char)arr[tmp + 1] != '^' && (char)arr[tmp + 1] != '*' && (char)arr[tmp + 1] != '/' && (char)arr[tmp + 1] != '+' && (char)arr[tmp + 1] != '-')
                {
                    arr.Insert(tmp+1, '*');
                    tmp--;
                }
                tmp = arr.LastIndexOf(')', tmp - 1);
            }
        }
        public void aritmatika()
        {
            cekKali();
            bool cekKurung;
            if (arr.IndexOf('(') != -1)
                cekKurung = true;
            else
                cekKurung = false;
            while (cekKurung == true)
            {
                int bKurung = arr.LastIndexOf('(');
                int tKurung = arr.IndexOf(')', bKurung);
                int pos;
                while (tKurung - bKurung > 2)
                {
                    pos = prioritas(bKurung + 1, tKurung - 1);
                    arr[pos - 1] = hitung(Convert.ToDouble(arr[pos - 1]), Convert.ToDouble(arr[pos + 1]), (char)arr[pos]);
                    arr.RemoveAt(pos);
                    arr.RemoveAt(pos);
                    tKurung = arr.IndexOf(')', bKurung);
                    tampil();
                }
                arr.RemoveAt(tKurung);
                arr.RemoveAt(bKurung);
                if (arr.IndexOf('(') != -1)
                    cekKurung = true;
                else
                    cekKurung = false;
            }
            while (arr.Count != 1)
            {
                int pos = prioritas(0, arr.Count);
                arr[pos - 1] = hitung(Convert.ToDouble(arr[pos - 1]), Convert.ToDouble(arr[pos + 1]), (char)arr[pos]);
                arr.RemoveAt(pos);
                arr.RemoveAt(pos);
                tampil();
            }
        }
    }
}
