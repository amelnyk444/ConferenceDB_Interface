namespace ConferenceDB_Interface
{
    partial class speakersList
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
            this.dataGridView1.Location = new System.Drawing.Point(12, 40);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(631, 196);
            this.dataGridView1.TabIndex = 6;
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
            this.acDegree.ReadOnly = true;
            // 
            // acStatus
            // 
            this.acStatus.HeaderText = "Вчене звання";
            this.acStatus.Name = "acStatus";
            this.acStatus.ReadOnly = true;
            // 
            // workplace
            // 
            this.workplace.HeaderText = "Місце праці";
            this.workplace.Name = "workplace";
            this.workplace.ReadOnly = true;
            // 
            // position
            // 
            this.position.HeaderText = "Посада";
            this.position.Name = "position";
            this.position.ReadOnly = true;
            // 
            // biography
            // 
            this.biography.HeaderText = "Біографія";
            this.biography.Name = "biography";
            this.biography.ReadOnly = true;
            // 
            // speakerName
            // 
            this.speakerName.HeaderText = "Ім\'я";
            this.speakerName.Name = "speakerName";
            this.speakerName.ReadOnly = true;
            // 
            // Forname
            // 
            this.Forname.HeaderText = "Прізвище";
            this.Forname.Name = "Forname";
            this.Forname.ReadOnly = true;
            // 
            // speakersList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 285);
            this.Controls.Add(this.dataGridView1);
            this.Name = "speakersList";
            this.Text = "Список виступаючих";
            this.Load += new System.EventHandler(this.speakersList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

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