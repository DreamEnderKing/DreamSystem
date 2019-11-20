using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;



namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            wifi wifi = new wifi();
            uint a = 0;
            IntPtr handle = IntPtr.Zero;
            uint r = wifi.WlanOpenHandle(2, IntPtr.Zero, out a, ref handle);
            IntPtr ppInterfaceList = IntPtr.Zero;
            wifi.WLAN_INTERFACE_INFO_LIST interfaceList;
            if (wifi.WlanEnumInterfaces(handle, IntPtr.Zero, ref ppInterfaceList) == 0)
            {
                interfaceList = new wifi.WLAN_INTERFACE_INFO_LIST(ppInterfaceList);
                Console.WriteLine("有{0}个无线网络适配器", interfaceList.dwNumberOfItems);
                for (int i = 0; i < interfaceList.dwNumberOfItems; i++)
                {
                    Console.WriteLine("{0}", interfaceList.InterfaceInfo[i].strInterfaceDescription);
                    IntPtr ppAvailableNetworkList = new IntPtr();
                    Guid pInterfaceGuid = interfaceList.InterfaceInfo[i].InterfaceGuid;
                    wifi.WlanGetAvailableNetworkList(handle, ref pInterfaceGuid, 0x00000002, IntPtr.Zero, ref ppAvailableNetworkList);
                    wifi.WLAN_AVAILABLE_NETWORK_LIST wlanAvailableNetworkList = new wifi.WLAN_AVAILABLE_NETWORK_LIST(ppAvailableNetworkList);

                    for (int j = 0; j < wlanAvailableNetworkList.dwNumberOfItems; j++)
                    {
                        wifi.WLAN_AVAILABLE_NETWORK network = wlanAvailableNetworkList.wlanAvailableNetwork[j];
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Available Network: ");
                        Console.WriteLine("SSID: " + network.dot11Ssid.ucSSID);
                        Console.WriteLine("StrProfile:" + network.strProfileName);
                        Console.WriteLine("Encrypted: " + network.bSecurityEnabled);
                        Console.WriteLine("Signal Strength: " + network.wlanSignalQuality);
                        Console.WriteLine("Default Authentication: " + network.dot11DefaultAuthAlgorithm.ToString());
                        Console.WriteLine("Default Cipher: " + network.dot11DefaultCipherAlgorithm.ToString());
                        Console.WriteLine();
                        Console.Read();
                    }

                    wifi.WlanFreeMemory(ppAvailableNetworkList);

                }

            }




        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;

            login form2 = new login();

            form2.Show();
            this.Close();
        }

        [DllImport("User32.dll")]
        public static extern int PrivateExtractIcons(
              string lpszFile, //文件名可以是exe,dll,ico,cur,ani,bmp
              int nIconIndex,  //从第几个图标开始获取
              int cxIcon,      //获取图标的尺寸x
              int cyIcon,      //获取图标的尺寸y
              IntPtr[] phicon, //获取到的图标指针数组
              int[] piconid,   //图标对应的资源编号
              int nIcons,      //指定获取的图标数量，仅当文件类型为.exe 和 .dll时候可用
             int flags        //标志，默认0就可以，具体可以看LoadImage函数
         );

        private void button2_Click(object sender, EventArgs e)
        {
            //选择对话框
            OpenFileDialog opfd = new OpenFileDialog();
            if (opfd.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            var file = opfd.FileName;
            //指定存放图标的文件夹
            const string folderToSave = "D:\\temp\\";
            if (!Directory.Exists(folderToSave)) Directory.CreateDirectory(folderToSave);
            //选中文件中的图标总数
            var iconTotalCount = PrivateExtractIcons(file, 0, 0, 0, null, null, 0, 0);
            //用于接收获取到的图标指针
            IntPtr[] hIcons = new IntPtr[iconTotalCount];
            //对应的图标id
            int[] ids = new int[iconTotalCount];
            //成功获取到的图标个数
            var successCount = PrivateExtractIcons(file, 0, 256, 256, hIcons, ids, iconTotalCount, 0);
            //保存图标
            int i = 0;
            if (hIcons[i] == IntPtr.Zero)
            { }
            else
            {
                using (var ico = Icon.FromHandle(hIcons[i]))
                {
                    using (var myIcon = ico.ToBitmap())
                    {
                        myIcon.Save(folderToSave + ids[i].ToString("000") + ".png", ImageFormat.Png);
                    }
                }
            }
        }
        class image_dealer
        {
            public Bitmap WayOne(string file)
            {
                using (Image i = new Bitmap(file))
                {
                    Bitmap b = new Bitmap(i.Width, i.Height);
                    using (Graphics g = Graphics.FromImage(b))
                    {
                        g.FillEllipse(new TextureBrush(i), 0, 0, i.Width, i.Height);
                    }
                    return b;
                }
            }


            public Bitmap WayTwo(string file)
            {
                using (Image i = new Bitmap(file))
                {
                    Bitmap b = new Bitmap(i.Width, i.Height);
                    using (Graphics g = Graphics.FromImage(b))
                    {
                        g.DrawImage(i, 0, 0, b.Width, b.Height);
                        int r = Math.Min(b.Width, b.Height) / 2;
                        PointF c = new PointF(b.Width / 2.0F, b.Height / 2.0F);
                        for (int h = 0; h < b.Height; h++)
                            for (int w = 0; w < b.Width; w++)
                                if ((int)Math.Pow(r, 2) < ((int)Math.Pow(w * 1.0 - c.X, 2) + (int)Math.Pow(h * 1.0 - c.Y, 2)))
                                {
                                    b.SetPixel(w, h, Color.Transparent);
                                }
                    }
                    return b;
                }
            }

            public Bitmap WaySOne(string file)
            {
                using (Image i = new Bitmap(file))
                {
                    Bitmap b = new Bitmap(i.Width, i.Height);
                    using (Graphics g = Graphics.FromImage(b))
                    {
                        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                        using (System.Drawing.Drawing2D.GraphicsPath p = new System.Drawing.Drawing2D.GraphicsPath(System.Drawing.Drawing2D.FillMode.Alternate))
                        {
                            p.AddEllipse(0, 0, i.Width, i.Height);
                            g.FillPath(new TextureBrush(i), p);
                        }
                        //g.FillEllipse(new TextureBrush(i), 0, 0, i.Width, i.Height);
                    }
                    return b;
                }
            }
            public Bitmap WaySTwo(string file)
            {
                using (Image i = new Bitmap(file))
                {
                    Bitmap b = new Bitmap(i.Width, i.Height);
                    using (Graphics g = Graphics.FromImage(b))
                    {
                        g.DrawImage(i, 0, 0, b.Width, b.Height);
                        int r = Math.Min(b.Width, b.Height) / 2;
                        PointF c = new PointF(b.Width / 2.0F, b.Height / 2.0F);
                        for (int h = 0; h < b.Height; h++)
                            for (int w = 0; w < b.Width; w++)
                                if ((int)Math.Pow(r, 2) < ((int)Math.Pow(w * 1.0 - c.X, 2) + (int)Math.Pow(h * 1.0 - c.Y, 2)))
                                {
                                    b.SetPixel(w, h, Color.Transparent);
                                }
                        //画背景色圆
                        using (Pen p = new Pen(System.Drawing.SystemColors.Control))
                            g.DrawEllipse(p, 0, 0, b.Width, b.Height);
                    }
                    return b;
                }
            }
        }

        class wifi
        {
            [DllImport("wlanapi", EntryPoint = "WlanOpenHandle")]
            public static extern uint WlanOpenHandle(uint dwClientVersion, IntPtr pReserved, [Out]out uint pdwNegotiatedVersion, ref IntPtr phClientHandle);
            [DllImport("wlanapi", EntryPoint = "WlanEnumInterfaces")]
            public static extern uint WlanEnumInterfaces([In] IntPtr hHandle, IntPtr pReserved, ref IntPtr ppInterfaceList);
            [DllImport("Wlanapi", EntryPoint = "WlanGetAvailableNetworkList")]
            public static extern uint WlanGetAvailableNetworkList(IntPtr hClientHandle, ref Guid pInterfaceGuid, uint dwFlags, IntPtr pReserved, ref IntPtr ppAvailableNetworkList);
            [DllImport("Wlanapi", EntryPoint = "WlanFreeMemory")]
            public static extern void WlanFreeMemory([In] IntPtr pMemory);


            public enum WLAN_INTERFACE_STATE
            {
                wlan_interface_state_not_ready = 0,
                wlan_interface_state_connected = 1,
                wlan_interface_state_ad_hoc_network_formed = 2,
                wlan_interface_state_disconnecting = 3,
                wlan_interface_state_disconnected = 4,
                wlan_interface_state_associating = 5,
                wlan_interface_state_discovering = 6,
                wlan_interface_state_authenticating = 7
            }
            public enum DOT11_BSS_TYPE
            {
                dot11_BSS_type_infrastructure = 1,
                dot11_BSS_type_independent = 2,
                dot11_BSS_type_any = 3,
            }
            public enum DOT11_PHY_TYPE
            {

                dot11_phy_type_unknown = 1,
                dot11_phy_type_any,
                dot11_phy_type_fhss,
                dot11_phy_type_dsss,
                dot11_phy_type_irbaseband,
                dot11_phy_type_ofdm,
                dot11_phy_type_hrdsss,
                dot11_phy_type_erp,
                dot11_phy_type_ht,
                dot11_phy_type_IHV_start,
                dot11_phy_type_IHV_end
            }
            public enum DOT11_AUTH_ALGORITHM
            {
                DOT11_AUTH_ALGO_80211_OPEN = 1,
                DOT11_AUTH_ALGO_80211_SHARED_KEY = 2,
                DOT11_AUTH_ALGO_WPA = 3,
                DOT11_AUTH_ALGO_WPA_PSK = 4,
                DOT11_AUTH_ALGO_WPA_NONE = 5,
                DOT11_AUTH_ALGO_RSNA = 6,
                DOT11_AUTH_ALGO_RSNA_PSK = 7,
                DOT11_AUTH_ALGO_IHV_START = -2147483648,
                DOT11_AUTH_ALGO_IHV_END = -1,
            }
            public enum DOT11_CIPHER_ALGORITHM
            {
                DOT11_CIPHER_ALGO_NONE = 0,
                DOT11_CIPHER_ALGO_WEP40 = 1,
                DOT11_CIPHER_ALGO_TKIP = 2,
                DOT11_CIPHER_ALGO_CCMP = 4,
                DOT11_CIPHER_ALGO_WEP104 = 5,
                DOT11_CIPHER_ALGO_WPA_USE_GROUP = 256,
                DOT11_CIPHER_ALGO_RSN_USE_GROUP = 256,
                DOT11_CIPHER_ALGO_WEP = 257,
                DOT11_CIPHER_ALGO_IHV_START = -2147483648,
                DOT11_CIPHER_ALGO_IHV_END = -1,
            }


            [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
            public struct DOT11_SSID
            {
                public uint uSSIDLength;
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
                public string ucSSID;
            }

            [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
            public struct WLAN_INTERFACE_INFO
            {
                /// GUID->_GUID
                public Guid InterfaceGuid;//Guid自动生成代码
                                          /// WCHAR[256]
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
                public string strInterfaceDescription;
                /// WLAN_INTERFACE_STATE->_WLAN_INTERFACE_STATE
                public WLAN_INTERFACE_STATE isState;
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct WLAN_INTERFACE_INFO_LIST //struct结构
            {
                public Int32 dwNumberOfItems;
                public Int32 dwIndex;
                public WLAN_INTERFACE_INFO[] InterfaceInfo;
                public WLAN_INTERFACE_INFO_LIST(IntPtr pList)
                {
                    dwNumberOfItems = Marshal.ReadInt32(pList, 0);
                    dwIndex = Marshal.ReadInt32(pList, 4);
                    InterfaceInfo = new WLAN_INTERFACE_INFO[dwNumberOfItems];
                    for (int i = 0; i < dwNumberOfItems; i++)
                    {
                        IntPtr pItemList = new IntPtr(pList.ToInt32() + (i * 532) + 8);
                        WLAN_INTERFACE_INFO wii = new WLAN_INTERFACE_INFO();
                        wii = (WLAN_INTERFACE_INFO)Marshal.PtrToStructure(pItemList, typeof(WLAN_INTERFACE_INFO));
                        InterfaceInfo[i] = wii;
                    }
                }
            }

            [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
            public struct WLAN_AVAILABLE_NETWORK
            {
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
                public string strProfileName;
                public DOT11_SSID dot11Ssid;
                public DOT11_BSS_TYPE dot11BssType;
                public uint uNumberOfBssids;
                public bool bNetworkConnectable;
                public uint wlanNotConnectableReason;
                public uint uNumberOfPhyTypes;
                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
                public DOT11_PHY_TYPE[] dot11PhyTypes;
                public bool bMorePhyTypes;
                public uint wlanSignalQuality;
                public bool bSecurityEnabled;
                public DOT11_AUTH_ALGORITHM dot11DefaultAuthAlgorithm;
                public DOT11_CIPHER_ALGORITHM dot11DefaultCipherAlgorithm;
                public uint dwFlags;
                public uint dwReserved;
            }
            [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
            public struct WLAN_AVAILABLE_NETWORK_LIST
            {
                internal uint dwNumberOfItems;
                internal uint dwIndex;
                internal WLAN_AVAILABLE_NETWORK[] wlanAvailableNetwork;

                internal WLAN_AVAILABLE_NETWORK_LIST(IntPtr ppAvailableNetworkList)
                {
                    dwNumberOfItems = (uint)Marshal.ReadInt32(ppAvailableNetworkList);
                    dwIndex = (uint)Marshal.ReadInt32(ppAvailableNetworkList, 4);
                    wlanAvailableNetwork = new WLAN_AVAILABLE_NETWORK[dwNumberOfItems];

                    for (int i = 0; i < dwNumberOfItems; i++)
                    {
                        IntPtr pWlanAvailableNetwork = new IntPtr(ppAvailableNetworkList.ToInt32() + i * Marshal.SizeOf(typeof(WLAN_AVAILABLE_NETWORK)) + 8);
                        wlanAvailableNetwork[i] = (WLAN_AVAILABLE_NETWORK)Marshal.PtrToStructure(pWlanAvailableNetwork, typeof(WLAN_AVAILABLE_NETWORK));
                    }
                }
            }

        }
    }
}
