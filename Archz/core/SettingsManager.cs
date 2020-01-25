﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using Archz.modules;

namespace Archz.core
{
    public class SettingsManager
    {
        static private string configFileName = "config.xml";
        static private XmlDocument configFile;
        static public void Init()
        {
            if(!File.Exists(configFileName))
            {
                throw new FileNotFoundException("Configuration file not found");
            }

            configFile = new XmlDocument();
            configFile.Load(configFileName);
        }

        static public BasicFileSorterSettings LoadSettingsForBasicFileSorter()
        {
            BasicFileSorterSettings settings = new BasicFileSorterSettings();
            XmlNodeList basicFileSorterNodesList = configFile.DocumentElement.SelectNodes("BasicFileSorter");
            foreach(XmlNode nodeList in basicFileSorterNodesList)
            {
                var observedFolders = nodeList.SelectSingleNode("ObservedFolders");
                foreach(XmlNode folder in observedFolders.ChildNodes)
                {
                    settings.ObservedFolders.Add(folder.InnerText);
                }

                var extenstionsDef = nodeList.SelectSingleNode("ExtensionsDefinition");
                foreach(XmlNode item in extenstionsDef.ChildNodes)
                {
                    settings.ExtensionsDefinition[item.InnerText] = item.Attributes["category"].Value;
                }

                var categoryFolders = nodeList.SelectSingleNode("CategoryFolders");
                foreach(XmlNode folder in categoryFolders.ChildNodes)
                {
                    settings.CategoryFolders[folder.Attributes["category"].Value] = folder.InnerText;
                }
        
            }

            return settings;
        } 

        
    }
}
