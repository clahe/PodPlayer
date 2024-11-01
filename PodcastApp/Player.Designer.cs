using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using System.Xml.Linq;

namespace PodcastApp
{
    partial class Player
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            listView1 = new ListView();
            NamnHeader1 = new ColumnHeader();
            KategoriHeader1 = new ColumnHeader();
            FrekvensHeader1 = new ColumnHeader();
            avsnittHeader1 = new ColumnHeader();
            label1 = new Label();
            textBoxUrl = new TextBox();
            buttonLaggTillUrl = new Button();
            buttonRensaUrlBox = new Button();
            listBoxListaOverAvsnitt = new ListBox();
            textBoxBeskrivning = new TextBox();
            textBoxKategroiRuta = new TextBox();
            label2 = new Label();
            buttonLaggTillKategori = new Button();
            buttonTaBortKategori = new Button();
            comboBoxFilterKategori = new ComboBox();
            label3 = new Label();
            listBoxListaAvKategori = new ListBox();
            textBoxNamnRuta = new TextBox();
            label4 = new Label();
            buttonLaggTillNamn = new Button();
            buttonAndraNamn = new Button();
            buttonAndraKategori = new Button();
            comboBoxFilterFrekvens = new ComboBox();
            label5 = new Label();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { NamnHeader1, KategoriHeader1, FrekvensHeader1, avsnittHeader1 });
            listView1.Location = new Point(51, 180);
            listView1.Name = "listView1";
            listView1.Size = new Size(414, 523);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // NamnHeader1
            // 
            NamnHeader1.Text = "Titel";
            NamnHeader1.Width = 105;
            // 
            // KategoriHeader1
            // 
            KategoriHeader1.Text = "Kategori";
            KategoriHeader1.Width = 100;
            // 
            // FrekvensHeader1
            // 
            FrekvensHeader1.Text = "Frekvens";
            FrekvensHeader1.Width = 100;
            // 
            // avsnittHeader1
            // 
            avsnittHeader1.Text = "Antal avsnitt";
            avsnittHeader1.Width = 105;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 46);
            label1.Name = "label1";
            label1.Size = new Size(38, 20);
            label1.TabIndex = 1;
            label1.Text = "URL:";
            label1.Click += label1_Click;
            // 
            // textBoxUrl
            // 
            textBoxUrl.Location = new Point(60, 39);
            textBoxUrl.Name = "textBoxUrl";
            textBoxUrl.Size = new Size(264, 27);
            textBoxUrl.TabIndex = 2;
            textBoxUrl.TextChanged += textBox1_TextChanged;
            // 
            // buttonLaggTillUrl
            // 
            buttonLaggTillUrl.Location = new Point(80, 72);
            buttonLaggTillUrl.Name = "buttonLaggTillUrl";
            buttonLaggTillUrl.Size = new Size(94, 29);
            buttonLaggTillUrl.TabIndex = 3;
            buttonLaggTillUrl.Text = "Lägg till";
            buttonLaggTillUrl.UseVisualStyleBackColor = true;
            buttonLaggTillUrl.Click += button1_ClickAsync;
            // 
            // buttonRensaUrlBox
            // 
            buttonRensaUrlBox.Location = new Point(180, 72);
            buttonRensaUrlBox.Name = "buttonRensaUrlBox";
            buttonRensaUrlBox.Size = new Size(94, 29);
            buttonRensaUrlBox.TabIndex = 4;
            buttonRensaUrlBox.Text = "Rensa";
            buttonRensaUrlBox.UseVisualStyleBackColor = true;
            buttonRensaUrlBox.Click += button2_Click;
            // 
            // listBoxListaOverAvsnitt
            // 
            listBoxListaOverAvsnitt.FormattingEnabled = true;
            listBoxListaOverAvsnitt.Location = new Point(471, 180);
            listBoxListaOverAvsnitt.Name = "listBoxListaOverAvsnitt";
            listBoxListaOverAvsnitt.Size = new Size(504, 524);
            listBoxListaOverAvsnitt.TabIndex = 5;
            listBoxListaOverAvsnitt.SelectedIndexChanged += listBox2_SelectedIndexChanged;
            // 
            // textBoxBeskrivning
            // 
            textBoxBeskrivning.Location = new Point(981, 180);
            textBoxBeskrivning.Multiline = true;
            textBoxBeskrivning.Name = "textBoxBeskrivning";
            textBoxBeskrivning.Size = new Size(452, 381);
            textBoxBeskrivning.TabIndex = 6;
            textBoxBeskrivning.TextChanged += textBox2_TextChanged;
            // 
            // textBoxKategroiRuta
            // 
            textBoxKategroiRuta.Location = new Point(724, 39);
            textBoxKategroiRuta.Name = "textBoxKategroiRuta";
            textBoxKategroiRuta.Size = new Size(194, 27);
            textBoxKategroiRuta.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(652, 46);
            label2.Name = "label2";
            label2.Size = new Size(66, 20);
            label2.TabIndex = 8;
            label2.Text = "Kategori";
            // 
            // buttonLaggTillKategori
            // 
            buttonLaggTillKategori.Location = new Point(724, 72);
            buttonLaggTillKategori.Name = "buttonLaggTillKategori";
            buttonLaggTillKategori.Size = new Size(94, 29);
            buttonLaggTillKategori.TabIndex = 9;
            buttonLaggTillKategori.Text = "Lägg till";
            buttonLaggTillKategori.UseVisualStyleBackColor = true;
            buttonLaggTillKategori.Click += button3_Click;
            // 
            // buttonTaBortKategori
            // 
            buttonTaBortKategori.Location = new Point(779, 107);
            buttonTaBortKategori.Name = "buttonTaBortKategori";
            buttonTaBortKategori.Size = new Size(94, 29);
            buttonTaBortKategori.TabIndex = 10;
            buttonTaBortKategori.Text = "Ta bort";
            buttonTaBortKategori.UseVisualStyleBackColor = true;
            buttonTaBortKategori.Click += button4_Click;
            // 
            // comboBoxFilterKategori
            // 
            comboBoxFilterKategori.FormattingEnabled = true;
            comboBoxFilterKategori.Location = new Point(88, 137);
            comboBoxFilterKategori.Name = "comboBoxFilterKategori";
            comboBoxFilterKategori.Size = new Size(151, 28);
            comboBoxFilterKategori.TabIndex = 11;
            comboBoxFilterKategori.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(16, 145);
            label3.Name = "label3";
            label3.Size = new Size(66, 20);
            label3.TabIndex = 12;
            label3.Text = "Kategori";
            // 
            // listBoxListaAvKategori
            // 
            listBoxListaAvKategori.FormattingEnabled = true;
            listBoxListaAvKategori.Location = new Point(924, 41);
            listBoxListaAvKategori.Name = "listBoxListaAvKategori";
            listBoxListaAvKategori.Size = new Size(196, 124);
            listBoxListaAvKategori.TabIndex = 13;
            listBoxListaAvKategori.SelectedIndexChanged += listBox2_SelectedIndexChanged;
            // 
            // textBoxNamnRuta
            // 
            textBoxNamnRuta.Location = new Point(421, 39);
            textBoxNamnRuta.Name = "textBoxNamnRuta";
            textBoxNamnRuta.Size = new Size(191, 27);
            textBoxNamnRuta.TabIndex = 14;
            textBoxNamnRuta.TextChanged += textBox4_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(366, 46);
            label4.Name = "label4";
            label4.Size = new Size(49, 20);
            label4.TabIndex = 15;
            label4.Text = "Namn";
            // 
            // buttonLaggTillNamn
            // 
            buttonLaggTillNamn.Location = new Point(421, 72);
            buttonLaggTillNamn.Name = "buttonLaggTillNamn";
            buttonLaggTillNamn.Size = new Size(94, 29);
            buttonLaggTillNamn.TabIndex = 16;
            buttonLaggTillNamn.Text = "Lägg till";
            buttonLaggTillNamn.UseVisualStyleBackColor = true;
            buttonLaggTillNamn.Click += button5_Click;
            // 
            // buttonAndraNamn
            // 
            buttonAndraNamn.Location = new Point(518, 72);
            buttonAndraNamn.Name = "buttonAndraNamn";
            buttonAndraNamn.Size = new Size(94, 29);
            buttonAndraNamn.TabIndex = 17;
            buttonAndraNamn.Text = "Ändra";
            buttonAndraNamn.UseVisualStyleBackColor = true;
            buttonAndraNamn.Click += button6_Click;
            // 
            // buttonAndraKategori
            // 
            buttonAndraKategori.Location = new Point(824, 72);
            buttonAndraKategori.Name = "buttonAndraKategori";
            buttonAndraKategori.Size = new Size(94, 29);
            buttonAndraKategori.TabIndex = 18;
            buttonAndraKategori.Text = "Ändra";
            buttonAndraKategori.UseVisualStyleBackColor = true;
            buttonAndraKategori.Click += button7_Click;
            // 
            // comboBoxFilterFrekvens
            // 
            comboBoxFilterFrekvens.FormattingEnabled = true;
            comboBoxFilterFrekvens.Location = new Point(264, 137);
            comboBoxFilterFrekvens.Name = "comboBoxFilterFrekvens";
            comboBoxFilterFrekvens.Size = new Size(151, 28);
            comboBoxFilterFrekvens.TabIndex = 19;
            comboBoxFilterFrekvens.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(421, 145);
            label5.Name = "label5";
            label5.Size = new Size(65, 20);
            label5.TabIndex = 20;
            label5.Text = "Frekvens";
            // 
            // PodcastApp
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1514, 936);
            Controls.Add(label5);
            Controls.Add(comboBoxFilterFrekvens);
            Controls.Add(buttonAndraKategori);
            Controls.Add(buttonAndraNamn);
            Controls.Add(buttonLaggTillNamn);
            Controls.Add(label4);
            Controls.Add(textBoxNamnRuta);
            Controls.Add(listBoxListaAvKategori);
            Controls.Add(label3);
            Controls.Add(comboBoxFilterKategori);
            Controls.Add(buttonTaBortKategori);
            Controls.Add(buttonLaggTillKategori);
            Controls.Add(label2);
            Controls.Add(textBoxKategroiRuta);
            Controls.Add(textBoxBeskrivning);
            Controls.Add(listBoxListaOverAvsnitt);
            Controls.Add(buttonRensaUrlBox);
            Controls.Add(buttonLaggTillUrl);
            Controls.Add(textBoxUrl);
            Controls.Add(label1);
            Controls.Add(listView1);
            Name = "PodcastApp";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PodcastApp";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView listView1;
        private Label label1;
        private TextBox textBoxUrl;
        private Button buttonLaggTillUrl;
        private Button buttonRensaUrlBox;
        private ListBox listBoxListaOverAvsnitt;
        private TextBox textBoxBeskrivning;
        private TextBox textBoxKategroiRuta;
        private Label label2;
        private Button buttonLaggTillKategori;
        private Button buttonTaBortKategori;
        private ComboBox comboBoxFilterKategori;
        private Label label3;
        private ListBox listBoxListaAvKategori;
        private TextBox textBoxNamnRuta;
        private Label label4;
        private Button buttonLaggTillNamn;
        private Button buttonAndraNamn;
        private Button buttonAndraKategori;
        private ColumnHeader NamnHeader1;
        private ColumnHeader KategoriHeader1;
        private ColumnHeader FrekvensHeader1;
        private ComboBox comboBoxFilterFrekvens;
        private Label label5;
        private ColumnHeader avsnittHeader1;
    }
}
