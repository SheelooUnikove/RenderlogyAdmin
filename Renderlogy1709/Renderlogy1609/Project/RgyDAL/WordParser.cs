using RenderlogyUtility.RenderlogyWord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RgyDAL
{
    /// <summary>
    /// WordParser Class
    /// </summary>
    public class WordParser
    {
        /// <summary>
        /// Return content as text of the given file
        /// </summary>
        /// <param name="filename"></param>
        /// <returns>String</returns>
        public String WordContent(String filename)
        {
            WordObject wordObj = new WordObject(filename);
            return wordObj.getTextFromWord();
        }
    }
}
