
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace VLGameProject.VLEditor {
    public class ViolettaLappyTool : MonoBehaviour {
        public static void LogBook(string arg_path, string arg_filename) {
            var h_path = $"{Application.dataPath}/Scripts/ViolettaLappyUnity/UnityScriptGenerate/LogBook/{arg_filename}-{DateTime.Now.ToString("yyyyMMdd-hhmmss")}.txt";

            //--Read original file--        
            string[] h_sz_allLine = File.ReadAllLines(arg_path);

            //Prepare Log Book            
            File.Create(h_path).Close();
            StreamWriter writer = new StreamWriter(h_path, true);

            //--Write Title--
            writer.WriteLine(h_path);
            writer.WriteLine();

            //--Copy All--
            foreach (string s in h_sz_allLine) {
                writer.WriteLine(s);
            }

            writer.Close();
        }

    }

    /// <summary>
    /// Tool for AutoGenerate GuiPage
    /// - Create Enum from CSV
    /// - Auto Generate Script from CSV
    /// </summary>
    public class VLEditor_GuiPage {

        [MenuItem("ViolettaLappy/ScriptGenerate/GuiPage/Create ENUMGuiPage from CSV")]
        public static void Create_ENUMGuiPageFromCSV() {
            string h_pathCSV = $"{Application.dataPath}/Scripts/ViolettaLappyUnity/UnityAssetCSV/GuiPage.csv";
            string h_pathFile = $"{Application.dataPath}/Scripts/ViolettaLappyUnity/UnityScriptGenerate/GuiPage/ENUMGuiPage.cs";
            string h_namespace = "VLGameProject.VLGui";

            if (File.Exists(h_pathCSV) == false) {
                Debug.LogWarning($"{h_pathCSV} not exists !! Please check the file !!");
                return; //safe-check
            }

            if (File.Exists(h_pathFile)) {
                Debug.LogWarning($"{h_pathFile} exists !! Will now overwrite !!");
            }

            //--Create Blank File Or Overwrite Existing File--            
            File.Create(h_pathFile).Close(); //=> Clear file
            StreamWriter h_writer = new StreamWriter(h_pathFile, true); //=> Prepare StreamWriter
            string[] h_sz_allLine = File.ReadAllLines(h_pathCSV); //=> Read all lines from csv                                    

            //--Add and Open Namespace--
            h_writer.WriteLine($"namespace {h_namespace} {{");

            //--Write Enum Class--
            h_writer.WriteLine($"public enum ENUMGuiPage {{"); //TODO

            //populate content            
            for (int i = 0; i < h_sz_allLine.Length; i++) {
                string s = h_sz_allLine[i];
                string[] splitData = s.Split(',');
                h_writer.WriteLine($"{splitData[0]},");
            }

            //end class
            h_writer.WriteLine($"}}");

            //--Close Namespace--
            h_writer.WriteLine($"}}");

            h_writer.WriteLine(); //=> Add White Space

            //--Close StreamWriter--
            h_writer.Close();

            //-ANNOUNCEMENT-
            Debug.Log($"Successful Auto Generate {h_pathFile} - Please Check {h_pathFile} for more info !!");

            //--Archive--
            ViolettaLappyTool.LogBook(h_pathFile, "ENUMGuiPage");
        }

        [MenuItem("ViolettaLappy/ScriptGenerate/GuiPage/Create Multiple GuiPage Class from CSV")]
        public static void Create_MultipleGuiPageClassFromCSV() {
            string h_pathCSV = $"{Application.dataPath}/Scripts/ViolettaLappyUnity/UnityAssetCSV/GuiPage.csv";
            string h_namespace = "VLGameProject.VLGui";
            string h_tempData = "";
            string h_tempData02 = "";

            if (File.Exists(h_pathCSV) == false) {
                Debug.LogWarning($"{h_pathCSV} not exists !! Please check the file !!");
                return; //safe-check
            }

            //--Read CSV File--                        
            string[] h_sz_allLine = File.ReadAllLines(h_pathCSV); //=> Read all lines from csv                        

            //Loop Inside Loop
            for (int i = 0; i < h_sz_allLine.Length; i++) {
                //for (int i = 0; i < 1; i++) {
                string s = h_sz_allLine[i];
                string[] splitData = s.Split(',');

                h_tempData = splitData[0];
                h_tempData02 = splitData[1];

                //create
                string h_pathFile = $"{Application.dataPath}/Scripts/ViolettaLappyUnity/UnityScriptGenerate/GuiPage/GuiPageType_{h_tempData02}.cs";

                if (File.Exists(h_pathFile)) {
                    Debug.LogError($"{h_pathFile} exists !! SKIPPING !!");
                    continue;
                }

                //--Create Blank File Or Overwrite Existing File--                        
                File.Create(h_pathFile).Close(); //Create empty file
                StreamWriter h_writer = new StreamWriter(h_pathFile, true); //=> Prepare StreamWriter                

                //--Add Using Libraries--
                h_writer.WriteLine($"using UnityEngine;");

                //--Add and Open Namespace--
                h_writer.WriteLine($"namespace {h_namespace} {{");

                //--Write Unity Menu--
                h_writer.WriteLine($"[CreateAssetMenu(fileName = \"New {h_tempData02}\", menuName = \"VLGameProject/GuiPage/New {h_tempData02}\")]");

                //--Write Class--
                h_writer.WriteLine($"public class GuiPageType_{h_tempData02} : SOABSGuiPageType {{"); //TODO-AddSplitData[2]
                h_writer.WriteLine($"public override ENUMGuiPage Get_GuiPageType() {{");
                h_writer.WriteLine($"return ENUMGuiPage.{h_tempData};"); //TODO-AddSplitData[1]
                h_writer.WriteLine($"}}"); //=> End Function
                h_writer.WriteLine($"}}"); //=> End Class                       

                //--Close Namespace--
                h_writer.WriteLine($"}}");
                h_writer.WriteLine(); //=> Add White Space

                //--Close StreamWriter--
                h_writer.Close();

                //-ANNOUNCEMENT-
                Debug.Log($"Successful Auto Generate {h_pathFile} - Please Check {h_pathFile} for more info !!");

                //--Archive--
                ViolettaLappyTool.LogBook(h_pathFile, h_tempData02);
            }
        }
    }

    /// <summary>
    /// Tool for AutoGenerate GuiPage
    /// - Create Enum from CSV
    /// - Auto Generate Script from CSV
    /// </summary>
    public class VLEditor_GuiText {

        [MenuItem("ViolettaLappy/ScriptGenerate/GuiText/Create ENUMGuiText from CSV")]
        public static void Create_ENUMGuiTextFromCSV() {
            string h_pathCSV = $"{Application.dataPath}/Scripts/ViolettaLappyUnity/UnityAssetCSV/GuiText.csv";
            string h_pathFile = $"{Application.dataPath}/Scripts/ViolettaLappyUnity/UnityScriptGenerate/GuiText/ENUMGuiText.cs";
            string h_namespace = "VLGameProject.VLGui";

            if (File.Exists(h_pathCSV) == false) {
                Debug.LogWarning($"{h_pathCSV} not exists !! Please check the file !!");
                return; //safe-check
            }

            if (File.Exists(h_pathFile)) {
                Debug.LogWarning($"{h_pathFile} exists !! Will now overwrite !!");
            }

            //--Create Blank File Or Overwrite Existing File--            
            File.Create(h_pathFile).Close(); //=> Clear file
            StreamWriter h_writer = new StreamWriter(h_pathFile, true); //=> Prepare StreamWriter
            string[] h_sz_allLine = File.ReadAllLines(h_pathCSV); //=> Read all lines from csv                                    

            //--Add and Open Namespace--
            h_writer.WriteLine($"namespace {h_namespace} {{");

            //--Write Enum Class--
            h_writer.WriteLine($"public enum ENUMGuiText {{"); //TODO

            //populate content
            for (int i = 0; i < h_sz_allLine.Length; i++) {
                string s = h_sz_allLine[i];
                string[] splitData = s.Split(',');
                h_writer.WriteLine($"{splitData[0]},");
            }

            //end class
            h_writer.WriteLine($"}}");

            //--Close Namespace--
            h_writer.WriteLine($"}}");

            h_writer.WriteLine(); //=> Add White Space

            //--Close StreamWriter--
            h_writer.Close();

            //-ANNOUNCEMENT-
            Debug.Log($"Successful Auto Generate {h_pathFile} - Please Check {h_pathFile} for more info !!");

            //--Archive--
            ViolettaLappyTool.LogBook(h_pathFile, "ENUMGuiText");
        }

        [MenuItem("ViolettaLappy/ScriptGenerate/GuiText/Create Multiple GuiText Class from CSV")]
        public static void Create_MultipleGuiPageClassFromCSV() {
            string h_pathCSV = $"{Application.dataPath}/Scripts/ViolettaLappyUnity/UnityAssetCSV/GuiText.csv";
            string h_namespace = "VLGameProject.VLGui";
            string h_tempData = "";
            string h_tempData02 = "";

            if (File.Exists(h_pathCSV) == false) {
                Debug.LogWarning($"{h_pathCSV} not exists !! Please check the file !!");
                return; //safe-check
            }

            //--Read CSV File--                        
            string[] h_sz_allLine = File.ReadAllLines(h_pathCSV); //=> Read all lines from csv                        

            //Loop Inside Loop            
            for (int i = 0; i < h_sz_allLine.Length; i++) {
                //for (int i = 0; i < 1; i++) {
                string s = h_sz_allLine[i];
                string[] splitData = s.Split(',');

                h_tempData = splitData[0];
                h_tempData02 = splitData[1];

                //create
                string h_pathFile = $"{Application.dataPath}/Scripts/ViolettaLappyUnity/UnityScriptGenerate/GuiText/GuiTextType_{h_tempData02}.cs";

                if (File.Exists(h_pathFile)) {
                    Debug.LogError($"{h_pathFile} exists !! SKIPPING !!");
                    continue;
                }

                //--Create Blank File Or Overwrite Existing File--                        
                File.Create(h_pathFile).Close(); //Create empty file
                StreamWriter h_writer = new StreamWriter(h_pathFile, true); //=> Prepare StreamWriter                

                //--Add Using Libraries--
                h_writer.WriteLine($"using UnityEngine;");

                //--Add and Open Namespace--
                h_writer.WriteLine($"namespace {h_namespace} {{");

                //--Write Unity Menu--
                h_writer.WriteLine($"[CreateAssetMenu(fileName = \"New {h_tempData02}\", menuName = \"VLGameProject/GuiTextType/New {h_tempData02}\")]");

                //--Write Class--
                h_writer.WriteLine($"public class GuiTextType_{h_tempData02} : SOABSGuiTextType {{"); //TODO-AddSplitData[2]
                h_writer.WriteLine($"public override ENUMGuiText Get_GuiTextType() {{");
                h_writer.WriteLine($"return ENUMGuiText.{h_tempData};"); //TODO-AddSplitData[1]
                h_writer.WriteLine($"}}"); //=> End Function
                h_writer.WriteLine($"}}"); //=> End Class                       

                //--Close Namespace--
                h_writer.WriteLine($"}}");
                h_writer.WriteLine(); //=> Add White Space

                //--Close StreamWriter--
                h_writer.Close();

                //-ANNOUNCEMENT-
                Debug.Log($"Successful Auto Generate {h_pathFile} - Please Check {h_pathFile} for more info !!");

                //--Archive--
                ViolettaLappyTool.LogBook(h_pathFile, h_tempData02);
            }
        }
    }

    /// <summary>
    /// Tool for AutoGenerate GuiPage
    /// - Create Enum from CSV
    /// - Auto Generate Script from CSV
    /// </summary>
    public class VLEditor_GuiDropdownBehavior {
        [MenuItem("ViolettaLappy/ScriptGenerate/GuiBehaviorDropdown/Create Multiple GuiDropdownBehavior Class from CSV")]
        public static void Create_MultipleGuiPageClassFromCSV() {
            string h_pathCSV = $"{Application.dataPath}/Scripts/ViolettaLappyUnity/UnityAssetCSV/GuiDropdownBehavior.csv";
            string h_namespace = "VLGameProject.VLGui";
            string h_tempData = "";
            string h_tempData02 = "";

            if (File.Exists(h_pathCSV) == false) {
                Debug.LogWarning($"{h_pathCSV} not exists !! Please check the file !!");
                return; //safe-check
            }

            //--Read CSV File--                        
            string[] h_sz_allLine = File.ReadAllLines(h_pathCSV); //=> Read all lines from csv                        

            //Loop Inside Loop            
            //for (int i = 0; i < h_sz_allLine.Length; i++) {
            for (int i = 0; i < 1; i++) {
                string s = h_sz_allLine[i];
                string[] splitData = s.Split(',');

                h_tempData = splitData[0];
                h_tempData02 = splitData[1];

                //create
                string h_pathFile = $"{Application.dataPath}/Scripts/ViolettaLappyUnity/UnityScriptGenerate/GuiBehaviorDropdown/GuiBehaviorDropdown_{h_tempData02}.cs";

                if (File.Exists(h_pathFile)) {
                    Debug.LogError($"{h_pathFile} exists !! SKIPPING !!");
                    continue;
                }

                //--Create Blank File Or Overwrite Existing File--                        
                File.Create(h_pathFile).Close(); //Create empty file
                StreamWriter h_writer = new StreamWriter(h_pathFile, true); //=> Prepare StreamWriter                

                //--Add Using Libraries--
                h_writer.WriteLine($"using UnityEngine;");

                //--Add and Open Namespace--
                h_writer.WriteLine($"namespace {h_namespace} {{");

                //--Write Unity Menu--
                h_writer.WriteLine($"[CreateAssetMenu(fileName = \"New {h_tempData02}\", menuName = \"VLGameProject/GuiDropdownBehavior/New {h_tempData02}\")]");

                //--Write Class--
                h_writer.WriteLine($"public class GuiDropdownBehavior_{h_tempData02} : SOABSGuiDropdownBehavior {{"); //TODO-AddSplitData[2]

                h_writer.WriteLine($"public static readonly string[] sz_str_string {{");
                //AddContentHere
                h_writer.WriteLine($"}};");                

                h_writer.WriteLine($"public static string[] Get_szString() {{");
                h_writer.WriteLine($"return sz_str_string;");
                h_writer.WriteLine($"}}");
                
                h_writer.WriteLine($"public override void GuiDropdownBehavior_EditorReset(GuiDropdown arg_dropdown) {{");
                h_writer.WriteLine($"if (arg_dropdown != null) {{");
                h_writer.WriteLine($"arg_dropdown.Dropdown_Clear();");
                h_writer.WriteLine($"foreach (string str in Get_szString()) {{");
                h_writer.WriteLine($"arg_dropdown.Dropdown_Add_Item(str);");
                h_writer.WriteLine($"}}");                                                 
                h_writer.WriteLine($"}}");

                h_writer.WriteLine($"public override void GuiDropdownBehavior_EditorReset(GuiDropdown arg_dropdown) {{");
                h_writer.WriteLine($"throw new System.NotImplementedException();");
                h_writer.WriteLine($"}}");

                h_writer.WriteLine($"}}"); //=> End Class                       

                //--Close Namespace--
                h_writer.WriteLine($"}}");
                h_writer.WriteLine(); //=> Add White Space

                //--Close StreamWriter--
                h_writer.Close();

                //-ANNOUNCEMENT-
                Debug.Log($"Successful Auto Generate {h_pathFile} - Please Check {h_pathFile} for more info !!");

                //--Archive--
                ViolettaLappyTool.LogBook(h_pathFile, h_tempData02);
            }
        }
    }
}
