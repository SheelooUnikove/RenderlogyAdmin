using RenderlogyEmail.Pop3;
using RenderlogyUtility.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RenderlogyEmail.Common.Logging;
using System.Web;

namespace RgyDAL
{
    public class ExcelParser
    {
        /// <summary>
        /// Get Content of given excel file's particular sheet in table format
        /// </summary>
        /// <param name="filename">Excel filename from which you want to get data</param>
        /// <param name="headEncode">Consider top header as data of the sheet:true ---- Consider top header as a row</param>
        /// <param name="SheetName">Sheet name of the given file to get data</param>
        /// <returns>Returns all data present in the given sheet as dataTable object.</returns>
        public DataTable ExcelContent(String filename, bool headEncode, String SheetName)
        {
            DataTable Returndt = new DataTable();
            ExcelObject excelObj;
            if(headEncode)
                excelObj = new ExcelObject(filename, HeaderEncoding.Yes);
            else
                excelObj = new ExcelObject(filename, HeaderEncoding.No);
            DataTable dtSchema = excelObj.GetSheetList();
            var retGivenSheetTableName = (from dr in dtSchema.AsEnumerable()
                     where dr["TABLE_NAME"].ToString().Contains(SheetName)
                     select dr["TABLE_NAME"]).ToList();
            if(retGivenSheetTableName != null)
            {
                Returndt = excelObj.ReadSheet(retGivenSheetTableName[0].ToString(), "");
            }
            return Returndt;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename">Excel filename from which you want to get data</param>
        /// <param name="headEncode">Consider top header as data of the sheet:true ---- Consider top header as a row</param>
        /// <param name="SheetName">Sheet name of the given file to get data</param>
        /// <returns>Returns all column and their definitions present in the given sheet as dataTable object.</returns>
        public DataTable ExcelColumnDef(String filename, bool headEncode, String SheetName)
        {
            DataTable Returndt = new DataTable();
            ExcelObject excelObj;
            if(headEncode)
                excelObj = new ExcelObject(filename, HeaderEncoding.Yes);
            else
                excelObj = new ExcelObject(filename, HeaderEncoding.No);
            
            Returndt = excelObj.GetColumnDefinition(SheetName);
            return Returndt;
        }
        public DataSet XmlColumnDefSynonym(String AgainstType, String connString, String FilePath)
        {
            Pop3DataClient data = new Pop3DataClient();
            return data.GetXmlFileFields(AgainstType, connString, FilePath);
        }
        public DataTable GetSpecificColumnsValue(String filename, bool headEncode, String SheetName,List<object> columnsList, String Criteria)
        {
            ExcelObject excelObj;
            if (headEncode)
                excelObj = new ExcelObject(filename, HeaderEncoding.Yes);
            else
                excelObj = new ExcelObject(filename, HeaderEncoding.No);

            return excelObj.GetSpecificColumnsValue(SheetName, columnsList, Criteria);
        }
    }
}
