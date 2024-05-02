// Decompiled with JetBrains decompiler
// Type: EsdTurnikesi.Main
// Assembly: EsdTurnikesi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C8099926-BBEB-495E-ADF6-36B4F5F75BE8
// Assembly location: C:\Users\serkan.baki\Desktop\PROJELER\2-) Gömülü Sistem Projeleri\(1707482-537)_Fabrika Girişi İçin Temassız Sıcaklık Ölçüm İstasyonu\SOFTWARE\GUI\esd-rar\ESD\Release\EsdTurnikesi.exe

using EsdTurnikesi.Properties;
using Modbus.Device;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO.Ports;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Utilities; 

namespace EsdTurnikesi
{
  public class Main : Form
  {
    public OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Ace.Oledb.12.0;Data Source=" + Ayarlar.Default.IDdosyayolu);
    public OleDbCommand komut = new OleDbCommand();
    public DataSet dtset = new DataSet();
    public DataTable dttable = new DataTable();
    public OleDbConnection baglan2 = new OleDbConnection("Provider=Microsoft.Ace.Oledb.12.0;Data Source=" + Ayarlar.Default.Logdosyayolu);
    public OleDbCommand komut2 = new OleDbCommand();
    public DataSet dtset2 = new DataSet();
    public DataTable dttable2 = new DataTable();
    public string Gelen = string.Empty;
    public string Gelen2 = string.Empty;
    public string Gelen22 = string.Empty;
    public bool esdAktif = true;
    public bool mifaredataaktif = true;
    public bool mifaredataaktif2 = true;
    public bool esddataaktif = true;
    public string esdresult = string.Empty;
    public AyarForm AyarFrm;
    public Kullanici KullaniciFrm;
    public GirisKayit GirisFrm;
    public Sifre SifreFrm;
    private const byte SW_HIDE = 0;
    private const byte SW_SHOW = 1;
    private IntPtr ShellHwnd;
    public ushort[] readreg;
    public int esdSolAyak;
    public int esdSagAyak;
    public int esdCiftAyak;
    public int esdBileklik;
    public bool AyakAktif;
    public bool bileklikAktif;
    public int yetki;
    private IContainer components;
    private TableLayoutPanel tableLayoutPanel1;
    private TableLayoutPanel tableLayoutPanel2;
    private Button btnCikis;
    private Button btnAyar;
    private Button btnKullanici;
    private Button btnGirisKayit;
    private TableLayoutPanel tableLayoutPanel3;
    private PictureBox pictureSol;
    private PictureBox pictureSag;
    private TableLayoutPanel tableLayoutPanel4;
    private Panel panel1;
    private Label lblID;
    private Label lblTarih;
    private Label lblGorevi;
    private Label lblAdSoyad;
    private TableLayoutPanel tableLayoutPanel5;
    private Label lblSolOlcum;
    private TableLayoutPanel tableLayoutPanel6;
    private Label lblSagOlcum;
    private TableLayoutPanel tableLayoutPanel7;
    private Label label6;
    private Label lblSaat;
    public SerialPort mifarePort;
    public SerialPort esdPort;
    public SerialPort plcPort;
    public Timer timerModbus;
    public Timer timerBekleme;
    public Timer timerESD;
    private Label lblElOlcum;
    private PictureBox pictureEl;
    private Label lblUyari;
    public Timer timerMifare;
    private Timer timerAdmin;
    public Timer timerTurnike;
    public SerialPort mifarePort2;
    public Timer timerMifare2;

    [DllImport("user32.dll")]
    public static extern bool GetLastInputInfo(ref Main.tagLASTINPUTINFO plii);

    public Main()
    {
      this.AyarFrm = new AyarForm();
      this.AyarFrm.MainFrm = this;
      this.KullaniciFrm = new Kullanici();
      this.KullaniciFrm.MainFrm = this;
      this.GirisFrm = new GirisKayit();
      this.GirisFrm.MainFrm = this;
      this.SifreFrm = new Sifre();
      this.SifreFrm.MainFrm = this;
      this.InitializeComponent();
    }

    [DllImport("user32.dll")]
    public static extern byte ShowWindow(IntPtr hWnd, int nCmdShow);

    [DllImport("user32.dll")]
    public static extern IntPtr FindWindow(string ClassName, string WindowName);

