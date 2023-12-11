namespace KR1VSSIT
{
    public interface IMainForm
    {
        event EventHandler<GetCSEventArgs> GetControlSum;
        event EventHandler Ñomparison;
    }
    public partial class MainForm : Form, IMainForm
    {
        public string FilePath;
        public MainForm()
        {
            InitializeComponent();
        }
        public event EventHandler<GetCSEventArgs>? GetControlSum;
        public event EventHandler? Ñomparison;

        private void SelectFile_button_Click(object sender, EventArgs e)
        {

            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                FilePath = dialog.FileName;
            }
            else
            {
            return;
            }
            if (GetControlSum != null)
                GetControlSum.Invoke(this, new GetCSEventArgs(FilePath));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Ñomparison != null)
                Ñomparison.Invoke(this, new EventArgs());
        }
    }

    public class GetCSEventArgs : EventArgs
    {
        public readonly string filePath;


        public GetCSEventArgs(string filePath)
        {
            this.filePath = filePath;

        }

    }
}