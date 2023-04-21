using Grad23_BattleDex.services;
using Grad23_BattleDex.SG;
using Grad23_BattleDex.Topics;

namespace Grad23_BattleDex
{
    public partial class frmBattle : Form
    {
        private BattleDexTopic topicGenerator;
        private string topic;
        private int slideCount;
        private int time;
        List<string> slides;

        public frmBattle()
        {
            InitializeComponent();

            topicGenerator = new("Resources\\rules.json");
            topic = string.Empty;

            slides = new();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            DeckGenerator.CreatePresentation("Resources\\template.pptx", "presentation.pptx", topic, slides);
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            string[] tags = TopicParser.Parse(topic);
            slides = SlideGenerator.Generate(tags.ToList(), slideCount);
        }

        private void btnRandom_Click(object sender, EventArgs e)
        {
            string newTopic = topicGenerator.CreateTopic(5);
            txtTopic.Text = newTopic;
        }

        private void txtTopic_TextChanged(object sender, EventArgs e)
        {
            TextBox txtSender = (TextBox)sender;
            topic = txtSender.Text;
        }

        private void nudSlides_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown nudSender = (NumericUpDown)sender;
            slideCount = (int)nudSender.Value;
        }

        private void nudTime_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown nudSender = (NumericUpDown)sender;
            time = (int)nudSender.Value;
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {

        }

        private void btnNext_Click(object sender, EventArgs e)
        {

        }
    }

}
