using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace _6_Tera_language
{
    partial class Form1 :Form
    {


        private TextBox txtInput;
        private Button btnScan;
        private ListBox lstTokens;
        private Scanner scanner = new Scanner();


        private void btnScan_Click(object sender, EventArgs e)
        {
            lstTokens.Items.Clear();
            string input = txtInput.Text;
            List<Token> tokens = scanner.Scan(input);
            foreach (var token in tokens)
            {
                lstTokens.Items.Add(token.ToString());
            }
        }

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
            this.txtInput = new TextBox();
            this.btnScan = new Button();
            this.lstTokens = new ListBox();

            // 
            // txtInput
            // 
            this.txtInput.Multiline = true;
            this.txtInput.ScrollBars = ScrollBars.Vertical;
            this.txtInput.Font = new Font("Consolas", 10);
            this.txtInput.SetBounds(10, 10, 780, 150);

            // 
            // btnScan
            // 
            this.btnScan.Text = "Tokinize the code";
            this.btnScan.SetBounds(10, 170, 150, 30);
            this.btnScan.Click += new EventHandler(this.btnScan_Click);

            // 
            // lstTokens
            // 
            this.lstTokens.SetBounds(10, 210, 780, 200);
            this.lstTokens.Font = new Font("Consolas", 10);

            // 
            // Form1
            // 
            this.ClientSize = new Size(800, 450);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.btnScan);
            this.Controls.Add(this.lstTokens);
            this.Name = "Form1";
            this.Text = "Tera Language Scanner";
        }

        #endregion
    }
}
