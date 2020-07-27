namespace Team_Builder_Upgrade
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ListBoxGroupBox = new System.Windows.Forms.GroupBox();
            this.DisplayTotalCartPriceLabel = new System.Windows.Forms.Label();
            this.ManagementReportButton = new System.Windows.Forms.Button();
            this.EventPlaceListBox = new System.Windows.Forms.ListBox();
            this.TotalCartPriceLabel = new System.Windows.Forms.Label();
            this.EventPlaceeLabel = new System.Windows.Forms.Label();
            this.ClearButton = new System.Windows.Forms.Button();
            this.TotalCostDetails = new System.Windows.Forms.Label();
            this.PlacesRequiredTextBox = new System.Windows.Forms.TextBox();
            this.AddBookingButton = new System.Windows.Forms.Button();
            this.TotalCost = new System.Windows.Forms.Label();
            this.PlacesRequiredLabel = new System.Windows.Forms.Label();
            this.MealsOptionLabel = new System.Windows.Forms.Label();
            this.MealListBox = new System.Windows.Forms.ListBox();
            this.DaysLabel1 = new System.Windows.Forms.Label();
            this.EventNameLabel = new System.Windows.Forms.Label();
            this.EventsNameListBox = new System.Windows.Forms.ListBox();
            this.CartListbox = new System.Windows.Forms.ListBox();
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.AddBookingToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.ClearButtonToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.ReportButtonToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.ConfirmButtonToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.ExitButtonToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.TeamBuilderLabel = new System.Windows.Forms.Label();
            this.ListBoxGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // ListBoxGroupBox
            // 
            this.ListBoxGroupBox.Controls.Add(this.DisplayTotalCartPriceLabel);
            this.ListBoxGroupBox.Controls.Add(this.ManagementReportButton);
            this.ListBoxGroupBox.Controls.Add(this.EventPlaceListBox);
            this.ListBoxGroupBox.Controls.Add(this.TotalCartPriceLabel);
            this.ListBoxGroupBox.Controls.Add(this.EventPlaceeLabel);
            this.ListBoxGroupBox.Controls.Add(this.ClearButton);
            this.ListBoxGroupBox.Controls.Add(this.TotalCostDetails);
            this.ListBoxGroupBox.Controls.Add(this.PlacesRequiredTextBox);
            this.ListBoxGroupBox.Controls.Add(this.AddBookingButton);
            this.ListBoxGroupBox.Controls.Add(this.TotalCost);
            this.ListBoxGroupBox.Controls.Add(this.PlacesRequiredLabel);
            this.ListBoxGroupBox.Controls.Add(this.MealsOptionLabel);
            this.ListBoxGroupBox.Controls.Add(this.MealListBox);
            this.ListBoxGroupBox.Controls.Add(this.DaysLabel1);
            this.ListBoxGroupBox.Controls.Add(this.EventNameLabel);
            this.ListBoxGroupBox.Controls.Add(this.EventsNameListBox);
            this.ListBoxGroupBox.Location = new System.Drawing.Point(12, 115);
            this.ListBoxGroupBox.Name = "ListBoxGroupBox";
            this.ListBoxGroupBox.Size = new System.Drawing.Size(607, 422);
            this.ListBoxGroupBox.TabIndex = 8;
            this.ListBoxGroupBox.TabStop = false;
            this.ListBoxGroupBox.Text = "Select Items";
            // 
            // DisplayTotalCartPriceLabel
            // 
            this.DisplayTotalCartPriceLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DisplayTotalCartPriceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DisplayTotalCartPriceLabel.Location = new System.Drawing.Point(407, 279);
            this.DisplayTotalCartPriceLabel.Name = "DisplayTotalCartPriceLabel";
            this.DisplayTotalCartPriceLabel.Size = new System.Drawing.Size(125, 34);
            this.DisplayTotalCartPriceLabel.TabIndex = 35;
            this.DisplayTotalCartPriceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ManagementReportButton
            // 
            this.ManagementReportButton.Location = new System.Drawing.Point(407, 350);
            this.ManagementReportButton.Name = "ManagementReportButton";
            this.ManagementReportButton.Size = new System.Drawing.Size(107, 30);
            this.ManagementReportButton.TabIndex = 33;
            this.ManagementReportButton.Text = "&Report";
            this.ManagementReportButton.UseVisualStyleBackColor = true;
            this.ManagementReportButton.Click += new System.EventHandler(this.ManagementReportButton_Click);
            // 
            // EventPlaceListBox
            // 
            this.EventPlaceListBox.FormattingEnabled = true;
            this.EventPlaceListBox.ItemHeight = 16;
            this.EventPlaceListBox.Items.AddRange(new object[] {
            "Cork                            ",
            "Dublin                         ",
            "Galway                       ",
            "Belmullet                     ",
            "Belfast                         "});
            this.EventPlaceListBox.Location = new System.Drawing.Point(233, 37);
            this.EventPlaceListBox.Name = "EventPlaceListBox";
            this.EventPlaceListBox.Size = new System.Drawing.Size(105, 116);
            this.EventPlaceListBox.TabIndex = 5;
            this.EventPlaceListBox.SelectedIndexChanged += new System.EventHandler(this.EventPlaceListBox_SelectedIndexChanged);
            // 
            // TotalCartPriceLabel
            // 
            this.TotalCartPriceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalCartPriceLabel.Location = new System.Drawing.Point(251, 279);
            this.TotalCartPriceLabel.Name = "TotalCartPriceLabel";
            this.TotalCartPriceLabel.Size = new System.Drawing.Size(150, 33);
            this.TotalCartPriceLabel.TabIndex = 34;
            this.TotalCartPriceLabel.Text = "Total Cart Price:";
            this.TotalCartPriceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EventPlaceeLabel
            // 
            this.EventPlaceeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EventPlaceeLabel.Location = new System.Drawing.Point(240, 17);
            this.EventPlaceeLabel.Name = "EventPlaceeLabel";
            this.EventPlaceeLabel.Size = new System.Drawing.Size(120, 16);
            this.EventPlaceeLabel.TabIndex = 18;
            this.EventPlaceeLabel.Text = "Event Place";
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(243, 350);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(107, 30);
            this.ClearButton.TabIndex = 31;
            this.ClearButton.Text = "&Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // TotalCostDetails
            // 
            this.TotalCostDetails.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.TotalCostDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalCostDetails.Location = new System.Drawing.Point(407, 230);
            this.TotalCostDetails.Name = "TotalCostDetails";
            this.TotalCostDetails.Size = new System.Drawing.Size(125, 34);
            this.TotalCostDetails.TabIndex = 29;
            this.TotalCostDetails.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PlacesRequiredTextBox
            // 
            this.PlacesRequiredTextBox.Location = new System.Drawing.Point(162, 230);
            this.PlacesRequiredTextBox.Name = "PlacesRequiredTextBox";
            this.PlacesRequiredTextBox.Size = new System.Drawing.Size(105, 22);
            this.PlacesRequiredTextBox.TabIndex = 30;
            this.PlacesRequiredTextBox.TextChanged += new System.EventHandler(this.PlacesRequiredTextBox_TextChanged);
            // 
            // AddBookingButton
            // 
            this.AddBookingButton.Location = new System.Drawing.Point(74, 350);
            this.AddBookingButton.Name = "AddBookingButton";
            this.AddBookingButton.Size = new System.Drawing.Size(107, 30);
            this.AddBookingButton.TabIndex = 13;
            this.AddBookingButton.Text = "Add &Booking";
            this.AddBookingButton.UseVisualStyleBackColor = true;
            this.AddBookingButton.Click += new System.EventHandler(this.AddBookingButton_Click);
            // 
            // TotalCost
            // 
            this.TotalCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalCost.Location = new System.Drawing.Point(287, 230);
            this.TotalCost.Name = "TotalCost";
            this.TotalCost.Size = new System.Drawing.Size(114, 33);
            this.TotalCost.TabIndex = 28;
            this.TotalCost.Text = "Total Cost :";
            this.TotalCost.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PlacesRequiredLabel
            // 
            this.PlacesRequiredLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlacesRequiredLabel.Location = new System.Drawing.Point(2, 224);
            this.PlacesRequiredLabel.Name = "PlacesRequiredLabel";
            this.PlacesRequiredLabel.Size = new System.Drawing.Size(150, 33);
            this.PlacesRequiredLabel.TabIndex = 29;
            this.PlacesRequiredLabel.Text = "Places Required :";
            this.PlacesRequiredLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MealsOptionLabel
            // 
            this.MealsOptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MealsOptionLabel.Location = new System.Drawing.Point(366, 17);
            this.MealsOptionLabel.Name = "MealsOptionLabel";
            this.MealsOptionLabel.Size = new System.Drawing.Size(120, 16);
            this.MealsOptionLabel.TabIndex = 21;
            this.MealsOptionLabel.Text = "Meal Options";
            // 
            // MealListBox
            // 
            this.MealListBox.FormattingEnabled = true;
            this.MealListBox.ItemHeight = 16;
            this.MealListBox.Items.AddRange(new object[] {
            "Full Meal    ",
            "Half Meal                       ",
            "Breakfast   ",
            "None"});
            this.MealListBox.Location = new System.Drawing.Point(369, 37);
            this.MealListBox.Name = "MealListBox";
            this.MealListBox.Size = new System.Drawing.Size(104, 116);
            this.MealListBox.TabIndex = 20;
            this.MealListBox.SelectedIndexChanged += new System.EventHandler(this.MealListBox_SelectedIndexChanged);
            // 
            // DaysLabel1
            // 
            this.DaysLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DaysLabel1.Location = new System.Drawing.Point(159, 18);
            this.DaysLabel1.Name = "DaysLabel1";
            this.DaysLabel1.Size = new System.Drawing.Size(52, 16);
            this.DaysLabel1.TabIndex = 16;
            this.DaysLabel1.Text = "Days";
            // 
            // EventNameLabel
            // 
            this.EventNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EventNameLabel.Location = new System.Drawing.Point(16, 18);
            this.EventNameLabel.Name = "EventNameLabel";
            this.EventNameLabel.Size = new System.Drawing.Size(102, 16);
            this.EventNameLabel.TabIndex = 15;
            this.EventNameLabel.Text = "Event Name";
            // 
            // EventsNameListBox
            // 
            this.EventsNameListBox.FormattingEnabled = true;
            this.EventsNameListBox.ItemHeight = 16;
            this.EventsNameListBox.Items.AddRange(new object[] {
            "Mystery Weekend            2 days                 ",
            "CSI Weekend                  3 days                 ",
            "The Great Outdoors         4 days                 ",
            "The Chase                       6 days                 ",
            "Digital Refresh                 2 days                 ",
            "Action Photography       5 days                   ",
            "Team Ryder Cup             3 days                   ",
            "Abselling                          2 days                 ",
            "War Games                     6 days                  ",
            "Find Wally                       5 days                   "});
            this.EventsNameListBox.Location = new System.Drawing.Point(6, 37);
            this.EventsNameListBox.Name = "EventsNameListBox";
            this.EventsNameListBox.Size = new System.Drawing.Size(210, 164);
            this.EventsNameListBox.TabIndex = 4;
            this.EventsNameListBox.SelectedIndexChanged += new System.EventHandler(this.EventsNameListBox_SelectedIndexChanged);
            // 
            // CartListbox
            // 
            this.CartListbox.FormattingEnabled = true;
            this.CartListbox.ItemHeight = 16;
            this.CartListbox.Location = new System.Drawing.Point(679, 132);
            this.CartListbox.Name = "CartListbox";
            this.CartListbox.Size = new System.Drawing.Size(322, 292);
            this.CartListbox.TabIndex = 9;
            this.CartListbox.SelectedIndexChanged += new System.EventHandler(this.CartListbox_SelectedIndexChanged);
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.Location = new System.Drawing.Point(793, 465);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(107, 30);
            this.ConfirmButton.TabIndex = 14;
            this.ConfirmButton.Text = "&Confirm";
            this.ConfirmButton.UseVisualStyleBackColor = true;
            this.ConfirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(793, 524);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(107, 30);
            this.ExitButton.TabIndex = 32;
            this.ExitButton.Text = "E&xit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // TeamBuilderLabel
            // 
            this.TeamBuilderLabel.AutoSize = true;
            this.TeamBuilderLabel.Font = new System.Drawing.Font("Cooper Black", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TeamBuilderLabel.ForeColor = System.Drawing.Color.Green;
            this.TeamBuilderLabel.Location = new System.Drawing.Point(320, 9);
            this.TeamBuilderLabel.Name = "TeamBuilderLabel";
            this.TeamBuilderLabel.Size = new System.Drawing.Size(441, 69);
            this.TeamBuilderLabel.TabIndex = 36;
            this.TeamBuilderLabel.Text = "Team Builder";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 566);
            this.Controls.Add(this.TeamBuilderLabel);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.ConfirmButton);
            this.Controls.Add(this.CartListbox);
            this.Controls.Add(this.ListBoxGroupBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ListBoxGroupBox.ResumeLayout(false);
            this.ListBoxGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox ListBoxGroupBox;
        private System.Windows.Forms.Label EventPlaceeLabel;
        private System.Windows.Forms.Label DaysLabel1;
        private System.Windows.Forms.Label EventNameLabel;
        private System.Windows.Forms.ListBox EventsNameListBox;
        private System.Windows.Forms.Label TotalCostDetails;
        private System.Windows.Forms.Label TotalCost;
        private System.Windows.Forms.Button AddBookingButton;
        private System.Windows.Forms.ListBox MealListBox;
        private System.Windows.Forms.Label MealsOptionLabel;
        private System.Windows.Forms.TextBox PlacesRequiredTextBox;
        private System.Windows.Forms.Label PlacesRequiredLabel;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.ListBox EventPlaceListBox;
        private System.Windows.Forms.ListBox CartListbox;
        private System.Windows.Forms.Button ConfirmButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Label DisplayTotalCartPriceLabel;
        private System.Windows.Forms.Label TotalCartPriceLabel;
        private System.Windows.Forms.Button ManagementReportButton;
        private System.Windows.Forms.ToolTip AddBookingToolTip;
        private System.Windows.Forms.ToolTip ClearButtonToolTip;
        private System.Windows.Forms.ToolTip ReportButtonToolTip;
        private System.Windows.Forms.ToolTip ConfirmButtonToolTip;
        private System.Windows.Forms.ToolTip ExitButtonToolTip;
        private System.Windows.Forms.Label TeamBuilderLabel;
    }
}

