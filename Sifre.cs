// Decompiled with JetBrains decompiler
// Type: EsdTurnikesi.Sifre
// Assembly: EsdTurnikesi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C8099926-BBEB-495E-ADF6-36B4F5F75BE8
// Assembly location: C:\Users\serkan.baki\Desktop\PROJELER\2-) Gömülü Sistem Projeleri\(1707482-537)_Fabrika Girişi İçin Temassız Sıcaklık Ölçüm İstasyonu\SOFTWARE\GUI\esd-rar\ESD\Release\EsdTurnikesi.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace EsdTurnikesi
{
  public class Sifre : Form
  {
    public Main MainFrm;
    private IContainer components;
    private Button btnGiris;
    private TextBox txtSifre;
    private Label label2;
    private Label label1;
    private Button button1;

    public Sifre()
    {
      this.InitializeComponent();
    }

    private void Sifre_Load(object sender, EventArgs e)
    {
    }

    private void btnGiris_Click(object sender, EventArgs e)
    {
      if (this.txtSifre.Text == Ayarlar.Default.adminSifre)
      {
        this.MainFrm.yetki = 1;
        this.MainFrm.yetkidegistir();
        this.txtSifre.Clear();
        this.Close();
      }
      else if (this.txtSifre.Text == Ayarlar.Default.kaliteSifre)
      {
        this.MainFrm.yetki = 2;
        this.MainFrm.yetkidegistir();
        this.txtSifre.Clear();
        this.Close();
      }
      else
      {
        int num = (int) MessageBox.Show("Hatalı Giriş!");
        this.txtSifre.Clear();
      }
    }

    private void txtSifre_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyData != Keys.Return)
        return;
      this.btnGiris_Click(sender, (EventArgs) e);
    }

    private void sifre_FormClosing(object sender, FormClosingEventArgs e)
    {
      this.txtSifre.Text = "";
    }

    private void button1_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.btnGiris = new Button();
      this.txtSifre = new TextBox();
      this.label2 = new Label();
      this.label1 = new Label();
      this.button1 = new Button();
      this.SuspendLayout();
      this.btnGiris.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular, GraphicsUnit.Point, (byte) 162);
      this.btnGiris.Location = new Point(33, 61);
      this.btnGiris.Name = "btnGiris";
      this.btnGiris.Size = new Size(75, 28);
      this.btnGiris.TabIndex = 6;
      this.btnGiris.Text = "Giriş";
      this.btnGiris.UseVisualStyleBackColor = true;
      this.btnGiris.Click += new EventHandler(this.btnGiris_Click);
      this.txtSifre.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular, GraphicsUnit.Point, (byte) 162);
      this.txtSifre.Location = new Point(65, 32);
      this.txtSifre.Name = "txtSifre";
      this.txtSifre.PasswordChar = '*';
      this.txtSifre.Size = new Size(141, 23);
      this.txtSifre.TabIndex = 5;
      this.txtSifre.KeyDown += new KeyEventHandler(this.txtSifre_KeyDown);
      this.label2.AutoSize = true;
      this.label2.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular, GraphicsUnit.Point, (byte) 162);
      this.label2.Location = new Point(14, 35);
      this.label2.Name = "label2";
      this.label2.Size = new Size(45, 17);
      this.label2.TabIndex = 4;
      this.label2.Text = "Şifre :";
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular, GraphicsUnit.Point, (byte) 162);
      this.label1.ForeColor = Color.Red;
      this.label1.Location = new Point(35, 8);
      this.label1.Name = "label1";
      this.label1.Size = new Size(149, 17);
      this.label1.TabIndex = 4;
      this.label1.Text = "Yetkilendirme Gerekli !";
      this.button1.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular, GraphicsUnit.Point, (byte) 162);
      this.button1.Location = new Point(114, 61);
      this.button1.Name = "button1";
      this.button1.Size = new Size(75, 28);
      this.button1.TabIndex = 6;
      this.button1.Text = "Kapat";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new EventHandler(this.button1_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.DarkTurquoise;
      this.ClientSize = new Size(221, 97);
      this.Controls.Add((Control) this.button1);
      this.Controls.Add((Control) this.btnGiris);
      this.Controls.Add((Control) this.txtSifre);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.label2);
      this.FormBorderStyle = FormBorderStyle.None;
      this.KeyPreview = true;
      this.Name = " ";
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = nameof (Sifre);
      this.Load += new EventHandler(this.Sifre_Load);
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
