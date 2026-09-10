using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;


namespace InfourokParser
{
    internal class ParserStarter
    {
        public void GetText(string urlAddr)
        {
            HtmlWeb web = new HtmlWeb();
            var htmlDoc = web.Load(urlAddr);
            IEnumerable<HtmlNode> nodes = htmlDoc.DocumentNode.Descendants(0).Where(n => n.HasClass("MsoNormal"));

            using (WordprocessingDocument wordprocessing = WordprocessingDocument.Create("parsedText.docx", WordprocessingDocumentType.Document))
                {

                MainDocumentPart mainDocPart = wordprocessing.AddMainDocumentPart();
                mainDocPart.Document = new Document();
                mainDocPart.Document.Body = mainDocPart.Document.AppendChild(new Body());
                Body body = mainDocPart.Document.Body;
                foreach (HtmlNode node in nodes)
                {
                    Paragraph para = body.AppendChild(new Paragraph());
                    Run run = para.AppendChild(new Run());
                    Text text = run.AppendChild(new Text(node.InnerText.Replace("&nbsp;", " ")));
                }
            }
        } 
    }
}
