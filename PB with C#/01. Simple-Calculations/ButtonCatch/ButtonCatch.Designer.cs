
namespace ButtonCatch
{
    partial class ButtonCatch
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
            this.CatchButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CatchButton
            // 
            this.CatchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CatchButton.Location = new System.Drawing.Point(138, 90);
            this.CatchButton.Name = "CatchButton";
            this.CatchButton.Size = new System.Drawing.Size(181, 85);
            this.CatchButton.TabIndex = 0;
            this.CatchButton.Text = "Catch Me!";
            this.CatchButton.UseVisualStyleBackColor = true;
            this.CatchButton.Click += new System.EventHandler(this.CatchButton_Click);
            // 
            // ButtonCatch
            // 
            this.ClientSize = new System.Drawing.Size(584, 343);
            this.Controls.Add(this.CatchButton);
            this.Name = "ButtonCatch";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CatchButt;
        private System.Windows.Forms.Button CatchButton;
    }
}

