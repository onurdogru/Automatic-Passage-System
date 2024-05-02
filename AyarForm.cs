// Decompiled with JetBrains decompiler
// Type: EsdTurnikesi.AyarForm
// Assembly: EsdTurnikesi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C8099926-BBEB-495E-ADF6-36B4F5F75BE8
// Assembly location: C:\Users\serkan.baki\Desktop\PROJELER\2-) Gömülü Sistem Projeleri\(1707482-537)_Fabrika Girişi İçin Temassız Sıcaklık Ölçüm İstasyonu\SOFTWARE\GUI\esd-rar\ESD\Release\EsdTurnikesi.exe

using System;
using System.ComponentModel;
using System.Data.OleDb;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;

namespace EsdTurnikesi
{
  public class AyarForm : Form
  {
    public Main MainFrm;
    private IContainer components;
    private GroupBox groupBox1;
    private Label label1;
    public ComboBox mifarecom;
    private Label label6;
    private Label label5;
    private Label label4;
    private Label label3;
    public ComboBox mifareParity;
    public ComboBox mifareStop;
    public ComboBox mifareData;
    public ComboBox mifareBaud;
    private GroupBox groupBox2;
    private Label label2;
    private Label label7;
    private Label label8;
    private Label label9;
    private Label label10;
    public ComboBox esdParity;
    public ComboBox esdStop;
    public ComboBox esdData;
    public ComboBox esdBaud;
    public ComboBox esdcom;
    private Button btnKaydet;
    private GroupBox groupBox3;
    private Button btnLogsec;
    private Button btnIDsec;
    private TextBox txtLogdosya;
    private Label label12;
    private TextBox txtIDdosya;
    private Label label11;
    private GroupBox groupBox4;
    private Label label13;
    private Label label14;
    private Label label15;
    private Label label16;
    private Label label17;
    public ComboBox plcParity;
    public ComboBox plcStop;
    public ComboBox plcData;
    public ComboBox plcBaud;
    public ComboBox plcCom;
    private GroupBox groupBox5;
    private CheckBox checkBox1;
    private Label label19;
    private Label label18;
    private TextBox plcModbusTimer;
    private GroupBox groupBox6;
    private CheckBox checkAyak;
    private Label label33;
    private Label label32;
    private TextBox txtTimerBekleme;
    private CheckBox checkBileklik;
    private Label label25;
    private Label label23;
    private Label label21;
    private TextBox txtTimerAdmin;
    private TextBox txtTimerMifare;
    private Label label24;
    private TextBox txtTimerESD;
    private Label label22;
    private Label label20;
    private TextBox txtKaliteSifre;
    private TextBox txtAdminSifre;
    private Label label27;
    private Label label26;
    private CheckBox checkBox2;
    private Label label29;
    private TextBox txtTimerTurnike;
    private Label label28;
    private GroupBox groupBox7;
    private GroupBox groupBox8;
    private ComboBox comboBox1;
    private CheckBox checkBox3;
    private Label label30;
    private GroupBox groupBox9;
    private Label label38;
    private TextBox txtTimerMifare2;
    private Label label39;
    private GroupBox groupBox10;
    private Label label31;
    private Label label34;
    private Label label35;
    private Label label36;
    private Label label37;
    public ComboBox mifareParity2;
    public ComboBox mifareStop2;
    public ComboBox mifareData2;
    public ComboBox mifareBaud2;
    public ComboBox mifarecom2;

    public AyarForm()
    {
      this.InitializeComponent();
    }

    private void AyarForm_Load(object sender, EventArgs e)
    {
      this.mifarecom.Text = Ayarlar.Default.mifareCom;
      this.mifareBaud.Text = Ayarlar.Default.mifareBaud.ToString();
      this.mifareData.Text = Ayarlar.Default.mifaredataBits.ToString();
      this.mifareStop.Text = Ayarlar.Default.mifarestopBit.ToString();
      this.mifareParity.Text = Ayarlar.Default.mifareParity.ToString();
      this.mifarecom2.Text = Ayarlar.Default.mifareCom2;
      this.mifareBaud2.Text = Ayarlar.Default.mifareBaud2.ToString();
      this.mifareData2.Text = Ayarlar.Default.mifaredataBits2.ToString();
      this.mifareStop2.Text = Ayarlar.Default.mifarestopBits2.ToString();
      this.mifareParity2.Text = Ayarlar.Default.mifareParity2.ToString();
      this.esdcom.Text = Ayarlar.Default.esdCom;
      this.esdBaud.Text = Ayarlar.Default.esdBaud.ToString();
      this.esdData.Text = Ayarlar.Default.esddataBits.ToString();
      this.esdStop.Text = Ayarlar.Default.esdstopBit.ToString();
      this.esdParity.Text = Ayarlar.Default.esdParity.ToString();
      this.txtIDdosya.Text = Ayarlar.Default.IDdosyayolu;
      this.txtLogdosya.Text = Ayarlar.Default.Logdosyayolu;
      this.plcCom.Text = Ayarlar.Default.plcCom;
      this.plcBaud.Text = Ayarlar.Default.plcBaud.ToString();
      this.plcData.Text = Ayarlar.Default.plcdataBits.ToString();
      this.plcStop.Text = Ayarlar.Default.plcstopBit.ToString();
      this.plcParity.Text = Ayarlar.Default.plcParity.ToString();
      this.plcModbusTimer.Text = Ayarlar.Default.timerModbus.ToString();
      this.txtTimerBekleme.Text = Ayarlar.Default.timerBekleme.ToString();
      this.txtTimerAdmin.Text = Ayarlar.Default.timerAdmin.ToString();
      this.txtTimerESD.Text = Ayarlar.Default.timerESD.ToString();
      this.txtTimerMifare.Text = Ayarlar.Default.timerMifare.ToString();
      this.txtTimerMifare2.Text = Ayarlar.Default.timerMifare2.ToString();
      this.txtAdminSifre.Text = Ayarlar.Default.adminSifre.ToString();
      this.txtKaliteSifre.Text = Ayarlar.Default.kaliteSifre.ToString();
      this.txtTimerTurnike.Text = Ayarlar.Default.timerTurnike.ToString();
      this.checkBox1.Checked = this.MainFrm.timerModbus.Enabled;
      this.checkAyak.Checked = Ayarlar.Default.checkAyak;
      if (Ayarlar.Default.checkBileklik)
        this.checkBileklik.Checked = true;
      else
        this.checkBileklik.Checked = false;
    }

