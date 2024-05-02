// Decompiled with JetBrains decompiler
// Type: EsdTurnikesi.GirisKayit
// Assembly: EsdTurnikesi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C8099926-BBEB-495E-ADF6-36B4F5F75BE8
// Assembly location: C:\Users\serkan.baki\Desktop\PROJELER\2-) Gömülü Sistem Projeleri\(1707482-537)_Fabrika Girişi İçin Temassız Sıcaklık Ölçüm İstasyonu\SOFTWARE\GUI\esd-rar\ESD\Release\EsdTurnikesi.exe

using System;
using System.ComponentModel;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace EsdTurnikesi
{
  public class GirisKayit : Form
  {
    public Main MainFrm;
    private IContainer components;
    private TableLayoutPanel tableLayoutPanel1;
    private Panel panel1;
    private Label label1;
    private TextBox textBox1;
    public DataGridView dataGrid;
    private GroupBox groupBox1;
    private Label label3;
    private Label label2;
    private DateTimePicker dateTimePicker2;
    private DateTimePicker dateTimePicker1;
    private GroupBox groupBox3;
    private Button button2;
    private Button button1;
    private GroupBox groupBox2;
    private CheckBox checkBox2;
    private CheckBox checkBox1;
    private Label label4;
    private Button button3;

    public GirisKayit()
    {
      this.InitializeComponent();
    }

    private void GirisKayit_Load(object sender, EventArgs e)
    {
    }

    public void Listele()
    {
      try
      {
        this.MainFrm.dttable2.Clear();
        this.MainFrm.baglan2.Open();
        new OleDbDataAdapter("Select * From liste", this.MainFrm.baglan2).Fill(this.MainFrm.dttable2);
        this.dataGrid.DataSource = (object) this.MainFrm.dttable2;
        this.MainFrm.baglan2.Close();
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message);
        this.MainFrm.baglan2.Close();
      }
    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {
      this.dataGrid.DataSource = (object) new BindingSource()
      {
        DataSource = this.dataGrid.DataSource,
        Filter = ("ID like '%" + this.textBox1.Text + "%' Or AdSoyad like '%" + this.textBox1.Text + "%' Or Gorevi like '%" + this.textBox1.Text + "%' Or EsdSonuc like '%" + this.textBox1.Text + "%'")
      };
      this.dataGrid.Columns[4].DefaultCellStyle.Format = "dd.MM.yyyy";
      this.dataGrid.Columns[5].DefaultCellStyle.Format = "hh:mm:ss";
    }

    private void button2_Click(object sender, EventArgs e)
    {
      if (this.checkBox1.Checked)
      {
        try
        {
          this.MainFrm.dttable2.Clear();
          this.MainFrm.baglan2.Open();
          OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter("SELECT * FROM liste WHERE Tarih >= @Tarih1 AND Tarih <= @Tarih2", this.MainFrm.baglan2);
          oleDbDataAdapter.SelectCommand.Parameters.AddWithValue("@Tarih1", (object) this.dateTimePicker1.Value.Date);
          oleDbDataAdapter.SelectCommand.Parameters.AddWithValue("@Tarih2", (object) this.dateTimePicker2.Value.Date);
          oleDbDataAdapter.Fill(this.MainFrm.dttable2);
          this.dataGrid.DataSource = (object) this.MainFrm.dttable2;
          this.dataGrid.Columns[4].DefaultCellStyle.Format = "dd.MM.yyyy";
          this.dataGrid.Columns[5].DefaultCellStyle.Format = "hh:mm:ss";
          this.MainFrm.baglan2.Close();
        }
        catch (Exception ex)
        {
          int num = (int) MessageBox.Show(ex.Message);
          this.MainFrm.baglan2.Close();
        }
      }
      else
        this.Listele();
    }

    private void checkBox2_CheckedChanged(object sender, EventArgs e)
    {
      if (this.checkBox2.Checked)
        this.textBox1.Enabled = true;
      else
        this.textBox1.Enabled = false;
    }

    private void ToCsV(DataGridView dGV, string filename)
    {
      try
      {
        string str1 = "";
        string str2 = "";
        for (int index = 0; index < dGV.Columns.Count; ++index)
          str2 = str2.ToString() + Convert.ToString(dGV.Columns[index].HeaderText) + "\t";
        string s = str1 + str2 + "\r\n";
        for (int index1 = 0; index1 < dGV.RowCount - 1; ++index1)
        {
          string str3 = "";
          for (int index2 = 0; index2 < dGV.Rows[index1].Cells.Count; ++index2)
          {
            switch (index2)
            {
              case 4:
                string str4 = dGV.Rows[index1].Cells[index2].Value.ToString();
                str3 = str3.ToString() + str4.Substring(0, 10) + "\t";
                break;
              case 5:
                string str5 = dGV.Rows[index1].Cells[index2].Value.ToString();
                str3 = str3.ToString() + str5.Substring(11) + "\t";
                break;
              default:
                str3 = str3.ToString() + Convert.ToString(dGV.Rows[index1].Cells[index2].Value) + "\t";
                break;
            }
          }
          s = s + str3 + "\r\n";
        }
        byte[] bytes = Encoding.GetEncoding(1254).GetBytes(s);
        FileStream fileStream = new FileStream(filename, FileMode.Create);
        BinaryWriter binaryWriter = new BinaryWriter((Stream) fileStream);
        binaryWriter.Write(bytes, 0, bytes.Length);
        binaryWriter.Flush();
        binaryWriter.Close();
        fileStream.Close();
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("Kaydetme hatası: " + ex.ToString());
      }
    }

    private void button1_Click(object sender, EventArgs e)
    {
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      saveFileDialog.Filter = "Excel Documents (*.xls)|*.xls";
      saveFileDialog.FileName = "ESD Kayıtları " + DateTime.Now.ToShortDateString() + ".xls";
      if (saveFileDialog.ShowDialog() != DialogResult.OK)
        return;
      this.ToCsV(this.dataGrid, saveFileDialog.FileName);
    }

    private void button3_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show("Tüm kayıtları silmek istediğinizden emin misiniz ?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
      {
        try
        {
          this.MainFrm.baglan2.Open();
          this.MainFrm.komut2.Connection = this.MainFrm.baglan2;
          this.MainFrm.komut2.CommandText = "Delete * From liste";
          this.MainFrm.komut2.ExecuteNonQuery();
          this.MainFrm.baglan2.Close();
          this.Listele();
          int num = (int) MessageBox.Show("Tüm Kayıtlar Silindi");
        }
        catch (Exception ex)
        {
          int num = (int) MessageBox.Show(ex.Message);
          this.MainFrm.baglan2.Close();
        }
      }
      else
        this.MainFrm.baglan2.Close();
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
      this.panel1 = new Panel();
      this.groupBox3 = new GroupBox();
      this.button2 = new Button();
      this.button1 = new Button();
      this.groupBox2 = new GroupBox();
      this.label4 = new Label();
      this.label1 = new Label();
      this.textBox1 = new TextBox();
      this.checkBox2 = new CheckBox();
      this.groupBox1 = new GroupBox();
      this.checkBox1 = new CheckBox();
      this.label3 = new Label();
      this.label2 = new Label();
      this.dateTimePicker2 = new DateTimePicker();
      this.dateTimePicker1 = new DateTimePicker();
      this.dataGrid = new DataGridView();
      this.button3 = new Button();
      this.tableLayoutPanel1.SuspendLayout();
      this.panel1.SuspendLayout();
      this.groupBox3.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.groupBox1.SuspendLayout();
      ((ISupportInitialize) this.dataGrid).BeginInit();
      this.SuspendLayout();
      this.tableLayoutPanel1.ColumnCount = 1;
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
      this.tableLayoutPanel1.Controls.Add((Control) this.panel1, 0, 0);
      this.tableLayoutPanel1.Controls.Add((Control) this.dataGrid, 0, 1);
      this.tableLayoutPanel1.Dock = DockStyle.Fill;
      this.tableLayoutPanel1.Location = new Point(0, 0);
      this.tableLayoutPanel1.Margin = new Padding(5, 4, 5, 4);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 2;
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 120f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
      this.tableLayoutPanel1.Size = new Size(984, 631);
      this.tableLayoutPanel1.TabIndex = 0;
      this.panel1.BorderStyle = BorderStyle.FixedSingle;
      this.panel1.Controls.Add((Control) this.groupBox3);
      this.panel1.Controls.Add((Control) this.groupBox2);
      this.panel1.Controls.Add((Control) this.groupBox1);
      this.panel1.Dock = DockStyle.Fill;
      this.panel1.Location = new Point(5, 4);
      this.panel1.Margin = new Padding(5, 4, 5, 4);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(974, 112);
      this.panel1.TabIndex = 0;
      this.groupBox3.Controls.Add((Control) this.button3);
      this.groupBox3.Controls.Add((Control) this.button2);
      this.groupBox3.Controls.Add((Control) this.button1);
      this.groupBox3.Location = new Point(467, 7);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new Size(234, 100);
      this.groupBox3.TabIndex = 5;
      this.groupBox3.TabStop = false;
      this.groupBox3.Text = "Raporlama:";
      this.button2.Location = new Point(15, 59);
      this.button2.Name = "button2";
      this.button2.Size = new Size(100, 30);
      this.button2.TabIndex = 0;
      this.button2.Text = "Listele";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new EventHandler(this.button2_Click);
      this.button1.Location = new Point(15, 23);
      this.button1.Name = "button1";
      this.button1.Size = new Size(100, 30);
      this.button1.TabIndex = 0;
      this.button1.Text = "Excel'e Aktar";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new EventHandler(this.button1_Click);
      this.groupBox2.Controls.Add((Control) this.label4);
      this.groupBox2.Controls.Add((Control) this.label1);
      this.groupBox2.Controls.Add((Control) this.textBox1);
      this.groupBox2.Controls.Add((Control) this.checkBox2);
      this.groupBox2.Location = new Point(261, 7);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new Size(200, 100);
      this.groupBox2.TabIndex = 4;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Özel Arama:";
      this.label4.AutoSize = true;
      this.label4.Font = new Font("Arial", 8f);
      this.label4.ForeColor = Color.Gray;
      this.label4.Location = new Point(5, 67);
      this.label4.Name = "label4";
      this.label4.Size = new Size(179, 28);
      this.label4.TabIndex = 3;
      this.label4.Text = "Sadece ID, AdSoyad, Gorevi ve\r\nEsdSonuc alanlarında arama yapar)";
      this.label1.AutoSize = true;
      this.label1.Location = new Point(8, 44);
      this.label1.Name = "label1";
      this.label1.Size = new Size(52, 18);
      this.label1.TabIndex = 1;
      this.label1.Text = "Arama:";
      this.textBox1.Enabled = false;
      this.textBox1.Location = new Point(66, 41);
      this.textBox1.Margin = new Padding(3, 2, 3, 2);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new Size(128, 25);
      this.textBox1.TabIndex = 1;
      this.textBox1.TextChanged += new EventHandler(this.textBox1_TextChanged);
      this.checkBox2.AutoSize = true;
      this.checkBox2.Location = new Point(11, 21);
      this.checkBox2.Name = "checkBox2";
      this.checkBox2.Size = new Size(130, 22);
      this.checkBox2.TabIndex = 2;
      this.checkBox2.Text = "Özel Arama Aktif";
      this.checkBox2.UseVisualStyleBackColor = true;
      this.checkBox2.CheckedChanged += new EventHandler(this.checkBox2_CheckedChanged);
      this.groupBox1.Controls.Add((Control) this.checkBox1);
      this.groupBox1.Controls.Add((Control) this.label3);
      this.groupBox1.Controls.Add((Control) this.label2);
      this.groupBox1.Controls.Add((Control) this.dateTimePicker2);
      this.groupBox1.Controls.Add((Control) this.dateTimePicker1);
      this.groupBox1.Location = new Point(6, 7);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(249, 100);
      this.groupBox1.TabIndex = 3;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Tarihe Göre Filtrele:";
      this.checkBox1.AutoSize = true;
      this.checkBox1.CheckAlign = ContentAlignment.TopCenter;
      this.checkBox1.Checked = true;
      this.checkBox1.CheckState = CheckState.Checked;
      this.checkBox1.Location = new Point(199, 24);
      this.checkBox1.Name = "checkBox1";
      this.checkBox1.Size = new Size(45, 54);
      this.checkBox1.TabIndex = 3;
      this.checkBox1.Text = "Filtre\r\nAktif";
      this.checkBox1.UseVisualStyleBackColor = true;
      this.label3.AutoSize = true;
      this.label3.Location = new Point(9, 60);
      this.label3.Name = "label3";
      this.label3.Size = new Size(68, 18);
      this.label3.TabIndex = 1;
      this.label3.Text = "Son Tarih:";
      this.label2.AutoSize = true;
      this.label2.Location = new Point(9, 29);
      this.label2.Name = "label2";
      this.label2.Size = new Size(60, 18);
      this.label2.TabIndex = 1;
      this.label2.Text = "İlk Tarih:";
      this.dateTimePicker2.CustomFormat = "dd.MM.yyyy";
      this.dateTimePicker2.Format = DateTimePickerFormat.Custom;
      this.dateTimePicker2.Location = new Point(83, 55);
      this.dateTimePicker2.Name = "dateTimePicker2";
      this.dateTimePicker2.Size = new Size(110, 25);
      this.dateTimePicker2.TabIndex = 2;
      this.dateTimePicker1.CustomFormat = "dd.MM.yyyy";
      this.dateTimePicker1.Format = DateTimePickerFormat.Custom;
      this.dateTimePicker1.Location = new Point(83, 24);
      this.dateTimePicker1.Name = "dateTimePicker1";
      this.dateTimePicker1.Size = new Size(110, 25);
      this.dateTimePicker1.TabIndex = 2;
      this.dateTimePicker1.Value = new DateTime(2015, 6, 30, 13, 55, 30, 0);
      this.dataGrid.AllowUserToAddRows = false;
      this.dataGrid.AllowUserToDeleteRows = false;
      this.dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
      this.dataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGrid.Dock = DockStyle.Fill;
      this.dataGrid.Location = new Point(5, 124);
      this.dataGrid.Margin = new Padding(5, 4, 5, 4);
      this.dataGrid.MultiSelect = false;
      this.dataGrid.Name = "dataGrid";
      this.dataGrid.ReadOnly = true;
      this.dataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dataGrid.Size = new Size(974, 503);
      this.dataGrid.TabIndex = 2;
      this.button3.Location = new Point(121, 23);
      this.button3.Name = "button3";
      this.button3.Size = new Size(100, 30);
      this.button3.TabIndex = 0;
      this.button3.Text = "Kayıtları Sil";
      this.button3.UseVisualStyleBackColor = true;
      this.button3.Click += new EventHandler(this.button3_Click);
      this.AutoScaleDimensions = new SizeF(8f, 18f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(984, 631);
      this.Controls.Add((Control) this.tableLayoutPanel1);
      this.Font = new Font("Calibri", 11f);
      this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
      this.Margin = new Padding(5, 4, 5, 4);
      this.Name = " ";
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Giriş Kayıtları";
      this.Load += new EventHandler(this.GirisKayit_Load);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.panel1.ResumeLayout(false);
      this.groupBox3.ResumeLayout(false);
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      ((ISupportInitialize) this.dataGrid).EndInit();
      this.ResumeLayout(false);
    }
  }
}
