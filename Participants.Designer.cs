namespace ConferenceDB_Interface
{
    partial class Participants
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Participants));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.speakerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.acDegree = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.acStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.workplace = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.position = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.biography = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.speakerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Forname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 240);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(139, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Додати учасника";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(13, 280);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(139, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Видалити учасника";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(13, 319);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(139, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Змінити учасника";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(214, 254);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(228, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "Залучити учасника до виступу";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(214, 296);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(228, 23);
            this.button5.TabIndex = 4;
            this.button5.Text = "Видалити учасника з виступу";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.speakerID,
            this.acDegree,
            this.acStatus,
            this.workplace,
            this.position,
            this.biography,
            this.speakerName,
            this.Forname});
            this.dataGridView1.Location = new System.Drawing.Point(13, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(598, 196);
            this.dataGridView1.TabIndex = 5;
            // 
            // speakerID
            // 
            this.speakerID.HeaderText = "ID";
            this.speakerID.Name = "speakerID";
            this.speakerID.ReadOnly = true;
            // 
            // acDegree
            // 
            this.acDegree.HeaderText = "Науковий ступінь";
            this.acDegree.Name = "acDegree";
            // 
            // acStatus
            // 
            this.acStatus.HeaderText = "Вчене звання";
            this.acStatus.Name = "acStatus";
            // 
            // workplace
            // 
            this.workplace.HeaderText = "Місце праці";
            this.workplace.Name = "workplace";
            // 
            // position
            // 
            this.position.HeaderText = "Посада";
            this.position.Name = "position";
            // 
            // biography
            // 
            this.biography.HeaderText = "Біографія";
            this.biography.Name = "biography";
            // 
            // speakerName
            // 
            this.speakerName.HeaderText = "Ім\'я";
            this.speakerName.Name = "speakerName";
            // 
            // Forname
            // 
            this.Forname.HeaderText = "Прізвище";
            this.Forname.Name = "Forname";
            // 
            // Participants
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(623, 357);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Participants";
            this.Text = "Учасники ";
            this.Load += new System.EventHandler(this.Participants_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn speakerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn acDegree;
        private System.Windows.Forms.DataGridViewTextBoxColumn acStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn workplace;
        private System.Windows.Forms.DataGridViewTextBoxColumn position;
        private System.Windows.Forms.DataGridViewTextBoxColumn biography;
        private System.Windows.Forms.DataGridViewTextBoxColumn speakerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Forname;
    }
}