    private void btnKaydet_Click(object sender, EventArgs e)
    {
      try
      {
        this.MainFrm.timerModbus.Enabled = false;
        this.MainFrm.timerBekleme.Enabled = false;
        this.MainFrm.timerESD.Enabled = false;
        this.MainFrm.timerMifare.Enabled = false;
        this.MainFrm.timerMifare2.Enabled = false;
        this.MainFrm.timerTurnike.Enabled = false;
        this.MainFrm.mifarePort.Close();
        this.MainFrm.mifarePort2.Close();
        this.MainFrm.esdPort.Close();
        this.MainFrm.plcPort.Close();
        Ayarlar.Default.mifareCom = this.mifarecom.Text;
        Ayarlar.Default.mifareBaud = Convert.ToInt32(this.mifareBaud.Text);
        Ayarlar.Default.mifaredataBits = Convert.ToInt32(this.mifareData.Text);
        switch (this.mifareStop.SelectedIndex)
        {
          case 0:
            Ayarlar.Default.mifarestopBit = StopBits.None;
            break;
          case 1:
            Ayarlar.Default.mifarestopBit = StopBits.One;
            break;
          case 2:
            Ayarlar.Default.mifarestopBit = StopBits.Two;
            break;
          case 3:
            Ayarlar.Default.mifarestopBit = StopBits.OnePointFive;
            break;
          default:
            Ayarlar.Default.mifarestopBit = StopBits.One;
            break;
        }
        switch (this.mifareParity.SelectedIndex)
        {
          case 0:
            Ayarlar.Default.mifareParity = Parity.None;
            break;
          case 1:
            Ayarlar.Default.mifareParity = Parity.Odd;
            break;
          case 2:
            Ayarlar.Default.mifareParity = Parity.Even;
            break;
          case 3:
            Ayarlar.Default.mifareParity = Parity.Mark;
            break;
          case 4:
            Ayarlar.Default.mifareParity = Parity.Space;
            break;
          default:
            Ayarlar.Default.mifareParity = Parity.None;
            break;
        }
        Ayarlar.Default.mifareCom2 = this.mifarecom2.Text;
        Ayarlar.Default.mifareBaud2 = Convert.ToInt32(this.mifareBaud2.Text);
        Ayarlar.Default.mifaredataBits2 = Convert.ToInt32(this.mifareData2.Text);
        switch (this.mifareStop2.SelectedIndex)
        {
          case 0:
            Ayarlar.Default.mifarestopBits2 = StopBits.None;
            break;
          case 1:
            Ayarlar.Default.mifarestopBits2 = StopBits.One;
            break;
          case 2:
            Ayarlar.Default.mifarestopBits2 = StopBits.Two;
            break;
          case 3:
            Ayarlar.Default.mifarestopBits2 = StopBits.OnePointFive;
            break;
          default:
            Ayarlar.Default.mifarestopBits2 = StopBits.One;
            break;
        }
        switch (this.mifareParity2.SelectedIndex)
        {
          case 0:
            Ayarlar.Default.mifareParity2 = Parity.None;
            break;
          case 1:
            Ayarlar.Default.mifareParity2 = Parity.Odd;
            break;
          case 2:
            Ayarlar.Default.mifareParity2 = Parity.Even;
            break;
          case 3:
            Ayarlar.Default.mifareParity2 = Parity.Mark;
            break;
          case 4:
            Ayarlar.Default.mifareParity2 = Parity.Space;
            break;
          default:
            Ayarlar.Default.mifareParity2 = Parity.None;
            break;
        }
        Ayarlar.Default.esdCom = this.esdcom.Text;
        Ayarlar.Default.esdBaud = Convert.ToInt32(this.esdBaud.Text);
        Ayarlar.Default.esddataBits = Convert.ToInt32(this.esdData.Text);
        switch (this.esdStop.SelectedIndex)
        {
          case 0:
            Ayarlar.Default.esdstopBit = StopBits.None;
            break;
          case 1:
            Ayarlar.Default.esdstopBit = StopBits.One;
            break;
          case 2:
            Ayarlar.Default.esdstopBit = StopBits.Two;
            break;
          case 3:
            Ayarlar.Default.esdstopBit = StopBits.OnePointFive;
            break;
          default:
            Ayarlar.Default.esdstopBit = StopBits.One;
            break;
        }
        switch (this.esdParity.SelectedIndex)
        {
          case 0:
            Ayarlar.Default.esdParity = Parity.None;
            break;
          case 1:
            Ayarlar.Default.esdParity = Parity.Odd;
            break;
          case 2:
            Ayarlar.Default.esdParity = Parity.Even;
            break;
          case 3:
            Ayarlar.Default.esdParity = Parity.Mark;
            break;
          case 4:
            Ayarlar.Default.esdParity = Parity.Space;
            break;
          default:
            Ayarlar.Default.esdParity = Parity.None;
            break;
        }
        Ayarlar.Default.plcCom = this.plcCom.Text;
        Ayarlar.Default.plcBaud = Convert.ToInt32(this.plcBaud.Text);
        Ayarlar.Default.plcdataBits = Convert.ToInt32(this.plcData.Text);
        switch (this.plcStop.SelectedIndex)
        {
          case 0:
            Ayarlar.Default.plcstopBit = StopBits.None;
            break;
          case 1:
            Ayarlar.Default.plcstopBit = StopBits.One;
            break;
          case 2:
            Ayarlar.Default.plcstopBit = StopBits.Two;
            break;
          case 3:
            Ayarlar.Default.plcstopBit = StopBits.OnePointFive;
            break;
          default:
            Ayarlar.Default.plcstopBit = StopBits.One;
            break;
        }
        switch (this.plcParity.SelectedIndex)
        {
          case 0:
            Ayarlar.Default.plcParity = Parity.None;
            break;
          case 1:
            Ayarlar.Default.plcParity = Parity.Odd;
            break;
          case 2:
            Ayarlar.Default.plcParity = Parity.Even;
            break;
          case 3:
            Ayarlar.Default.plcParity = Parity.Mark;
            break;
          case 4:
            Ayarlar.Default.plcParity = Parity.Space;
            break;
          default:
            Ayarlar.Default.plcParity = Parity.None;
            break;
        }
        Ayarlar.Default.IDdosyayolu = this.txtIDdosya.Text;
        Ayarlar.Default.Logdosyayolu = this.txtLogdosya.Text;
        Ayarlar.Default.timerModbus = Convert.ToInt32(this.plcModbusTimer.Text);
        Ayarlar.Default.timerBekleme = Convert.ToInt32(this.txtTimerBekleme.Text);
        Ayarlar.Default.timerMifare = Convert.ToInt32(this.txtTimerMifare.Text);
        Ayarlar.Default.timerMifare2 = Convert.ToInt32(this.txtTimerMifare2.Text);
        Ayarlar.Default.timerESD = Convert.ToInt32(this.txtTimerESD.Text);
        Ayarlar.Default.timerTurnike = Convert.ToInt32(this.txtTimerTurnike.Text);
        Ayarlar.Default.checkAyak = this.checkAyak.Checked;
        Ayarlar.Default.checkBileklik = this.checkBileklik.Checked;
        Ayarlar.Default.adminSifre = this.txtAdminSifre.Text;
        Ayarlar.Default.kaliteSifre = this.txtKaliteSifre.Text;
        Ayarlar.Default.Save();
        this.MainFrm.baglan = new OleDbConnection("Provider=Microsoft.Ace.Oledb.12.0;Data Source=" + Ayarlar.Default.IDdosyayolu);
        this.MainFrm.baglan2 = new OleDbConnection("Provider=Microsoft.Ace.Oledb.12.0;Data Source=" + Ayarlar.Default.Logdosyayolu);
        this.MainFrm.mifarePort.PortName = Ayarlar.Default.mifareCom;
        this.MainFrm.mifarePort.BaudRate = Ayarlar.Default.mifareBaud;
        this.MainFrm.mifarePort.DataBits = Ayarlar.Default.mifaredataBits;
        this.MainFrm.mifarePort.StopBits = Ayarlar.Default.mifarestopBit;
        this.MainFrm.mifarePort.Parity = Ayarlar.Default.mifareParity;
        this.MainFrm.mifarePort2.PortName = Ayarlar.Default.mifareCom2;
        this.MainFrm.mifarePort2.BaudRate = Ayarlar.Default.mifareBaud2;
        this.MainFrm.mifarePort2.DataBits = Ayarlar.Default.mifaredataBits2;
        this.MainFrm.mifarePort2.StopBits = Ayarlar.Default.mifarestopBits2;
        this.MainFrm.mifarePort2.Parity = Ayarlar.Default.mifareParity2;
        this.MainFrm.esdPort.PortName = Ayarlar.Default.esdCom;
        this.MainFrm.esdPort.BaudRate = Ayarlar.Default.esdBaud;
        this.MainFrm.esdPort.DataBits = Ayarlar.Default.esddataBits;
        this.MainFrm.esdPort.StopBits = Ayarlar.Default.esdstopBit;
        this.MainFrm.esdPort.Parity = Ayarlar.Default.esdParity;
        this.MainFrm.plcPort.PortName = Ayarlar.Default.plcCom;
        this.MainFrm.plcPort.BaudRate = Ayarlar.Default.plcBaud;
        this.MainFrm.plcPort.DataBits = Ayarlar.Default.plcdataBits;
        this.MainFrm.plcPort.StopBits = Ayarlar.Default.plcstopBit;
        this.MainFrm.plcPort.Parity = Ayarlar.Default.plcParity;
        this.MainFrm.timerModbus.Interval = Ayarlar.Default.timerModbus;
        this.MainFrm.timerBekleme.Interval = Ayarlar.Default.timerBekleme;
        this.MainFrm.timerMifare.Interval = Ayarlar.Default.timerMifare;
        this.MainFrm.timerMifare2.Interval = Ayarlar.Default.timerMifare2;
        this.MainFrm.timerESD.Interval = Ayarlar.Default.timerESD;
        this.MainFrm.timerTurnike.Interval = Ayarlar.Default.timerTurnike;
        this.MainFrm.AyakAktif = Ayarlar.Default.checkAyak;
        this.MainFrm.bileklikAktif = Ayarlar.Default.checkBileklik;
        try
        {
          this.MainFrm.mifarePort.Open();
        }
        catch (Exception ex)
        {
          int num = (int) MessageBox.Show("mifareport hatası: ");
        }
        try
        {
          this.MainFrm.mifarePort2.Open();
        }
        catch (Exception ex)
        {
          int num = (int) MessageBox.Show("mifareport2 hatası: ");
        }
        try
        {
          this.MainFrm.esdPort.Open();
        }
        catch (Exception ex)
        {
          int num = (int) MessageBox.Show("esdport hatası: ");
        }
        try
        {
          this.MainFrm.plcPort.Open();
        }
        catch (Exception ex)
        {
          int num = (int) MessageBox.Show("plcport hatası: ");
        }
        this.MainFrm.timerModbus.Enabled = this.checkBox1.Checked;
        int num1 = (int) MessageBox.Show("Bütün ayarlar başarıyla kaydedildi.");
        this.Close();
      }
      catch (Exception ex)
      {
        this.MainFrm.timerModbus.Enabled = false;
        int num = (int) MessageBox.Show("Kayıt ya da port hatası: " + ex.ToString());
      }
    }

