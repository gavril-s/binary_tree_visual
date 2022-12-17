namespace GUI
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
            this.treePictureBox = new System.Windows.Forms.PictureBox();
            this.singleInputBox = new System.Windows.Forms.TextBox();
            this.addButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.doubleInputFirstBox = new System.Windows.Forms.TextBox();
            this.doubleInputSecondBox = new System.Windows.Forms.TextBox();
            this.replaceButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.treePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // treePictureBox
            // 
            this.treePictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treePictureBox.Location = new System.Drawing.Point(0, 0);
            this.treePictureBox.Name = "treePictureBox";
            this.treePictureBox.Size = new System.Drawing.Size(1271, 656);
            this.treePictureBox.TabIndex = 0;
            this.treePictureBox.TabStop = false;
            // 
            // singleInputBox
            // 
            this.singleInputBox.Location = new System.Drawing.Point(1139, 12);
            this.singleInputBox.Name = "singleInputBox";
            this.singleInputBox.Size = new System.Drawing.Size(100, 20);
            this.singleInputBox.TabIndex = 1;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(1151, 38);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 2;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(1151, 67);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(75, 23);
            this.removeButton.TabIndex = 3;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            // 
            // doubleInputFirstBox
            // 
            this.doubleInputFirstBox.Location = new System.Drawing.Point(1139, 121);
            this.doubleInputFirstBox.Name = "doubleInputFirstBox";
            this.doubleInputFirstBox.Size = new System.Drawing.Size(100, 20);
            this.doubleInputFirstBox.TabIndex = 4;
            // 
            // doubleInputSecondBox
            // 
            this.doubleInputSecondBox.Location = new System.Drawing.Point(1139, 147);
            this.doubleInputSecondBox.Name = "doubleInputSecondBox";
            this.doubleInputSecondBox.Size = new System.Drawing.Size(100, 20);
            this.doubleInputSecondBox.TabIndex = 5;
            // 
            // replaceButton
            // 
            this.replaceButton.Location = new System.Drawing.Point(1151, 173);
            this.replaceButton.Name = "replaceButton";
            this.replaceButton.Size = new System.Drawing.Size(75, 23);
            this.replaceButton.TabIndex = 6;
            this.replaceButton.Text = "Replace";
            this.replaceButton.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1271, 656);
            this.Controls.Add(this.replaceButton);
            this.Controls.Add(this.doubleInputSecondBox);
            this.Controls.Add(this.doubleInputFirstBox);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.singleInputBox);
            this.Controls.Add(this.treePictureBox);
            this.Name = "MainForm";
            this.Text = "BST";
            ((System.ComponentModel.ISupportInitialize)(this.treePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox treePictureBox;
        private System.Windows.Forms.TextBox singleInputBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.TextBox doubleInputFirstBox;
        private System.Windows.Forms.TextBox doubleInputSecondBox;
        private System.Windows.Forms.Button replaceButton;
    }
}