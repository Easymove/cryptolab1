using System;
using System.Collections.Generic;
using System.Windows.Forms;
using cryptolab1.components;

namespace cryptolab1
{
    public partial class MainForm : Form
    {
        private readonly List<string> _randomMode = new List<string> {"random", "equal"};

        private readonly List<string> _tables = new List<string>
        {
            "function table",
            "massages aprior",
            "keys aprior",
            "message aposterior",
            "message aposterior diff aprior",
            "keys aposterior div message aprior"
        };

        private List<string> _cryptograms;
        private TableData<string> _encodingTab;
        private TableData<double> _keyAfterMassageTab;
        private List<string> _keys;
        private TableData<double> _keysTab;
        private TableData<double> _messageAfterTab;
        private TableData<double> _messageDiffTab;

        private List<string> _messages;
        private TableData<double> _messageTab;

        private readonly NameGenerator _nameGen = new NameGenerator();
        private readonly ProbabilityGenerator _probGen = new ProbabilityGenerator();
        private readonly TableUtils _tableUtil;

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
            if (_messageTab == null)
            {
                ComputeTables();
            }

            switch (tableDropdown.SelectedIndex)
            {
                case 0:
                    _tableUtil.FillTable(_encodingTab);
                    return;
                case 1:
                    _tableUtil.FillTable(_messageTab);
                    return;
                case 2:
                    _tableUtil.FillTable(_keysTab);
                    return;
                case 3:
                    _tableUtil.FillTable(_messageAfterTab);
                    return;
                case 4:
                    _tableUtil.FillTable(_messageDiffTab);
                    return;
                case 5:
                    _tableUtil.FillTable(_keyAfterMassageTab);
                    return;
                default:
                    return;
            }
        }

        private void ComputeTables()
        {
            if (_messages == null)
            {
                generateTables();
            }
            _messageAfterTab = new TableData<double>(_cryptograms, _messages,
                _tableUtil.GenerateAposteriorMessageTable(_encodingTab, _messageTab, _keysTab, _cryptograms.ToArray()));
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
                    _encodingTab = _tableUtil.SaveTable(_encodingTab);
                    return;
                case 1:
                    _messageTab = _tableUtil.SaveTable(_messageTab);
                    return;
                case 2:
                    _keysTab = _tableUtil.SaveTable(_keysTab);
                    return;
                case 3:
                    _messageAfterTab = _tableUtil.SaveTable(_messageAfterTab);
                    return;
                case 4:
                    _messageDiffTab = _tableUtil.SaveTable(_messageDiffTab);
                    return;
                case 5:
                    _keyAfterMassageTab = _tableUtil.SaveTable(_keyAfterMassageTab);
                    return;
                default:
                    return;
            }
        }

        private void genButton_Click(object sender, EventArgs e)
        {
            generateTables();
        }

        private void generateTables()
        {
            _messages = _nameGen.GenerateNames("M", (int) mCountBox.Value);
            _keys = _nameGen.GenerateNames("K", (int) kCountBox.Value);
            _cryptograms = _nameGen.GenerateNames("E", (int) eCountBox.Value);

            _encodingTab = new TableData<string>(_keys, _messages,
                _tableUtil.GenerateEncodingTable(kCountBox.Value, mCountBox.Value, eCountBox.Value));

            _messageTab = new TableData<double>(new List<string> {"P"}, _messages,
                new List<List<double>>
                {
                    _probGen.GenerateProbabilities((int) mCountBox.Value, randomDropdown.SelectedIndex)
                });

            _keysTab = new TableData<double>(new List<string> {"P"}, _keys,
                new List<List<double>>
                {
                    _probGen.GenerateProbabilities((int) kCountBox.Value, randomDropdown.SelectedIndex)
                });
        }
    }
}