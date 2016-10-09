using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using cryptolab1.components;

namespace cryptolab1
{
    public partial class MainForm : Form
    {
        private readonly List<String> _tables = new List<String> {"massages", "keys"};
        private readonly List<String> _randomMode = new List<String> { "random", "equal" };
        
        private TableData<String> _encodingTab;
        private TableData<Double> _massageTab;
        private TableData<Double> _keysTab;
        private TableData<Double> _messageAfterTab;
        private TableData<Double> _messageDiffTab;
        private TableData<Double> _keyAfterMassageTab; 
        
        private NameGenerator _nameGen = new NameGenerator();
        private ProbabilityGenerator _probGen = new ProbabilityGenerator();
        private TableUtils _tableUtil;

        public MainForm()
        {
            InitializeComponent();

            randomMode.DataSource = _randomMode;
            randomDropdown.DataSource = randomMode;
            tableNames.DataSource = _tables;
            tableDropdown.DataSource = tableNames;
            _tableUtil = new TableUtils(probabilityTable);
        }

        private void renderButton_Click(object sender, EventArgs e)
        {
            if (_massageTab == null) { ComputeTables(); }

            switch (tableDropdown.SelectedIndex)
            {
                case 0:
                    _tableUtil.FillTable(_massageTab);
                    return;
                case 1:
                    _tableUtil.FillTable(_keysTab);
                    return;
                default:
                    return;
            }
        }

        private void ComputeTables()
        {
            _massageTab = new TableData<double>(new List<string> { "P" },
                _nameGen.GenerateNames("M", (int)mCountBox.Value),
                new List<List<double>> { _probGen.GenerateProbabilities((int)mCountBox.Value, 
                                                                randomDropdown.SelectedIndex) });

           _keysTab = new TableData<double>(new List<string> { "P" },
                _nameGen.GenerateNames("K", (int)mCountBox.Value),
                new List<List<double>> { _probGen.GenerateProbabilities((int)mCountBox.Value, 
                                                                randomDropdown.SelectedIndex) });

        }

        private void computeButton_Click(object sender, EventArgs e)
        {
            ComputeTables();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            switch (tableDropdown.SelectedIndex)
            {
                case 0:
                    _massageTab = _tableUtil.SaveTable(_massageTab);
                    return;
                case 1:
                    _keysTab = _tableUtil.SaveTable(_keysTab);
                    return;
                default:
                    return;
            }
        }
    }
}
