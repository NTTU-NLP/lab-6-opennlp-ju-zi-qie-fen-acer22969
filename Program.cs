using System.IO;
using java.io;
using System.Text.RegularExpressions;
using opennlp.tools.sentdetect;

namespace lab6
{
    class Program
    {
        static void Sent(string src)
        {
            StreamReader input = new StreamReader(src);
            StreamWriter output = new StreamWriter(Regex.Replace(src, "(.*).txt", "$1_sent.txt"));
            while (input.Peek() != -1)
            {
                InputStream modelIn = new FileInputStream(@"..\..\..\en-sent.bin");
                SentenceModel smodel = new SentenceModel(modelIn);
                SentenceDetector detector = new SentenceDetectorME(smodel);
                string[] sents = detector.sentDetect(input.ReadLine());
                foreach (string sent in sents)
                    output.Write(sent + " ");
            }
        }
        static void Main(string[] args)
        {
            foreach (string src in Directory.GetFiles(@"..\..\..\DataSet\"))
            {
                Sent(src);
            }
        }
    }
}
