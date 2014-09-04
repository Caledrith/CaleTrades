using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace SourceEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static void WriteText(string filePath, string text)
        {
            byte[] encodedText = Encoding.Unicode.GetBytes(text);

            using (FileStream sourceStream = new FileStream(filePath,
                FileMode.Create, FileAccess.Write, FileShare.None,
                bufferSize: 4096, useAsync: true))
            {
                sourceStream.Write(encodedText, 0, encodedText.Length);
            };
        }

        public static string ReadText(string filePath)
        {
            using (FileStream sourceStream = new FileStream(filePath,
                FileMode.Open, FileAccess.Read, FileShare.Read,
                bufferSize: 4096, useAsync: true))
            {
                StringBuilder sb = new StringBuilder();

                byte[] buffer = new byte[0x1000];
                int numRead;
                while ((numRead = sourceStream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    string text = Encoding.Unicode.GetString(buffer, 0, numRead);
                    sb.Append(text);
                }

                return sb.ToString();
            }
        }

        public EditorClasses appset = new EditorClasses();
        private void Form1_Load(object sender, EventArgs e)
        {
            string filepath = Application.StartupPath + @"\data.txt";
            if (File.Exists(filepath))
            {
                string n = ReadText(filepath);
                appset = JsonConvert.DeserializeObject<EditorClasses>(n);
            }

            Options.SelectedObject = appset;
        }

        private void Form1_FormClosing(object sender, EventArgs e)
        {
            string filepath = Application.StartupPath + @"\data.txt";
            string json = JsonConvert.SerializeObject(appset, Formatting.Indented);
            WriteText(filepath, json);
        }
    }
}