    private void Main_Load(object sender, EventArgs e)
    {
      this.ShellHwnd = Main.FindWindow("Shell TrayWnd", (string) null);
      IntPtr shellHwnd = this.ShellHwnd;
      int num1 = (int) Main.ShowWindow(this.ShellHwnd, 0);
      this.FormBorderStyle = FormBorderStyle.None;
      this.WindowState = FormWindowState.Maximized;
      Control.CheckForIllegalCrossThreadCalls = false;
      foreach (string portName in SerialPort.GetPortNames())
      {
        this.AyarFrm.mifarecom.Items.Add((object) portName);
        this.AyarFrm.mifarecom2.Items.Add((object) portName);
        this.AyarFrm.esdcom.Items.Add((object) portName);
        this.AyarFrm.plcCom.Items.Add((object) portName);
      }
      this.mifarePort.PortName = Ayarlar.Default.mifareCom;
      this.mifarePort.BaudRate = Ayarlar.Default.mifareBaud;
      this.mifarePort.DataBits = Ayarlar.Default.mifaredataBits;
      this.mifarePort.StopBits = Ayarlar.Default.mifarestopBit;
      this.mifarePort.Parity = Ayarlar.Default.mifareParity;
      this.mifarePort.ReceivedBytesThreshold = 1;
      this.mifarePort2.PortName = Ayarlar.Default.mifareCom2;
      this.mifarePort2.BaudRate = Ayarlar.Default.mifareBaud2;
      this.mifarePort2.DataBits = Ayarlar.Default.mifaredataBits2;
      this.mifarePort2.StopBits = Ayarlar.Default.mifarestopBits2;
      this.mifarePort2.Parity = Ayarlar.Default.mifareParity2;
      this.mifarePort2.ReceivedBytesThreshold = 1;
      this.esdPort.PortName = Ayarlar.Default.esdCom;
      this.esdPort.BaudRate = Ayarlar.Default.esdBaud;
      this.esdPort.DataBits = Ayarlar.Default.esddataBits;
      this.esdPort.StopBits = Ayarlar.Default.esdstopBit;
      this.esdPort.Parity = Ayarlar.Default.esdParity;
      this.plcPort.PortName = Ayarlar.Default.plcCom;
      this.plcPort.BaudRate = Ayarlar.Default.plcBaud;
      this.plcPort.DataBits = Ayarlar.Default.plcdataBits;
      this.plcPort.StopBits = Ayarlar.Default.plcstopBit;
      this.plcPort.Parity = Ayarlar.Default.plcParity;
      this.timerModbus.Interval = Ayarlar.Default.timerModbus;
      this.timerAdmin.Interval = Ayarlar.Default.timerAdmin;
      this.timerBekleme.Interval = Ayarlar.Default.timerBekleme;
      this.timerESD.Interval = Ayarlar.Default.timerESD;
      this.timerMifare.Interval = Ayarlar.Default.timerMifare;
      this.timerMifare2.Interval = Ayarlar.Default.timerMifare2;
      this.timerTurnike.Interval = Ayarlar.Default.timerTurnike;
      this.AyakAktif = Ayarlar.Default.checkAyak;
      this.bileklikAktif = Ayarlar.Default.checkBileklik;
      this.yetki = 0;
      this.yetkidegistir();
      try
      {
        this.mifarePort.Open();
        this.mifarePort2.Open();
        this.esdPort.Open();
        this.plcPort.Open();
      }
      catch (Exception ex)
      {
        this.timerModbus.Enabled = false;
        int num2 = (int) MessageBox.Show("Port Hatası: " + ex.ToString());
      }
      new globalKeyboardHook()
      {
        HookedKeys = {
          Keys.Alt,
          Keys.RControlKey,
          Keys.LControlKey,
          Keys.Delete,
          Keys.Tab,
          Keys.Shift,
          Keys.F4
        }
      }.KeyDown += new KeyEventHandler(this.gkh_KeyDown);
    }

    private void gkh_KeyDown(object sender, KeyEventArgs e)
    {
      e.Handled = true;
    }

    private void btnCikis_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void btnAyar_Click(object sender, EventArgs e)
    {
      int num = (int) this.AyarFrm.ShowDialog();
    }

    private void btnKullanici_Click(object sender, EventArgs e)
    {
      int num = (int) this.KullaniciFrm.ShowDialog();
    }

    private void btnGirisKayit_Click(object sender, EventArgs e)
    {
      int num = (int) this.GirisFrm.ShowDialog();
    }

    public void logekle()
    {
      try
      {
        this.baglan2.Open();
        this.komut2.Connection = this.baglan2;
        this.komut2.CommandText = "Insert Into liste (ID, AdSoyad, Gorevi, Tarih, Saat, SolAyak, SagAyak, Bileklik, EsdSonuc) Values ('" + this.lblID.Text + "','" + this.lblAdSoyad.Text + "','" + this.lblGorevi.Text + "','" + this.lblTarih.Text + "','" + this.lblSaat.Text + "','" + this.lblSolOlcum.Text + "','" + this.lblSagOlcum.Text + "','" + this.lblElOlcum.Text + "','" + this.esdresult + "')";
        this.komut2.ExecuteNonQuery();
        this.baglan2.Close();
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message);
        this.baglan2.Close();
      }
    }

    public void yaziortala()
    {
      Label lblId = this.lblID;
      Size size1 = this.panel1.Size;
      int num1 = size1.Width / 2;
      size1 = this.lblID.Size;
      int num2 = size1.Width / 2;
      Point point1 = new Point(num1 - num2, this.lblID.Location.Y);
      lblId.Location = point1;
      Label lblAdSoyad = this.lblAdSoyad;
      Size size2 = this.panel1.Size;
      int num3 = size2.Width / 2;
      size2 = this.lblAdSoyad.Size;
      int num4 = size2.Width / 2;
      Point point2 = new Point(num3 - num4, this.lblAdSoyad.Location.Y);
      lblAdSoyad.Location = point2;
      Label lblTarih = this.lblTarih;
      Size size3 = this.panel1.Size;
      int width1 = size3.Width;
      size3 = this.lblTarih.Size;
      int width2 = size3.Width;
      int num5 = width1 - width2;
      size3 = this.lblSaat.Size;
      int width3 = size3.Width;
      Point point3 = new Point((num5 - width3 - 5) / 2, this.lblTarih.Location.Y);
      lblTarih.Location = point3;
      Label lblSaat = this.lblSaat;
      Point location = this.lblTarih.Location;
      int x = location.X + this.lblTarih.Size.Width + 5;
      location = this.lblSaat.Location;
      int y = location.Y;
      Point point4 = new Point(x, y);
      lblSaat.Location = point4;
    }

