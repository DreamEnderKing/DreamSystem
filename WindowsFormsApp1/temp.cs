﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp1
{
    public static class Tmp
    {
        public static temp user = new temp();
    }

    public class temp
    {
        string user = "public";
        public string User
        {
            get { return user; }
            set { user = value; }
        }
        public temp newTemp()
        {
            temp Temp = new temp();
            return Temp;
        }
    }

    public static class DIO
    {
        public class DI
        {
            public DI(string name, Image image)
            {
                Icon = image;
                Name = name;
                X = 0;
                Y = 0;

            }

            public string Name { get; set; }
            public Image Icon { get; set; }
            public int X;
            public int Y;

        }
        static int time_r;

        public static void writeDI(string folderpath,DI item)
        {
            BinaryWriter file = new BinaryWriter(new FileStream(folderpath + "\\" + item.Name + ".rw",FileMode.Create));
            int position = 0;
            //第一步：写入名称
            Byte[] bytes = new Byte[2 * item.Name.Length];
            for (int i = 0; i < item.Name.Length; i++)
            {
                Byte[] bytetmp=BitConverter.GetBytes(item.Name.ToCharArray()[i]);
                bytes[2 * i] = bytetmp[0];
                bytes[2 * i + 1] = bytetmp[1];
            }
            file.Write(bytes.Length);
            file.Write(bytes);
            //第二步：写入位置
            file.Write(item.X);
            file.Write(item.Y);
            //第三步：写入图片
            Bitmap ico = (Bitmap)item.Icon;
            ico.Save(folderpath + "\\" + item.Name + ".rwp", ImageFormat.Gif);

            file.Dispose();
        }

        static void readDI(string filepath,ref DI item)
        {
            if (filepath.EndsWith(".rw"))
            {
                FileStream stream = File.Open(filepath, FileMode.Open, FileAccess.Read);
                stream.Position = 0;
                BinaryReader file = new BinaryReader(stream);
                int position = 0;
                //第一步：读取名称
                int it = file.ReadInt32();
                char[] c = new char[it / 2];
                for (int i = 0; i < it / 2; i++)
                {
                    c[i] = file.ReadChar();
                    file.ReadChar();
                }
                string str = new string(c);
                item.Name = str;
                //第二步：读取位置
                item.X = file.ReadInt32();
                item.Y = file.ReadInt32();
                file.Dispose();
            }
            else if(filepath.EndsWith(".rwp"))
            {
                //第三步：读取图标
                string str = Application.StartupPath + @"\PC\temp\" + item.Name + ".gif";
                File.Copy(filepath, str);
                Bitmap bitmap = new Bitmap(str);
                item.Icon = bitmap;
            }

            
        }

        public static void readDIs(DirectoryInfo d,out ArrayList list)
        {
            list = new ArrayList();
            foreach (FileInfo f in d.GetFiles())
            {
                if(f.FullName.EndsWith(".rw"))
                {
                    //rw文件
                    string str = f.FullName.Substring(0, f.FullName.Length - 3);
                    DI dI = new DI("", new Bitmap(64, 64));
                    readDI(f.FullName, ref dI);
                    //rwp文件
                    readDI(str + ".rwp", ref dI);
                    list.Add(dI);

                }
            }

        }

}

}
