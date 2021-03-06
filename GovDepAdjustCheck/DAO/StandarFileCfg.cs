﻿using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Xml;
using System.Text;
using System.Threading.Tasks;
using GovDepAdjustCheck.Interfaces;
using GovDepAdjustCheck.Models;
using LxbXml;

namespace GovDepAdjustCheck.DAO
{
    class StandarFileCfg: IEnumerable<StandarFileColumnInfo>
    {
        private string _cfgfilename = @"CFG\AppCfg.xml";
        public StandarFileCfg(string cfgfilename) { _cfgfilename = cfgfilename; }

         //public void Add()

        //public IEnumerator<StandarFileColumnInfo> GetEnumerator()
        //{
        //    return this.ReadConfiguration();

        //}
        

        //public IEnumerator<StandarFileColumnInfo> GetEnumerator1()
        //{
        //    return ReadConfiguration();
        //}

        public IEnumerator<StandarFileColumnInfo> GetEnumerator()
        {
            return this.GetEnumerator(delegate
            {
                return XMLHelper.GetXmlNodeListByXpath(_cfgfilename, "//Configurations//StandarFile//column");
            });
        }
        public IEnumerator<StandarFileColumnInfo> GetEnumerator(Func<XmlNodeList> provider)
        {
            //var xmlnodelist = XMLHelper.GetXmlNodeListByXpath(CfgFileName, "//Configurations//StandarFile//column");
            using (XmlNodeList xmlnodelist = provider())
            {
                foreach (XmlNode colNode in xmlnodelist)
                {
                    yield return new StandarFileColumnInfo(columnname: colNode.Attributes["name"].Value, valuetype: GetTypeByString(colNode.Attributes["valuetype"].Value));
                }
            }

        }

        IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }

        public Type GetTypeByString(string type)
        {
            switch (type.ToLower())
            {
                case "bool":
                    return Type.GetType("System.Boolean", true, true);
                case "byte":
                    return Type.GetType("System.Byte", true, true);
                case "sbyte":
                    return Type.GetType("System.SByte", true, true);
                case "char":
                    return Type.GetType("System.Char", true, true);
                case "decimal":
                    return Type.GetType("System.Decimal", true, true);
                case "double":
                    return Type.GetType("System.Double", true, true);
                case "float":
                    return Type.GetType("System.Single", true, true);
                case "int":
                    return Type.GetType("System.Int32", true, true);
                case "uint":
                    return Type.GetType("System.UInt32", true, true);
                case "long":
                    return Type.GetType("System.Int64", true, true);
                case "ulong":
                    return Type.GetType("System.UInt64", true, true);
                case "object":
                    return Type.GetType("System.Object", true, true);
                case "short":
                    return Type.GetType("System.Int16", true, true);
                case "ushort":
                    return Type.GetType("System.UInt16", true, true);
                case "string":
                    return Type.GetType("System.String", true, true);
                case "date":
                case "datetime":
                    return Type.GetType("System.DateTime", true, true);
                case "guid":
                    return Type.GetType("System.Guid", true, true);
                default:
                    return Type.GetType(type, true, true);
            }
        }   

    }


}
