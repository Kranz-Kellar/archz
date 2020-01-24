using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Archz.core
{
    public sealed class SettingsManager
    {
        static private string nameOfConfigFile = "config.eqs";
        static public void LoadSettings()
        {

        }

        /// <summary>
        /// Returns value of attribute
        /// </summary>
        /// <param name="nameOfKey"></param>
        /// <returns></returns>
        static public string GetAttribute(string nameOfKey)
        {
            return new string("No_Imp");
        }

        /// <summary>
        /// Returns list of values of node
        /// </summary>
        /// <param name="nameOfNode"></param>
        /// <returns></returns>
        static public string GetNode(string nameOfNode)
        {
            return new string("No_Imp");
        }
    }
}
