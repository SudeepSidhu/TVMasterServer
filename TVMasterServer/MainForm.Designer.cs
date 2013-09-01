namespace TVMasterServer
{
    partial class MainForm
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
            this.lstServers = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.txtServerLog = new System.Windows.Forms.TextBox();
            this.txtDebug = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClearServerLog = new System.Windows.Forms.Button();
            this.btnClearDebugLog = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstServers
            // 
            this.lstServers.FormattingEnabled = true;
            this.lstServers.Location = new System.Drawing.Point(15, 25);
            this.lstServers.Name = "lstServers";
            this.lstServers.Size = new System.Drawing.Size(165, 277);
            this.lstServers.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Servers";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(15, 308);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(105, 308);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 3;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // txtServerLog
            // 
            this.txtServerLog.Location = new System.Drawing.Point(186, 25);
            this.txtServerLog.Multiline = true;
            this.txtServerLog.Name = "txtServerLog";
            this.txtServerLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtServerLog.Size = new System.Drawing.Size(569, 111);
            this.txtServerLog.TabIndex = 4;
            // 
            // txtDebug
            // 
            this.txtDebug.Location = new System.Drawing.Point(186, 155);
            this.txtDebug.Multiline = true;
            this.txtDebug.Name = "txtDebug";
            this.txtDebug.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDebug.Size = new System.Drawing.Size(569, 147);
            this.txtDebug.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(183, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Master Server log";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(183, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Debug log";
            // 
            // btnClearServerLog
            // 
            this.btnClearServerLog.Location = new System.Drawing.Point(362, 308);
            this.btnClearServerLog.Name = "btnClearServerLog";
            this.btnClearServerLog.Size = new System.Drawing.Size(103, 23);
            this.btnClearServerLog.TabIndex = 8;
            this.btnClearServerLog.Text = "Clear Server log";
            this.btnClearServerLog.UseVisualStyleBackColor = true;
            this.btnClearServerLog.Click += new System.EventHandler(this.btnClearServerLog_Click);
            // 
            // btnClearDebugLog
            // 
            this.btnClearDebugLog.Location = new System.Drawing.Point(471, 308);
            this.btnClearDebugLog.Name = "btnClearDebugLog";
            this.btnClearDebugLog.Size = new System.Drawing.Size(103, 23);
            this.btnClearDebugLog.TabIndex = 9;
            this.btnClearDebugLog.Text = "Clear Debug log";
            this.btnClearDebugLog.UseVisualStyleBackColor = true;
            this.btnClearDebugLog.Click += new System.EventHandler(this.btnClearDebugLog_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 336);
            this.Controls.Add(this.btnClearDebugLog);
            this.Controls.Add(this.btnClearServerLog);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDebug);
            this.Controls.Add(this.txtServerLog);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstServers);
            this.Name = "MainForm";
            this.Text = "TV Master Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstServers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.TextBox txtServerLog;
        private System.Windows.Forms.TextBox txtDebug;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClearServerLog;
        private System.Windows.Forms.Button btnClearDebugLog;
    }
}

