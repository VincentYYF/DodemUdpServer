using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Media;
using System.Diagnostics;
using System.Data.SqlClient;

namespace DodemUdpServer
{
    public partial class Form_Main : Form
    {
        public delegate void DelegateChangeText(string Messages);
        StringBuilder mStringBuilder = new StringBuilder();
        public delegate void DelegateDealByte(byte[] Messages);

        public delegate void DelegateDealString(string Messages);

        public delegate void DelegateDealDeviceOnline(string Messages);

        public delegate void DelegateDealDeviceStatus(byte[] Messages);

        UDPServerClass mUDPServer;

        string SelectDeviceName;
        public Form_Main()
        {
            InitializeComponent();
        }

        private void button_CreatServer_Click(object sender, EventArgs e)
        {
            mUDPServer = new UDPServerClass();
            string sIPaddress = comboBox_IP.Text;
            string sPort = textBox_PORT.Text;
            IPAddress myIPaddress = IPAddress.Parse(sIPaddress);
            int myPort = int.Parse(sPort);
            mUDPServer.MyIPAddress = myIPaddress;
            mUDPServer.PortName = myPort;
            mUDPServer.Thread_Listen();
            mUDPServer.MessageArrived += new UDPServerClass.MessageHandler(UDPServer_MessageArrived);
            mUDPServer.ByteMessageArrived += new UDPServerClass.ByteMessageHandler(UDPServer_ByteNessageArrived);
            mUDPServer.MessageDeviceOnline += new UDPServerClass.DeviceMessageHandler(UDPServer_DeviceOnline);
            mUDPServer.MessageDeviceStatus += new UDPServerClass.ByteMessageHandler(UDPServer_DeviceStatus);
           
        }

        private void button_CloseServer_Click(object sender, EventArgs e)
        {
            mUDPServer.CloseUdpThread();

        }
        void ChangeTxt(string Messages)
        {
            string SBText = mStringBuilder.ToString();
            mStringBuilder.Remove(0, mStringBuilder.Length);
            mStringBuilder.Append(Messages + "\r\n" + SBText);
            richTextBox_info.Text = mStringBuilder.ToString();
        }
        void UDPServer_MessageArrived(string Message)
        {
            richTextBox_info.Invoke(new DelegateChangeText(ChangeTxt), Message);
            //DelegateDealString ProtocolDealString = new DelegateDealString(EventDealString);
            //ProtocolDealString(Message);
        }

        void UDPServer_ByteNessageArrived(byte[] Message)
        {
            DelegateDealByte ProtocolDealByte = new DelegateDealByte(EventDealByte);
            ProtocolDealByte(Message);
        }

        void UDPServer_DeviceStatus(byte[] Message)
        {
            DelegateDealByte DealDeviceStatus = new DelegateDealByte(EventUpdateStatus);
            DealDeviceStatus(Message);
        }
        void ChangeTree(string Messages)
        {

            string name = "未识别设备";
            foreach (TreeNode node in this.treeView_DeviceList.Nodes)
            {
                string nodeName = node.FullPath;
                if (node.FullPath == name)
                    node.Nodes.Add(new TreeNode(Messages));
            }
        }
        void UDPServer_DeviceOnline(string DeviceIMEI)
        {
            this.treeView_DeviceList.Invoke(new DelegateDealDeviceOnline(ChangeTree),DeviceIMEI);
           
        }
        public void InitLocalIpStatus()
        {
            textBox_PORT.Text = "8080";
            comboBox_IP.Items.Add("127.0.0.1");
            IPAddress[] ips = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
            foreach (IPAddress ipa in ips)
            {
                Console.WriteLine("IP: {0}", ipa.ToString());
                if (ipa.AddressFamily == AddressFamily.InterNetwork)
                {
                    comboBox_IP.Items.Add(ipa.ToString());//获取本地IP地址
                    comboBox_IP.SelectedIndex = 0;
                    //IpMessageInit(MyIPAddress.ToString());
                    break;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitLocalIpStatus();
            InitDeviceTree();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //System.Environment.Exit(System.Environment.ExitCode);
            Environment.Exit(0);
        }

        public void InitDeviceTree()
        {
//             this.treeView_DeviceList.SelectedNode.ForeColor = Color.Black;
//             this.treeView_DeviceList.SelectedNode.BackColor = Color.Blue;
            DataSet ds_Department = getDataSet("type");
            foreach (DataRow dr in ds_Department.Tables[0].Rows)
            {
                //部门表绑定，作为一级层次  
                TreeNode tn_origine = new TreeNode();
                tn_origine.Text = dr["Name"].ToString();
                this.treeView_DeviceList.Nodes.Add(tn_origine);
            }
            TreeNode tc_origine = new TreeNode();
            tc_origine.Text = "未识别设备";
            this.treeView_DeviceList.Nodes.Add(tc_origine);
        }

        public DataSet getDataSet(string tableName)
        {
            DataSet ds = new DataSet();
            string strSQL = "select * from " + tableName;
            ds = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, strSQL, null);
            return ds;
        }

        public void EventDealString(string Messages)
        {
            Console.WriteLine("处理收到的数据String:{0}", Messages);

        }

        public void EventDealByte(byte[] Messages)
        {
            //Console.WriteLine("处理收到的数据Byte:{0}", Encoding.Default.GetString(Messages, 0, Messages.Length));
        }

        public void EventUpdateStatus(byte[] Messages)
        {
            Console.WriteLine("处理收到的数据Byte:{0}", Encoding.Default.GetString(Messages, 0, Messages.Length));
        }
        public void FlashDeviceStatus(string Device_IMEI)
        {
            TreeNode tnRet = null;
            foreach (TreeNode tn in this.treeView_DeviceList.Nodes)
            {
               /* tnRet = FindNode(tn, "");*/
                if (tnRet != null) break;
            }
        }

        private void button_SetPassWord_Click(object sender, EventArgs e)
        {
            string strPassWordOld = this.textBox_PassWordOld.Text;
            string strPassWordNew = this.textBox_PassWordNew.Text;
            byte[] ChangePassWordByte = new byte[8];
            string strPassWord;
            if (SelectDeviceName!=null)
            {
                if (strPassWordOld.Length == 4 && strPassWordNew.Length == 4)
                {
                    strPassWord = strPassWordOld + strPassWordNew;
                    ChangePassWordByte = System.Text.Encoding.Default.GetBytes(strPassWord);
                    mUDPServer.SendMessage_SetDevicePassWord(SelectDeviceName, ChangePassWordByte);
                }
                else
                {
                    MessageBox.Show("密码框请填写完整");
                }
               
            }
            else
            {
                MessageBox.Show("没有选中设备");
            }
           
        }

        private void button_SetParameters_Click(object sender, EventArgs e)
        {

        }

        private void treeView_DeviceList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Parent != null)
            {
                SelectDeviceName = e.Node.Text;
                //MessageBox.Show(SelectDeviceName);
                updateDeviceInfo(SelectDeviceName);
            }
        }

        public int updateDeviceInfo(string SelectDeviceName)
        {
            int res = 0;
            this.label_SelectDeviceName.Text = SelectDeviceName;
            res = mUDPServer.GetDeviceStatus(SelectDeviceName);
            return res;
        }

        private void treeView_DeviceList_DoubleClick(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// 获取当前设备的真实密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_GetPassWord_Click(object sender, EventArgs e)
        {

        }
    }
}