    public bool getir()
    {
      if (this.baglan.State == ConnectionState.Open)
        this.baglan.Close();
      this.baglan.Open();
      this.komut.Connection = this.baglan;
      OleDbCommand oleDbCommand = new OleDbCommand("Select * From personel Where ID='" + this.lblID.Text + "'", this.baglan);
      OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
      if (oleDbDataReader.Read())
      {
        this.lblAdSoyad.Text = oleDbDataReader[1].ToString();
        this.lblGorevi.Text = oleDbDataReader[2].ToString();
        this.lblTarih.Text = DateTime.Now.ToShortDateString();
        this.lblSaat.Text = DateTime.Now.ToLongTimeString();
        this.lblID.ForeColor = Color.Green;
        this.lblAdSoyad.ForeColor = Color.Green;
        this.lblGorevi.ForeColor = Color.Green;
        this.lblTarih.ForeColor = Color.Green;
        this.lblSaat.ForeColor = Color.Green;
        this.yaziortala();
        oleDbCommand.Dispose();
        this.baglan.Close();
        return true;
      }
      this.lblAdSoyad.ForeColor = Color.Red;
      this.lblGorevi.ForeColor = Color.Red;
      this.lblAdSoyad.Text = "Tanımsız";
      this.lblGorevi.Text = "Tanımsız";
      this.yaziortala();
      oleDbCommand.Dispose();
      this.baglan.Close();
      return false;
    }

