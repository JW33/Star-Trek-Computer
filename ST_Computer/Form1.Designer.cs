namespace ST_Computer
{
    partial class Form1
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
            this.ckbListenFOrWakeUpCommand = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtWakeUpCommand = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPhrases = new System.Windows.Forms.TextBox();
            this.btnStartListening = new System.Windows.Forms.Button();
            this.lblHeard = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ckbListenFOrWakeUpCommand
            // 
            this.ckbListenFOrWakeUpCommand.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ckbListenFOrWakeUpCommand.AutoSize = true;
            this.ckbListenFOrWakeUpCommand.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ckbListenFOrWakeUpCommand.Checked = true;
            this.ckbListenFOrWakeUpCommand.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbListenFOrWakeUpCommand.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ckbListenFOrWakeUpCommand.Location = new System.Drawing.Point(46, 30);
            this.ckbListenFOrWakeUpCommand.Name = "ckbListenFOrWakeUpCommand";
            this.ckbListenFOrWakeUpCommand.Size = new System.Drawing.Size(165, 17);
            this.ckbListenFOrWakeUpCommand.TabIndex = 0;
            this.ckbListenFOrWakeUpCommand.Text = "Listen for Wake-up command";
            this.ckbListenFOrWakeUpCommand.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Wake-up command:";
            // 
            // txtWakeUpCommand
            // 
            this.txtWakeUpCommand.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtWakeUpCommand.Location = new System.Drawing.Point(154, 91);
            this.txtWakeUpCommand.Name = "txtWakeUpCommand";
            this.txtWakeUpCommand.Size = new System.Drawing.Size(100, 20);
            this.txtWakeUpCommand.TabIndex = 2;
            this.txtWakeUpCommand.Text = "computer";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(267, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Enter words or phrases to recognize, one per each line:";
            // 
            // txtPhrases
            // 
            this.txtPhrases.AllowDrop = true;
            this.txtPhrases.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPhrases.Location = new System.Drawing.Point(52, 179);
            this.txtPhrases.Multiline = true;
            this.txtPhrases.Name = "txtPhrases";
            this.txtPhrases.Size = new System.Drawing.Size(261, 93);
            this.txtPhrases.TabIndex = 4;
            // 
            // btnStartListening
            // 
            this.btnStartListening.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnStartListening.BackColor = System.Drawing.Color.Lime;
            this.btnStartListening.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnStartListening.Location = new System.Drawing.Point(52, 280);
            this.btnStartListening.Name = "btnStartListening";
            this.btnStartListening.Size = new System.Drawing.Size(97, 32);
            this.btnStartListening.TabIndex = 5;
            this.btnStartListening.Text = "Start Listening";
            this.btnStartListening.UseVisualStyleBackColor = false;
            // 
            // lblHeard
            // 
            this.lblHeard.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblHeard.Location = new System.Drawing.Point(52, 321);
            this.lblHeard.Name = "lblHeard";
            this.lblHeard.Size = new System.Drawing.Size(261, 47);
            this.lblHeard.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(388, 377);
            this.Controls.Add(this.lblHeard);
            this.Controls.Add(this.btnStartListening);
            this.Controls.Add(this.txtPhrases);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtWakeUpCommand);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ckbListenFOrWakeUpCommand);
            this.Name = "Form1";
            this.Text = "ST Computer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox ckbListenFOrWakeUpCommand;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtWakeUpCommand;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPhrases;
        private System.Windows.Forms.Button btnStartListening;
        private System.Windows.Forms.Label lblHeard;
    }
}

