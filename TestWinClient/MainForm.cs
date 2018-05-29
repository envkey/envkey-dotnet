using System;
using System.Windows.Forms;
using EnvKey;

namespace TestWinClient
{
  public partial class MainForm : Form
  {
    public MainForm()
    {
      InitializeComponent();
    }

    private void LoadEnvKeyButton_Click(object sender, EventArgs e)
    {
      var envKey = EnvKeyToUseTextbox.Text;
      if (string.IsNullOrEmpty(envKey))
      {
        ResultTextbox.Text = "Envkey missing.";

        return;
      }

      if (envKey.StartsWith("ENVKEY="))
      {
        envKey = envKey.Substring("ENVKEY=".Length);
      }

      var config = new EnvKeyConfig(new EnvKeyOptions
      {
        EnvKey = envKey
      });

      ResultTextbox.Text = config.TryLoadRaw(out var rawConfig)
        ? rawConfig
        : "Loading error.";
    }
  }
}
