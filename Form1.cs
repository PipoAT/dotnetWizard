using System.Diagnostics;

namespace DotnetFromCSharp;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();

        this.MinimizeBox = false;
        this.MaximizeBox = false;
        this.FormBorderStyle = FormBorderStyle.FixedSingle;
        this.Text = ".NET Wizard";

        Button btnDNETBuild = new Button();
        btnDNETBuild.Text = "Execute .NET BUILD COMMAND";
        btnDNETBuild.Location = new Point (0, 25);
        btnDNETBuild.Width = 200;
        btnDNETBuild.Click += btnDNETBuild_Click;
        this.Controls.Add(btnDNETBuild);
    }

    private void btnDNETBuild_Click(object? sender, EventArgs e)
    {
        using (var folderBrowserDialog = new FolderBrowserDialog())
        {
            folderBrowserDialog.Description = "Select the working directory for .NET command execution.";

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                var workingDirectory = folderBrowserDialog.SelectedPath;

                // Run the Git command using the selected working directory
                var processStartInfo = new ProcessStartInfo
                {
                    FileName = "dotnet",
                    Arguments = "build",
                    WorkingDirectory = workingDirectory,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (var process = new Process())
                {
                    process.StartInfo = processStartInfo;
                    process.Start();

                    var output = process.StandardOutput.ReadToEnd();
                    MessageBox.Show(output);
                }
            }
        }
    }

    
}
