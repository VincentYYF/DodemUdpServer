namespace DodemUdpServer
{
    partial class Form_Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button_CreatServer = new System.Windows.Forms.Button();
            this.button_CloseServer = new System.Windows.Forms.Button();
            this.textBox_PORT = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBox_info = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox_IP = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox_PassWordOld = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.button_GetPassWord = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox_PassWordNew = new System.Windows.Forms.TextBox();
            this.button_SetPassWord = new System.Windows.Forms.Button();
            this.button_SetParameters = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_PassWord = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.treeView_DeviceList = new System.Windows.Forms.TreeView();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.textBox_AHPassWord = new System.Windows.Forms.TextBox();
            this.textBox_RestarTime = new System.Windows.Forms.TextBox();
            this.textBox_OnlineTime = new System.Windows.Forms.TextBox();
            this.textBox_SleepTime = new System.Windows.Forms.TextBox();
            this.textBox_SampIntevalr = new System.Windows.Forms.TextBox();
            this.textBox_HeartTime = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabControl_Basic = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.label_SelectDeviceName = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.tabControl_Basic.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_CreatServer
            // 
            this.button_CreatServer.Location = new System.Drawing.Point(196, 18);
            this.button_CreatServer.Name = "button_CreatServer";
            this.button_CreatServer.Size = new System.Drawing.Size(75, 23);
            this.button_CreatServer.TabIndex = 0;
            this.button_CreatServer.Text = "创建服务";
            this.button_CreatServer.UseVisualStyleBackColor = true;
            this.button_CreatServer.Click += new System.EventHandler(this.button_CreatServer_Click);
            // 
            // button_CloseServer
            // 
            this.button_CloseServer.Location = new System.Drawing.Point(196, 65);
            this.button_CloseServer.Name = "button_CloseServer";
            this.button_CloseServer.Size = new System.Drawing.Size(75, 23);
            this.button_CloseServer.TabIndex = 1;
            this.button_CloseServer.Text = "关闭服务";
            this.button_CloseServer.UseVisualStyleBackColor = true;
            this.button_CloseServer.Click += new System.EventHandler(this.button_CloseServer_Click);
            // 
            // textBox_PORT
            // 
            this.textBox_PORT.Location = new System.Drawing.Point(67, 65);
            this.textBox_PORT.Name = "textBox_PORT";
            this.textBox_PORT.Size = new System.Drawing.Size(121, 21);
            this.textBox_PORT.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "IP地址";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "端口号";
            // 
            // richTextBox_info
            // 
            this.richTextBox_info.Location = new System.Drawing.Point(6, 21);
            this.richTextBox_info.MaxLength = 50;
            this.richTextBox_info.Name = "richTextBox_info";
            this.richTextBox_info.Size = new System.Drawing.Size(769, 201);
            this.richTextBox_info.TabIndex = 6;
            this.richTextBox_info.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.richTextBox_info);
            this.groupBox1.Location = new System.Drawing.Point(212, 391);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(784, 228);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "消息框";
            // 
            // comboBox_IP
            // 
            this.comboBox_IP.FormattingEnabled = true;
            this.comboBox_IP.Location = new System.Drawing.Point(67, 20);
            this.comboBox_IP.Name = "comboBox_IP";
            this.comboBox_IP.Size = new System.Drawing.Size(121, 20);
            this.comboBox_IP.TabIndex = 8;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button_CreatServer);
            this.groupBox2.Controls.Add(this.comboBox_IP);
            this.groupBox2.Controls.Add(this.button_CloseServer);
            this.groupBox2.Controls.Add(this.textBox_PORT);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(716, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(280, 100);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox_PassWordOld);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.button_GetPassWord);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.textBox_PassWordNew);
            this.groupBox3.Controls.Add(this.button_SetPassWord);
            this.groupBox3.Location = new System.Drawing.Point(6, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(444, 181);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "基本信息";
            // 
            // textBox_PassWordOld
            // 
            this.textBox_PassWordOld.Location = new System.Drawing.Point(67, 60);
            this.textBox_PassWordOld.Name = "textBox_PassWordOld";
            this.textBox_PassWordOld.Size = new System.Drawing.Size(100, 21);
            this.textBox_PassWordOld.TabIndex = 6;
            this.textBox_PassWordOld.Text = "1234";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(14, 64);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 12);
            this.label11.TabIndex = 5;
            this.label11.Text = "老密码";
            // 
            // button_GetPassWord
            // 
            this.button_GetPassWord.Location = new System.Drawing.Point(190, 58);
            this.button_GetPassWord.Name = "button_GetPassWord";
            this.button_GetPassWord.Size = new System.Drawing.Size(75, 23);
            this.button_GetPassWord.TabIndex = 4;
            this.button_GetPassWord.Text = "获取终端密码";
            this.button_GetPassWord.UseVisualStyleBackColor = true;
            this.button_GetPassWord.Click += new System.EventHandler(this.button_GetPassWord_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(14, 23);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 3;
            this.label10.Text = "新密码";
            // 
            // textBox_PassWordNew
            // 
            this.textBox_PassWordNew.Location = new System.Drawing.Point(67, 17);
            this.textBox_PassWordNew.Name = "textBox_PassWordNew";
            this.textBox_PassWordNew.Size = new System.Drawing.Size(100, 21);
            this.textBox_PassWordNew.TabIndex = 2;
            // 
            // button_SetPassWord
            // 
            this.button_SetPassWord.Location = new System.Drawing.Point(190, 17);
            this.button_SetPassWord.Name = "button_SetPassWord";
            this.button_SetPassWord.Size = new System.Drawing.Size(75, 23);
            this.button_SetPassWord.TabIndex = 0;
            this.button_SetPassWord.Text = "设置终端密码";
            this.button_SetPassWord.UseVisualStyleBackColor = true;
            this.button_SetPassWord.Click += new System.EventHandler(this.button_SetPassWord_Click);
            // 
            // button_SetParameters
            // 
            this.button_SetParameters.Location = new System.Drawing.Point(363, 145);
            this.button_SetParameters.Name = "button_SetParameters";
            this.button_SetParameters.Size = new System.Drawing.Size(75, 23);
            this.button_SetParameters.TabIndex = 1;
            this.button_SetParameters.Text = "配置参数";
            this.button_SetParameters.UseVisualStyleBackColor = true;
            this.button_SetParameters.Click += new System.EventHandler(this.button_SetParameters_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "设备密码";
            // 
            // textBox_PassWord
            // 
            this.textBox_PassWord.Location = new System.Drawing.Point(67, 26);
            this.textBox_PassWord.Name = "textBox_PassWord";
            this.textBox_PassWord.Size = new System.Drawing.Size(100, 21);
            this.textBox_PassWord.TabIndex = 2;
            // 
            // groupBox4
            // 
            this.groupBox4.Location = new System.Drawing.Point(19, 11);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(288, 176);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "主动指令";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label_SelectDeviceName);
            this.groupBox5.Location = new System.Drawing.Point(716, 131);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(280, 123);
            this.groupBox5.TabIndex = 12;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "类型";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.treeView_DeviceList);
            this.groupBox6.Location = new System.Drawing.Point(12, 12);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(200, 607);
            this.groupBox6.TabIndex = 13;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "设备列表";
            // 
            // treeView_DeviceList
            // 
            this.treeView_DeviceList.HideSelection = false;
            this.treeView_DeviceList.Location = new System.Drawing.Point(6, 18);
            this.treeView_DeviceList.Name = "treeView_DeviceList";
            this.treeView_DeviceList.Size = new System.Drawing.Size(188, 583);
            this.treeView_DeviceList.TabIndex = 0;
            this.treeView_DeviceList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_DeviceList_AfterSelect);
            this.treeView_DeviceList.DoubleClick += new System.EventHandler(this.treeView_DeviceList_DoubleClick);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.textBox_AHPassWord);
            this.groupBox7.Controls.Add(this.textBox_RestarTime);
            this.groupBox7.Controls.Add(this.button_SetParameters);
            this.groupBox7.Controls.Add(this.textBox_OnlineTime);
            this.groupBox7.Controls.Add(this.textBox_SleepTime);
            this.groupBox7.Controls.Add(this.textBox_SampIntevalr);
            this.groupBox7.Controls.Add(this.textBox_HeartTime);
            this.groupBox7.Controls.Add(this.label9);
            this.groupBox7.Controls.Add(this.label8);
            this.groupBox7.Controls.Add(this.label7);
            this.groupBox7.Controls.Add(this.label6);
            this.groupBox7.Controls.Add(this.label5);
            this.groupBox7.Controls.Add(this.label4);
            this.groupBox7.Controls.Add(this.label3);
            this.groupBox7.Controls.Add(this.textBox_PassWord);
            this.groupBox7.Location = new System.Drawing.Point(6, 6);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(444, 181);
            this.groupBox7.TabIndex = 14;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "设备信息";
            // 
            // textBox_AHPassWord
            // 
            this.textBox_AHPassWord.Location = new System.Drawing.Point(66, 150);
            this.textBox_AHPassWord.Name = "textBox_AHPassWord";
            this.textBox_AHPassWord.Size = new System.Drawing.Size(100, 21);
            this.textBox_AHPassWord.TabIndex = 15;
            // 
            // textBox_RestarTime
            // 
            this.textBox_RestarTime.Location = new System.Drawing.Point(237, 109);
            this.textBox_RestarTime.Name = "textBox_RestarTime";
            this.textBox_RestarTime.Size = new System.Drawing.Size(100, 21);
            this.textBox_RestarTime.TabIndex = 14;
            // 
            // textBox_OnlineTime
            // 
            this.textBox_OnlineTime.Location = new System.Drawing.Point(238, 68);
            this.textBox_OnlineTime.Name = "textBox_OnlineTime";
            this.textBox_OnlineTime.Size = new System.Drawing.Size(100, 21);
            this.textBox_OnlineTime.TabIndex = 13;
            // 
            // textBox_SleepTime
            // 
            this.textBox_SleepTime.Location = new System.Drawing.Point(237, 26);
            this.textBox_SleepTime.Name = "textBox_SleepTime";
            this.textBox_SleepTime.Size = new System.Drawing.Size(100, 21);
            this.textBox_SleepTime.TabIndex = 12;
            // 
            // textBox_SampIntevalr
            // 
            this.textBox_SampIntevalr.Location = new System.Drawing.Point(67, 109);
            this.textBox_SampIntevalr.Name = "textBox_SampIntevalr";
            this.textBox_SampIntevalr.Size = new System.Drawing.Size(100, 21);
            this.textBox_SampIntevalr.TabIndex = 11;
            // 
            // textBox_HeartTime
            // 
            this.textBox_HeartTime.Location = new System.Drawing.Point(67, 68);
            this.textBox_HeartTime.Name = "textBox_HeartTime";
            this.textBox_HeartTime.Size = new System.Drawing.Size(100, 21);
            this.textBox_HeartTime.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 156);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 9;
            this.label9.Text = "密文认证";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(180, 114);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 8;
            this.label8.Text = "重启时间";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(178, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 7;
            this.label7.Text = "在线时长";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(178, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "休眠时长";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "采样间隔";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "心跳间隔";
            // 
            // tabControl_Basic
            // 
            this.tabControl_Basic.Controls.Add(this.tabPage1);
            this.tabControl_Basic.Controls.Add(this.tabPage2);
            this.tabControl_Basic.Controls.Add(this.tabPage3);
            this.tabControl_Basic.Location = new System.Drawing.Point(6, 17);
            this.tabControl_Basic.Name = "tabControl_Basic";
            this.tabControl_Basic.SelectedIndex = 0;
            this.tabControl_Basic.Size = new System.Drawing.Size(464, 219);
            this.tabControl_Basic.TabIndex = 15;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(456, 193);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(456, 193);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox7);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(456, 193);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.tabControl_Basic);
            this.groupBox8.Location = new System.Drawing.Point(218, 12);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(479, 242);
            this.groupBox8.TabIndex = 16;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "基本命令";
            // 
            // label_SelectDeviceName
            // 
            this.label_SelectDeviceName.AutoSize = true;
            this.label_SelectDeviceName.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_SelectDeviceName.Location = new System.Drawing.Point(62, 43);
            this.label_SelectDeviceName.Name = "label_SelectDeviceName";
            this.label_SelectDeviceName.Size = new System.Drawing.Size(163, 29);
            this.label_SelectDeviceName.TabIndex = 0;
            this.label_SelectDeviceName.Text = "未选择设备";
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 627);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form_Main";
            this.Text = "广东电网协议测试";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.tabControl_Basic.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_CreatServer;
        private System.Windows.Forms.Button button_CloseServer;
        private System.Windows.Forms.TextBox textBox_PORT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBox_info;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox_IP;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TreeView treeView_DeviceList;
        private System.Windows.Forms.Button button_SetParameters;
        private System.Windows.Forms.Button button_SetPassWord;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_PassWord;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox_PassWordNew;
        private System.Windows.Forms.TextBox textBox_AHPassWord;
        private System.Windows.Forms.TextBox textBox_RestarTime;
        private System.Windows.Forms.TextBox textBox_OnlineTime;
        private System.Windows.Forms.TextBox textBox_SleepTime;
        private System.Windows.Forms.TextBox textBox_SampIntevalr;
        private System.Windows.Forms.TextBox textBox_HeartTime;
        private System.Windows.Forms.TabControl tabControl_Basic;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.TextBox textBox_PassWordOld;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button_GetPassWord;
        private System.Windows.Forms.Label label_SelectDeviceName;
    }
}

