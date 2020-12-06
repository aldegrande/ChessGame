namespace GuiChess
{
    partial class ChessGame
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.startButton = new System.Windows.Forms.Button();
            this.scoreBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.scoreBox2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(21, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(835, 744);
            this.panel1.TabIndex = 0;
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(872, 687);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(175, 101);
            this.startButton.TabIndex = 1;
            this.startButton.Text = "Click to Start Game";
            this.startButton.UseVisualStyleBackColor = true;
            // 
            // scoreBox1
            // 
            this.scoreBox1.Location = new System.Drawing.Point(872, 115);
            this.scoreBox1.Name = "scoreBox1";
            this.scoreBox1.Size = new System.Drawing.Size(175, 20);
            this.scoreBox1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(869, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "The Player";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(869, 577);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "The CPU";
            // 
            // scoreBox2
            // 
            this.scoreBox2.Location = new System.Drawing.Point(872, 593);
            this.scoreBox2.Name = "scoreBox2";
            this.scoreBox2.Size = new System.Drawing.Size(175, 20);
            this.scoreBox2.TabIndex = 5;
            // 
            // ChessGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1088, 800);
            this.Controls.Add(this.scoreBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.scoreBox1);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.panel1);
            this.Name = "ChessGame";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.TextBox scoreBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox scoreBox2;
    }
}

