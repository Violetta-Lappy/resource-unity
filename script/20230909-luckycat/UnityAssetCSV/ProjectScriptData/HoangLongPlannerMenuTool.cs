using UnityEngine;
using UnityEditor;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening.Plugins.Core.PathCore;

[CreateAssetMenu(menuName = "SO/TestCSV")]
public class SOTestCSV : ScriptableObject {
    public string str_test;
    public string str_test02;
}

public static class HoangLongPlannerExternalTool {
    public enum ENUM_FILEPATH_LICENSE {
        NONE = 0,
        APACHE2 = 1,
        MIT = 2,
        GNUGPL3 = 3,
    }

    public const string K_FILEPATH_LICENSE_APACHE2 = "/ProjectScriptData/License/20230707-License-Apache2.txt";
    public const string K_FILEPATH_LICENSE_MIT = "/ProjectScriptData/License/20230707-License-MIT.txt";
    public const string K_FILEPATH_LICENSE_GNUGPL3 = "/ProjectScriptData/License/20230707-License-GNUGPL3.txt";

    private static readonly Dictionary<ENUM_FILEPATH_LICENSE, string> dict_filepathLicense = new Dictionary<ENUM_FILEPATH_LICENSE, string>() {
        {ENUM_FILEPATH_LICENSE.NONE, "NONE"},
        {ENUM_FILEPATH_LICENSE.APACHE2, K_FILEPATH_LICENSE_APACHE2},
        {ENUM_FILEPATH_LICENSE.MIT, K_FILEPATH_LICENSE_MIT},
        {ENUM_FILEPATH_LICENSE.GNUGPL3, K_FILEPATH_LICENSE_GNUGPL3},
    };

    public static string GetLicenseFilepath(ENUM_FILEPATH_LICENSE _type) { return dict_filepathLicense[_type]; }
    public static string[] GetAllStringFromFilePath(ENUM_FILEPATH_LICENSE _type) {
        string[] temp = File.ReadAllLines(Application.dataPath + GetLicenseFilepath(_type));
        return temp;
    }

    public static bool Is_GUID_Correct(string _guid) {
        bool result = true;
        Guid tempGUID;        
        if (Guid.TryParse(_guid, out tempGUID) == false) {
            Debug.LogWarning($"UNABLE TO VALIDATE GUID - {tempGUID}. PLEASE CHECK !!");
            result = false; //set-result-to-bad            
        }       
        return result; //return-outcome
    }
}

public class HoangLongPlannerMenuTool {
    private const string K_FILEPATH_SOGUIPageCSV = "/ProjectScriptData/SourceCSV/SOGUIPage.csv";
    private const string K_FILEPATH_SOGUIButtonCSV = "/ProjectScriptData/SourceCSV/SOGUIButton.csv";

    private static void LogBook(string _path, string _filename) {
        //Read original file        
        string[] allLines = File.ReadAllLines(_path);

        //Prepare Log Book
        var newpath = $"{Application.dataPath}/ProjectScriptData/LogBook/{_filename}-{DateTime.Now.ToString("yyyyMMdd-hhmmss")}.txt";
        File.Create(newpath).Close(); //=> NOTHING
        StreamWriter writer = new StreamWriter(newpath, true); //Prepare to write        

        writer.WriteLine($"{Application.dataPath}/ProjectScriptData/LogBook/{_filename}-{DateTime.Now.ToString("yyyyMMdd-hhmmss")}.txt");
        writer.WriteLine();

        foreach (string s in allLines) {
            writer.WriteLine(s);
        }

        writer.Close();
    }

