namespace LabApporve
{
    partial class Form2
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
            UID = new Label();
            PIN = new Label();
            UID_input = new TextBox();
            PIN_Input = new TextBox();
            APV_btn = new Button();
            SuspendLayout();
            // 
            // UID
            // 
            UID.AutoSize = true;
            UID.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            UID.Location = new Point(12, 56);
            UID.Name = "UID";
            UID.Size = new Size(78, 28);
            UID.TabIndex = 0;
            UID.Text = "USERID";
            // 
            // PIN
            // 
            PIN.AutoSize = true;
            PIN.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PIN.Location = new Point(12, 123);
            PIN.Name = "PIN";
            PIN.Size = new Size(43, 28);
            PIN.TabIndex = 0;
            PIN.Text = "PIN";
            // 
            // UID_input
            // 
            UID_input.Location = new Point(96, 60);
            UID_input.Name = "UID_input";
            UID_input.Size = new Size(189, 27);
            UID_input.TabIndex = 1;
            // 
            // PIN_Input
            // 
            PIN_Input.Location = new Point(96, 123);
            PIN_Input.Name = "PIN_Input";
            PIN_Input.Size = new Size(189, 27);
            PIN_Input.TabIndex = 1;
            // 
            // APV_btn
            // 
            APV_btn.Location = new Point(96, 195);
            APV_btn.Name = "APV_btn";
            APV_btn.Size = new Size(94, 29);
            APV_btn.TabIndex = 2;
            APV_btn.Text = "Approve";
            APV_btn.UseVisualStyleBackColor = true;
            APV_btn.Click += saveApprove;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(297, 247);
            Controls.Add(APV_btn);
            Controls.Add(PIN_Input);
            Controls.Add(UID_input);
            Controls.Add(PIN);
            Controls.Add(UID);
            Name = "Form2";
            Text = "Form2";
            Load += Form2_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label UID;
        private Label PIN;
        private TextBox UID_input;
        private TextBox PIN_Input;
        private Button APV_btn;
    }
}