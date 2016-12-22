using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListBoxApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static void GoToTop(ListBox listBox)
        {
            listBox.TopIndex = 0;
        }

        public static void GoToBottom(ListBox listBox)
        {
            listBox.TopIndex = listBox.Items.Count - 1;
        }

        public static void Add(ListBox listBox, string text)
        {
            listBox.Items.Add(text);
        }

        public static void AddAndGoToTop(ListBox listBox, string text)
        {
            Add(listBox, text);
            GoToTop(listBox);
        }

        public static void AddAndGoToBottom(ListBox listBox, string text)
        {
            Add(listBox, text);
            GoToBottom(listBox);
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            AddAndGoToBottom(listBox1, $"randomText - {new Random().Next()}");
        }

        public static void Update(ListBox listBox, int index, string text)
        {
            //This animated way to change component
            //listBox.Items[index] = text;

            //This is not animated way to change component
            var temp = listBox.SelectedIndex;
            var objects = new object[listBox.Items.Count];
            listBox.Items.CopyTo(objects, 0);
            objects[index] = text;
            listBox.Items.Clear();
            listBox.Items.AddRange(objects);
            listBox.SelectedIndex = temp;
        }

        public static void UpdateAndGoToTop(ListBox listBox, int index, string text)
        {
            Update(listBox, index, text);
            GoToTop(listBox);
        }

        public static void UpdateAndGoToBottom(ListBox listBox, int index, string text)
        {
            Update(listBox, index, text);
            GoToBottom(listBox);
        }

        public static void UpdateAndSavePosition(ListBox listBox, int index, string text)
        {
            int indexTemp = listBox.TopIndex;
            Update(listBox, index, text);
            listBox.TopIndex = indexTemp;
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            UpdateAndSavePosition(listBox1, listBox1.SelectedIndex, $"randomText - {new Random().Next()}");
        }
    }
}
