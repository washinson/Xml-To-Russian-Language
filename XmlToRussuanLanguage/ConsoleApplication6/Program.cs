using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RavSoft.GoogleTranslator;
using System.IO;
using System.Text;

namespace ConsoleApplication6
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length<1){  Console.WriteLine("cant");  return;  }
            string ttt = args[0];
            //string ttt = "strings.xml";
            StreamReader reader = new StreamReader(ttt, new UTF8Encoding(false));
            StreamWriter writer = new StreamWriter(ttt+"1", false, new UTF8Encoding(false));
            Translator translate = new Translator();
            //string tt = t.Translate("Profile selected: %1$s \n Remove profile %1$s?", "English", "Russian");
            while (!reader.EndOfStream)
            {
                string str = reader.ReadLine();
                if(str.Contains("<string"))
                {
                    int l = 0;
                    for (; str[l] != '>'; l++) ;
                    if (str.Substring(l - 1, 2) != "/>")
                    {
                        l++;
                        int r = l;
                        for (; str[r] != '<'; r++)
                        {
                            if (r == str.Length-1)
                            {
                                str += "\n" + reader.ReadLine();
                            }
                        }
                        string trt1 = str.Substring(l, r - l);
                        string trt2 = translate.Translate(trt1, "English", "Russian");
                        str = str.Substring(0, l) + trt2 + str.Substring(r, str.Length - r);
                    }
                }
                writer.WriteLine(str);
                writer.Flush();
            }
            
        }
    }
}
