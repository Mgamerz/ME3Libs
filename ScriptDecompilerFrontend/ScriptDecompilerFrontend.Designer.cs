namespace ScriptDecompilerFrontend
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.outputTextField = new System.Windows.Forms.TextBox();
            this.inputTextField = new System.Windows.Forms.TextBox();
            this.inputBrowse = new System.Windows.Forms.Button();
            this.outputBrowse = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.currentOperation = new System.Windows.Forms.Label();
            this.decompilerToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(359, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select a folder that contains .pcc files you want to decompile the scripts of.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(230, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Select an output folder to output the .txt files to.";
            // 
            // outputTextField
            // 
            this.outputTextField.Location = new System.Drawing.Point(16, 74);
            this.outputTextField.Name = "outputTextField";
            this.outputTextField.Size = new System.Drawing.Size(392, 20);
            this.outputTextField.TabIndex = 2;
            // 
            // inputTextField
            // 
            this.inputTextField.Location = new System.Drawing.Point(16, 29);
            this.inputTextField.Name = "inputTextField";
            this.inputTextField.Size = new System.Drawing.Size(392, 20);
            this.inputTextField.TabIndex = 3;
            // 
            // inputBrowse
            // 
            this.inputBrowse.Location = new System.Drawing.Point(414, 27);
            this.inputBrowse.Name = "inputBrowse";
            this.inputBrowse.Size = new System.Drawing.Size(75, 23);
            this.inputBrowse.TabIndex = 4;
            this.inputBrowse.Text = "Browse";
            this.inputBrowse.UseVisualStyleBackColor = true;
            this.inputBrowse.Click += new System.EventHandler(this.inputBrowse_Click);
            // 
            // outputBrowse
            // 
            this.outputBrowse.Location = new System.Drawing.Point(414, 72);
            this.outputBrowse.Name = "outputBrowse";
            this.outputBrowse.Size = new System.Drawing.Size(75, 23);
            this.outputBrowse.TabIndex = 5;
            this.outputBrowse.Text = "Browse";
            this.outputBrowse.UseVisualStyleBackColor = true;
            this.outputBrowse.Click += new System.EventHandler(this.outputBrowse_Click);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(375, 101);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(114, 23);
            this.startButton.TabIndex = 6;
            this.startButton.Text = "Start Decompiler";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(16, 101);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(197, 23);
            this.progressBar.TabIndex = 7;
            // 
            // currentOperation
            // 
            this.currentOperation.AutoSize = true;
            this.currentOperation.Location = new System.Drawing.Point(219, 106);
            this.currentOperation.Name = "currentOperation";
            this.currentOperation.Size = new System.Drawing.Size(127, 13);
            this.currentOperation.TabIndex = 8;
            this.currentOperation.Text = "Select inputs and outputs";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 133);
            this.Controls.Add(this.currentOperation);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.outputBrowse);
            this.Controls.Add(this.inputBrowse);
            this.Controls.Add(this.inputTextField);
            this.Controls.Add(this.outputTextField);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "ME3 Script Decompiler";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox outputTextField;
        private System.Windows.Forms.TextBox inputTextField;
        private System.Windows.Forms.Button inputBrowse;
        private System.Windows.Forms.Button outputBrowse;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label currentOperation;
        private System.Windows.Forms.ToolTip decompilerToolTip;
    }
}

