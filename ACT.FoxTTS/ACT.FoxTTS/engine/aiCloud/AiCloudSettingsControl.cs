using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ACT.FoxCommon;
using ACT.FoxCommon.localization;

namespace ACT.FoxTTS.engine.ai_cloud
{
    public partial class AiCloudSettingsControl : UserControl, IPluginComponent
    {

        private FoxTTSPlugin _plugin;

        public AiCloudSettingsControl()
        {
            InitializeComponent();
        }

        public void AttachToAct(FoxTTSPlugin plugin)
        {
            _plugin = plugin;

            var parentPanel = plugin.EngineSettingsPanel;
            parentPanel.Controls.Add(this);
            parentPanel.Resize += ParentPanelOnResize;
            ParentPanelOnResize(parentPanel, null);
        }

        public void PostAttachToAct(FoxTTSPlugin plugin)
        {
            var settings = plugin.Settings.AiCloudTtsSettings;
            trackBarSpeed.SetValue(settings.Speed, 10);
            trackBarPitch.SetValue(settings.Pitch, 10);
            trackBarVolume.SetValue(settings.Volume, 10);
            comboBoxPerson.SelectedIndex = settings.Person.Clamp(0, comboBoxPerson.Items.Count - 1);
            txtBoxProxy.Text = settings.Proxy;

            trackBarSpeed.ValueChanged += OnValueChanged;
            trackBarPitch.ValueChanged += OnValueChanged;
            trackBarVolume.ValueChanged += OnValueChanged;
            comboBoxPerson.SelectedIndexChanged += OnValueChanged;
            txtBoxProxy.TextChanged += OnValueChanged;

            OnValueChanged(null, EventArgs.Empty);
        }

        public void RemoveFromAct()
        {
            Parent.Controls.Remove(this);
        }

        public void DoLocalization()
        {
            LocalizationBase.TranslateControls(this);
        }

        private void ParentPanelOnResize(object sender, EventArgs eventArgs)
        {
            Location = new Point(0, 0);
            Size = ((Control)sender).Size;
        }

        private void OnValueChanged(object sender, EventArgs eventArgs)
        {
            var settings = _plugin.Settings.AiCloudTtsSettings;

            labelSpeedValue.Text = (trackBarSpeed.Value * 0.1).ToString();
            settings.Speed = trackBarSpeed.Value;

            labelPitchValue.Text = (trackBarPitch.Value * 0.1).ToString();
            settings.Pitch = trackBarPitch.Value;

            labelVolumeValue.Text = (trackBarVolume.Value * 0.1).ToString();
            settings.Volume = trackBarVolume.Value;

            settings.Person = comboBoxPerson.SelectedIndex;

            settings.Proxy = txtBoxProxy.Text;
        }
    }
}
