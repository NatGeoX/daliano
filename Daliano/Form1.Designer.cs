namespace WinFormsApp2
{
    partial class Form1
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
            button1 = new Button();
            promptDisplay = new Label();
            promptInput = new TextBox();
            resultDisplay = new PictureBox();
            savePic = new Button();
            ((System.ComponentModel.ISupportInitialize)resultDisplay).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(310, 3);
            button1.Name = "button1";
            button1.Size = new Size(99, 36);
            button1.TabIndex = 0;
            button1.Text = "Generate";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // promptDisplay
            // 
            promptDisplay.AutoSize = true;
            promptDisplay.Location = new Point(527, 11);
            promptDisplay.Name = "promptDisplay";
            promptDisplay.Size = new Size(47, 15);
            promptDisplay.TabIndex = 1;
            promptDisplay.Text = "Prompt";
            // 
            // promptInput
            // 
            promptInput.Location = new Point(7, 8);
            promptInput.Name = "promptInput";
            promptInput.Size = new Size(297, 23);
            promptInput.TabIndex = 2;
            // 
            // resultDisplay
            // 
            resultDisplay.Location = new Point(9, 54);
            resultDisplay.Name = "resultDisplay";
            resultDisplay.Size = new Size(709, 381);
            resultDisplay.TabIndex = 4;
            resultDisplay.TabStop = false;
            // 
            // savePic
            // 
            savePic.Location = new Point(415, 3);
            savePic.Name = "savePic";
            savePic.Size = new Size(95, 36);
            savePic.TabIndex = 5;
            savePic.Text = "Save";
            savePic.UseVisualStyleBackColor = true;
            savePic.Click += button2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(730, 449);
            Controls.Add(savePic);
            Controls.Add(resultDisplay);
            Controls.Add(promptInput);
            Controls.Add(promptDisplay);
            Controls.Add(button1);
            Name = "Form1";
            Text = "DALLE-3 by Nat from The AI Observer";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)resultDisplay).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label promptDisplay;
        private TextBox promptInput;
        private PictureBox resultDisplay;
        private Button savePic;
    }
}