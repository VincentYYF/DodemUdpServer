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
using System.Text.RegularExpressions;

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
        byte SelectDeviceFunction;
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
            this.treeView_DeviceList.Invoke(new DelegateDealDeviceOnline(ChangeTree), DeviceIMEI);

        }
        public void InitLocalIpStatus()
        {
            textBox_PORT.Text = "56666";
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
            InitDeviceFunction();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //System.Environment.Exit(System.Environment.ExitCode);
            Environment.Exit(0);
        }

        /// <summary>
        /// 设备树初始化，从SQL中获取设备种类
        /// </summary>
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

        /// <summary>
        /// 初始化设备功能列表
        /// </summary>
        public void InitDeviceFunction()
        {
            this.comboBox_Function.Items.Add("导地线拉力及倾角监测功能");
            this.comboBox_Function.Items.Add("绝缘子泄漏电流监测功能");
            this.comboBox_Function.Items.Add("气象数据监测功能");
            this.comboBox_Function.Items.Add("导线温度、电流数据监测功能");
            this.comboBox_Function.Items.Add("杆塔振动数据监测功能");
            this.comboBox_Function.Items.Add("导线侧倾角监测功能");
            this.comboBox_Function.Items.Add("舞动振幅频率监测功能");
            this.comboBox_Function.Items.Add("导线微风震动数据监测功能");
            this.comboBox_Function.Items.Add("综合防盗功能");
            this.comboBox_Function.Items.Add("山火报警功能");
            this.comboBox_Function.Items.Add("大风舞动报警功能");
            this.comboBox_Function.Items.Add("设备故障自检功能");
            this.comboBox_Function.Items.Add("微风振动动态数据监测功能");
            this.comboBox_Function.Items.Add("舞动动态数据监测功能");
            this.comboBox_Function.Items.Add("污秽数据监测功能");
            this.comboBox_Function.Items.Add("导线弧垂数据监测功能");
            this.comboBox_Function.Items.Add("电缆温度数据监测功能");
            this.comboBox_Function.Items.Add("电缆护层接地电流数据监测功能");
            this.comboBox_Function.Items.Add("故障定位数据监测功能");
            this.comboBox_Function.Items.Add("电缆局放数据监测功能");
            this.comboBox_Function.Items.Add("文件传输功能");
            this.comboBox_Function.Items.Add("图像监测功能");
            this.comboBox_Function.SelectedIndex = 0;
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
            if (Messages[7] == 0x05)
            {
                byte[] DeviceTime = new byte[6];
                byte[] DeviceSignel = new byte[1];
                byte[] DeviceVoltage = new byte[1];
                DeviceTime[0] = Messages[10];
                DeviceTime[0] = Messages[11];
                DeviceTime[0] = Messages[12];
                DeviceTime[0] = Messages[13];
                DeviceTime[0] = Messages[14];
                DeviceTime[0] = Messages[15];
                DeviceSignel[0] = Messages[16];
                DeviceVoltage[0] = Messages[17];
                string strDeviceTime = (DeviceTime[0] + 2000).ToString("X2");
                strDeviceTime += "-";
                strDeviceTime = (DeviceTime[1]).ToString("X2");
                strDeviceTime += "-";
                strDeviceTime = (DeviceTime[2]).ToString("X2");
                strDeviceTime += " ";
                strDeviceTime = (DeviceTime[3]).ToString("X2");
                strDeviceTime += ":";
                strDeviceTime = (DeviceTime[4]).ToString("X2");
                strDeviceTime += ":";
                strDeviceTime = (DeviceTime[5]).ToString("X2");

                string strDeviceSignel = DeviceSignel[0].ToString("X2");
                string strDeviceVoltage = DeviceVoltage[0].ToString("X2");

                this.label_DeviceTime.Text = strDeviceTime;
                this.label_DeviceSignal.Text = strDeviceTime;
                this.label_DeviceVoltage.Text = strDeviceTime;
            }
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
            if (SelectDeviceName != null)
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

        /// <summary>
        /// 设备设备参数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_SetParameters_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 鼠标点击tree之后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView_DeviceList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Parent != null)
            {
                SelectDeviceName = e.Node.Text;
                //MessageBox.Show(SelectDeviceName);
                updateDeviceInfo(SelectDeviceName);
            }
        }

        /// <summary>
        /// 更新一次设备控件，发送设备心跳包数据来解析
        /// </summary>
        /// <param name="SelectDeviceName"></param>
        /// <returns></returns>
        public int updateDeviceInfo(string SelectDeviceName)
        {
            int res = 0;
            this.label_SelectDeviceName.Text = SelectDeviceName;
            res = mUDPServer.GetDeviceStatus(SelectDeviceName);
            return res;
        }

        /// <summary>
        /// 设备树木双击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// 设备设备主站信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_SetStation_Click(object sender, EventArgs e)
        {
            string strStationIpOld = this.textBox_StationIpOld.Text;
            string strStationIpNew = this.textBox_StationIpNew.Text;
            byte[] byteIpOld = new byte[4];
            byte[] byteIpNew = new byte[4];

            string strStationPortOld = this.textBox_StationPortOld.Text;
            string strStationPortNew = this.textBox_StationPortNew.Text;
            byte[] bytePortOld = new byte[2];
            byte[] bytePortNew = new byte[2];

            string strStationCardNumberOld = this.textBox_StationCardNumberOld.Text;
            string strStationCardNumberNew = this.textBox_StationCardNumberNew.Text;
            byte[] byteCardOld = new byte[6];
            byte[] byteCardNew = new byte[6];

            string strPassWord = this.textBox_DevicePassWord.Text;
            byte[] orderByte = new byte[28];
            byte[] bytePassWord = new byte[4];
            if (SelectDeviceName != null)
            {
                if (strPassWord.Length == 4)
                {
                    bytePassWord = System.Text.Encoding.Default.GetBytes(strPassWord);
                    string[] ipold = strStationIpOld.Split('.');
                    string[] ipnew = strStationIpNew.Split('.');
                    if(ipold.Length==4 && ipnew.Length==4)
                    {
                        byteIpOld = byteEnCodeIp(ipold);
                        byteIpNew = byteEnCodeIp(ipnew);
                    }
                    else
                    {
                        MessageBox.Show("IP地址请正确填写");
                        return;
                    }
                    if(IsNumeric(strStationPortOld) && IsNumeric(strStationPortNew))
                    {
                        int hPortOld = int.Parse(strStationPortOld)/255;
                        int lPortOld = int.Parse(strStationPortOld)%255;
                        bytePortOld[0] = (byte)hPortOld;
                        bytePortOld[1] = (byte)lPortOld;

                        int hPortNew = int.Parse(strStationPortNew) / 255;
                        int lPortNew = int.Parse(strStationPortNew) % 255;
                        bytePortNew[0] = (byte)hPortNew;
                        bytePortNew[1] = (byte)lPortNew;

                    }
                    else
                    {
                        MessageBox.Show("端口请正确填写");
                        return;
                    }
                    if(IsHealthTel(strStationCardNumberOld)&& IsHealthTel(strStationCardNumberNew))
                    {
                        string tempStr;
                        tempStr = strStationCardNumberOld.Substring(0, 1);
                        byteCardOld[0] = (byte)(Convert.ToSByte(tempStr, 16) + 240);
                        tempStr = strStationCardNumberNew.Substring(0, 1);
                        byteCardNew[0] = (byte)(Convert.ToSByte(tempStr, 16) * 240);
                        for (int i=0;i<5; i++)
                        {
                            tempStr = strStationCardNumberOld.Substring(1+i*2, 2);
                            byteCardOld[i+1] = (byte)Convert.ToSByte(tempStr, 16);
                            tempStr = strStationCardNumberNew.Substring(1 + i * 2, 2);
                            byteCardNew[i + 1] = (byte)Convert.ToSByte(tempStr, 16);

                        }
                        
                       
                        //byteCardOld[i+1] = tempbyteCardOld[i];
                        //byteCardNew[i+1] = tempbyteCardNew[i];

                    }
                    else
                    {
                        MessageBox.Show("电话号码请正确填写");
                        return;
                    }
                    orderByte[0] = bytePassWord[0];
                    orderByte[1] = bytePassWord[1];
                    orderByte[2] = bytePassWord[2];
                    orderByte[3] = bytePassWord[3];

                    orderByte[4] = byteIpOld[0];
                    orderByte[5] = byteIpOld[1];
                    orderByte[6] = byteIpOld[2];
                    orderByte[7] = byteIpOld[3];

                    orderByte[8] = bytePortOld[0];
                    orderByte[9] = bytePortOld[1];
                   
                    orderByte[10] = byteIpNew[0];
                    orderByte[11] = byteIpNew[1];
                    orderByte[12] = byteIpNew[2];
                    orderByte[13] = byteIpNew[3];

                    orderByte[14] = bytePortNew[0];
                    orderByte[15] = bytePortNew[1];
                  
                    orderByte[16] = byteCardOld[0];
                    orderByte[17] = byteCardOld[1];
                    orderByte[18] = byteCardOld[2];
                    orderByte[19] = byteCardOld[3];
                    orderByte[20] = byteCardOld[4];
                    orderByte[21] = byteCardOld[5];

                    orderByte[22] = byteCardNew[0];
                    orderByte[23] = byteCardNew[1];
                    orderByte[24] = byteCardNew[2];
                    orderByte[25] = byteCardNew[3];
                    orderByte[26] = byteCardNew[4];
                    orderByte[27] = byteCardNew[5];

                    mUDPServer.SendMessage_SetDeviceStationParameter(SelectDeviceName, orderByte);
                }
                else
                {
                    MessageBox.Show("密码框请填写完整");
                    return;
                }

            }
            else
            {
                MessageBox.Show("没有选中设备");
            }
        }

        /// <summary>
        /// string 转化为四字节byte
        /// </summary>
        /// <param name="ips"></param>
        /// <returns></returns>
        public byte[] byteEnCodeIp(String[] ips)
        {

           // String[] ips = ip.Split('.');

            byte[] ipbs = new byte[4];

            //IP地址压缩成4字节,如果要进一步处理的话,就可以转换成一个int了. 

            for (int i = 0; i < 4; i++)
            {

                int m = int.Parse(ips[i]);

                byte b = (byte)m;

                if (m > 127)
                {

                    b = (byte)(127 - m);

                }

                ipbs[i] = b;

            }
            return ipbs;
        }

        /// <summary>
        /// 检查string是不是数字
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNumeric(string value)
        {
            return Regex.IsMatch(value, @"^[+-]?\d*[.]?\d*$");
        }

        /// <summary>
        /// string是否是个电话号码
        /// </summary>
        /// <param name="strInput"></param>
        /// <returns></returns>
        public static bool IsTel(string strInput)
        {
            return Regex.IsMatch(strInput, @"\d{3}-\d{8}|\d{4}-\d{7}");
        }

        /// <summary>
        /// 判断string是不是电话格式
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsHealthTel(string str)
        {
            if(IsNumeric(str))
            {
                if (str.Length == 11)
                {
                    return true;
                }
                else
                    return false;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 重置设备
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_DeviceReset_Click(object sender, EventArgs e)
        {
            string strPassWord = this.textBox_DevicePassWord.Text;
            byte[] orderByte = new byte[4];
            if (SelectDeviceName != null)
            {
                if(strPassWord.Length==4)
                {
                    orderByte = System.Text.Encoding.Default.GetBytes(strPassWord);
                    mUDPServer.SendMessage_SetDeviceReset(SelectDeviceName, orderByte);
                }
                else
                {
                    MessageBox.Show("请填对设备密码");
                }
                    
            }
            else
            {
                MessageBox.Show("没有选中设备");
            }
        }

        /// <summary>
        /// 短信唤醒
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_WeekUp_Click(object sender, EventArgs e)
        {
            string strPassWord = this.textBox_DevicePassWord.Text;
            byte[] orderByte = new byte[4];
            if (SelectDeviceName != null)
            {
                if (strPassWord.Length == 4)
                {
                    orderByte = System.Text.Encoding.Default.GetBytes(strPassWord);
                    mUDPServer.SendMessage_SetDeviceWeekUp(SelectDeviceName, orderByte);
                }
                else
                {
                    MessageBox.Show("请填对设备密码");
                }

            }
            else
            {
                MessageBox.Show("没有选中设备");
            }
        }

        /// <summary>
        /// 查询设备参数配置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_CheckDeviceParameters_Click(object sender, EventArgs e)
        {
            if (SelectDeviceName != null)
            {
                mUDPServer.SendMessage_GetDeviceInfo(SelectDeviceName);
            }
            else
            {
                MessageBox.Show("没有选中设备");
            }
        }

        /// <summary>
        /// 设备功能选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox_Function_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(comboBox_Function.SelectedIndex.ToString());
            string SelectValue = comboBox_Function.Text;
            switch(SelectValue)
            {
                case "导地线拉力及倾角监测功能":
                    this.textBox_OrderNumber.Text = "0x22";
                    SelectDeviceFunction = 0x22;
                    break;
                case "绝缘子泄漏电流监测功能":
                    this.textBox_OrderNumber.Text = "0x24";
                    SelectDeviceFunction = 0x24;
                    break;
                case "气象数据监测功能":
                    this.textBox_OrderNumber.Text = "0x25";
                    SelectDeviceFunction = 0x25;
                    break;
                case "导线温度、电流数据监测功能":
                    this.textBox_OrderNumber.Text = "0x26";
                    SelectDeviceFunction = 0x26;
                    break;
                case "杆塔振动数据监测功能":
                    this.textBox_OrderNumber.Text = "0x27";
                    SelectDeviceFunction = 0x27;
                    break;
                case "导线侧倾角监测功能":
                    this.textBox_OrderNumber.Text = "0x28";
                    SelectDeviceFunction = 0x28;
                    break;
                case "舞动振幅频率监测功能":
                    this.textBox_OrderNumber.Text = "0x29";
                    SelectDeviceFunction = 0x29;
                    break;
                case "杆塔倾斜数据监测功能":
                    this.textBox_OrderNumber.Text = "0x2A";
                    SelectDeviceFunction = 0x2A;
                    break;
                case "导线微风震动数据监测功能":
                    this.textBox_OrderNumber.Text = "0x2B";
                    SelectDeviceFunction = 0x2B;
                    break;
                case "综合防盗功能":
                    this.textBox_OrderNumber.Text = "0x2C";
                    SelectDeviceFunction = 0x2C;
                    break;
                case "山火报警功能":
                    this.textBox_OrderNumber.Text = "0x2D";
                    SelectDeviceFunction = 0x2D;
                    break;
                case "大风舞动报警功能":
                    this.textBox_OrderNumber.Text = "0x2E";
                    SelectDeviceFunction = 0x2E;
                    break;
                case "设备故障自检功能":
                    this.textBox_OrderNumber.Text = "0x30";
                    SelectDeviceFunction = 0x30;
                    break;
                case "微风振动动态数据监测功能":
                    this.textBox_OrderNumber.Text = "0x32";
                    SelectDeviceFunction = 0x32;
                    break;
                case "舞动动态数据监测功能":
                    this.textBox_OrderNumber.Text = "0x36";
                    SelectDeviceFunction = 0x36;
                    break;
                case "污秽数据监测功能":
                    this.textBox_OrderNumber.Text = "0x41";
                    SelectDeviceFunction = 0x41;
                    break;
                case "导线弧垂数据监测功能":
                    this.textBox_OrderNumber.Text = "0x42";
                    SelectDeviceFunction = 0x42;
                    break;
                case "电缆温度数据监测功能":
                    this.textBox_OrderNumber.Text = "0x43";
                    SelectDeviceFunction = 0x43;
                    break;
                case "电缆护层接地电流数据监测功能":
                    this.textBox_OrderNumber.Text = "0x44";
                    SelectDeviceFunction = 0x44;
                    break;
                case "故障定位数据监测功能":
                    this.textBox_OrderNumber.Text = "0x45";
                    SelectDeviceFunction = 0x45;
                    break;
                case "电缆局放数据监测功能":
                    this.textBox_OrderNumber.Text = "0x46";
                    SelectDeviceFunction = 0x46;
                    break;
                case "文件传输功能":
                    this.textBox_OrderNumber.Text = "0x73";
                    SelectDeviceFunction = 0x73;
                    break;
                case "图像监测功能":
                    this.textBox_OrderNumber.Text = "0x84";
                    SelectDeviceFunction = 0x84;
                    break;

            }
        }

        /// <summary>
        /// 设置设备功能 0x0B
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_SetDeviceFunction_Click(object sender, EventArgs e)
        {
            string strPassWord = this.textBox_ResetPassWord.Text;
            byte[] bytePassWord = new byte[4];
            byte[] orderByte = new byte[5];
            orderByte[4] = SelectDeviceFunction;
            if (SelectDeviceName != null)
            {
                if(strPassWord.Length==4)
                {
                    bytePassWord = System.Text.Encoding.Default.GetBytes(strPassWord);
                    orderByte[0] = bytePassWord[0];
                    orderByte[1] = bytePassWord[1];
                    orderByte[2] = bytePassWord[2];
                    orderByte[3] = bytePassWord[3];

                    mUDPServer.SendMessage_SetDeviceFunction(SelectDeviceName, orderByte);
                }
                else
                {
                    MessageBox.Show("请正确填好设备密码");
                }
               
            }
            else
            {
                MessageBox.Show("没有选中设备");
            }
        }

        /// <summary>
        /// 查询设备时间 0x0D
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_CheckDeviceTime_Click(object sender, EventArgs e)
        {
            if (SelectDeviceName != null)
            {
                mUDPServer.SendMessage_GetDeviceTime(SelectDeviceName);
            }
            else
            {
                MessageBox.Show("没有选中设备");
            }
        }

        /// <summary>
        /// 上传历史数据 0x21
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_UpLoadHistory_Click(object sender, EventArgs e)
        {
            if (SelectDeviceName != null)
            {
                mUDPServer.SendMessage_GetDeviceHistoryData(SelectDeviceName);
            }
            else
            {
                MessageBox.Show("没有选中设备");
            }
        }

        /// <summary>
        /// 上传最新数据 0x21 0xBBBB
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_UpLoadNow_Click(object sender, EventArgs e)
        {
           
            byte[] orderByte = new byte[2];
          
            if (SelectDeviceName != null)
            {
                orderByte[0] = 0xBB;
                orderByte[1] = 0xBB;
                mUDPServer.SendMessage_GetDeviceNowData(SelectDeviceName, orderByte);

            }
            else
            {
                MessageBox.Show("没有选中设备");
            }
        }

        /// <summary>
        /// 主动请求图片上传 0x83
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_RequestPicture_Click(object sender, EventArgs e)
        {
            byte[] orderByte = new byte[2];
            if(this.radioButton_Channel1.Checked==true)
            {
                orderByte[0] = 0x01;
            }
            else
            {
                orderByte[0] = 0x02;
            }

            if (SelectDeviceName != null)
            {
                
                orderByte[1] = 0x00;
                mUDPServer.SendMessage_GetDeviceNowPicture(SelectDeviceName, orderByte);

            }
            else
            {
                MessageBox.Show("没有选中设备");
            }
        }
    }
}
