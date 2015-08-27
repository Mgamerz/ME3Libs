using ME3Data.DataTypes.ScriptTypes;
using ME3Data.FileFormats.PCC;
using ME3Data.Utility;
using ME3Script.Analysis.Visitors;
using ME3Script.Decompiling;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScriptDecompilerFrontend
{
    public partial class ScriptDecompilerFrontend : Form
    {
        int numFilesToProcess = 0;
        public ScriptDecompilerFrontend()
        {
            InitializeComponent();
            decompilerToolTip.AutoPopDelay = 32000; //16bit
        }

        private void inputBrowse_Click(object sender, EventArgs e)
        {
            string folderPath = "";
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                inputTextField.Text = folderBrowserDialog1.SelectedPath;
                string[] files = System.IO.Directory.GetFiles(folderBrowserDialog1.SelectedPath, "*.pcc");
                if (files.Count() <= 0)
                {
                    startButton.Enabled = false;
                    decompilerToolTip.SetToolTip(this.currentOperation, "No input files. Select a folder with .pcc files to decompile.");

                }
                else
                {
                    string tooltipText = "Files to decompile:\n";
                    foreach (string file in files)
                    {
                        tooltipText += file;
                        tooltipText += "\n";
                    }
                    decompilerToolTip.SetToolTip(this.currentOperation, tooltipText);

                    if (outputTextField.Text.Equals(""))
                    {
                        outputTextField.Text = Path.Combine(folderBrowserDialog1.SelectedPath,"decompiledOutput");
                    }
                    startButton.Enabled = true;
                }
                currentOperation.Text = "Input: " + files.Count() + " files";
            }
        }

        private void outputBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                outputTextField.Text = folderBrowserDialog1.SelectedPath;
                if (Directory.Exists(inputTextField.Text))
                {
                    //check if files > 0

                }
            }
        }

        private async void startButton_Click(object sender, EventArgs e)
        {
            var progressIndicator = new Progress<int>(ReportProgress);
            //call async method
            string[] files = System.IO.Directory.GetFiles(inputTextField.Text, "*.pcc");
            numFilesToProcess = files.Count();
            int uploads = await decompileFiles(files.OfType<string>().ToList(), progressIndicator);
        }


        async Task<int> decompileFiles(List<String> fileList, IProgress<int> progress)
        {
            int totalCount = fileList.Count;
            int processCount = await Task.Run<int>(() =>
            {
                int tempCount = 0;
                foreach (var file in fileList)
                {
                    //await the processing and uploading logic here
                    int processed = decompileFile(file);
                    if (progress != null)
                    {
                        progress.Report((tempCount * 100 / totalCount));
                    }
                    tempCount++;
                }

                return tempCount;
            });
            return processCount;
        }

        void ReportProgress(int value)
        {
            //Update the UI to reflect the progress value that is passed back.
            progressBar.Value = Math.Min(value, 100);
        }

        int decompileFile(string file)
        {
            string name = Path.GetFileNameWithoutExtension(file);
            var stream = new FileStream(file, FileMode.Open);
            var pcc = new PCCFile(new PCCStreamReader(stream), name);

            pcc.DeserializeTables();
            pcc.DeserializeObjects();
            var deps = pcc.ImportPackageNames;
            pcc.ResolveLinks();
            var dumpPath = outputTextField.Text +@"\" + pcc.Name + @"\";
            System.IO.Directory.CreateDirectory(dumpPath);

            foreach (var exp in pcc.Exports.Where(e => e.ClassName.ToLower() == "class"))
            {
                var obj = exp.Object as ME3Class;
                var convert = new ME3ObjectConverter(obj);
                var ast = convert.ConvertClass();
                var CodeBuilder = new CodeBuilderVisitor();
                ast.AcceptVisitor(CodeBuilder);
                File.WriteAllLines(dumpPath + exp.ObjectName + ".txt", CodeBuilder.GetCodeLines());
            }
            stream.Close();
            return 1;
        } 
    }
}
