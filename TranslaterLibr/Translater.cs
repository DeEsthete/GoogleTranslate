using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TranslaterLibr
{
    public class Translater
    {
        public string WordToTranslate { get; set; }
        public HttpWebRequest WrGETURL { get; set; }
        public string TransText { get; set; }

        public Translater()
        {
            WordToTranslate = "-1";
            TransText = "-1";
        }

        public string Translate(string wordToTranslate)
        {
            WordToTranslate = wordToTranslate;
            TransText = "-1";
            WrGETURL = (HttpWebRequest)WebRequest.Create(@"http://translate.google.com.ua/translate_a/t?client=t&text=" + WordToTranslate + "&hl=ru&sl=en&tl=ru&ie=UTF-8&oe=UTF-8&multires=1&prev=btn&ssel=0&tsel=0&sc=1");
            HttpWebResponse vkHttpWebResponse = (HttpWebResponse)WrGETURL.GetResponse();
            StreamReader vkStreamReader = new StreamReader(vkHttpWebResponse.GetResponseStream());
            string response = vkStreamReader.ReadToEnd();
            response = response.Replace('[', '1');
            response = response.Replace('"', '2');
            Regex transTextRegex = new Regex(@"(1112)(\w*)(2)");
            Match transTextMatch = transTextRegex.Match(response);
            TransText = transTextMatch.Value;
            TransText = TransText.Remove(0, 4);
            TransText = TransText.Remove(TransText.Length - 1, 1);
            return TransText;
        }
    }
}
