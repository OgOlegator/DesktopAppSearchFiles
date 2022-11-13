namespace DesktopAppSearchFiles
{
    partial class SearchFilesForm
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
            this.components = new System.ComponentModel.Container();
            this.startDirectoryTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.searchFilesTextBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.filesTreeView = new System.Windows.Forms.TreeView();
            this.stopSearchButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.countSearchFilesLabel = new System.Windows.Forms.Label();
            this.countFilesLabel = new System.Windows.Forms.Label();
            this.timerAfterSearch = new System.Windows.Forms.Timer(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.labelNameSearchDirectory = new System.Windows.Forms.Label();
            this.labelCountFilesFound = new System.Windows.Forms.Label();
            this.labelCountFiles = new System.Windows.Forms.Label();
            this.labelTimeAfterSearch = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // startDirectoryTextBox
            // 
            this.startDirectoryTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.startDirectoryTextBox.Location = new System.Drawing.Point(187, 5);
            this.startDirectoryTextBox.Name = "startDirectoryTextBox";
            this.startDirectoryTextBox.Size = new System.Drawing.Size(441, 27);
            this.startDirectoryTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Стартовая директория:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(91, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Имя файла:";
            // 
            // searchFilesTextBox
            // 
            this.searchFilesTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchFilesTextBox.Location = new System.Drawing.Point(187, 37);
            this.searchFilesTextBox.Name = "searchFilesTextBox";
            this.searchFilesTextBox.Size = new System.Drawing.Size(441, 27);
            this.searchFilesTextBox.TabIndex = 3;
            // 
            // searchButton
            // 
            this.searchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchButton.Location = new System.Drawing.Point(378, 71);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(122, 29);
            this.searchButton.TabIndex = 4;
            this.searchButton.Text = "Поиск";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // filesTreeView
            // 
            this.filesTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filesTreeView.Location = new System.Drawing.Point(11, 107);
            this.filesTreeView.Name = "filesTreeView";
            this.filesTreeView.Size = new System.Drawing.Size(617, 281);
            this.filesTreeView.TabIndex = 5;
            // 
            // stopSearchButton
            // 
            this.stopSearchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.stopSearchButton.Location = new System.Drawing.Point(506, 71);
            this.stopSearchButton.Name = "stopSearchButton";
            this.stopSearchButton.Size = new System.Drawing.Size(122, 29);
            this.stopSearchButton.TabIndex = 6;
            this.stopSearchButton.Text = "Остановить";
            this.stopSearchButton.UseVisualStyleBackColor = true;
            this.stopSearchButton.Click += new System.EventHandler(this.stopSearchButton_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 399);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(189, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Поиск идет в директории:";
            // 
            // countSearchFilesLabel
            // 
            this.countSearchFilesLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.countSearchFilesLabel.AutoSize = true;
            this.countSearchFilesLabel.Location = new System.Drawing.Point(71, 419);
            this.countSearchFilesLabel.Name = "countSearchFilesLabel";
            this.countSearchFilesLabel.Size = new System.Drawing.Size(129, 20);
            this.countSearchFilesLabel.TabIndex = 8;
            this.countSearchFilesLabel.Text = "Файлов найдено:";
            // 
            // countFilesLabel
            // 
            this.countFilesLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.countFilesLabel.AutoSize = true;
            this.countFilesLabel.Location = new System.Drawing.Point(93, 439);
            this.countFilesLabel.Name = "countFilesLabel";
            this.countFilesLabel.Size = new System.Drawing.Size(107, 20);
            this.countFilesLabel.TabIndex = 9;
            this.countFilesLabel.Text = "Всего файлов:";
            // 
            // timerAfterSearch
            // 
            this.timerAfterSearch.Interval = 1000;
            this.timerAfterSearch.Tick += new System.EventHandler(this.timerAfterSearch_Tick);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 459);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(192, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Времени с начала поиска:";
            // 
            // labelNameSearchDirectory
            // 
            this.labelNameSearchDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelNameSearchDirectory.AutoSize = true;
            this.labelNameSearchDirectory.Location = new System.Drawing.Point(207, 399);
            this.labelNameSearchDirectory.Name = "labelNameSearchDirectory";
            this.labelNameSearchDirectory.Size = new System.Drawing.Size(0, 20);
            this.labelNameSearchDirectory.TabIndex = 12;
            // 
            // labelCountFilesFound
            // 
            this.labelCountFilesFound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelCountFilesFound.AutoSize = true;
            this.labelCountFilesFound.Location = new System.Drawing.Point(207, 419);
            this.labelCountFilesFound.Name = "labelCountFilesFound";
            this.labelCountFilesFound.Size = new System.Drawing.Size(0, 20);
            this.labelCountFilesFound.TabIndex = 13;
            // 
            // labelCountFiles
            // 
            this.labelCountFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelCountFiles.AutoSize = true;
            this.labelCountFiles.Location = new System.Drawing.Point(207, 439);
            this.labelCountFiles.Name = "labelCountFiles";
            this.labelCountFiles.Size = new System.Drawing.Size(0, 20);
            this.labelCountFiles.TabIndex = 14;
            // 
            // labelTimeAfterSearch
            // 
            this.labelTimeAfterSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelTimeAfterSearch.AutoSize = true;
            this.labelTimeAfterSearch.Location = new System.Drawing.Point(207, 459);
            this.labelTimeAfterSearch.Name = "labelTimeAfterSearch";
            this.labelTimeAfterSearch.Size = new System.Drawing.Size(0, 20);
            this.labelTimeAfterSearch.TabIndex = 15;
            // 
            // SearchFilesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 485);
            this.Controls.Add(this.labelTimeAfterSearch);
            this.Controls.Add(this.labelCountFiles);
            this.Controls.Add(this.labelCountFilesFound);
            this.Controls.Add(this.labelNameSearchDirectory);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.countFilesLabel);
            this.Controls.Add(this.countSearchFilesLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.stopSearchButton);
            this.Controls.Add(this.filesTreeView);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.searchFilesTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.startDirectoryTextBox);
            this.Name = "SearchFilesForm";
            this.Text = "Поиск файлов";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SearchFilesForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox startDirectoryTextBox;
        private Label label1;
        private Label label2;
        private TextBox searchFilesTextBox;
        private Button searchButton;
        private TreeView filesTreeView;
        private Button stopSearchButton;
        private Label label3;
        private Label countSearchFilesLabel;
        private Label countFilesLabel;
        private System.Windows.Forms.Timer timerAfterSearch;
        private Label label4;
        private Label labelNameSearchDirectory;
        private Label labelCountFilesFound;
        private Label labelCountFiles;
        private Label labelTimeAfterSearch;
    }
}