    private void mifarePort_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
      if (this.mifaredataaktif)
      {
        this.Invoke((Delegate) new EventHandler(this.EnableTimerMifare));
        int bytesToRead = this.mifarePort.BytesToRead;
        byte[] numArray = new byte[bytesToRead];
        this.mifarePort.Read(numArray, 0, bytesToRead);
        this.Gelen += Encoding.ASCII.GetString(numArray);
      }
      else
      {
        this.mifarePort.DiscardInBuffer();
        this.mifarePort.DiscardOutBuffer();
      }
    }

    private void mifarePort2_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
      if (this.mifaredataaktif2)
      {
        this.Invoke((Delegate) new EventHandler(this.EnableTimerMifare2));
        int bytesToRead = this.mifarePort2.BytesToRead;
        byte[] numArray = new byte[bytesToRead];
        this.mifarePort2.Read(numArray, 0, bytesToRead);
        this.Gelen += Encoding.ASCII.GetString(numArray);
      }
      else
      {
        this.mifarePort2.DiscardInBuffer();
        this.mifarePort2.DiscardOutBuffer();
      }
    }

    private void esdPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
      if (this.esddataaktif)
      {
        this.Invoke((Delegate) new EventHandler(this.EnableTimerESD));
        int bytesToRead = this.esdPort.BytesToRead;
        byte[] numArray = new byte[bytesToRead];
        this.esdPort.Read(numArray, 0, bytesToRead);
        this.Gelen22 += Encoding.ASCII.GetString(numArray);
      }
      else
      {
        this.esdPort.DiscardInBuffer();
        this.esdPort.DiscardOutBuffer();
      }
    }

    private void EnableTimerESD(object sender, EventArgs e)
    {
      this.timerESD.Enabled = true;
    }

    private void EnableTimerMifare(object sender, EventArgs e)
    {
      this.timerMifare.Enabled = true;
    }

    private void EnableTimerMifare2(object sender, EventArgs e)
    {
      this.timerMifare2.Enabled = true;
    }

    private void timerModbus_Tick(object sender, EventArgs e)
    {
      try
      {
        IModbusSerialMaster ascii = (IModbusSerialMaster) ModbusSerialMaster.CreateAscii(this.plcPort);
        ascii.Transport.ReadTimeout = 300;
        this.readreg = ascii.ReadHoldingRegisters((byte) 1, (ushort) 4246, (ushort) 2);
      }
      catch (Exception ex)
      {
        this.timerModbus.Enabled = false;
        int num = (int) MessageBox.Show("Modbus haberleşme hatası: " + ex.ToString());
      }
    }

    private void timerBekleme_Tick(object sender, EventArgs e)
    {
      this.esdAktif = false;
      this.timerBekleme.Enabled = false;
      this.lblID.Text = "";
      this.lblID.ForeColor = Color.Black;
      this.lblAdSoyad.Text = "";
      this.lblAdSoyad.ForeColor = Color.Black;
      this.lblGorevi.Text = "";
      this.lblGorevi.ForeColor = Color.Black;
      this.lblTarih.Text = "";
      this.lblTarih.ForeColor = Color.Black;
      this.lblSaat.Text = "";
      this.lblSaat.ForeColor = Color.Black;
      this.pictureSol.Image = (Image) Resources.ayaksol;
      this.pictureSag.Image = (Image) Resources.ayaksag;
      this.pictureEl.Image = (Image) Resources.wirstbandblack;
      this.lblSolOlcum.Text = "";
      this.lblSagOlcum.Text = "";
      this.lblElOlcum.Text = "";
      this.mifaredataaktif = true;
      this.mifarePort.DiscardInBuffer();
      this.mifarePort.DiscardOutBuffer();
      this.mifaredataaktif2 = true;
      this.mifarePort2.DiscardInBuffer();
      this.mifarePort2.DiscardOutBuffer();
      this.Gelen2 = string.Empty;
      this.Gelen22 = string.Empty;
      this.lblUyari.Text = "ESD ölçümü için öncelikle kimlik kartınızı okutunuz...";
      this.lblUyari.BackColor = Color.White;
      this.lblUyari.ForeColor = Color.Black;
    }

    private void timerESD_Tick(object sender, EventArgs e)
    {
      this.timerESD.Enabled = false;
      this.esddataaktif = false;
      this.Gelen2 = this.Gelen22;
      this.Gelen22 = string.Empty;
      string empty1 = string.Empty;
      string empty2 = string.Empty;
      string empty3 = string.Empty;
      string empty4 = string.Empty;
      string empty5 = string.Empty;
      if (!this.esdAktif)
        return;
      this.Gelen2 = this.Gelen2.Trim();
      if (this.Gelen2.Length > 25 && this.AyakAktif)
      {
        string str1 = this.Gelen2.Substring(this.Gelen2.IndexOf('\x0002') + 1, this.Gelen2.IndexOf('\x0003') - 1);
        string str2 = str1.Substring(0, 3);
        string str3 = str1.Substring(4);
        if (str3 == "OVR" || str3 == "UNR")
          str3 = "0";
        if (!(str2 == "RSG"))
        {
          if (!(str2 == "RHG"))
          {
            if (!(str2 == "RSL"))
            {
              if (!(str2 == "RSR"))
              {
                if (str2 == "ERG")
                  this.esdresult = str3;
              }
              else
                this.esdSagAyak = Convert.ToInt32(str3);
            }
            else
              this.esdSolAyak = Convert.ToInt32(str3);
          }
          else
            this.esdBileklik = Convert.ToInt32(str3);
        }
        else
          this.esdCiftAyak = Convert.ToInt32(str3);
        this.Gelen2 = this.Gelen2.Substring(this.Gelen2.IndexOf('\x0003'));
        this.Gelen2 = this.Gelen2.Substring(2);
        string str4 = this.Gelen2.Substring(2, this.Gelen2.IndexOf('\x0003') - 2);
        string str5 = str4.Substring(0, 3);
        string str6 = str4.Substring(4);
        if (str6 == "OVR" || str6 == "UNR")
          str6 = "0";
        if (!(str5 == "RSG"))
        {
          if (!(str5 == "RHG"))
          {
            if (!(str5 == "RSL"))
            {
              if (!(str5 == "RSR"))
              {
                if (str5 == "ERG")
                  this.esdresult = str6;
              }
              else
                this.esdSagAyak = Convert.ToInt32(str6);
            }
            else
              this.esdSolAyak = Convert.ToInt32(str6);
          }
          else
            this.esdBileklik = Convert.ToInt32(str6);
        }
        else
          this.esdCiftAyak = Convert.ToInt32(str6);
        string str7 = this.Gelen2.Substring(this.Gelen2.IndexOf('\x0003')).Substring(2);
        string str8 = str7.Substring(2, str7.IndexOf('\x0003') - 2);
        string str9 = str8.Substring(0, 3);
        string str10 = str8.Substring(4);
        if (str10 == "OVR" || str10 == "UNR")
          str10 = "0";
        if (!(str9 == "RSG"))
        {
          if (!(str9 == "RHG"))
          {
            if (!(str9 == "RSL"))
            {
              if (!(str9 == "RSR"))
              {
                if (str9 == "ERG")
                  this.esdresult = str10;
              }
              else
                this.esdSagAyak = Convert.ToInt32(str10);
            }
            else
              this.esdSolAyak = Convert.ToInt32(str10);
          }
          else
            this.esdBileklik = Convert.ToInt32(str10);
        }
        else
          this.esdCiftAyak = Convert.ToInt32(str10);
        if (this.esdSolAyak == 0)
        {
          this.lblSolOlcum.Text = "OVER MOhm";
          this.lblSolOlcum.ForeColor = Color.Red;
          this.pictureSol.Image = (Image) Resources.ayaksolred;
          this.lblSolOlcum.Visible = true;
        }
        else
        {
          this.lblSolOlcum.Text = ((float) this.esdSolAyak / 1000f).ToString("N3") + " MOhm";
          this.lblSolOlcum.ForeColor = Color.Green;
          this.pictureSol.Image = (Image) Resources.ayaksolgreen;
          this.lblSolOlcum.Visible = true;
        }
        if (this.esdSagAyak == 0)
        {
          this.lblSagOlcum.Text = "OVER MOhm";
          this.lblSagOlcum.ForeColor = Color.Red;
          this.pictureSag.Image = (Image) Resources.ayaksagred;
          this.lblSagOlcum.Visible = true;
        }
        else
        {
          this.lblSagOlcum.Text = ((float) this.esdSagAyak / 1000f).ToString("N3") + " MOhm";
          this.lblSagOlcum.ForeColor = Color.Green;
          this.pictureSag.Image = (Image) Resources.ayaksaggreen;
          this.lblSagOlcum.Visible = true;
        }
        if (this.esdresult == "OK")
        {
          this.esdresult = "PASS";
          this.lblUyari.Text = "PASS";
          this.lblUyari.BackColor = Color.Green;
          this.lblUyari.ForeColor = Color.White;
          this.timerBekleme.Enabled = false;
          this.timerBekleme.Interval = Ayarlar.Default.timerBekleme;
          this.timerBekleme.Enabled = true;
          this.turnikeGirisAc();
        }
        else
        {
          this.esdresult = "FAIL";
          this.lblUyari.Text = "FAIL";
          this.lblUyari.BackColor = Color.Red;
          this.lblUyari.ForeColor = Color.White;
          this.timerBekleme.Enabled = false;
          this.timerBekleme.Interval = Ayarlar.Default.timerBekleme;
          this.timerBekleme.Enabled = true;
        }
        this.logekle();
      }
      else if (this.Gelen2.Length < 12 && this.Gelen2.Length > 8)
      {
        string str1 = this.Gelen2.Substring(this.Gelen2.IndexOf('\x0002') + 1, this.Gelen2.IndexOf('\x0003') - 1);
        string str2 = str1.Substring(0, 3);
        string str3 = str1.Substring(4);
        if (str3 == "OVR" || str3 == "UNR")
          str3 = "0";
        if (!(str2 == "RSG"))
        {
          if (!(str2 == "RHG"))
          {
            if (!(str2 == "RSL"))
            {
              if (!(str2 == "RSR"))
              {
                if (str2 == "ERG")
                  this.esdresult = str3;
              }
              else
                this.esdSagAyak = Convert.ToInt32(str3);
            }
            else
              this.esdSolAyak = Convert.ToInt32(str3);
          }
          else
            this.esdBileklik = Convert.ToInt32(str3);
        }
        else
          this.esdCiftAyak = Convert.ToInt32(str3);
        if (this.esdresult == "-10")
        {
          this.lblUyari.Text = "Sağlıklı ölçüm için en az 1 saniye elinizi butonun üzerinde tutunuz!";
          this.lblUyari.BackColor = Color.White;
          this.lblUyari.ForeColor = Color.Black;
          this.timerBekleme.Enabled = false;
          this.timerBekleme.Interval = Ayarlar.Default.timerBekleme;
          this.timerBekleme.Enabled = true;
        }
      }
      else if (this.Gelen2.Length < 22 && this.Gelen2.Length > 16 && this.bileklikAktif)
      {
        string str1 = this.Gelen2.Substring(this.Gelen2.IndexOf('\x0002') + 1, this.Gelen2.IndexOf('\x0003') - 1);
        string str2 = str1.Substring(0, 3);
        string str3 = str1.Substring(4);
        if (str3 == "OVR" || str3 == "UNR")
          str3 = "0";
        if (!(str2 == "RSG"))
        {
          if (!(str2 == "RHG"))
          {
            if (!(str2 == "RSL"))
            {
              if (!(str2 == "RSR"))
              {
                if (str2 == "ERG")
                  this.esdresult = str3;
              }
              else
                this.esdSagAyak = Convert.ToInt32(str3);
            }
            else
              this.esdSolAyak = Convert.ToInt32(str3);
          }
          else
            this.esdBileklik = Convert.ToInt32(str3);
        }
        else
          this.esdCiftAyak = Convert.ToInt32(str3);
        this.Gelen2 = this.Gelen2.Substring(this.Gelen2.IndexOf('\x0003'));
        this.Gelen2 = this.Gelen2.Substring(2);
        string str4 = this.Gelen2.Substring(2, this.Gelen2.IndexOf('\x0003') - 2);
        string str5 = str4.Substring(0, 3);
        string str6 = str4.Substring(4);
        if (str6 == "OVR" || str6 == "UNR")
          str6 = "0";
        if (!(str5 == "RSG"))
        {
          if (!(str5 == "RHG"))
          {
            if (!(str5 == "RSL"))
            {
              if (!(str5 == "RSR"))
              {
                if (str5 == "ERG")
                  this.esdresult = str6;
              }
              else
                this.esdSagAyak = Convert.ToInt32(str6);
            }
            else
              this.esdSolAyak = Convert.ToInt32(str6);
          }
          else
            this.esdBileklik = Convert.ToInt32(str6);
        }
        else
          this.esdCiftAyak = Convert.ToInt32(str6);
        if (this.esdBileklik == 0)
          this.lblElOlcum.Text = "OVER MOhm";
        else
          this.lblElOlcum.Text = ((float) this.esdBileklik / 1000f).ToString("N3") + " MOhm";
        if (this.esdresult == "OK")
        {
          this.esdresult = "PASS";
          this.lblUyari.Text = "PASS";
          this.lblUyari.BackColor = Color.Green;
          this.lblUyari.ForeColor = Color.White;
          this.lblElOlcum.ForeColor = Color.Green;
          this.pictureEl.Image = (Image) Resources.wirstbandgreen;
          this.lblElOlcum.Visible = true;
          this.timerBekleme.Enabled = false;
          this.timerBekleme.Interval = Ayarlar.Default.timerBekleme;
          this.timerBekleme.Enabled = true;
          this.turnikeGirisAc();
        }
        else
        {
          this.esdresult = "FAIL";
          this.lblUyari.Text = "FAIL";
          this.lblUyari.BackColor = Color.Red;
          this.lblUyari.ForeColor = Color.White;
          this.lblElOlcum.ForeColor = Color.Red;
          this.pictureEl.Image = (Image) Resources.wirstbandred;
          this.lblElOlcum.Visible = true;
          this.timerBekleme.Enabled = false;
          this.timerBekleme.Interval = Ayarlar.Default.timerBekleme;
          this.timerBekleme.Enabled = true;
        }
        this.logekle();
      }
      this.Gelen2 = string.Empty;
    }

    private void EnableTimerBekleme(object sender, EventArgs e)
    {
      this.timerBekleme.Enabled = true;
    }

    private void timerMifare_Tick(object sender, EventArgs e)
    {
      this.mifaredataaktif = false;
      this.timerMifare.Enabled = false;
      string empty = string.Empty;
      string gelen = this.Gelen;
      this.Gelen = string.Empty;
      this.lblID.Text = gelen;
      this.KullaniciFrm.textBox2.Text = gelen;
      if (this.getir() && !this.KullaniciFrm.Visible && (!this.AyarFrm.Visible && !this.GirisFrm.Visible) && !this.SifreFrm.Visible)
      {
        this.esddataaktif = true;
        this.esdAktif = true;
        this.Invoke((Delegate) new EventHandler(this.EnableTimerBekleme));
        this.lblUyari.Text = (Ayarlar.Default.timerBekleme / 1000).ToString() + " saniye içerisinde ESD ölçümünü yapınız.";
        this.lblUyari.BackColor = Color.Yellow;
        this.lblUyari.ForeColor = Color.Black;
      }
      else
      {
        this.esddataaktif = false;
        this.esdAktif = false;
        this.Gelen = string.Empty;
        empty = string.Empty;
        this.Invoke((Delegate) new EventHandler(this.EnableTimerBekleme));
      }
      this.mifarePort.DiscardInBuffer();
      this.mifarePort.DiscardOutBuffer();
    }

    private void timerMifare2_Tick(object sender, EventArgs e)
    {
      this.mifaredataaktif2 = false;
      this.timerMifare2.Enabled = false;
      string empty = string.Empty;
      string gelen = this.Gelen;
      this.Gelen = string.Empty;
      this.lblID.Text = gelen;
      this.KullaniciFrm.textBox2.Text = gelen;
      if (this.getir() && !this.KullaniciFrm.Visible && (!this.AyarFrm.Visible && !this.GirisFrm.Visible) && !this.SifreFrm.Visible)
      {
        this.turnikeCikisAc();
        this.Invoke((Delegate) new EventHandler(this.EnableTimerBekleme));
        this.lblUyari.Text = (Ayarlar.Default.timerBekleme / 1000).ToString() + " saniye içerisinde ESD ölçümünü yapınız.";
        this.lblUyari.BackColor = Color.Yellow;
        this.lblUyari.ForeColor = Color.Black;
      }
      else
      {
        this.Gelen = string.Empty;
        empty = string.Empty;
        this.Invoke((Delegate) new EventHandler(this.EnableTimerBekleme));
      }
      this.mifarePort2.DiscardInBuffer();
      this.mifarePort2.DiscardOutBuffer();
    }

    public void yetkidegistir()
    {
      if (this.yetki == 0)
      {
        this.btnCikis.Enabled = false;
        this.btnAyar.Enabled = false;
        this.btnKullanici.Enabled = false;
        this.btnGirisKayit.Enabled = false;
        this.label6.ForeColor = Color.Black;
        this.label6.Text = "ESD ÖLÇÜM İSTASYONU";
      }
      if (this.yetki == 1)
      {
        this.btnCikis.Enabled = true;
        this.btnAyar.Enabled = true;
        this.btnKullanici.Enabled = true;
        this.btnGirisKayit.Enabled = true;
        this.label6.ForeColor = Color.Red;
        this.label6.Text = "ESD ÖLÇÜM İSTASYONU ADMIN MODU";
        this.timerAdmin.Enabled = true;
      }
      if (this.yetki != 2)
        return;
      this.btnCikis.Enabled = false;
      this.btnKullanici.Enabled = true;
      this.btnGirisKayit.Enabled = true;
      this.label6.ForeColor = Color.Red;
      this.label6.Text = "ESD ÖLÇÜM İSTASYONU KALİTE MODU";
      this.timerAdmin.Enabled = true;
    }

    private void Main_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyData != Keys.L)
        return;
      if (this.yetki != 0)
      {
        this.timerAdmin.Enabled = false;
        this.yetki = 0;
        this.yetkidegistir();
      }
      else
      {
        int num = (int) this.SifreFrm.ShowDialog();
      }
    }

    private void timerAdmin_Tick(object sender, EventArgs e)
    {
      Main.tagLASTINPUTINFO plii = new Main.tagLASTINPUTINFO();
      int num = 0;
      plii.cbSize = (uint) Marshal.SizeOf((object) plii);
      plii.dwTime = 0;
      if (Main.GetLastInputInfo(ref plii))
        num = Environment.TickCount - plii.dwTime;
      if (num <= 10000)
        return;
      this.timerAdmin.Enabled = false;
      this.yetki = 0;
      this.yetkidegistir();
    }

    public void turnikeGirisAc()
    {
      ModbusSerialMaster ascii = ModbusSerialMaster.CreateAscii(this.plcPort);
      ((IModbusSerialMaster) ascii).Transport.ReadTimeout = 300;
      ascii.WriteSingleCoil((byte) 1, (ushort) 1280, true);
      this.timerTurnike.Enabled = true;
    }

    public void turnikeCikisAc()
    {
      ModbusSerialMaster ascii = ModbusSerialMaster.CreateAscii(this.plcPort);
      ((IModbusSerialMaster) ascii).Transport.ReadTimeout = 300;
      ascii.WriteSingleCoil((byte) 1, (ushort) 1281, true);
      this.timerTurnike.Enabled = true;
    }

    private void turnikeTmr_Tick(object sender, EventArgs e)
    {
      ModbusSerialMaster ascii = ModbusSerialMaster.CreateAscii(this.plcPort);
      ((IModbusSerialMaster) ascii).Transport.ReadTimeout = 300;
      this.timerTurnike.Enabled = false;
      ascii.WriteSingleCoil((byte) 1, (ushort) 1280, false);
      ascii.WriteSingleCoil((byte) 1, (ushort) 1281, false);
    }

    private void Main_FormClosing(object sender, FormClosingEventArgs e)
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblSaat = new System.Windows.Forms.Label();
            this.lblTarih = new System.Windows.Forms.Label();
            this.lblAdSoyad = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.lblGorevi = new System.Windows.Forms.Label();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.lblElOlcum = new System.Windows.Forms.Label();
            this.lblUyari = new System.Windows.Forms.Label();
            this.pictureEl = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCikis = new System.Windows.Forms.Button();
            this.btnAyar = new System.Windows.Forms.Button();
            this.btnKullanici = new System.Windows.Forms.Button();
            this.btnGirisKayit = new System.Windows.Forms.Button();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureSol = new System.Windows.Forms.PictureBox();
            this.lblSolOlcum = new System.Windows.Forms.Label();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureSag = new System.Windows.Forms.PictureBox();
            this.lblSagOlcum = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.mifarePort = new System.IO.Ports.SerialPort(this.components);
            this.esdPort = new System.IO.Ports.SerialPort(this.components);
            this.plcPort = new System.IO.Ports.SerialPort(this.components);
            this.timerModbus = new System.Windows.Forms.Timer(this.components);
            this.timerBekleme = new System.Windows.Forms.Timer(this.components);
            this.timerESD = new System.Windows.Forms.Timer(this.components);
            this.timerMifare = new System.Windows.Forms.Timer(this.components);
            this.timerAdmin = new System.Windows.Forms.Timer(this.components);
            this.timerTurnike = new System.Windows.Forms.Timer(this.components);
            this.mifarePort2 = new System.IO.Ports.SerialPort(this.components);
            this.timerMifare2 = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEl)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureSol)).BeginInit();
            this.tableLayoutPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureSag)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1314, 712);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 400F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel5, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel6, 2, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 78);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1308, 631);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel7, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(457, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 3;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(394, 625);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblSaat);
            this.panel1.Controls.Add(this.lblTarih);
            this.panel1.Controls.Add(this.lblAdSoyad);
            this.panel1.Controls.Add(this.lblID);
            this.panel1.Controls.Add(this.lblGorevi);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 403);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(388, 144);
            this.panel1.TabIndex = 1;
            // 
            // lblSaat
            // 
            this.lblSaat.AutoSize = true;
            this.lblSaat.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSaat.Location = new System.Drawing.Point(191, 100);
            this.lblSaat.Name = "lblSaat";
            this.lblSaat.Size = new System.Drawing.Size(0, 39);
            this.lblSaat.TabIndex = 0;
            // 
            // lblTarih
            // 
            this.lblTarih.AutoSize = true;
            this.lblTarih.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTarih.Location = new System.Drawing.Point(109, 100);
            this.lblTarih.Name = "lblTarih";
            this.lblTarih.Size = new System.Drawing.Size(0, 39);
            this.lblTarih.TabIndex = 0;
            // 
            // lblAdSoyad
            // 
            this.lblAdSoyad.AutoSize = true;
            this.lblAdSoyad.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblAdSoyad.Location = new System.Drawing.Point(118, 53);
            this.lblAdSoyad.Name = "lblAdSoyad";
            this.lblAdSoyad.Size = new System.Drawing.Size(0, 39);
            this.lblAdSoyad.TabIndex = 0;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblID.Location = new System.Drawing.Point(119, 6);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(0, 39);
            this.lblID.TabIndex = 0;
            // 
            // lblGorevi
            // 
            this.lblGorevi.AutoSize = true;
            this.lblGorevi.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblGorevi.Location = new System.Drawing.Point(176, 53);
            this.lblGorevi.Name = "lblGorevi";
            this.lblGorevi.Size = new System.Drawing.Size(0, 39);
            this.lblGorevi.TabIndex = 0;
            this.lblGorevi.Visible = false;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 1;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Controls.Add(this.lblElOlcum, 0, 1);
            this.tableLayoutPanel7.Controls.Add(this.lblUyari, 0, 2);
            this.tableLayoutPanel7.Controls.Add(this.pictureEl, 0, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 3;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(388, 394);
            this.tableLayoutPanel7.TabIndex = 2;
            // 
            // lblElOlcum
            // 
            this.lblElOlcum.AutoSize = true;
            this.lblElOlcum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblElOlcum.Font = new System.Drawing.Font("Calibri", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblElOlcum.Location = new System.Drawing.Point(3, 234);
            this.lblElOlcum.Name = "lblElOlcum";
            this.lblElOlcum.Size = new System.Drawing.Size(382, 40);
            this.lblElOlcum.TabIndex = 1;
            this.lblElOlcum.Text = "00.0 Mohm";
            this.lblElOlcum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblElOlcum.Visible = false;
            // 
            // lblUyari
            // 
            this.lblUyari.AutoSize = true;
            this.lblUyari.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUyari.Font = new System.Drawing.Font("Calibri", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblUyari.Location = new System.Drawing.Point(3, 274);
            this.lblUyari.Name = "lblUyari";
            this.lblUyari.Size = new System.Drawing.Size(382, 120);
            this.lblUyari.TabIndex = 2;
            this.lblUyari.Text = "ESD ölçümü için öncelikle kimlik kartınızı okutunuz...";
            this.lblUyari.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureEl
            // 
            this.pictureEl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureEl.Image = ((System.Drawing.Image)(resources.GetObject("pictureEl.Image")));
            this.pictureEl.Location = new System.Drawing.Point(3, 3);
            this.pictureEl.Name = "pictureEl";
            this.pictureEl.Size = new System.Drawing.Size(382, 228);
            this.pictureEl.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureEl.TabIndex = 3;
            this.pictureEl.TabStop = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.btnCikis, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnAyar, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnKullanici, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnGirisKayit, 3, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(5, 555);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(384, 65);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // btnCikis
            // 
            this.btnCikis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCikis.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnCikis.Location = new System.Drawing.Point(5, 5);
            this.btnCikis.Margin = new System.Windows.Forms.Padding(5);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(86, 55);
            this.btnCikis.TabIndex = 0;
            this.btnCikis.Text = "Çıkış";
            this.btnCikis.UseVisualStyleBackColor = true;
            this.btnCikis.Click += new System.EventHandler(this.btnCikis_Click);
            // 
            // btnAyar
            // 
            this.btnAyar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAyar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAyar.Location = new System.Drawing.Point(101, 5);
            this.btnAyar.Margin = new System.Windows.Forms.Padding(5);
            this.btnAyar.Name = "btnAyar";
            this.btnAyar.Size = new System.Drawing.Size(86, 55);
            this.btnAyar.TabIndex = 1;
            this.btnAyar.Text = "Ayarlar";
            this.btnAyar.UseVisualStyleBackColor = true;
            this.btnAyar.Click += new System.EventHandler(this.btnAyar_Click);
            // 
            // btnKullanici
            // 
            this.btnKullanici.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnKullanici.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKullanici.Location = new System.Drawing.Point(197, 5);
            this.btnKullanici.Margin = new System.Windows.Forms.Padding(5);
            this.btnKullanici.Name = "btnKullanici";
            this.btnKullanici.Size = new System.Drawing.Size(86, 55);
            this.btnKullanici.TabIndex = 2;
            this.btnKullanici.Text = "Kullanıcı İşlemleri";
            this.btnKullanici.UseVisualStyleBackColor = true;
            this.btnKullanici.Click += new System.EventHandler(this.btnKullanici_Click);
            // 
            // btnGirisKayit
            // 
            this.btnGirisKayit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGirisKayit.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGirisKayit.Location = new System.Drawing.Point(293, 5);
            this.btnGirisKayit.Margin = new System.Windows.Forms.Padding(5);
            this.btnGirisKayit.Name = "btnGirisKayit";
            this.btnGirisKayit.Size = new System.Drawing.Size(86, 55);
            this.btnGirisKayit.TabIndex = 3;
            this.btnGirisKayit.Text = "Giriş Kayıtları";
            this.btnGirisKayit.UseVisualStyleBackColor = true;
            this.btnGirisKayit.Click += new System.EventHandler(this.btnGirisKayit_Click);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.pictureSol, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.lblSolOlcum, 0, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(448, 625);
            this.tableLayoutPanel5.TabIndex = 3;
            // 
            // pictureSol
            // 
            this.pictureSol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureSol.Location = new System.Drawing.Point(3, 3);
            this.pictureSol.Name = "pictureSol";
            this.pictureSol.Size = new System.Drawing.Size(442, 579);
            this.pictureSol.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureSol.TabIndex = 0;
            this.pictureSol.TabStop = false;
            // 
            // lblSolOlcum
            // 
            this.lblSolOlcum.AutoSize = true;
            this.lblSolOlcum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSolOlcum.Font = new System.Drawing.Font("Calibri", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSolOlcum.Location = new System.Drawing.Point(3, 585);
            this.lblSolOlcum.Name = "lblSolOlcum";
            this.lblSolOlcum.Size = new System.Drawing.Size(442, 40);
            this.lblSolOlcum.TabIndex = 1;
            this.lblSolOlcum.Text = "00.0 Mohm";
            this.lblSolOlcum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSolOlcum.Visible = false;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Controls.Add(this.pictureSag, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.lblSagOlcum, 0, 1);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(857, 3);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(448, 625);
            this.tableLayoutPanel6.TabIndex = 4;
            // 
            // pictureSag
            // 
            this.pictureSag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureSag.Location = new System.Drawing.Point(3, 3);
            this.pictureSag.Name = "pictureSag";
            this.pictureSag.Size = new System.Drawing.Size(442, 579);
            this.pictureSag.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureSag.TabIndex = 1;
            this.pictureSag.TabStop = false;
            // 
            // lblSagOlcum
            // 
            this.lblSagOlcum.AutoSize = true;
            this.lblSagOlcum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSagOlcum.Font = new System.Drawing.Font("Calibri", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSagOlcum.Location = new System.Drawing.Point(3, 585);
            this.lblSagOlcum.Name = "lblSagOlcum";
            this.lblSagOlcum.Size = new System.Drawing.Size(442, 40);
            this.lblSagOlcum.TabIndex = 1;
            this.lblSagOlcum.Text = "00.0 Mohm";
            this.lblSagOlcum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSagOlcum.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Yellow;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Calibri", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(1308, 75);
            this.label6.TabIndex = 2;
            this.label6.Text = "ESD ÖLÇÜM İSTASYONU";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mifarePort
            // 
            this.mifarePort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.mifarePort_DataReceived);
            // 
            // esdPort
            // 
            this.esdPort.ReadTimeout = 100;
            this.esdPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.esdPort_DataReceived);
            // 
            // timerModbus
            // 
            this.timerModbus.Interval = 500;
            this.timerModbus.Tick += new System.EventHandler(this.timerModbus_Tick);
            // 
            // timerBekleme
            // 
            this.timerBekleme.Interval = 3000;
            this.timerBekleme.Tick += new System.EventHandler(this.timerBekleme_Tick);
            // 
            // timerESD
            // 
            this.timerESD.Interval = 1000;
            this.timerESD.Tick += new System.EventHandler(this.timerESD_Tick);
            // 
            // timerMifare
            // 
            this.timerMifare.Interval = 1000;
            this.timerMifare.Tick += new System.EventHandler(this.timerMifare_Tick);
            // 
            // timerAdmin
            // 
            this.timerAdmin.Interval = 500;
            this.timerAdmin.Tick += new System.EventHandler(this.timerAdmin_Tick);
            // 
            // timerTurnike
            // 
            this.timerTurnike.Interval = 2000;
            this.timerTurnike.Tick += new System.EventHandler(this.turnikeTmr_Tick);
            // 
            // mifarePort2
            // 
            this.mifarePort2.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.mifarePort2_DataReceived);
            // 
            // timerMifare2
            // 
            this.timerMifare2.Interval = 1000;
            this.timerMifare2.Tick += new System.EventHandler(this.timerMifare2_Tick);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1314, 712);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Main";
            this.Text = "ALP-EsdSis (Kimlik ve Esd Ölçümü Takip Sistemi)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Main_KeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEl)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureSol)).EndInit();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureSag)).EndInit();
            this.ResumeLayout(false);

    }

    public struct tagLASTINPUTINFO
    {
      public uint cbSize;
      public int dwTime;
    }
  }
}
