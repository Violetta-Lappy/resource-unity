using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using UnityEngine;
using UnityEditor;
using System;
using UltEvents;

namespace VLGameProject.MemoryCard {
    public static class MemoryCardXmlSetting {
        public static readonly string K_FILENAME_XML = $"MemoryCardSaveData-{DateTime.Now.ToString("yyyyMMdd-hhmmss")}.xml";
        public static readonly string K_FILEPATH_XML_DATABASE_FILE = $"{Application.dataPath}/StreamingAssets/MemoryCard/{K_FILENAME_XML}";
    }

    public class MemoryCardXml : MonoBehaviour {
        [SerializeField] private XmlDatabase m_database;

        public UltEvent OnSaveStart;
        public UltEvent OnSaveProcess;
        public UltEvent OnSaveSuccess;
        public UltEvent OnSaveFail;

        private void Start() {
            //Save_MemoryCard();
        }

        public XmlDatabase Get_Database() { return m_database; }

        public void Save_MemoryCard() {
            XmlSerializer serializer = new XmlSerializer(typeof(XmlDatabase));
            FileStream stream = new FileStream(MemoryCardXmlSetting.K_FILEPATH_XML_DATABASE_FILE, FileMode.Create);

            //Build Save File Info
            m_database.Get_SaveFileInfo()
                .Set_SourceName(MemoryCardXmlSetting.K_FILENAME_XML)
                .Set_GameName("LuckyCat")
                .Set_GameVersion("Version 2023 P0")
                .Set_Title($"LuckyCat {MemoryCardXmlSetting.K_FILENAME_XML}")
                .Set_DateAndTime(DateTime.Now.ToString())
                .Set_Date(DateTime.Now.ToLongDateString())
                .Set_Time(DateTime.Now.TimeOfDay.ToString())
                .Set_TotalTimePlay(DateTime.Now.ToString());

            //Serialize all info SOGUIPAGE to XML
            string[] allLines = File.ReadAllLines(Application.dataPath + "/ProjectScriptData/SOGUIPage.csv"); //=> Read SOGuiPage CSV File
            foreach (string s in allLines) {
                string[] splitData = s.Split(',');

                XmlItemEntryGuiPage xmlGuiPage = new XmlItemEntryGuiPage()
                    .Set_ContextName(splitData[0])
                    .Set_Guid(splitData[1]);

                m_database.Add_Item_To_List_GuiPage(xmlGuiPage);
            }

            serializer.Serialize(stream, m_database); //=> Serialize and Write to designated xml file
            stream.Close();
        }

        public void Load_MemoryCard() {
            XmlSerializer serializer = new XmlSerializer(typeof(XmlDatabase));
            FileStream stream = new FileStream(MemoryCardXmlSetting.K_FILEPATH_XML_DATABASE_FILE, FileMode.Open);
            m_database = serializer.Deserialize(stream) as XmlDatabase;
            stream.Close();
        }
    }

    [System.Serializable]
    public class XmlDatabase {
        public XmlItemEntrySaveFileInfo m_saveFileInfo;
        [XmlArray("DATA_MEMORYCARD")] public List<XmlItemEntry> list_m_memoryCard;
        [XmlArray("DATA_GAMEPROGRAM")] public List<XmlItemEntryGameProgram> list_m_gameProgram;
        [XmlArray("DATA_GUIPAGE")] public List<XmlItemEntryGuiPage> list_m_guiPage;

        public XmlItemEntrySaveFileInfo Get_SaveFileInfo() { return m_saveFileInfo; }
        public void Add_Item_To_List_MemoryCard(XmlItemEntry _itemEntry) => list_m_memoryCard.Add(_itemEntry);
        public void Add_Item_To_List_GuiPage(XmlItemEntryGuiPage _itemEntry) => list_m_guiPage.Add(_itemEntry);
    }

    [System.Serializable]
    public class XmlItemEntry {
        [XmlAttribute(AttributeName = "K_CONTEXT_NAME", DataType = "string")]
        public string str_contextName;
        [XmlAttribute(AttributeName = "K_GUID", DataType = "string")]
        public string str_guid;
    }

    [System.Serializable]
    public class XmlItemEntrySaveFileInfo {
        [XmlAttribute(AttributeName = "K_CONTEXT_NAME", DataType = "string")]
        public string str_contextName;
        [XmlAttribute(AttributeName = "K_GUID", DataType = "string")]
        public string str_guid;

        //Save File Info
        public string str_sourceName;
        public string str_gameName;
        public string str_gameVersion;
        public string str_title;
        public string str_dateAndTime;
        public string str_date;
        public string str_time;
        public string str_totalTimePlay;

        public XmlItemEntrySaveFileInfo() { }

        public XmlItemEntrySaveFileInfo Set_SourceName(string _text) {
            str_sourceName = _text;
            return this;
        }
        public XmlItemEntrySaveFileInfo Set_GameName(string _text) {
            str_gameName = _text;
            return this;
        }
        public XmlItemEntrySaveFileInfo Set_GameVersion(string _text) {
            str_gameVersion = _text;
            return this;
        }
        public XmlItemEntrySaveFileInfo Set_Title(string _text) {
            str_title = _text;
            return this;
        }
        public XmlItemEntrySaveFileInfo Set_DateAndTime(string _text) {
            str_dateAndTime = _text;
            return this;
        }
        public XmlItemEntrySaveFileInfo Set_Date(string _text) {
            str_date = _text;
            return this;
        }
        public XmlItemEntrySaveFileInfo Set_Time(string _text) {
            str_time = _text;
            return this;
        }
        public XmlItemEntrySaveFileInfo Set_TotalTimePlay(string _text) {
            str_totalTimePlay = _text;
            return this;
        }        
    }

    [System.Serializable]
    public class XmlItemEntryGameProgram {
        [XmlAttribute(AttributeName = "K_CONTEXT_NAME", DataType = "string")]
        public string str_contextName;
        [XmlAttribute(AttributeName = "K_GUID", DataType = "string")]
        public string str_guid;
        public object m_content;
    }

    [System.Serializable]
    public class XmlItemEntryGameAchievement {
        public string str_guid; //GUID
        public string str_contextName;
        public string str_description;
        public bool isUnlock;
    }

    [System.Serializable]
    public class XmlItemEntryGuiPage {
        [XmlAttribute(AttributeName = "K_CONTEXT_NAME", DataType = "string")]
        public string str_contextName;

        [XmlAttribute(AttributeName = "K_GUID", DataType = "string")]
        public string str_guid;

        public ProgramValueElement m_value = new ProgramValueElement(10, 10, 10, 10, 10, 10);

        public XmlItemEntryGuiPage Set_ContextName(string _text) {
            str_contextName = _text;
            return this;
        }

        public XmlItemEntryGuiPage Set_Guid(string _text) {
            str_guid = _text;
            return this;
        }

        public XmlItemEntryGuiPage() { } //=> I really don't understand why XML need parameterless constructor
    }

    [System.Serializable]
    public class XmlItemEntryGuiSlider {
        [XmlAttribute(AttributeName = "K_CONTEXT_NAME", DataType = "string")]
        public string str_contextName;
        [XmlAttribute(AttributeName = "K_GUID", DataType = "string")]
        public string str_guid;
        //GUISlider Value
        public ProgramValueElement m_value = new ProgramValueElement(10, 10, 10, 10, 10, 10);
    }

}

