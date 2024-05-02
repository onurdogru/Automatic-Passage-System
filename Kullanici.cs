// Decompiled with JetBrains decompiler
// Type: EsdTurnikesi.Kullanici
// Assembly: EsdTurnikesi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C8099926-BBEB-495E-ADF6-36B4F5F75BE8
// Assembly location: C:\Users\serkan.baki\Desktop\PROJELER\2-) Gömülü Sistem Projeleri\(1707482-537)_Fabrika Girişi İçin Temassız Sıcaklık Ölçüm İstasyonu\SOFTWARE\GUI\esd-rar\ESD\Release\EsdTurnikesi.exe

using System;
using System.ComponentModel;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;

namespace EsdTurnikesi
{
  public class Kullanici : Form
  {
    public Main MainFrm;
    private IContainer components;
    private TableLayoutPanel tableLayoutPanel1;
    private Panel panel1;
    private Button button2;
    private Button button1;
    private Button btnYeni;
    private TextBox textBox4;
    private TextBox textBox3;
    private Label label4;
    private Label label3;
    private Label label2;
    private TextBox textBox1;
    private Label label1;
    public DataGridView dataGrid;
    private Button btnTemizle;
    public TextBox textBox2;

    public Kullanici()
    {
      this.InitializeComponent();
    }

    private void Kullanici_Load(object sender, EventArgs e)
    {
      this.Listele();
    }

    public void Listele()
    {
      try
      {
        this.MainFrm.dttable.Clear();
        this.MainFrm.baglan.Open();
        new OleDbDataAdapter("Select * From personel ORDER BY AdSoyad ASC", this.MainFrm.baglan).Fill(this.MainFrm.dttable);
        this.dataGrid.DataSource = (object) this.MainFrm.dttable;
        this.MainFrm.baglan.Close();
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message);
        this.MainFrm.baglan.Close();
      }
    }

    public void Temizle()
    {
      this.textBox1.Clear();
      this.textBox2.Clear();
      this.textBox3.Clear();
      this.textBox4.Clear();
    }

