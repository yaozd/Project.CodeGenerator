using System;
using System.Collections.Generic;
using Project.CodeGenerator.DBSchema;
using Project.CodeGenerator.EnumExt;
using Project.CodeGenerator.Utils;

namespace Project.CodeGenerator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            TemplateHelper.Init();
            //
            var dbSchema = DBSchemaFactory.GetDBSchema();
            var tableList = dbSchema.GetTablesList();
            //生成Model================================================
            var templateFileName = "ModelAuto";
            var savePath = @"D:\._1\Model";
            var _namespaceVal = "Project.CodeGenerator.Model";
            GenerateTemplate_Model(templateFileName, tableList, dbSchema, _namespaceVal, savePath);
            //生成Dao================================================
            templateFileName = "ModelAuto";
            savePath = @"D:\._1\Dao";
            _namespaceVal = "Project.CodeGenerator.Model";
            GenerateTemplate_Model(templateFileName, tableList, dbSchema, _namespaceVal, savePath);
            //生成Service================================================
            templateFileName = "ModelAuto";
            savePath = @"D:\._1\Service";
            _namespaceVal = "Project.CodeGenerator.Model";
            GenerateTemplate_Model(templateFileName, tableList, dbSchema, _namespaceVal, savePath);
            //Pause();
        }

        private static void GenerateTemplate_Model(string templateFileName, List<string> tableList, IDBSchema dbSchema,
            string _namespaceVal, string savePath)
        {
            DisplayTemplateName(templateFileName);
            var templateText = TemplateHelper.ReadTemplate(templateFileName);
            foreach (var tableName in tableList)
            {
                var table = dbSchema.GetTableMetadata(tableName);
                Display(tableName, table);
                var classnameVal = tableName;
                var namespaceVal = _namespaceVal;
                var outputText = TemplateHelper.Parse(TemplateKey.TemplateModel, templateText, table, classnameVal,
                    namespaceVal);
                outputText = TemplateHelper.Clean(outputText, RegexPub.H1());
                FileHelper.Save(string.Format(@"{0}\{1}.cs", savePath, classnameVal), outputText);
            }
        }


        private static void Pause()
        {
            Console.ReadKey();
        }

        private static void DisplayTemplateName(string name)
        {
            Console.ForegroundColor= ConsoleColor.Red;
            Console.WriteLine("Display Template Name:{0}", name);
            Console.ForegroundColor = ConsoleColor.White;

        }

        private static void Display(string tableName, Table table)
        {
            Console.WriteLine("tableName:{0},table.ColumnNames:{1}", tableName, table.ColumnNames);
        }
    }
}