    private void btnIDsec_Click(object sender, EventArgs e)
    {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.Filter = "Database Dosyaları|*.accdb|Tüm Dosyalar|*.*";
      if (openFileDialog.ShowDialog() != DialogResult.OK)
        return;
      this.txtIDdosya.Text = openFileDialog.FileName;
    }

    private void btnLogsec_Click(object sender, EventArgs e)
    {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.Filter = "Database Dosyaları|*.accdb|Tüm Dosyalar|*.*";
      if (openFileDialog.ShowDialog() != DialogResult.OK)
        return;
      this.txtLogdosya.Text = openFileDialog.FileName;
    }

    private void checkBox2_CheckedChanged(object sender, EventArgs e)
    {
      if (this.checkBox2.Checked)
      {
        this.txtAdminSifre.Enabled = true;
        this.txtKaliteSifre.Enabled = true;
        this.txtAdminSifre.PasswordChar = char.MinValue;
        this.txtKaliteSifre.PasswordChar = char.MinValue;
      }
      else
      {
        this.txtAdminSifre.Enabled = false;
        this.txtKaliteSifre.Enabled = false;
        this.txtAdminSifre.PasswordChar = '*';
        this.txtKaliteSifre.PasswordChar = '*';
      }
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.groupBox1 = new GroupBox();
      this.label6 = new Label();
      this.label5 = new Label();
      this.label4 = new Label();
      this.label3 = new Label();
      this.label1 = new Label();
      this.mifareParity = new ComboBox();
      this.mifareStop = new ComboBox();
      this.mifareData = new ComboBox();
      this.mifareBaud = new ComboBox();
      this.mifarecom = new ComboBox();
      this.groupBox2 = new GroupBox();
      this.label2 = new Label();
      this.label7 = new Label();
      this.label8 = new Label();
      this.label9 = new Label();
      this.label10 = new Label();
      this.esdParity = new ComboBox();
      this.esdStop = new ComboBox();
      this.esdData = new ComboBox();
      this.esdBaud = new ComboBox();
      this.esdcom = new ComboBox();
      this.btnKaydet = new Button();
      this.groupBox3 = new GroupBox();
      this.btnLogsec = new Button();
      this.btnIDsec = new Button();
      this.txtLogdosya = new TextBox();
      this.label12 = new Label();
      this.txtIDdosya = new TextBox();
      this.label11 = new Label();
      this.groupBox4 = new GroupBox();
      this.label13 = new Label();
      this.label14 = new Label();
      this.label15 = new Label();
      this.label16 = new Label();
      this.label17 = new Label();
      this.plcParity = new ComboBox();
      this.plcStop = new ComboBox();
      this.plcData = new ComboBox();
      this.plcBaud = new ComboBox();
      this.plcCom = new ComboBox();
      this.groupBox5 = new GroupBox();
      this.checkBox1 = new CheckBox();
      this.label19 = new Label();
      this.label18 = new Label();
      this.plcModbusTimer = new TextBox();
      this.groupBox6 = new GroupBox();
      this.label29 = new Label();
      this.label23 = new Label();
      this.label21 = new Label();
      this.label25 = new Label();
      this.txtTimerESD = new TextBox();
      this.label20 = new Label();
      this.txtTimerMifare = new TextBox();
      this.label22 = new Label();
      this.label33 = new Label();
      this.txtTimerTurnike = new TextBox();
      this.txtTimerBekleme = new TextBox();
      this.label28 = new Label();
      this.label32 = new Label();
      this.txtTimerAdmin = new TextBox();
      this.label24 = new Label();
      this.checkBox2 = new CheckBox();
      this.checkBileklik = new CheckBox();
      this.checkAyak = new CheckBox();
      this.txtKaliteSifre = new TextBox();
      this.txtAdminSifre = new TextBox();
      this.label27 = new Label();
      this.label26 = new Label();
      this.groupBox7 = new GroupBox();
      this.groupBox8 = new GroupBox();
      this.comboBox1 = new ComboBox();
      this.checkBox3 = new CheckBox();
      this.label30 = new Label();
      this.groupBox9 = new GroupBox();
      this.groupBox10 = new GroupBox();
      this.label31 = new Label();
      this.label34 = new Label();
      this.label35 = new Label();
      this.label36 = new Label();
      this.label37 = new Label();
      this.mifareParity2 = new ComboBox();
      this.mifareStop2 = new ComboBox();
      this.mifareData2 = new ComboBox();
      this.mifareBaud2 = new ComboBox();
      this.mifarecom2 = new ComboBox();
      this.label38 = new Label();
      this.txtTimerMifare2 = new TextBox();
      this.label39 = new Label();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.groupBox3.SuspendLayout();
      this.groupBox4.SuspendLayout();
      this.groupBox5.SuspendLayout();
      this.groupBox6.SuspendLayout();
      this.groupBox7.SuspendLayout();
      this.groupBox8.SuspendLayout();
      this.groupBox10.SuspendLayout();
      this.SuspendLayout();
      this.groupBox1.Controls.Add((Control) this.label6);
      this.groupBox1.Controls.Add((Control) this.label5);
      this.groupBox1.Controls.Add((Control) this.label4);
      this.groupBox1.Controls.Add((Control) this.label3);
      this.groupBox1.Controls.Add((Control) this.label1);
      this.groupBox1.Controls.Add((Control) this.mifareParity);
      this.groupBox1.Controls.Add((Control) this.mifareStop);
      this.groupBox1.Controls.Add((Control) this.mifareData);
      this.groupBox1.Controls.Add((Control) this.mifareBaud);
      this.groupBox1.Controls.Add((Control) this.mifarecom);
      this.groupBox1.Location = new Point(14, 14);
      this.groupBox1.Margin = new Padding(3, 2, 3, 2);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Padding = new Padding(3, 2, 3, 2);
      this.groupBox1.Size = new Size(185, 177);
      this.groupBox1.TabIndex = 4;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Giriş Mifare Okuyucu Com:";
      this.label6.AutoSize = true;
      this.label6.Location = new Point(7, 147);
      this.label6.Name = "label6";
      this.label6.Size = new Size(45, 17);
      this.label6.TabIndex = 3;
      this.label6.Text = "Parity:";
      this.label5.AutoSize = true;
      this.label5.Location = new Point(7, 117);
      this.label5.Name = "label5";
      this.label5.Size = new Size(53, 17);
      this.label5.TabIndex = 3;
      this.label5.Text = "StopBit:";
      this.label4.AutoSize = true;
      this.label4.Location = new Point(7, 87);
      this.label4.Name = "label4";
      this.label4.Size = new Size(61, 17);
      this.label4.TabIndex = 3;
      this.label4.Text = "DataBits:";
      this.label3.AutoSize = true;
      this.label3.Location = new Point(7, 57);
      this.label3.Name = "label3";
      this.label3.Size = new Size(68, 17);
      this.label3.TabIndex = 3;
      this.label3.Text = "BaudRate:";
      this.label1.AutoSize = true;
      this.label1.Location = new Point(7, 27);
      this.label1.Name = "label1";
      this.label1.Size = new Size(61, 17);
      this.label1.TabIndex = 3;
      this.label1.Text = "ComPort:";
      this.mifareParity.FormattingEnabled = true;
      this.mifareParity.Items.AddRange(new object[5]
      {
        (object) "None",
        (object) "Odd",
        (object) "Even",
        (object) "Mark",
        (object) "Space"
      });
      this.mifareParity.Location = new Point(81, 145);
      this.mifareParity.Margin = new Padding(3, 4, 3, 4);
      this.mifareParity.Name = "mifareParity";
      this.mifareParity.Size = new Size(94, 23);
      this.mifareParity.TabIndex = 2;
      this.mifareStop.FormattingEnabled = true;
      this.mifareStop.Items.AddRange(new object[4]
      {
        (object) "None",
        (object) "One",
        (object) "Two",
        (object) "OnePointFive"
      });
      this.mifareStop.Location = new Point(81, 115);
      this.mifareStop.Margin = new Padding(3, 4, 3, 4);
      this.mifareStop.Name = "mifareStop";
      this.mifareStop.Size = new Size(94, 23);
      this.mifareStop.TabIndex = 2;
      this.mifareData.FormattingEnabled = true;
      this.mifareData.Items.AddRange(new object[2]
      {
        (object) "8",
        (object) "7"
      });
      this.mifareData.Location = new Point(81, 85);
      this.mifareData.Margin = new Padding(3, 4, 3, 4);
      this.mifareData.Name = "mifareData";
      this.mifareData.Size = new Size(94, 23);
      this.mifareData.TabIndex = 2;
      this.mifareBaud.FormattingEnabled = true;
      this.mifareBaud.Items.AddRange(new object[8]
      {
        (object) "2400",
        (object) "4800",
        (object) "7200",
        (object) "9600",
        (object) "19200",
        (object) "38400",
        (object) "57600",
        (object) "115200"
      });
      this.mifareBaud.Location = new Point(81, 55);
      this.mifareBaud.Margin = new Padding(3, 4, 3, 4);
      this.mifareBaud.Name = "mifareBaud";
      this.mifareBaud.Size = new Size(94, 23);
      this.mifareBaud.TabIndex = 2;
      this.mifarecom.FormattingEnabled = true;
      this.mifarecom.Location = new Point(81, 25);
      this.mifarecom.Margin = new Padding(3, 4, 3, 4);
      this.mifarecom.Name = "mifarecom";
      this.mifarecom.Size = new Size(94, 23);
      this.mifarecom.TabIndex = 2;
      this.groupBox2.Controls.Add((Control) this.label2);
      this.groupBox2.Controls.Add((Control) this.label7);
      this.groupBox2.Controls.Add((Control) this.label8);
      this.groupBox2.Controls.Add((Control) this.label9);
      this.groupBox2.Controls.Add((Control) this.label10);
      this.groupBox2.Controls.Add((Control) this.esdParity);
      this.groupBox2.Controls.Add((Control) this.esdStop);
      this.groupBox2.Controls.Add((Control) this.esdData);
      this.groupBox2.Controls.Add((Control) this.esdBaud);
      this.groupBox2.Controls.Add((Control) this.esdcom);
      this.groupBox2.Location = new Point(204, 14);
      this.groupBox2.Margin = new Padding(3, 2, 3, 2);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Padding = new Padding(3, 2, 3, 2);
      this.groupBox2.Size = new Size(185, 177);
      this.groupBox2.TabIndex = 5;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "ESD Cihazı Com Ayar:";
      this.label2.AutoSize = true;
      this.label2.Location = new Point(7, 147);
      this.label2.Name = "label2";
      this.label2.Size = new Size(45, 17);
      this.label2.TabIndex = 3;
      this.label2.Text = "Parity:";
      this.label7.AutoSize = true;
      this.label7.Location = new Point(7, 117);
      this.label7.Name = "label7";
      this.label7.Size = new Size(53, 17);
      this.label7.TabIndex = 3;
      this.label7.Text = "StopBit:";
      this.label8.AutoSize = true;
      this.label8.Location = new Point(7, 87);
      this.label8.Name = "label8";
      this.label8.Size = new Size(61, 17);
      this.label8.TabIndex = 3;
      this.label8.Text = "DataBits:";
      this.label9.AutoSize = true;
      this.label9.Location = new Point(7, 57);
      this.label9.Name = "label9";
      this.label9.Size = new Size(68, 17);
      this.label9.TabIndex = 3;
      this.label9.Text = "BaudRate:";
      this.label10.AutoSize = true;
      this.label10.Location = new Point(7, 27);
      this.label10.Name = "label10";
      this.label10.Size = new Size(61, 17);
      this.label10.TabIndex = 3;
      this.label10.Text = "ComPort:";
      this.esdParity.FormattingEnabled = true;
      this.esdParity.Items.AddRange(new object[5]
      {
        (object) "None",
        (object) "Odd",
        (object) "Even",
        (object) "Mark",
        (object) "Space"
      });
      this.esdParity.Location = new Point(81, 145);
      this.esdParity.Margin = new Padding(3, 4, 3, 4);
      this.esdParity.Name = "esdParity";
      this.esdParity.Size = new Size(94, 23);
      this.esdParity.TabIndex = 2;
      this.esdStop.FormattingEnabled = true;
      this.esdStop.Items.AddRange(new object[4]
      {
        (object) "None",
        (object) "One",
        (object) "Two",
        (object) "OnePointFive"
      });
      this.esdStop.Location = new Point(81, 115);
      this.esdStop.Margin = new Padding(3, 4, 3, 4);
      this.esdStop.Name = "esdStop";
      this.esdStop.Size = new Size(94, 23);
      this.esdStop.TabIndex = 2;
      this.esdData.FormattingEnabled = true;
      this.esdData.Location = new Point(81, 85);
      this.esdData.Margin = new Padding(3, 4, 3, 4);
      this.esdData.Name = "esdData";
      this.esdData.Size = new Size(94, 23);
      this.esdData.TabIndex = 2;
      this.esdBaud.FormattingEnabled = true;
      this.esdBaud.Items.AddRange(new object[8]
      {
        (object) "2400",
        (object) "4800",
        (object) "7200",
        (object) "9600",
        (object) "19200",
        (object) "38400",
        (object) "57600",
        (object) "115200"
      });
      this.esdBaud.Location = new Point(81, 55);
      this.esdBaud.Margin = new Padding(3, 4, 3, 4);
      this.esdBaud.Name = "esdBaud";
      this.esdBaud.Size = new Size(94, 23);
      this.esdBaud.TabIndex = 2;
      this.esdcom.FormattingEnabled = true;
      this.esdcom.Location = new Point(81, 25);
      this.esdcom.Margin = new Padding(3, 4, 3, 4);
      this.esdcom.Name = "esdcom";
      this.esdcom.Size = new Size(94, 23);
      this.esdcom.TabIndex = 2;
      this.btnKaydet.Location = new Point(237, 496);
      this.btnKaydet.Margin = new Padding(3, 2, 3, 2);
      this.btnKaydet.Name = "btnKaydet";
      this.btnKaydet.Size = new Size(111, 30);
      this.btnKaydet.TabIndex = 6;
      this.btnKaydet.Text = "Ayarları Kaydet";
      this.btnKaydet.UseVisualStyleBackColor = true;
      this.btnKaydet.Click += new EventHandler(this.btnKaydet_Click);
      this.groupBox3.Controls.Add((Control) this.btnLogsec);
      this.groupBox3.Controls.Add((Control) this.btnIDsec);
      this.groupBox3.Controls.Add((Control) this.txtLogdosya);
      this.groupBox3.Controls.Add((Control) this.label12);
      this.groupBox3.Controls.Add((Control) this.txtIDdosya);
      this.groupBox3.Controls.Add((Control) this.label11);
      this.groupBox3.Location = new Point(14, 196);
      this.groupBox3.Margin = new Padding(3, 2, 3, 2);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Padding = new Padding(3, 2, 3, 2);
      this.groupBox3.Size = new Size(374, 78);
      this.groupBox3.TabIndex = 7;
      this.groupBox3.TabStop = false;
      this.groupBox3.Text = "Database Ayarları:";
      this.btnLogsec.Location = new Point(299, 47);
      this.btnLogsec.Margin = new Padding(3, 2, 3, 2);
      this.btnLogsec.Name = "btnLogsec";
      this.btnLogsec.Size = new Size(66, 21);
      this.btnLogsec.TabIndex = 2;
      this.btnLogsec.Text = "Seç";
      this.btnLogsec.UseVisualStyleBackColor = true;
      this.btnLogsec.Click += new EventHandler(this.btnLogsec_Click);
      this.btnIDsec.Location = new Point(299, 21);
      this.btnIDsec.Margin = new Padding(3, 2, 3, 2);
      this.btnIDsec.Name = "btnIDsec";
      this.btnIDsec.Size = new Size(66, 21);
      this.btnIDsec.TabIndex = 2;
      this.btnIDsec.Text = "Seç";
      this.btnIDsec.UseVisualStyleBackColor = true;
      this.btnIDsec.Click += new EventHandler(this.btnIDsec_Click);
      this.txtLogdosya.Location = new Point(109, 47);
      this.txtLogdosya.Margin = new Padding(3, 2, 3, 2);
      this.txtLogdosya.Name = "txtLogdosya";
      this.txtLogdosya.Size = new Size(185, 24);
      this.txtLogdosya.TabIndex = 1;
      this.label12.AutoSize = true;
      this.label12.Location = new Point(7, 49);
      this.label12.Name = "label12";
      this.label12.Size = new Size(95, 17);
      this.label12.TabIndex = 0;
      this.label12.Text = "Log Dosya Yolu:";
      this.txtIDdosya.Location = new Point(109, 21);
      this.txtIDdosya.Margin = new Padding(3, 2, 3, 2);
      this.txtIDdosya.Name = "txtIDdosya";
      this.txtIDdosya.Size = new Size(185, 24);
      this.txtIDdosya.TabIndex = 1;
      this.label11.AutoSize = true;
      this.label11.Location = new Point(7, 23);
      this.label11.Name = "label11";
      this.label11.Size = new Size(88, 17);
      this.label11.TabIndex = 0;
      this.label11.Text = "ID Dosya Yolu:";
      this.groupBox4.Controls.Add((Control) this.label13);
      this.groupBox4.Controls.Add((Control) this.label14);
      this.groupBox4.Controls.Add((Control) this.label15);
      this.groupBox4.Controls.Add((Control) this.label16);
      this.groupBox4.Controls.Add((Control) this.label17);
      this.groupBox4.Controls.Add((Control) this.plcParity);
      this.groupBox4.Controls.Add((Control) this.plcStop);
      this.groupBox4.Controls.Add((Control) this.plcData);
      this.groupBox4.Controls.Add((Control) this.plcBaud);
      this.groupBox4.Controls.Add((Control) this.plcCom);
      this.groupBox4.Location = new Point(394, 14);
      this.groupBox4.Margin = new Padding(3, 2, 3, 2);
      this.groupBox4.Name = "groupBox4";
      this.groupBox4.Padding = new Padding(3, 2, 3, 2);
      this.groupBox4.Size = new Size(185, 177);
      this.groupBox4.TabIndex = 8;
      this.groupBox4.TabStop = false;
      this.groupBox4.Text = "PLC Com Ayar:";
      this.label13.AutoSize = true;
      this.label13.Location = new Point(7, 147);
      this.label13.Name = "label13";
      this.label13.Size = new Size(45, 17);
      this.label13.TabIndex = 3;
      this.label13.Text = "Parity:";
      this.label14.AutoSize = true;
      this.label14.Location = new Point(7, 117);
      this.label14.Name = "label14";
      this.label14.Size = new Size(53, 17);
      this.label14.TabIndex = 3;
      this.label14.Text = "StopBit:";
      this.label15.AutoSize = true;
      this.label15.Location = new Point(7, 87);
      this.label15.Name = "label15";
      this.label15.Size = new Size(61, 17);
      this.label15.TabIndex = 3;
      this.label15.Text = "DataBits:";
      this.label16.AutoSize = true;
      this.label16.Location = new Point(7, 57);
      this.label16.Name = "label16";
      this.label16.Size = new Size(68, 17);
      this.label16.TabIndex = 3;
      this.label16.Text = "BaudRate:";
      this.label17.AutoSize = true;
      this.label17.Location = new Point(7, 27);
      this.label17.Name = "label17";
      this.label17.Size = new Size(61, 17);
      this.label17.TabIndex = 3;
      this.label17.Text = "ComPort:";
      this.plcParity.FormattingEnabled = true;
      this.plcParity.Items.AddRange(new object[5]
      {
        (object) "None",
        (object) "Odd",
        (object) "Even",
        (object) "Mark",
        (object) "Space"
      });
      this.plcParity.Location = new Point(81, 145);
      this.plcParity.Margin = new Padding(3, 4, 3, 4);
      this.plcParity.Name = "plcParity";
      this.plcParity.Size = new Size(94, 23);
      this.plcParity.TabIndex = 2;
      this.plcStop.FormattingEnabled = true;
      this.plcStop.Items.AddRange(new object[4]
      {
        (object) "None",
        (object) "One",
        (object) "Two",
        (object) "OnePointFive"
      });
      this.plcStop.Location = new Point(81, 115);
      this.plcStop.Margin = new Padding(3, 4, 3, 4);
      this.plcStop.Name = "plcStop";
      this.plcStop.Size = new Size(94, 23);
      this.plcStop.TabIndex = 2;
      this.plcData.FormattingEnabled = true;
      this.plcData.Location = new Point(81, 85);
      this.plcData.Margin = new Padding(3, 4, 3, 4);
      this.plcData.Name = "plcData";
      this.plcData.Size = new Size(94, 23);
      this.plcData.TabIndex = 2;
      this.plcBaud.FormattingEnabled = true;
      this.plcBaud.Items.AddRange(new object[8]
      {
        (object) "2400",
        (object) "4800",
        (object) "7200",
        (object) "9600",
        (object) "19200",
        (object) "38400",
        (object) "57600",
        (object) "115200"
      });
      this.plcBaud.Location = new Point(81, 55);
      this.plcBaud.Margin = new Padding(3, 4, 3, 4);
      this.plcBaud.Name = "plcBaud";
      this.plcBaud.Size = new Size(94, 23);
      this.plcBaud.TabIndex = 2;
      this.plcCom.FormattingEnabled = true;
      this.plcCom.Location = new Point(81, 25);
      this.plcCom.Margin = new Padding(3, 4, 3, 4);
      this.plcCom.Name = "plcCom";
      this.plcCom.Size = new Size(94, 23);
      this.plcCom.TabIndex = 2;
      this.groupBox5.Controls.Add((Control) this.checkBox1);
      this.groupBox5.Controls.Add((Control) this.label19);
      this.groupBox5.Controls.Add((Control) this.label18);
      this.groupBox5.Controls.Add((Control) this.plcModbusTimer);
      this.groupBox5.Location = new Point(394, 196);
      this.groupBox5.Margin = new Padding(3, 2, 3, 2);
      this.groupBox5.Name = "groupBox5";
      this.groupBox5.Padding = new Padding(3, 2, 3, 2);
      this.groupBox5.Size = new Size(185, 78);
      this.groupBox5.TabIndex = 9;
      this.groupBox5.TabStop = false;
      this.groupBox5.Text = "Modbus Timer";
      this.checkBox1.AutoSize = true;
      this.checkBox1.Location = new Point(21, 50);
      this.checkBox1.Margin = new Padding(3, 2, 3, 2);
      this.checkBox1.Name = "checkBox1";
      this.checkBox1.Size = new Size(137, 21);
      this.checkBox1.TabIndex = 3;
      this.checkBox1.Text = "Modbus Timer Aktif";
      this.checkBox1.UseVisualStyleBackColor = true;
      this.label19.AutoSize = true;
      this.label19.Location = new Point(145, 24);
      this.label19.Name = "label19";
      this.label19.Size = new Size(25, 17);
      this.label19.TabIndex = 2;
      this.label19.Text = "mS";
      this.label18.AutoSize = true;
      this.label18.Location = new Point(9, 24);
      this.label18.Name = "label18";
      this.label18.Size = new Size(45, 17);
      this.label18.TabIndex = 1;
      this.label18.Text = "Timer:";
      this.plcModbusTimer.Location = new Point(58, 21);
      this.plcModbusTimer.Margin = new Padding(3, 2, 3, 2);
      this.plcModbusTimer.Name = "plcModbusTimer";
      this.plcModbusTimer.Size = new Size(83, 24);
      this.plcModbusTimer.TabIndex = 0;
      this.groupBox6.Controls.Add((Control) this.label38);
      this.groupBox6.Controls.Add((Control) this.txtTimerMifare2);
      this.groupBox6.Controls.Add((Control) this.label39);
      this.groupBox6.Controls.Add((Control) this.label29);
      this.groupBox6.Controls.Add((Control) this.label23);
      this.groupBox6.Controls.Add((Control) this.label21);
      this.groupBox6.Controls.Add((Control) this.label25);
      this.groupBox6.Controls.Add((Control) this.txtTimerESD);
      this.groupBox6.Controls.Add((Control) this.label20);
      this.groupBox6.Controls.Add((Control) this.txtTimerMifare);
      this.groupBox6.Controls.Add((Control) this.label22);
      this.groupBox6.Controls.Add((Control) this.label33);
      this.groupBox6.Controls.Add((Control) this.txtTimerTurnike);
      this.groupBox6.Controls.Add((Control) this.txtTimerBekleme);
      this.groupBox6.Controls.Add((Control) this.label28);
      this.groupBox6.Controls.Add((Control) this.label32);
      this.groupBox6.Controls.Add((Control) this.txtTimerAdmin);
      this.groupBox6.Controls.Add((Control) this.label24);
      this.groupBox6.Location = new Point(14, 278);
      this.groupBox6.Margin = new Padding(3, 2, 3, 2);
      this.groupBox6.Name = "groupBox6";
      this.groupBox6.Padding = new Padding(3, 2, 3, 2);
      this.groupBox6.Size = new Size(161, 203);
      this.groupBox6.TabIndex = 10;
      this.groupBox6.TabStop = false;
      this.groupBox6.Text = "Timer Ayarları:";
      this.label29.AutoSize = true;
      this.label29.Location = new Point(132, 136);
      this.label29.Name = "label29";
      this.label29.Size = new Size(25, 17);
      this.label29.TabIndex = 2;
      this.label29.Text = "mS";
      this.label23.AutoSize = true;
      this.label23.Location = new Point(132, 24);
      this.label23.Name = "label23";
      this.label23.Size = new Size(25, 17);
      this.label23.TabIndex = 2;
      this.label23.Text = "mS";
      this.label21.AutoSize = true;
      this.label21.Location = new Point(131, 52);
      this.label21.Name = "label21";
      this.label21.Size = new Size(25, 17);
      this.label21.TabIndex = 2;
      this.label21.Text = "mS";
      this.label25.AutoSize = true;
      this.label25.Location = new Point(132, 108);
      this.label25.Name = "label25";
      this.label25.Size = new Size(25, 17);
      this.label25.TabIndex = 2;
      this.label25.Text = "mS";
      this.txtTimerESD.Location = new Point(81, 49);
      this.txtTimerESD.Margin = new Padding(3, 2, 3, 2);
      this.txtTimerESD.Name = "txtTimerESD";
      this.txtTimerESD.Size = new Size(47, 24);
      this.txtTimerESD.TabIndex = 0;
      this.label20.AutoSize = true;
      this.label20.Location = new Point(7, 52);
      this.label20.Name = "label20";
      this.label20.Size = new Size(70, 17);
      this.label20.TabIndex = 1;
      this.label20.Text = "Timer ESD:";
      this.txtTimerMifare.Location = new Point(81, 21);
      this.txtTimerMifare.Margin = new Padding(3, 2, 3, 2);
      this.txtTimerMifare.Name = "txtTimerMifare";
      this.txtTimerMifare.Size = new Size(47, 24);
      this.txtTimerMifare.TabIndex = 0;
      this.label22.AutoSize = true;
      this.label22.Location = new Point(8, 24);
      this.label22.Name = "label22";
      this.label22.Size = new Size(72, 17);
      this.label22.TabIndex = 1;
      this.label22.Text = "T.G Mifare:";
      this.label33.AutoSize = true;
      this.label33.Location = new Point(131, 80);
      this.label33.Name = "label33";
      this.label33.Size = new Size(25, 17);
      this.label33.TabIndex = 2;
      this.label33.Text = "mS";
      this.txtTimerTurnike.Location = new Point(81, 133);
      this.txtTimerTurnike.Margin = new Padding(3, 2, 3, 2);
      this.txtTimerTurnike.Name = "txtTimerTurnike";
      this.txtTimerTurnike.Size = new Size(47, 24);
      this.txtTimerTurnike.TabIndex = 0;
      this.txtTimerBekleme.Location = new Point(81, 77);
      this.txtTimerBekleme.Margin = new Padding(3, 2, 3, 2);
      this.txtTimerBekleme.Name = "txtTimerBekleme";
      this.txtTimerBekleme.Size = new Size(47, 24);
      this.txtTimerBekleme.TabIndex = 0;
      this.label28.AutoSize = true;
      this.label28.Location = new Point(8, 136);
      this.label28.Name = "label28";
      this.label28.Size = new Size(66, 17);
      this.label28.TabIndex = 1;
      this.label28.Text = "T. Turnike:";
      this.label32.AutoSize = true;
      this.label32.Location = new Point(8, 80);
      this.label32.Name = "label32";
      this.label32.Size = new Size(74, 17);
      this.label32.TabIndex = 1;
      this.label32.Text = "T. Bekleme:";
      this.txtTimerAdmin.Location = new Point(81, 105);
      this.txtTimerAdmin.Margin = new Padding(3, 2, 3, 2);
      this.txtTimerAdmin.Name = "txtTimerAdmin";
      this.txtTimerAdmin.Size = new Size(47, 24);
      this.txtTimerAdmin.TabIndex = 0;
      this.label24.AutoSize = true;
      this.label24.Location = new Point(7, 108);
      this.label24.Name = "label24";
      this.label24.Size = new Size(61, 17);
      this.label24.TabIndex = 1;
      this.label24.Text = "T. Admin:";
      this.checkBox2.AutoSize = true;
      this.checkBox2.Location = new Point(9, 24);
      this.checkBox2.Margin = new Padding(3, 2, 3, 2);
      this.checkBox2.Name = "checkBox2";
      this.checkBox2.Size = new Size(99, 21);
      this.checkBox2.TabIndex = 3;
      this.checkBox2.Text = "Şifre Değiştir";
      this.checkBox2.UseVisualStyleBackColor = true;
      this.checkBox2.CheckedChanged += new EventHandler(this.checkBox2_CheckedChanged);
      this.checkBileklik.AutoSize = true;
      this.checkBileklik.Location = new Point(103, 502);
      this.checkBileklik.Margin = new Padding(3, 2, 3, 2);
      this.checkBileklik.Name = "checkBileklik";
      this.checkBileklik.Size = new Size(95, 21);
      this.checkBileklik.TabIndex = 3;
      this.checkBileklik.Text = "Bileklik Aktif";
      this.checkBileklik.UseVisualStyleBackColor = true;
      this.checkAyak.AutoSize = true;
      this.checkAyak.Location = new Point(14, 502);
      this.checkAyak.Margin = new Padding(3, 2, 3, 2);
      this.checkAyak.Name = "checkAyak";
      this.checkAyak.Size = new Size(83, 21);
      this.checkAyak.TabIndex = 3;
      this.checkAyak.Text = "Ayak Aktif";
      this.checkAyak.UseVisualStyleBackColor = true;
      this.txtKaliteSifre.Enabled = false;
      this.txtKaliteSifre.Location = new Point(9, 133);
      this.txtKaliteSifre.Margin = new Padding(3, 2, 3, 2);
      this.txtKaliteSifre.Name = "txtKaliteSifre";
      this.txtKaliteSifre.PasswordChar = '*';
      this.txtKaliteSifre.Size = new Size(89, 24);
      this.txtKaliteSifre.TabIndex = 0;
      this.txtAdminSifre.Enabled = false;
      this.txtAdminSifre.Location = new Point(9, 77);
      this.txtAdminSifre.Margin = new Padding(3, 2, 3, 2);
      this.txtAdminSifre.Name = "txtAdminSifre";
      this.txtAdminSifre.PasswordChar = '*';
      this.txtAdminSifre.Size = new Size(89, 24);
      this.txtAdminSifre.TabIndex = 0;
      this.label27.AutoSize = true;
      this.label27.Location = new Point(8, 108);
      this.label27.Name = "label27";
      this.label27.Size = new Size(72, 17);
      this.label27.TabIndex = 1;
      this.label27.Text = "Kalite Şifre:";
      this.label26.AutoSize = true;
      this.label26.Location = new Point(8, 52);
      this.label26.Name = "label26";
      this.label26.Size = new Size(70, 17);
      this.label26.TabIndex = 1;
      this.label26.Text = "Adm. Şifre:";
      this.groupBox7.Controls.Add((Control) this.checkBox2);
      this.groupBox7.Controls.Add((Control) this.label26);
      this.groupBox7.Controls.Add((Control) this.txtAdminSifre);
      this.groupBox7.Controls.Add((Control) this.label27);
      this.groupBox7.Controls.Add((Control) this.txtKaliteSifre);
      this.groupBox7.Location = new Point(181, 278);
      this.groupBox7.Name = "groupBox7";
      this.groupBox7.Size = new Size(108, 203);
      this.groupBox7.TabIndex = 11;
      this.groupBox7.TabStop = false;
      this.groupBox7.Text = "Şifre Ayarları:";
      this.groupBox8.Controls.Add((Control) this.comboBox1);
      this.groupBox8.Controls.Add((Control) this.checkBox3);
      this.groupBox8.Controls.Add((Control) this.label30);
      this.groupBox8.Enabled = false;
      this.groupBox8.Location = new Point(295, 278);
      this.groupBox8.Name = "groupBox8";
      this.groupBox8.Size = new Size(153, 203);
      this.groupBox8.TabIndex = 12;
      this.groupBox8.TabStop = false;
      this.groupBox8.Text = "Veri Kayıt Ayarları:";
      this.comboBox1.FormattingEnabled = true;
      this.comboBox1.Items.AddRange(new object[3]
      {
        (object) "Günlük",
        (object) "Haftalık",
        (object) "Aylık"
      });
      this.comboBox1.Location = new Point(59, 49);
      this.comboBox1.Name = "comboBox1";
      this.comboBox1.Size = new Size(87, 23);
      this.comboBox1.TabIndex = 2;
      this.checkBox3.AutoSize = true;
      this.checkBox3.Location = new Point(9, 24);
      this.checkBox3.Name = "checkBox3";
      this.checkBox3.Size = new Size(138, 21);
      this.checkBox3.TabIndex = 0;
      this.checkBox3.Text = "Periyodik Kayıt Aktif";
      this.checkBox3.UseVisualStyleBackColor = true;
      this.label30.AutoSize = true;
      this.label30.Location = new Point(7, 52);
      this.label30.Name = "label30";
      this.label30.Size = new Size(52, 17);
      this.label30.TabIndex = 1;
      this.label30.Text = "Periyot:";
      this.groupBox9.Enabled = false;
      this.groupBox9.Location = new Point(454, 278);
      this.groupBox9.Name = "groupBox9";
      this.groupBox9.Size = new Size(125, 203);
      this.groupBox9.TabIndex = 13;
      this.groupBox9.TabStop = false;
      this.groupBox10.Controls.Add((Control) this.label31);
      this.groupBox10.Controls.Add((Control) this.label34);
      this.groupBox10.Controls.Add((Control) this.label35);
      this.groupBox10.Controls.Add((Control) this.label36);
      this.groupBox10.Controls.Add((Control) this.label37);
      this.groupBox10.Controls.Add((Control) this.mifareParity2);
      this.groupBox10.Controls.Add((Control) this.mifareStop2);
      this.groupBox10.Controls.Add((Control) this.mifareData2);
      this.groupBox10.Controls.Add((Control) this.mifareBaud2);
      this.groupBox10.Controls.Add((Control) this.mifarecom2);
      this.groupBox10.Location = new Point(585, 14);
      this.groupBox10.Margin = new Padding(3, 2, 3, 2);
      this.groupBox10.Name = "groupBox10";
      this.groupBox10.Padding = new Padding(3, 2, 3, 2);
      this.groupBox10.Size = new Size(185, 177);
      this.groupBox10.TabIndex = 14;
      this.groupBox10.TabStop = false;
      this.groupBox10.Text = "Çıkış Mifare Okuyucu Com:";
      this.label31.AutoSize = true;
      this.label31.Location = new Point(7, 147);
      this.label31.Name = "label31";
      this.label31.Size = new Size(45, 17);
      this.label31.TabIndex = 3;
      this.label31.Text = "Parity:";
      this.label34.AutoSize = true;
      this.label34.Location = new Point(7, 117);
      this.label34.Name = "label34";
      this.label34.Size = new Size(53, 17);
      this.label34.TabIndex = 3;
      this.label34.Text = "StopBit:";
      this.label35.AutoSize = true;
      this.label35.Location = new Point(7, 87);
      this.label35.Name = "label35";
      this.label35.Size = new Size(61, 17);
      this.label35.TabIndex = 3;
      this.label35.Text = "DataBits:";
      this.label36.AutoSize = true;
      this.label36.Location = new Point(7, 57);
      this.label36.Name = "label36";
      this.label36.Size = new Size(68, 17);
      this.label36.TabIndex = 3;
      this.label36.Text = "BaudRate:";
      this.label37.AutoSize = true;
      this.label37.Location = new Point(7, 27);
      this.label37.Name = "label37";
      this.label37.Size = new Size(61, 17);
      this.label37.TabIndex = 3;
      this.label37.Text = "ComPort:";
      this.mifareParity2.FormattingEnabled = true;
      this.mifareParity2.Items.AddRange(new object[5]
      {
        (object) "None",
        (object) "Odd",
        (object) "Even",
        (object) "Mark",
        (object) "Space"
      });
      this.mifareParity2.Location = new Point(81, 145);
      this.mifareParity2.Margin = new Padding(3, 4, 3, 4);
      this.mifareParity2.Name = "mifareParity2";
      this.mifareParity2.Size = new Size(94, 23);
      this.mifareParity2.TabIndex = 2;
      this.mifareStop2.FormattingEnabled = true;
      this.mifareStop2.Items.AddRange(new object[4]
      {
        (object) "None",
        (object) "One",
        (object) "Two",
        (object) "OnePointFive"
      });
      this.mifareStop2.Location = new Point(81, 115);
      this.mifareStop2.Margin = new Padding(3, 4, 3, 4);
      this.mifareStop2.Name = "mifareStop2";
      this.mifareStop2.Size = new Size(94, 23);
      this.mifareStop2.TabIndex = 2;
      this.mifareData2.FormattingEnabled = true;
      this.mifareData2.Items.AddRange(new object[2]
      {
        (object) "8",
        (object) "7"
      });
      this.mifareData2.Location = new Point(81, 85);
      this.mifareData2.Margin = new Padding(3, 4, 3, 4);
      this.mifareData2.Name = "mifareData2";
      this.mifareData2.Size = new Size(94, 23);
      this.mifareData2.TabIndex = 2;
      this.mifareBaud2.FormattingEnabled = true;
      this.mifareBaud2.Items.AddRange(new object[8]
      {
        (object) "2400",
        (object) "4800",
        (object) "7200",
        (object) "9600",
        (object) "19200",
        (object) "38400",
        (object) "57600",
        (object) "115200"
      });
      this.mifareBaud2.Location = new Point(81, 55);
      this.mifareBaud2.Margin = new Padding(3, 4, 3, 4);
      this.mifareBaud2.Name = "mifareBaud2";
      this.mifareBaud2.Size = new Size(94, 23);
      this.mifareBaud2.TabIndex = 2;
      this.mifarecom2.FormattingEnabled = true;
      this.mifarecom2.Location = new Point(81, 25);
      this.mifarecom2.Margin = new Padding(3, 4, 3, 4);
      this.mifarecom2.Name = "mifarecom2";
      this.mifarecom2.Size = new Size(94, 23);
      this.mifarecom2.TabIndex = 2;
      this.label38.AutoSize = true;
      this.label38.Location = new Point(132, 164);
      this.label38.Name = "label38";
      this.label38.Size = new Size(25, 17);
      this.label38.TabIndex = 5;
      this.label38.Text = "mS";
      this.txtTimerMifare2.Location = new Point(81, 161);
      this.txtTimerMifare2.Margin = new Padding(3, 2, 3, 2);
      this.txtTimerMifare2.Name = "txtTimerMifare2";
      this.txtTimerMifare2.Size = new Size(47, 24);
      this.txtTimerMifare2.TabIndex = 3;
      this.label39.AutoSize = true;
      this.label39.Location = new Point(8, 164);
      this.label39.Name = "label39";
      this.label39.Size = new Size(70, 17);
      this.label39.TabIndex = 4;
      this.label39.Text = "T.Ç Mifare:";
      this.AutoScaleDimensions = new SizeF(7f, 15f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(782, 543);
      this.Controls.Add((Control) this.groupBox10);
      this.Controls.Add((Control) this.groupBox9);
      this.Controls.Add((Control) this.groupBox8);
      this.Controls.Add((Control) this.groupBox7);
      this.Controls.Add((Control) this.groupBox6);
      this.Controls.Add((Control) this.checkBileklik);
      this.Controls.Add((Control) this.groupBox5);
      this.Controls.Add((Control) this.groupBox4);
      this.Controls.Add((Control) this.groupBox3);
      this.Controls.Add((Control) this.btnKaydet);
      this.Controls.Add((Control) this.groupBox2);
      this.Controls.Add((Control) this.groupBox1);
      this.Controls.Add((Control) this.checkAyak);
      this.Font = new Font("Calibri", 10f, FontStyle.Regular, GraphicsUnit.Point, (byte) 162);
      this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
      this.Margin = new Padding(3, 2, 3, 2);
      this.Name = " ";
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Ayarlar";
      this.Load += new EventHandler(this.AyarForm_Load);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.groupBox3.ResumeLayout(false);
      this.groupBox3.PerformLayout();
      this.groupBox4.ResumeLayout(false);
      this.groupBox4.PerformLayout();
      this.groupBox5.ResumeLayout(false);
      this.groupBox5.PerformLayout();
      this.groupBox6.ResumeLayout(false);
      this.groupBox6.PerformLayout();
      this.groupBox7.ResumeLayout(false);
      this.groupBox7.PerformLayout();
      this.groupBox8.ResumeLayout(false);
      this.groupBox8.PerformLayout();
      this.groupBox10.ResumeLayout(false);
      this.groupBox10.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