    public void Kaydet()
    {
      try
      {
        this.MainFrm.baglan.Open();
        this.MainFrm.komut.Connection = this.MainFrm.baglan;
        this.MainFrm.komut.CommandText = "Insert Into personel (ID, AdSoyad, Gorevi) Values ( " + this.textBox2.Text + ",'" + this.textBox3.Text + "','" + this.textBox4.Text + "')";
        this.MainFrm.komut.ExecuteNonQuery();
        this.MainFrm.baglan.Close();
        this.Listele();
        int num = (int) MessageBox.Show("Kayıt Eklendi", "Başarılı İşlem", MessageBoxButtons.OK, MessageBoxIcon.Question);
        this.Temizle();
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message);
        this.MainFrm.baglan.Close();
      }
    }

    public void Sil()
    {
      if (MessageBox.Show("Kaydı Silmek istediğinizden Eminmisiniz ?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
      {
        try
        {
          this.MainFrm.baglan.Open();
          this.MainFrm.komut.Connection = this.MainFrm.baglan;
          this.MainFrm.komut.CommandText = "Delete From personel Where ID='" + this.dataGrid.CurrentRow.Cells[0].Value + "'";
          this.MainFrm.komut.ExecuteNonQuery();
          this.MainFrm.baglan.Close();
          this.Listele();
          int num = (int) MessageBox.Show("Kayıt Silindi", "Başarılı İşlem");
          this.Temizle();
        }
        catch (Exception ex)
        {
          int num = (int) MessageBox.Show(ex.Message);
          this.MainFrm.baglan.Close();
        }
      }
      else
        this.MainFrm.baglan.Close();
    }

    public void Duzenle()
    {
      try
      {
        this.MainFrm.baglan.Open();
        this.MainFrm.komut.Connection = this.MainFrm.baglan;
        this.MainFrm.komut.CommandText = "update personel set ID='" + this.textBox2.Text + "',AdSoyad='" + this.textBox3.Text + "',Gorevi='" + this.textBox4.Text + "' where ID='" + this.dataGrid.CurrentRow.Cells[0].Value + "'";
        this.MainFrm.komut.ExecuteNonQuery();
        this.MainFrm.baglan.Close();
        this.Listele();
        int num = (int) MessageBox.Show("Kayıt Düzenlendi", "Başarılı İşlem");
        this.Temizle();
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message);
        this.MainFrm.baglan.Close();
      }
    }

    public void Arama()
    {
      try
      {
        this.MainFrm.dttable.Clear();
        this.MainFrm.baglan.Open();
        new OleDbDataAdapter("Select * From personel where ID like'" + this.textBox1.Text + "%' or AdSoyad like'" + this.textBox1.Text + "%' or Gorevi like'" + this.textBox1.Text + "%' ORDER BY AdSoyad ASC", this.MainFrm.baglan).Fill(this.MainFrm.dttable);
        this.dataGrid.DataSource = (object) this.MainFrm.dttable;
        this.MainFrm.baglan.Close();
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message);
        this.MainFrm.baglan.Close();
      }
    }

    private void btnYeni_Click(object sender, EventArgs e)
    {
      this.Kaydet();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      this.Duzenle();
    }

    private void button2_Click(object sender, EventArgs e)
    {
      this.Sil();
    }

    private void btnTemizle_Click(object sender, EventArgs e)
    {
      this.Temizle();
    }

    private void dataGridCell_Click(object sender, DataGridViewCellEventArgs e)
    {
      this.textBox2.Text = this.dataGrid.CurrentRow.Cells[0].Value.ToString();
      this.textBox3.Text = this.dataGrid.CurrentRow.Cells[1].Value.ToString();
      this.textBox4.Text = this.dataGrid.CurrentRow.Cells[2].Value.ToString();
    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {
      this.dataGrid.DataSource = (object) new BindingSource()
      {
        DataSource = this.dataGrid.DataSource,
        Filter = ("ID like '%" + this.textBox1.Text + "%' Or AdSoyad like '%" + this.textBox1.Text + "%' Or Gorevi like '%" + this.textBox1.Text + "%'")
      };
      if (this.dataGrid.Rows.Count <= 0)
        return;
      this.textBox2.Text = this.dataGrid.CurrentRow.Cells[0].Value.ToString();
      this.textBox3.Text = this.dataGrid.CurrentRow.Cells[1].Value.ToString();
      this.textBox4.Text = this.dataGrid.CurrentRow.Cells[2].Value.ToString();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.tableLayoutPanel1 = new TableLayoutPanel();
      this.dataGrid = new DataGridView();
      this.panel1 = new Panel();
      this.btnTemizle = new Button();
      this.button2 = new Button();
      this.button1 = new Button();
      this.btnYeni = new Button();
      this.textBox4 = new TextBox();
      this.textBox3 = new TextBox();
      this.textBox2 = new TextBox();
      this.label4 = new Label();
      this.label3 = new Label();
      this.label2 = new Label();
      this.textBox1 = new TextBox();
      this.label1 = new Label();
      this.tableLayoutPanel1.SuspendLayout();
      ((ISupportInitialize) this.dataGrid).BeginInit();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      this.tableLayoutPanel1.ColumnCount = 2;
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 300f));
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
      this.tableLayoutPanel1.Controls.Add((Control) this.dataGrid, 1, 0);
      this.tableLayoutPanel1.Controls.Add((Control) this.panel1, 0, 0);
      this.tableLayoutPanel1.Dock = DockStyle.Fill;
      this.tableLayoutPanel1.Location = new Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 1;
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.tableLayoutPanel1.Size = new Size(944, 526);
      this.tableLayoutPanel1.TabIndex = 0;
      this.dataGrid.AllowUserToAddRows = false;
      this.dataGrid.AllowUserToDeleteRows = false;
      this.dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
      this.dataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGrid.Dock = DockStyle.Fill;
      this.dataGrid.Location = new Point(303, 3);
      this.dataGrid.MultiSelect = false;
      this.dataGrid.Name = "dataGrid";
      this.dataGrid.ReadOnly = true;
      this.dataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dataGrid.Size = new Size(638, 520);
      this.dataGrid.TabIndex = 1;
      this.dataGrid.CellClick += new DataGridViewCellEventHandler(this.dataGridCell_Click);
      this.panel1.Controls.Add((Control) this.btnTemizle);
      this.panel1.Controls.Add((Control) this.button2);
      this.panel1.Controls.Add((Control) this.button1);
      this.panel1.Controls.Add((Control) this.btnYeni);
      this.panel1.Controls.Add((Control) this.textBox4);
      this.panel1.Controls.Add((Control) this.textBox3);
      this.panel1.Controls.Add((Control) this.textBox2);
      this.panel1.Controls.Add((Control) this.label4);
      this.panel1.Controls.Add((Control) this.label3);
      this.panel1.Controls.Add((Control) this.label2);
      this.panel1.Controls.Add((Control) this.textBox1);
      this.panel1.Controls.Add((Control) this.label1);
      this.panel1.Dock = DockStyle.Fill;
      this.panel1.Location = new Point(3, 3);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(294, 520);
      this.panel1.TabIndex = 0;
      this.btnTemizle.Location = new Point(149, 241);
      this.btnTemizle.Name = "btnTemizle";
      this.btnTemizle.Size = new Size(110, 50);
      this.btnTemizle.TabIndex = 8;
      this.btnTemizle.Text = "&Temizle";
      this.btnTemizle.UseVisualStyleBackColor = true;
      this.btnTemizle.Click += new EventHandler(this.btnTemizle_Click);
      this.button2.Location = new Point(33, 241);
      this.button2.Name = "button2";
      this.button2.Size = new Size(110, 50);
      this.button2.TabIndex = 7;
      this.button2.Text = "Seçili Kullanıcı &Sil";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new EventHandler(this.button2_Click);
      this.button1.Location = new Point(149, 185);
      this.button1.Name = "button1";
      this.button1.Size = new Size(110, 50);
      this.button1.TabIndex = 6;
      this.button1.Text = "Seçili Kullanıcı &Güncelle";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new EventHandler(this.button1_Click);
      this.btnYeni.Location = new Point(33, 185);
      this.btnYeni.Name = "btnYeni";
      this.btnYeni.Size = new Size(110, 50);
      this.btnYeni.TabIndex = 5;
      this.btnYeni.Text = "Yeni Kullanıcı &Ekle";
      this.btnYeni.UseVisualStyleBackColor = true;
      this.btnYeni.Click += new EventHandler(this.btnYeni_Click);
      this.textBox4.Location = new Point(87, 143);
      this.textBox4.Name = "textBox4";
      this.textBox4.Size = new Size(192, 27);
      this.textBox4.TabIndex = 4;
      this.textBox3.Location = new Point(87, 110);
      this.textBox3.Name = "textBox3";
      this.textBox3.Size = new Size(192, 27);
      this.textBox3.TabIndex = 3;
      this.textBox2.Location = new Point(87, 77);
      this.textBox2.Name = "textBox2";
      this.textBox2.Size = new Size(192, 27);
      this.textBox2.TabIndex = 2;
      this.label4.AutoSize = true;
      this.label4.Location = new Point(9, 146);
      this.label4.Name = "label4";
      this.label4.Size = new Size(55, 19);
      this.label4.TabIndex = 2;
      this.label4.Text = "Görevi:";
      this.label3.AutoSize = true;
      this.label3.Location = new Point(9, 113);
      this.label3.Name = "label3";
      this.label3.Size = new Size(80, 19);
      this.label3.TabIndex = 2;
      this.label3.Text = "Adı Soyadı:";
      this.label2.AutoSize = true;
      this.label2.Location = new Point(9, 80);
      this.label2.Name = "label2";
      this.label2.Size = new Size(27, 19);
      this.label2.TabIndex = 2;
      this.label2.Text = "ID:";
      this.textBox1.Location = new Point(129, 6);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new Size(150, 27);
      this.textBox1.TabIndex = 1;
      this.textBox1.TextChanged += new EventHandler(this.textBox1_TextChanged);
      this.label1.AutoSize = true;
      this.label1.Location = new Point(9, 9);
      this.label1.Name = "label1";
      this.label1.Size = new Size(114, 19);
      this.label1.TabIndex = 0;
      this.label1.Text = "Kullanıcı Arama:";
      this.AutoScaleDimensions = new SizeF(8f, 19f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(944, 526);
      this.Controls.Add((Control) this.tableLayoutPanel1);
      this.Font = new Font("Calibri", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 162);
      this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
      this.Margin = new Padding(4);
      this.Name = " ";
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Kullanıcı İşlemleri";
      this.Load += new EventHandler(this.Kullanici_Load);
      this.tableLayoutPanel1.ResumeLayout(false);
      ((ISupportInitialize) this.dataGrid).EndInit();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