    [MenuItem("PlannerMenuTools/GUISystem/Validate GUID From SOGUIPage CSV")]
    public static void Validate_GUID_From_SOGUIPage_CSV() {
        string[] allLines = File.ReadAllLines(Application.dataPath + K_FILEPATH_SOGUIPageCSV);
        List<string> distinctGUID = new List<string>();

        bool result = true;

        foreach (string s in allLines) {
            string[] splitData = s.Split(',');
            Guid tempGUID;

            bool isValid = Guid.TryParse(splitData[1], out tempGUID);
            if (isValid == false) {
                Debug.LogWarning($"UNABLE TO VALIDATE GUID - {tempGUID} for {splitData[0]} at {Application.dataPath + K_FILEPATH_SOGUIPageCSV}. PLEASE CHECK !!");
                result = false;
                continue;
            }

            distinctGUID.Add(splitData[1]);
        }

        //if (distinctGUID.Distinct().Count() != distinctGUID.Count()) {
        //    Debug.LogError($"DETECTED DUPLICATE GUID !! {distinctGUID.Distinct().Count()}");
        //    result = false;
        //}

        var duplicates = distinctGUID.GroupBy(p => p).Where(g => g.Count() > 1).Select(g => g.Key);
        if (duplicates.Count() > 0) {
            foreach(string s in duplicates) {
                Debug.LogError($"DETECTED {duplicates.Count()} DUPLICATE GUID !! - {s}");
            }            
            result = false;
        }         

        if (result) Debug.Log($"SUCESSFUL GUID VALIDATE CHECK !! {Application.dataPath + K_FILEPATH_SOGUIPageCSV}");
        else if (result == false) Debug.LogError($"BAD GUID VALIDATE CHECK at {Application.dataPath + K_FILEPATH_SOGUIPageCSV}. PLEASE CHECK !!");
    }

    [MenuItem("PlannerMenuTools/GUISystem/Generate or Update SOGUIButton From CSV [DO NOT USE]")]
    public static void Generate_SOGUIButton() {

    }    

    [MenuItem("PlannerMenuTools/GUISystem/Auto Generated Code Dictionary SOGUIPage From CSV")]
    public static void Write_Dictionary_SoGuiPage_From_Csv() {
        string path = Application.dataPath + "/Scripts/Generated/SOGUIPage.generated.cs";
        var K_CLASS_NAME = "CONST_GUIPAGE";
        var K_ENUM_NAME = "ENUM_GUIPAGE";

        File.Create(path).Close();

        StreamWriter writer = new StreamWriter(path, true); //Prepare to write

        string[] allLines = File.ReadAllLines(Application.dataPath + K_FILEPATH_SOGUIPageCSV);

        foreach (string s in HoangLongPlannerExternalTool.GetAllStringFromFilePath(HoangLongPlannerExternalTool.ENUM_FILEPATH_LICENSE.APACHE2)) {
            writer.WriteLine(s);
        }
        writer.WriteLine(); //=> Insert White Space

        writer.WriteLine($"using System.Collections.Generic;"); //=> Add Libraries
        writer.WriteLine(); //=> Insert White Space

        writer.WriteLine($"public enum {K_ENUM_NAME} {{"); //=> Start of source file
        //foreach (string s in allLines) {
        //    string[] splitData = s.Split(',');
        //    writer.WriteLine($"{splitData[0]},");
        //}
        for (int i = 0; i < allLines.Length; i++) {
            string s = allLines[i];
            string[] splitData = s.Split(',');
            writer.WriteLine($"{splitData[0]} = {i},");
        }
        writer.WriteLine("};"); //=> End of source file

        writer.WriteLine($"public class {K_CLASS_NAME} {{"); //=> Start of source file

        writer.WriteLine($"public static Dictionary<{K_ENUM_NAME}, string> Get_Dict_Type2Str() {{ return dict_type2str; }}");
        writer.WriteLine($"public static Dictionary<string, {K_ENUM_NAME}> Get_Dict_Str2Type() {{ return dict_str2type; }}");

        writer.WriteLine($"public static {K_ENUM_NAME} Get_Type_Page(string _text) {{ return dict_str2type[_text]; }}"); //=> Start of source file        
        writer.WriteLine($"public static string Get_Text_GUID({K_ENUM_NAME} _type) {{ return dict_type2str[_type]; //=> Useful for load data with exact GUID }}"); //=> Start of source file        

        writer.WriteLine($"private static readonly Dictionary<{K_ENUM_NAME}, string> dict_type2str = new Dictionary<{K_ENUM_NAME}, string>() {{"); //=> Start of source file
        foreach (string s in allLines) {
            string[] splitData = s.Split(',');
            writer.WriteLine($"{{{K_ENUM_NAME}.{splitData[0]}, {splitData[0]}}},");
        }
        writer.WriteLine("};"); //=> End of source file

        writer.WriteLine($"private static readonly Dictionary<string, {K_ENUM_NAME}> dict_str2type = new Dictionary<string, {K_ENUM_NAME}>() {{"); //=> Start of source file
        foreach (string s in allLines) {
            string[] splitData = s.Split(',');
            writer.WriteLine($"{{{splitData[0]}, {K_ENUM_NAME}.{splitData[0]}}},");
        }
        writer.WriteLine("};"); //=> End of source file

        foreach (string s in allLines) {
            string[] splitData = s.Split(',');
            writer.WriteLine($"public const string {splitData[0]} = \"{splitData[1]}\";");
        }

        writer.WriteLine("}"); //=> End of source file

        writer.Close();

        Debug.Log($"Successful Auto Generate {path} - Please Check {path} for more info !!");

        LogBook(path, "SOGUIPage.generated.cs");
    }

