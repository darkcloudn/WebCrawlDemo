﻿using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fizzler;
using Fizzler.Systems.HtmlAgilityPack;
using System.IO;
using System.Text.RegularExpressions;

namespace Crawl
{
    class Tool
    {

        public  void CrawlUlti(string ten, string fileName, string url)
        {
            String stringPath = @"E:\Project\Project C Sharp\Crawl\Crawl2\Crawl\Crawl\truyen\" + fileName + ".txt";
            FileStream fs = new FileStream(stringPath, FileMode.Create, FileAccess.ReadWrite);
            StreamWriter sWriter = new StreamWriter(fs, Encoding.UTF8);
            sWriter.WriteLine("tenfile");
            sWriter.WriteLine(fileName);
            sWriter.WriteLine("endtenfile");
            sWriter.WriteLine("tentruyen");
            sWriter.WriteLine(ten);
            sWriter.WriteLine("endtentruyen");
            HtmlWeb htmlWeb = new HtmlWeb()
            {
                AutoDetectEncoding = false,
                OverrideEncoding = Encoding.UTF8
            };
            //Load Web
            // String url = "https://giaitri321.vip/doc-truyen/con-duong-mang-ten-em.html/";
            HtmlDocument document = htmlWeb.Load(url);

            int index = 2;

            //Load Các tag li trong ul
            var threadItems = document.DocumentNode.QuerySelectorAll(".bai-viet-box > p").ToList();


            var author = document.DocumentNode.QuerySelector("strong");
            sWriter.WriteLine("chap" + "1");
            foreach (var item in threadItems)
            {
                sWriter.WriteLine("<p>" + item.InnerText + "</p>");
            }
            sWriter.WriteLine("endchap" + "1" + "\n");
            // string tacgia = author.InnerText;
            do
            {
                document = htmlWeb.Load(url + index);
                threadItems = document.DocumentNode.QuerySelectorAll(".bai-viet-box > p").ToList();
                author = document.DocumentNode.QuerySelector("strong");
                sWriter.WriteLine("chap" + index);
                foreach (var item in threadItems)
                {
                    sWriter.WriteLine("<p>" + item.InnerText + "</p>");

                }
                sWriter.WriteLine("endchap" + index + "\n");

                index++;
            } while (author == null);
            sWriter.Flush();
            fs.Close();
        }
        public  String convertUrlToFileName(String url)
        {

            Regex regex = new Regex(@"/");
            String[] fileName = regex.Split(url);
            Regex regex1 = new Regex(@"\. ");

            string fname = fileName[4].Replace(".", "/");
            string[] name = regex.Split(fname);
            return name[0];
        }

    }
}
