using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace LanguageSkillsWPF.Infrastructure
{
    internal class TextExtractor
    {
        public string Extract(string file)
        {
            StringBuilder sb = new StringBuilder();
            using (PdfReader reader = new PdfReader(file))
            {
                for (int pageNo = 1; pageNo <= reader.NumberOfPages; pageNo++)
                {
                    ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
                    string text = PdfTextExtractor.GetTextFromPage(reader, pageNo, strategy);
                    text = Encoding.UTF8.GetString(ASCIIEncoding.Convert(Encoding.Default,Encoding.UTF8,Encoding.Default.GetBytes(text)));  
                    sb.Append(text);
                }
            }
            return sb.ToString();
        }
    }
}
