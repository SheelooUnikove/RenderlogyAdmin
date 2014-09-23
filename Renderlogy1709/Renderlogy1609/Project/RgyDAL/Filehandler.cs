//using iTextSharp.text.pdf;
using RenderlogyEmail.Common.Logging;
using RenderlogyEmail.Mime;
using RenderlogyEmail.Pop3;
using RenderlogyUtility.Excel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
namespace RgyDAL
{
    public class Filehandler
    {
        public string GetFileContent(string filepath)
        {
            StreamReader myFile = new StreamReader(filepath);
            return myFile.ReadToEnd();

            if(File.Exists(filepath))
            {
                string ext = Path.GetExtension(filepath);
                switch (ext)
                {
                    case "DOC":
                        parseUsingPDFBox(filepath);
                        break;
                    case "doc":

                        Console.WriteLine("The number is one!");
                        break;
                    case "DOCX":
                        Console.WriteLine("The number is zero!");
                        break;
                    case "docx":
                        Console.WriteLine("The number is one!");
                        break;
                    case "xlsx":
                        Console.WriteLine("The number is zero!");
                        break;
                    case "XLSX":
                        Console.WriteLine("The number is one!");
                        break;
                    case "xls":
                        Console.WriteLine("The number is zero!");
                        break;
                    case "XLS":
                        Console.WriteLine("The number is one!");
                        break;
                    default:
                        break;

                }
            }
        }

        public  string parseUsingPDFBox(string filename)
        {
            string strDocDescriptionForBrowse = string.Empty;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            // create an instance of the pdfparser class
            try
            {
                // Create a reader for the given PDF file
                //PdfReader reader = new PdfReader(filename);
                //for (int page = 1; page <= reader.NumberOfPages; page++)
                //{
                //    PDFParser objPDFParser = new PDFParser();
                //    sb.Append(objPDFParser.ExtractTextFromPDFBytes(reader.GetPageContent(page)));
                //}
                //DBConnection con = new DBConnection();
                //SqlConnection cn = con.Connection();
                //cn.Open();
                //SqlCommand cm = new SqlCommand("Sp_UpdateParseData", cn);
                //cm.CommandType = CommandType.StoredProcedure;
                //cm.Parameters.AddWithValue("@FileName", filename);
                //cm.Parameters.AddWithValue("@Description", sb.ToString());
                //cm.ExecuteNonQuery();
                //cm.Dispose();
             return sb.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}