    [MenuItem("PlannerMenuTools/GUISystem/Auto Generated Code Dictionary SOGUIButton From CSV - DO NOT USE")]
    public static void WriteDictionarySOGUIButtonFromCSV() {

    }
}

public class HoangLongPlannerMemoryCard {

    [MenuItem("PlannerMenuTools/MemoryCard/Auto Generate MemoryCard CSV2MC - DO NOT USE")]
    public static void Auto_Generate_Script_MemoryCard_Csv2Mc() {
        //Memory Card Block into Memory Card
    }

    [MenuItem("PlannerMenuTools/MemoryCard/Auto Generate Script MemoryCard CSV2XML")]
    public static void Auto_Generate_Script_MemoryCard_Csv2Xml() {
        //Item Entry Save File Info
        //Item Entry Game Achievements        
        //Item Entry Game Program        
        //Item Entry Game Progress Stats        
        //Item Entry Player Stats        
    }

    [MenuItem("PlannerMenuTools/MemoryCard/Auto Generate MemoryCard CSV2JSON - DO NOT USE")]
    public static void Auto_Generate_Script_MemoryCard_Csv2Json() {

    }
}

//Class that enhance enum with GUID for save load purpose
public class HoangLongPlannerEnumEx {
    [MenuItem("PlannerMenuTools/EnumEx/Auto Generate Script ENUMEX_TEST")]
    public static void Auto_Generate_Script_EnumExTest() {

        string path = Application.dataPath + "/Scripts/Generated/EnumExTest.generated.cs";        
        var K_ENUMEX_NAME = "ENUMEX_TEST";
        var K_ENUM_NAME = "ENUM_TEST";        

        StreamWriter writer = new StreamWriter(path, true); //Prepare to write        

        foreach (string s in HoangLongPlannerExternalTool.GetAllStringFromFilePath(HoangLongPlannerExternalTool.ENUM_FILEPATH_LICENSE.APACHE2)) {
            writer.WriteLine(s);
        }
        writer.WriteLine(); //=> Insert White Space

        writer.WriteLine($"public class {K_ENUMEX_NAME} {{"); //=> Start of Class EnumEx        

        writer.WriteLine($"public string str_guid; {{");
        writer.WriteLine($"public {K_ENUM_NAME} enum_type;");

        writer.WriteLine($"public enum {K_ENUM_NAME} {{"); //=> Start of Enum
        //Write each string of enum name
        writer.WriteLine("};"); //=> End of Enum

        writer.WriteLine("}"); //=> End of Class EnumEx
    }
}

public class HoangLongPlannerGameValueManager {
    [MenuItem("PlannerMenuTools/GameValueManager/Auto Generate Script GameValueManager")]
    public static void Auto_Generate_Script_GameValueManager() {

        string path = Application.dataPath + "/Scripts/Generated/GameValueManager.generated.cs";
        var K_CLASS_NAME = "GameValueManager";
        var K_ENUM_NAME = "ENUM_GAMEVALUE";
        string[] K_SZ_ENUM_NAME = { 
            "K_NONE",             
            "K_LIFE",                                      
            "K_COIN",
            "K_COINEARN",
            "K_ENEMYCOUNT",
        };

        StreamWriter writer = new StreamWriter(path, true); //Prepare to write        

        foreach (string s in HoangLongPlannerExternalTool.GetAllStringFromFilePath(HoangLongPlannerExternalTool.ENUM_FILEPATH_LICENSE.APACHE2)) {
            writer.WriteLine(s);
        }
        writer.WriteLine(); //=> Insert White Space

        writer.WriteLine($"public class {K_CLASS_NAME} : Monobehavior {{"); //=> Start of Class                

        writer.WriteLine($"public enum {K_ENUM_NAME} {{"); //=> Start of Enum
        //Write each string of enum name
        writer.WriteLine("};"); //=> End of Enum

        writer.WriteLine("}"); //=> End of Class
    }
}

